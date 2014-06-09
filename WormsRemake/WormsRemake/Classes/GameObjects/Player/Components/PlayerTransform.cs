using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        public class PlayerTransform : TransformComponent
        {
            public PlayerTransform(WormsGame parent, GameObject container)
                : base(parent, container)
            {
          
            }
            public override void Update(GameTime gameTime)
            {
                //var delta = (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
                _container.Position += _container.Velocity; //* delta);
            }
            public override void Recieve(Message message)
            {
                string recieved = message.Content;
                switch (recieved)
                {
                    case ("MOVE_DOWN"):
                        _container.Velocity = new Vector2(0, 1);
                        break;
                    case ("MOVE_UP"):
                        _container.Velocity = new Vector2(0, -1);
                        break;
                    case ("MOVE_LEFT"):
                        _container.Velocity = new Vector2(-1, 0);
                        break;
                    case ("MOVE_RIGHT"):
                        _container.Velocity = new Vector2(1, 0);
                        break;
                }

            }
        }
    }
}
