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
                //List<Rectangle> boundingBoxes = new List<Rectangle>();

                ////Defining collision boundaries...  
                //int originX = (int)this._container.Position.X;
                //int originY = (int)this._container.Position.Y;

                //boundingBoxes.Add(new Rectangle(originX + 66, originY + 431, 530, 50));
                //boundingBoxes.Add(new Rectangle(originX + 72, originY + 212,  33, 66));
                ////boundingBoxes.Add(new Rectangle(originX + 67, originY + 365, 129, 67));
                //boundingBoxes.Add(new Rectangle(originX + 78, originY + 272, 115, 91));
                ////boundingBoxes.Add(new Rectangle(originX + 73, originY + 211, 34, 60));
                ////boundingBoxes.Add(new Rectangle(originX + 188, originY + 261, 153, 61));
                ////boundingBoxes.Add(new Rectangle(originX + 107, originY + 242, 15, 29));
                ////boundingBoxes.Add(new Rectangle(originX + 122, originY + 247, 34, 60));
                ////boundingBoxes.Add(new Rectangle(originX + 199, originY + 235, 97, 29));
                //boundingBoxes.Add(new Rectangle(originX + 213, originY + 201, 70, 35));
                ////boundingBoxes.Add(new Rectangle(originX + 258, originY + 404, 53, 27));
                ////boundingBoxes.Add(new Rectangle(originX + 312, originY + 416, 276, 16));
                ////boundingBoxes.Add(new Rectangle(originX + 430, originY + 242, 114, 173));
                ////boundingBoxes.Add(new Rectangle(originX + 391, originY + 383, 52, 33));
                ////boundingBoxes.Add(new Rectangle(originX + 350, originY + 103, 78, 101));
                ////boundingBoxes.Add(new Rectangle(originX + 532, originY + 125, 42, 157));
                ////boundingBoxes.Add(new Rectangle(originX + 415, originY + 200, 86, 44));
                ////boundingBoxes.Add(new Rectangle(originX + 426, originY + 163, 51, 37));
                ////boundingBoxes.Add(new Rectangle(originX + 422, originY + 126, 28, 39));

                //this._container.World.AddCollisionData("terrain", boundingBoxes);

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
