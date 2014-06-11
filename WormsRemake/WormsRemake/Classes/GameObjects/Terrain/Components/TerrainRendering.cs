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
        public class TerrainRendering : RenderingComponent
        {
            public TerrainRendering(WormsGame parent, GameObject container)
                : base(parent, container)
            {
                this.AddTexture("TestTerrain", "Default");
                this._activeTexture = this._textures["Default"];
                this.SwitchActiveTexture("Default");
                this._container.World.CollisionHandler.RetrieveTextureData("terrain", ref this._activeTextureData);
            }
            public override void Update(GameTime gameTime)
            {
                this._sourceBatch.Draw(this._activeTexture, this._container.Position, Color.White);
            }
            public override void Recieve(Message message)
            {
                
            }
        }
    }
}