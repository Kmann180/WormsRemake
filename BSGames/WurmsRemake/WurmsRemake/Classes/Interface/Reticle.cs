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
        // Reticle class serves as both the cursor for Title & Game Over screens
        // as well as the actual aiming reticle for the main game.
        public class Reticle 
        {
            protected MouseState _mouseState;
            protected Sprite _sprite;
            protected Vector2 _position;

            public Reticle(Texture2D tex, SpriteBatch sb, Vector2 pos)
            {
                this._sprite = new Sprite(tex, sb, pos);
                this._mouseState = Mouse.GetState();
                this._position.X = this._mouseState.Position.X;
                this._position.Y = this._mouseState.Position.Y;
            }

            public void Update(GameTime gameTime)
            {
                this._sprite.Move(this._position);
            }

            public void Render(GameTime gameTime)
            {
                this._mouseState = Mouse.GetState();
                this._position.X = this._mouseState.Position.X;
                this._position.Y = this._mouseState.Position.Y;
                this._sprite.Draw(gameTime);
            }
        }
    }
}
