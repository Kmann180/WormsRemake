using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        public class CollisionHandler
        {
            private Dictionary<string, TextureData> _textureData;
            private World _world;

            public CollisionHandler(World world)
            {
                this._textureData = new Dictionary<string, TextureData>();
                this._world = world;
            }

            public void RetrieveTextureData(string source, ref TextureData data)
            {
                this._textureData[source] = data;
            }

            public void CheckCollisions()
            {
                if (this.IntersectsPixels(  this._textureData["player"]._rectangle, this._textureData["player"]._colorData,
                                            this._textureData["terrain"]._rectangle, this._textureData["terrain"]._colorData))
                {
                    this._world.Objects["player"].collisionTest = true;
                }
                else
                {
                    this._world.Objects["player"].collisionTest = false;
                }
            }

            enum CollisionType
            {
                LEFT,
                RIGHT,
                UP,
                DOWN
            }

            bool IntersectsPixels(  Rectangle rectangleA, Color[] dataA,
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
                        if ( (colorA.A != 0 && colorB.A != 0))
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }
                }
                return false;
            }

            void HandleCollisions(  TextureData dataA, TextureData dataB, params string[] objectKeys )
            {
                Rectangle rectangleA = dataA._rectangle;
                Rectangle rectangleB = dataB._rectangle;
                Color[] colorDataA = dataA._colorData;
                Color[] colorDataB = dataB._colorData;

                int top = Math.Max(rectangleA.Top, rectangleB.Top);
                int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
                int left = Math.Max(rectangleA.Left, rectangleB.Left);
                int right = Math.Min(rectangleA.Right, rectangleB.Right);

                for (int y = top; y < bottom; y++)
                {
                    for (int x = left; x < right; x++)
                    {
                        // Get the color of both pixels at this point
                        Color colorA = colorDataA[(x - rectangleA.Left) +
                                             (y - rectangleA.Top) * rectangleA.Width];
                        Color colorB = colorDataB[(x - rectangleB.Left) +
                                             (y - rectangleB.Top) * rectangleB.Width];
                        // If both pixels are not completely transparent,
                        if ((colorA.A != 0 && colorB.A != 0))
                        {
                            // then an intersection has been found
                            Vector2 collisionPoint = new Vector2(x, y);
                            Message collisionMessage = new Message("COLLISION", "physics");
                            collisionMessage.Attach(collisionPoint);
                            foreach (string s in objectKeys)
                            {
                                this._world.Objects[s].Send(collisionMessage);
                                return;
                            }
                        }
                    }
                }
                Message noCollisionMessage = new Message("NO_COLLISION", "physics" , "input");
                foreach (string s in objectKeys)
                {
                    this._world.Objects[s].Send(noCollisionMessage);
                    return;
                }
            }      
        }
    }
}
