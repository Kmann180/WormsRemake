using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1.Classes
{
    public class Player : Sprite
    {
        public Vector2 Movement { get; set; }

        public Player (Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        public void Update(GameTime gameTime)
        {
            HandleInput();
            Movement -= Movement * new Vector2(.1f, .1f); //Friction??
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;
        }

        public void HandleInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left)) { Movement += new Vector2(-1, 0); }
            if (keyboardState.IsKeyDown(Keys.Right)) { Movement += new Vector2(1, 0); }
            if (keyboardState.IsKeyDown(Keys.Up)) { Movement += new Vector2(0, -1); }
            if (keyboardState.IsKeyDown(Keys.Down)) { Movement += new Vector2(0, 1); }
        }
    }
}
