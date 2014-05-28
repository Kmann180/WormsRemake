using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace ConsoleApplication1.Classes
{
    class Level : Sprite
    {
        public Level( Texture2D backgroundTexture, SpriteBatch spriteBatch)
            : base(backgroundTexture, new Vector2(0,0), spriteBatch)
        {

        }
    }
}
