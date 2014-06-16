using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace WurmsRemake
{
    public partial class WurmsGame : Game
    {
        public class Player : GameObject
        {
            Dictionary<string, Projectile> _projectiles;
            Projectile _nextProjectile;

            bool _inputEnabled;
            bool _applyGravity;
            bool _enableJump;
            int _bulletAmmo;
            int _rocketAmmo;
            int _nextBullet;
            int _nextRocket;
            string _currentWeaponType;

            KeyboardState _keyboardState;
            MouseState _mouseState;
           
            public bool InputEnabled { get { return this._collision; } set { this._inputEnabled = value; } }

            Dictionary<string, bool> _inputToggles;

            public Player(WurmsGame parent, Texture2D tex, Vector2 pos)
                : base(parent, pos)
            {
                this._worldPosition = pos;
                this._sprite = new Sprite(tex, this._parent._spriteBatch, this._worldPosition);
                this._inputEnabled = true;
                this._inputToggles = new Dictionary<string, bool>();
                this._inputToggles["move_left"] = true;
                this._inputToggles["move_right"] = true;
                this._inputToggles["jump"] = true;
                this._applyGravity = true;
                this._keyboardState = Keyboard.GetState();
                this._mouseState = Mouse.GetState();
                this._projectiles = new Dictionary<string, Projectile>();

                this._bulletAmmo = 10;
                this._rocketAmmo = 5;
                this._nextBullet = 0;
                this._nextRocket = 0;
                this._currentWeaponType = "BULLETS";

                for (int i = 0; i < this._bulletAmmo; i++)
                {
                    this._projectiles["BULLETS_" + i] = new Projectile(this._parent, this._parent.Content.Load<Texture2D>("Bullet"), new Vector2(-100.0f, -100.0f), 3, 5);
                }
                for (int i = 0; i < this._rocketAmmo; i++)
                {
                    this._projectiles["ROCKETS" + i]  = new Projectile(this._parent, this._parent.Content.Load<Texture2D>("Rocket"), new Vector2(-200.0f, -100.0f), 5, 3);
                }
                this._nextProjectile = this._projectiles["BULLETS_0"];
            }

            public override void Render(GameTime gameTime)
            {
                this._sprite.Move(this._worldPosition);
                this._sprite.Draw(gameTime);

                foreach (KeyValuePair<string, Projectile> proj in this._projectiles)
                {
                    this._projectiles[proj.Key].Render(gameTime);
                }
            }

            public override void Physics(GameTime gameTime)
            {
                if (this._applyGravity)
                {
                    this._velocity.Y += this._gravity + .098f;
                }
                else
                {
                    this._velocity.Y = 0.0f;
                }
                if (!this._collision)
                {
                    this._applyGravity = true;
                }
            }

            public override void Translation(GameTime gameTime)
            {
                if (!this._collision)
                {
                    this._worldPosition += this._velocity;
                }

                foreach (KeyValuePair<string, Projectile> proj in this._projectiles)
                {

                }
            }

            public override void Input(GameTime gameTime)
            {
                if (this._inputEnabled)
                {
                    KeyboardState newState = Keyboard.GetState();
                    MouseState newMouseState = Mouse.GetState();

                    this._velocity.X = 0;  

                    if (newState.IsKeyDown(Keys.D) &&  this._inputToggles["move_right"] == true)
                    {
                        this._velocity.X = 1;
                    }
                    if (newState.IsKeyDown(Keys.A) && this._inputToggles["move_left"] == true)
                    {
                        this._velocity.X = -1;
                    }   
                    if (newState.IsKeyDown(Keys.Space) && this._keyboardState.IsKeyUp(Keys.Space) && this._inputToggles["jump"] == true)
                    {
                        if (this._enableJump)
                        {
                            this._velocity.Y = -3;
                        }
                        this._enableJump = false;
                    }

                    if (newMouseState.LeftButton == ButtonState.Pressed && this._mouseState.LeftButton == ButtonState.Released)
                    {
                        this._nextProjectile.Position = this._worldPosition;
                        Vector2 movement = new Vector2(newMouseState.Position.X, newMouseState.Position.Y) - this._worldPosition;
                        if (movement != Vector2.Zero)
                            movement.Normalize();
                        this._nextProjectile.Velocity = movement * this._nextProjectile.Speed;
                        if (this._currentWeaponType == "BULLETS")
                        {
                            if (this._nextBullet < this._bulletAmmo - 1)
                            {
                                this._nextBullet++;
                                this._nextProjectile = this._projectiles[this._currentWeaponType + '_' + this._nextBullet];
                            }
                        }
                        if (this._currentWeaponType == "ROCKETS")
                        {
                            if (this._nextRocket < this._rocketAmmo - 1)
                            {
                                this._nextRocket++;
                                this._nextProjectile = this._projectiles[this._currentWeaponType + '_' + this._nextRocket];
                            }
                        }
                    }

                    this._keyboardState = newState;
                    this._mouseState = newMouseState;
                }
                //If the player is not colliding with anything, go ahead and re-enable all its movement controls.
                if (!this._collision)
                {
                    this._inputToggles["move_left"] = true;
                    this._inputToggles["move_right"] = true;
                    this._inputToggles["jump"] = true;
                }
            }

            public override void Update(GameTime gameTime)
            {
                this.Physics(gameTime);
                this.Translation(gameTime);
                this.Input(gameTime);

                foreach (KeyValuePair<string, Projectile> proj in this._projectiles)
                {
                    this._projectiles[proj.Key].Update(gameTime);
                }
            }

            public override void CollisionResponse(string objectKey, Vector2 collisionPoint)
            {
                if (objectKey == "terrain")
                {
                    if (this._sprite.Bounds.Bottom > collisionPoint.Y)
                    {
                        this._enableJump = true;
                        this._applyGravity = false;
                        this._gravity = 0.0f;
                        this._worldPosition = new Vector2(this._worldPosition.X, collisionPoint.Y - this._sprite.Height);
                    }
                    if (this._sprite.Bounds.Center.X < collisionPoint.X)
                    {
                        this._inputToggles["move_right"] = false;
                    }
                    if (this._sprite.Bounds.Center.X > collisionPoint.X)
                    {
                        this._inputToggles["move_left"] = false;
                    }
                   
                }   
            }
        }
    }
}