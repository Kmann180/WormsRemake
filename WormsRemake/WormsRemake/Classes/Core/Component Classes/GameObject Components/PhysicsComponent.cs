using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        //CLASS NAME:PhysicsComponent
        //BRIEF:For containment in valid game objects.
        //      Handles keyboard and mouse input relevant to its container.

        public abstract class PhysicsComponent : Component
        {
            //Variables
            protected bool _collision;
            protected List<Rectangle> _bounds;

            //Properties
            public bool Collision { get { return this._collision; } set { this._collision = value; } }
            public List<Rectangle> Bounds { get { return this._bounds; } set { this._bounds = value; } }

            //Constructor
            public PhysicsComponent(WormsGame parent, GameObject container)
                : base(parent, container)
            {
               this._collision = false;
            }
        }
    }
}
