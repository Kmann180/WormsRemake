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
        public class Water : GameObject
        {
            public Water(WurmsGame parent, Texture2D tex, Vector2 pos)
                : base(parent, pos)
            {
                this._worldPosition = pos;
                this._velocity = new Vector2(0.0f, 0.0f);
                this._sprite = new Sprite(tex, this._parent._spriteBatch, this._worldPosition);
            }

            public override void Render(GameTime gameTime)
            {
                this._sprite.Move(this._worldPosition);
                this._sprite.Draw(gameTime);
            }

            public override void Physics(GameTime gameTime)
            {
                this._velocity.Y -= .0001f;
            }

            public override void Translation(GameTime gameTime)
            {
                this._worldPosition += this._velocity;
            }

            public override void Input(GameTime gameTime)
            {

            }
            public override void Update(GameTime gameTime)
            {
                this.Physics(gameTime);
                this.Translation(gameTime);
            }
            public override void CollisionResponse(string objectKey, Vector2 collisionPoint)
            {

            }
        }
    }
}
