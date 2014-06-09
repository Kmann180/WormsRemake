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
        public class Player : GameObject
        {
            public Player(WormsGame parent)
                : base(parent)
            {
                this._position = new Vector2(100, 100);
                this._velocity = new Vector2(0.0f, 0.0f);
                this._speed = 0;
            }

            public override void InitializeComponents()
            {
                this.AddComponent("rendering", new PlayerRendering(_parent, this));
                this.AddComponent("input", new PlayerInput(_parent, this));
                this.AddComponent("physics", new PlayerPhysics(_parent, this));
                this.AddComponent("transform", new PlayerTransform(_parent, this));
            }


            public override void Update(GameTime gameTime)
            {
                this._components["input"].Update(gameTime);
                this._components["physics"].Update(gameTime);
                this._components["transform"].Update(gameTime);
            }

            public override void Draw(GameTime gameTime)
            {
                this._components["rendering"].Update(gameTime);
            }
        }
    }
}
