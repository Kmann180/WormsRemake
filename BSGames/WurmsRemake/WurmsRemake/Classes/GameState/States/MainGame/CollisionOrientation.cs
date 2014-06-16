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
        enum CollisionOrientation
        {
            NORTH,
            SOUTH,
            EAST,
            WEST,
            NORTHEAST,
            NORTHWEST,
            SOUTHEAST,
            SOUTHWEST,
            NONE
        };
    }
}
