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
        //Button class - sprite & callback combination.
        //If the button is left clicked on (meaning the mouse is within the bounds of the sprite's texture)
        //its "callback" function will be called. (See Callback.cs, callbacks are simply a void delegate with no paramaters)
        public class Button 
        {
            protected MouseState _oldState;
            protected Callback _callback;
            protected Sprite _sprite;

            public Button(Texture2D tex, SpriteBatch sb, Vector2 pos, MouseState ms, Callback onClick)
            {
                this._sprite = new Sprite(tex, sb, pos);
                this._callback = new Callback(onClick);
                this._oldState = ms;
            }

            public void Update(GameTime gameTime)
            {
                MouseState newState = Mouse.GetState();

                if (        newState.LeftButton == ButtonState.Pressed 
                        &&  this._oldState.LeftButton == ButtonState.Released
                        && (this._oldState.Position.X >= this._sprite.Position.X && this._oldState.Position.X <= (this._sprite.Position.X + this._sprite.Width))
                        && (this._oldState.Position.Y >= this._sprite.Position.Y && this._oldState.Position.X <= (this._sprite.Position.Y + this._sprite.Height))
                   )
                {
                    this._callback();
                }

                this._oldState = newState; // this reassigns the old state so that it is ready for next time
            }

            public void Render(GameTime gameTime)
            {
                this._sprite.Draw(gameTime);
            }
        }
    }
   
}
