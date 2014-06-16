using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace WurmsRemake
{
    public partial class WurmsGame : Game
    {
        public class CollisionManager
        {
            Dictionary<string, GameObject> _objects;
            Reticle _reticle;

            public CollisionManager(ref Dictionary<string, GameObject> objects, ref Reticle reticle)
            {
                this._objects = objects;
                this._reticle = reticle;
            }

            public void Manage()
            {
                Rectangle playerOneRect = this._objects["player_one"].Sprite.Bounds;
                Rectangle terrainRect = this._objects["terrain"].Sprite.Bounds;
                Color[] playerColorData = this._objects["player_one"].Sprite.ColorData;
                Color[] terrainColorData = this._objects["terrain"].Sprite.ColorData;

                this._objects["player_one"].Sprite.Texture.GetData(playerColorData);
                this._objects["terrain"].Sprite.Texture.GetData(terrainColorData);

                int top = Math.Max(playerOneRect.Top, terrainRect.Top);
                int bottom = Math.Min(playerOneRect.Bottom, terrainRect.Bottom);
                int left = Math.Max(playerOneRect.Left, terrainRect.Left);
                int right = Math.Min(playerOneRect.Right, terrainRect.Right);

                for (int y = top; y < bottom; y++)
                {
                    for (int x = left; x < right; x++)
                    {
                        // Get the color of both pixels at this point
                        Color colorA = playerColorData[(x - playerOneRect.Left) +
                                             (y - playerOneRect.Top) * playerOneRect.Width];
                        Color colorB = terrainColorData[(x - terrainRect.Left) +
                                             (y - terrainRect.Top) * terrainRect.Width];
                        // If both pixels are not completely transparent,
                        if ((colorA.A != 0 && colorB.A != 0))
                        {
                            // then an intersection has been found
                            this._objects["player_one"].Collision = true;
                            this._objects["player_one"].CollisionResponse("terrain", new Vector2(x, y));
                            this._objects["terrain"].Collision = true;
                            this._objects["terrain"].CollisionResponse("player", new Vector2(x, y));
                        }
                        else
                        {
                            this._objects["player_one"].Collision = false;
                            this._objects["terrain"].Collision = false;
                        }
                    }
                }
                
            }

            
        }
    }
}
