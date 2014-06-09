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
            //Constructor
            public PlayerInput(WormsGame parent, GameObject container)
               : base(parent, container)
            {

            }

            //Methods
            public override void Update(GameTime gameTime)
            {
                KeyboardState kbState = Keyboard.GetState();
                string[] intendedRecipients = new String[] { "transform", "rendering" };

                //_container.Send(new Message("MOVE_NONE", intendedRecipients));

                if (kbState.IsKeyDown(Keys.W))
                {
                    _container.Send(new Message("MOVE_UP", intendedRecipients));
                }
                if (kbState.IsKeyDown(Keys.A))
                {
                    _container.Send(new Message("MOVE_LEFT", intendedRecipients));
                }
                if (kbState.IsKeyDown(Keys.D))
                {
                    _container.Send(new Message("MOVE_RIGHT", intendedRecipients));
                }
               
                
            }
            public override void Recieve(Message message)
            {
               
            }
        }
    }
}
