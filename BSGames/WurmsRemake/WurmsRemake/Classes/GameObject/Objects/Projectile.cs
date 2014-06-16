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
        public class Projectile : GameObject
        {
            protected int _damage;
            protected int _speed;
            protected bool _alive;

            public bool Alive { get { return this._alive; } set { this._alive = value; } }

            public Vector2 Position { get { return this._worldPosition; } set { this._worldPosition = value; } }        
            public Vector2 Velocity { get { return this._velocity; } set { this._velocity = value; } }
            public int Speed { get { return this._speed; } set { this._speed = value; } }

            public Projectile(WurmsGame parent, Texture2D tex, Vector2 pos, int damage, int speed)
                : base(parent, pos)
            {
                this._worldPosition = pos;
                this._sprite = new Sprite(tex, this._parent._spriteBatch, this._worldPosition);
                this._damage = damage;
                this._velocity = new Vector2(0.0f, 0.0f);
                this._alive = false;
                this._speed = speed;
            }

            public override void Render(GameTime gameTime)
            {
                this._sprite.Move(this._worldPosition);
                this._sprite.Draw(gameTime);
            }

            public override void Physics(GameTime gameTime)
            {

            }

            public override void Translation(GameTime gameTime)
            {
                this._worldPosition += this._velocity;
            }

            public override void Input(GameTime gameTime)
            {

            }
            public override void Update(GameTime gameTime)
            {
                this.Translation(gameTime);

            }
            public override void CollisionResponse(string objectKey, Vector2 collisionPoint)
            {

            }
        }
    }
}
