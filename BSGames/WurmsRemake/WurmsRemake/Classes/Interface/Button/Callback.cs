using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WurmsRemake
{
    public partial class WurmsGame : Game
    {
        public delegate void Callback(); //Quick and dirty delegate type to use for the button callback.
    }
}
