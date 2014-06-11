using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        public class TextureData
        {
            public Rectangle _rectangle;
            public Color[] _colorData;

            public TextureData(Rectangle rectangle, Color[] colorData)
            {
                this._rectangle = rectangle;
                this._colorData = colorData;
            }
        }
    }
}
