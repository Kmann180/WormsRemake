using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormGame : Game
    {
        class Utilities
        {
            bool IntersectsPixels(Rectangle rectangleA, Color[] dataA,
                                    Rectangle rectangleB, Color[] dataB)
            {
                int top = Math.Max(rectangleA.Top, rectangleB.Top);
                int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
                int left = Math.Max(rectangleA.Left, rectangleB.Left);
                int right = Math.Min(rectangleA.Right, rectangleB.Right);

                for (int y = top; y < bottom; y++)
                {
                    for (int x = left; x < right; x++)
                    {
                        // Get the color of both pixels at this point
                        Color colorA = dataA[(x - rectangleA.Left) +
                                             (y - rectangleA.Top) * rectangleA.Width];
                        Color colorB = dataB[(x - rectangleB.Left) +
                                             (y - rectangleB.Top) * rectangleB.Width];

                        // If both pixels are not completely transparent,
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }
                }
                return false;
            }

            bool RectangleIntersection(Rectangle rectangleA, Rectangle rectangleB)
            {
                if(rectangleA.Intersects(rectangleB))
                {
                    return true;
                }
                return false;
            }

        }
    }  
}
