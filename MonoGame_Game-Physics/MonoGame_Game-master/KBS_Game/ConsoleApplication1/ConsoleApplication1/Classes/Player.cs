using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1
{
    public class Player : Sprite
    {
        private bool OnGround = false;
        public bool IsAlive = true;
        private int JetpackFuel = 100;
        private int Health = 100;
        private float Velocity = 0;

        public Vector2 Movement { get; set; }

        public Player (Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        public void ApplyGravity(GameTime gameTime)
        {
            if (!OnGround)
            {
                float i = 1;
                Velocity += 0.1f * i;
                Position += new Vector2(0, Velocity);
            }
            else
            {
                Movement = new Vector2(0, 0);
                OnGround = true;
            }
        }

        public void Jump()
        {
            if (Position.Y >= 1 && OnGround)
            {
                OnGround = false;
                Movement += new Vector2(0, -10);

                Velocity = -5;
            }
        }

        public void JetPack()
        {
            if (JetpackFuel >= 0)
            {
                Velocity = 0;
                OnGround = false;
                Movement += new Vector2(0, -1);
                JetpackFuel -= 1;
            }
        }

        public void TakeDamage()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.D)) { Health -= 10; }
            if (Health <= 0)
            {
                IsAlive = false;
            }
        }

        public void FireWeapon()
        {

        }

        public void Update(GameTime gameTime)
        {
            TakeDamage();

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left)) { Movement += new Vector2(-1, 0); }
            if (keyboardState.IsKeyDown(Keys.Right)) { Movement += new Vector2(1, 0); }
            if (keyboardState.IsKeyDown(Keys.Up)) { Jump(); }
            if (keyboardState.IsKeyDown(Keys.Space)) { JetPack(); }

            Movement -= Movement * new Vector2(.1f, .1f);
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;
            
            //ApplyGravity(gameTime);

           
        }
    }
}