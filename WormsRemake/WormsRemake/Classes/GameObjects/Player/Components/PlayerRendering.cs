using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WormsRemake
{
    public partial class WormsGame: Game
    {
        public class PlayerRendering : RenderingComponent
        {
            public PlayerRendering(WormsGame parent, GameObject container)
                : base(parent, container)
            {
                this.AddTexture("RedPlayerWithShotgun", "Default");
                this._activeTexture = _textures["Default"];
                this.SwitchActiveTexture("Default");
                this._container.World.CollisionHandler.RetrieveTextureData("player", ref this._activeTextureData);
            }

            public override void Update(GameTime gameTime)
            {
                this._sourceBatch.Draw(this._activeTexture, this._container.Position, Color.White);
                //Player Entity will dynamically update TextureData while terrain will not.
                this._activeTextureData._rectangle = new Rectangle((int)this._container.Position.X, (int)this._container.Position.Y, this._activeTexture.Width, this._activeTexture.Height);
                this._activeTexture.GetData(this._activeTextureData._colorData);
            }

            public override void Recieve(Message message)
            {
               
            }
        }
    }
}
