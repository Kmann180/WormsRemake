using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WurmsRemake
{
    public partial class WurmsGame : Game
    {
        //Manages transitioning between the Title, MainGame, and GameOver States in the application.
        public class StateManager
        {
            WurmsGame _parent;
            Dictionary<string, GameState> _states;
            GameState _currentState;

            public GameState CurrentState { get { return this._currentState; } set { this._currentState = value; } }

            public StateManager(WurmsGame parent)
            {
                this._parent = parent;
                this._states = new Dictionary<string, GameState>();

                this._states["title"] = new Title(this._parent);
                this._states["main_game"] = new MainGame(this._parent);
                this._currentState = this._states["title"]; // Game will start up in the title state.
            }

            public void ManageTransitions()
            {
                if (this._currentState == this._states["title"] && this._currentState.Next)
                {
                    this._currentState = this._states["main_game"];
                }
            }

        }
    }
}
