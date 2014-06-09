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
        
        public class Terrain : GameObject
        {
            public Terrain(WormsGame parent, World world)
                : base(parent, world)
            {
                this._position = new Vector2(0, 0);
                this._velocity = new Vector2(0, 0);  //Terrain does not need a velocity.
                this._speed = 0;     //Terrain does need a speed.
                
            }

            public override void InitializeComponents()
            {
                this._components["rendering"] = new TerrainRendering(_parent, this);
                this._components["physics"] = new TerrainPhysics(_parent, this, (TerrainRendering)this.GetComponent("rendering"));
            }


            public override void Update(GameTime gameTime)
            {
                this._components["physics"].Update(gameTime);
            }

            public override void Draw(GameTime gameTime)
            {
                this._components["rendering"].Update(gameTime);
            }
        }
    }

}
