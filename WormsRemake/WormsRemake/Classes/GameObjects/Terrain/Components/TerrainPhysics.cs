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
            private TerrainRendering _renderingLink;

            public TerrainPhysics(WormsGame parent, GameObject container, TerrainRendering renderingLink)
                : base(parent, container)
            {
                this._renderingLink = renderingLink;
                List<Rectangle> boundingBoxes = new List<Rectangle>();
                boundingBoxes.Add(new Rectangle(    (int)this._container.Position.X,
                                                    400,
                                                    this._renderingLink.ActiveTexture.Width,
                                                    this._renderingLink.ActiveTexture.Height));
                this._container.World.AddCollisionData("terrain", boundingBoxes);
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