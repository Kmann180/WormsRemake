using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WurmsRemake
{
    //Base abstract class for Game States.
    //Game States will control their rendering and update logic seperately.
    //Game States will be contained in a State Manager.
    public partial class WurmsGame : Game
    {
        public abstract class GameState
        {
            protected KeyboardState _keyboardState;
            protected MouseState _mouseState;
            protected WurmsGame _parent;
            protected bool _next;

            public bool Next { get { return this._next; } }

            public GameState(WurmsGame parent)
            {
                this._parent = parent;
                this._mouseState = Mouse.GetState();
                this._keyboardState = Keyboard.GetState();
                this._next = false;
            }

            public abstract void Update(GameTime gameTime);
            public abstract void RenderScene(GameTime gameTime);
        }
    }
}
