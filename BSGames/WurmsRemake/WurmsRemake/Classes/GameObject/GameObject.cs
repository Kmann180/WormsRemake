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
        //Game Object base class.
        //Will handle the input, rendering, collision response, physics etc... for all objects that are part of the game world.
        public abstract class GameObject
        {
            protected Sprite _sprite;
            protected WurmsGame _parent;
            protected bool _collision;
            protected Vector2 _worldPosition;
            protected Vector2 _velocity;
            protected float _gravity;
            

            public Sprite Sprite { get { return this._sprite; } }
            public Boolean Collision { get { return this._collision; } set { this._collision = value; } }

            public GameObject(WurmsGame parent, Vector2 position)
            {
                this._parent = parent;
                this._worldPosition = position;
                this._velocity = new Vector2(0.0f, 0.0f);
                this._sprite = null;
                this._gravity = 0.0f;
            }

            public abstract void Render(GameTime gameTime);
            public abstract void Translation(GameTime gameTime);
            public abstract void Input(GameTime gameTime);
            public abstract void Physics(GameTime gameTime);
            public abstract void Update(GameTime gameTime);
            public abstract void CollisionResponse(string objectKey, Vector2 collisionPoint);
        }
    }
}
