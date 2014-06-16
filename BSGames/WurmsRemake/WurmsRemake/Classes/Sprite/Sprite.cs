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
        //Base sprite class to handle position tracking & rendering of a texture.
        //All sprites should belong to the sprite batch contained in the WurmsGame class in /MonoGame
        public class Sprite
        {
            protected SpriteBatch _spriteBatch;
            protected Vector2 _position;
            protected Texture2D _texture;   // pass in as Content.Load<Texture2D>("FileNameWithNoExtension")
                                            // remember to change the build action to "always copy"

            protected Rectangle _bounds;
            protected Color[] _colorData;

            public Vector2 Position { get { return this._position ;} set { this._position = value;} }
            public Texture2D Texture { get { return this._texture; } set { this._texture = value; } }
            public float Height { get { return this._texture.Height; } }
            public float Width { get { return this._texture.Width; } }
            public Rectangle Bounds { get { return this._bounds; } }
            public Color[] ColorData { get { return this._colorData; } }

            public Sprite(Texture2D tex, SpriteBatch sb, Vector2 pos)
            {
                this._texture = tex;
                this._spriteBatch = sb;
                this._position = pos;
                this._bounds = new Rectangle((int)this._position.X, (int)this._position.Y, this._texture.Width, this._texture.Height);
                this._colorData = new Color[this._bounds.Width * this._bounds.Height];
                this._texture.GetData(this._colorData);
            }

            //Marked as virtual so it can be overridden by its children.
            public virtual void Move(float x, float y)
            {
                this._position.X = x;
                this._position.Y = y;
                this._bounds = new Rectangle((int)this._position.X, (int)this._position.Y, this._texture.Width, this._texture.Height);
            }

            //Marked as virtual so it can be overridden by its children.
            public virtual void Move(Vector2 v)
            {
                this._position = v;
                this._bounds = new Rectangle((int)this._position.X, (int)this._position.Y, this._texture.Width, this._texture.Height);
            }

            //Marked as virtual so it can be overridden by its children.
            public virtual void Draw(GameTime gameTime)
            {
                this._texture.GetData(this._colorData);
                this._spriteBatch.Draw(this._texture, this._position, Color.White);
            }
        }
    }
}
