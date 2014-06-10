using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1.Classes
{
    class Reticle : Sprite
    {
        public Reticle (Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        public Vector2 RotateAroundPlayer(Vector2 Point, Vector2 Origin, float Rotation)
        {
            return Vector2.Transform(Point - Origin, Matrix.CreateRotationZ(Rotation)) + Origin;
            //return Vector2 NewPosition = Vector2.Transform(Point - Origin, Matrix.CreateRotationZ(Rotation)) + Origin;
            //this.Position = NewPosition;
        }

        public void Update()
        {

        }
    }
}
