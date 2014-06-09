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
        public class TerrainPhysics : PhysicsComponent
        {
            public TerrainPhysics(WormsGame parent, GameObject container)
                : base(parent, container)
            {
             
            }
            public override void Update(GameTime gameTime)
            {
                
            }
            public override void Recieve(Message message)
            {
                
            }
        }
    }
}