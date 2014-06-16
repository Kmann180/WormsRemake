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
        //Title State. Game will be in this state on startup.
        //Only two options: Play (starts the game) and Exit (exits the game)
        public class Title : GameState
        {   //Source sprite batch for the contained sprite(s) textures.
            Sprite _background;         //Wallpaper 
            Button _playBtn;            //"Play Button"
            Button _exitBtn;            //"Exit Button"
            Reticle _cursor;            //Cursor

            public Title(WurmsGame parent)
                : base(parent)
            {
                this._background = new Sprite(  this._parent.Content.Load<Texture2D>("TitleScreen"),
                                                this._parent._spriteBatch, 
                                                new Vector2(0.0f, 0.0f));
                
                this._playBtn = new Button( this._parent.Content.Load<Texture2D>("PlayButton"),
                                             this._parent._spriteBatch,
                                            new Vector2(270.0f, 290.0f),
                                            this._mouseState,
                                            new Callback(this.PlayCallback));

                this._exitBtn = new Button( this._parent.Content.Load<Texture2D>("ExitButton"),
                                            this._parent._spriteBatch,
                                            new Vector2(270, 360.0f),
                                            this._mouseState,
                                            new Callback(this.ExitCallback));

             
                this._cursor = new Reticle( this._parent.Content.Load<Texture2D>("CrossHair"),
                                            this._parent._spriteBatch,
                                            new Vector2(0.0f, 0.0f));

               
            }

            public override void Update(GameTime gameTime)
            {
                this._keyboardState = Keyboard.GetState();
                this._mouseState = Mouse.GetState();
                this._playBtn.Update(gameTime);
                this._exitBtn.Update(gameTime);
                this._cursor.Update(gameTime);
            }

            public override void RenderScene(GameTime gameTime)
            {
                this._background.Draw(gameTime);
                this._playBtn.Render(gameTime);
                this._exitBtn.Render(gameTime);
                this._cursor.Render(gameTime);
            }

            public void PlayCallback()
            {
                this._next = true;
            }

            public void ExitCallback()
            {
                this._parent.Exit();
            }
        }
    }
}
