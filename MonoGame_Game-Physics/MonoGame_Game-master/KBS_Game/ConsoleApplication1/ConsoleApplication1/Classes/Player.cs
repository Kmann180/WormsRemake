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
        private bool IsTriggered = false;
        private float Velocity = 0;

        public Vector2 Movement { get; set; }

        public Player (Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        public void ApplyGravity(GameTime gameTime)
        {
            if (IsTriggered)
            {
                float i = 1;
                Velocity += 0.1f * i;
                //Position += new Vector2(0, 0.4f);
                Position += new Vector2(0, Velocity);
                //Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;
                //i++;
            }
            else
            {
                Movement = new Vector2(0, 0);
                IsTriggered = false;
            }
        }

        public void Jump()
        {
            if (Position.Y >= 1 && !IsTriggered)
            {
                IsTriggered = true;
                Movement += new Vector2(0, -10);

                Velocity = -5;
            }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left)) { Movement += new Vector2(-1, 0); }
            if (keyboardState.IsKeyDown(Keys.Right)) { Movement += new Vector2(1, 0); }
            if (keyboardState.IsKeyDown(Keys.Up)) { Jump(); }

            Movement -= Movement * new Vector2(.1f, .1f);
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;
            
            ApplyGravity(gameTime);

           
        }
    }
}