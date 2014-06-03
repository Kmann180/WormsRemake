using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1
{
    //CLASS: Sprite
    //BRIEF: Basic sprite object for use in our game development. 
    //      Example use:...
    //      Sprite mySprite = new Sprite(_tileTexture, new Vector2(40,40), _spriteBatch);
    public class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { set; get; }
        public SpriteBatch SpriteBatch { get; set; }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }

        public Sprite(Texture2D texture, Vector2 position, SpriteBatch batch)
        {
            Texture = texture;
            Position = position;
            SpriteBatch = batch;
        }

        public void Draw()
        {
            SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
