using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1.Classes
{
    class TerrainDestroyer : Sprite
    {
        public TerrainDestroyer(Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        public void Update(Vector2 mousePosition)
        {
            Position = new Vector2(mousePosition.X, mousePosition.Y);
        }

        public void Deform(Sprite terrain)
        {
            Color[] pixelDeformData = new Color[this.Texture.Width * this.Texture.Height];
            this.Texture.GetData(pixelDeformData, 0, this.Texture.Width * this.Texture.Height);

            Color[] terrainColorData = new Color[terrain.Texture.Width * terrain.Texture.Height];
            terrain.Texture.GetData(terrainColorData, 0, terrain.Texture.Width * terrain.Texture.Height);

            for (int x = 0; x < this.Texture.Width; x++)
            {
                for (int y = 0; y < this.Texture.Height; y++)
                {
                    terrainColorData[((int)this.Position.X + x) + ((int)this.Position.Y + y) * terrain.Texture.Width] = pixelDeformData[x + y * this.Texture.Width];
                }
            }
            terrain.Texture.SetData(terrainColorData);
        }

    }
}
