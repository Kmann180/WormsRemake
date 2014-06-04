using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

/*namespace ConsoleApplication1.Classes
{
    class Reticle : Player
    {
        Vector2 Location {get; set;}
        Vector2 Origin {get; set;}

        public Vector2 RotateAroundPlayer(Vector2 Point, Vector2 a_Origin, float Rotation)
        {
            var Target = Point - a_Origin;

            if (Target == Vector2.Zero)
            {
                return Point;
            }

            var Angle = (float)Math.Atan2(Target.Y, Target.X);
            Angle += Rotation;

            Target = Target.Length() * new Vector2((float)Math.Cos(Angle), (float)Math.Sin(Angle));
            return Target + Origin;
        }

        public void Aim
        {
            //Location = RotateAroundPlayer(Position, Origin, 0.01f);
        }
    }
}*/
