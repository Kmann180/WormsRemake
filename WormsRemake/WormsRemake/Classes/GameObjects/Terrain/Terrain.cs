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
            public Terrain(WormsGame parent)
                : base(parent)
            {
                this._position = new Vector2(0, 0);
                this._velocity = new Vector2(0, 0);  //Terrain does not need a velocity.
                this._speed = 0;     //Terrain does need a speed.
            }

            public override void InitializeComponents()
            {
                this._components["Rendering"] = new TerrainRendering(_parent, this);
                this._components["Physics"] = new TerrainPhysics(_parent, this);
            }


            public override void Update(GameTime gameTime)
            {
                this._components["Physics"].Update(gameTime);
            }

            public override void Draw(GameTime gameTime)
            {
                this._components["Rendering"].Update(gameTime);
            }
        }
    }

}
