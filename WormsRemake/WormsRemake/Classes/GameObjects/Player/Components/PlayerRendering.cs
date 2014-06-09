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
