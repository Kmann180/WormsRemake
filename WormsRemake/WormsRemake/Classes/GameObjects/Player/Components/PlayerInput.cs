using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        //CLASS NAME: PlayerInput
        //BRIEF: Dervied InputComponent object for use in the player class.
        class PlayerInput : InputComponent
        {
            private Dictionary<string, bool> _inputToggles;

            //Constructor
            public PlayerInput(WormsGame parent, GameObject container)
               : base(parent, container)
            {
                this._inputToggles = new Dictionary<string, bool>();
                this._inputToggles["PLAYER_MOVE_LEFT"] = true;
                this._inputToggles["PLAYER_MOVE_RIGHT"] = true;
                this._inputToggles["PLAYER_JUMP"] = true;
            }

            //Methods
            public override void Update(GameTime gameTime)
            {
                KeyboardState kbState = Keyboard.GetState();
                string[] intendedRecipients = new String[] { "transform", "rendering" };

                if (kbState.IsKeyDown(Keys.S))
                {
                    _container.Send(new Message("MOVE_DOWN", intendedRecipients));
                }
                if (kbState.IsKeyDown(Keys.W))
                {
                    _container.Send(new Message("MOVE_UP", intendedRecipients));
                }
                if (kbState.IsKeyDown(Keys.A) && this._inputToggles["PLAYER_MOVE_LEFT"] == true)
                {
                    _container.Send(new Message("MOVE_LEFT", intendedRecipients));
                }
                if (kbState.IsKeyDown(Keys.D) && !this._container.collisionTest)
                {
                    _container.Send(new Message("MOVE_RIGHT", intendedRecipients));
                } 
            }
            public override void Recieve(Message message)
            {
                if (message.Content == "NO_COLLISION")
                {
                    this._inputToggles["PLAYER_MOVE_LEFT"] = true;
                    this._inputToggles["PLAYER_MOVE_RIGHT"] = true;
                    this._inputToggles["PLAYER_JUMP"] = true;
                }
            }
        }
    }
}
