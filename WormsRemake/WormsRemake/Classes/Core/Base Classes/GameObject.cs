using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        //CLASS NAME:GameObject
        //BRIEF:Base (absrtract) class for all the types of objects in the Game World , worms, 
        //      terrain, projectiles, etc...
        public abstract class GameObject
        {
            //Variables
            protected WormsGame _parent; //Parent will always be the single "WormGame"
            protected World _world;
            protected Vector2 _position; //The objects position in the game world.
            protected Vector2 _velocity; //The objects current velocity.
            //protected Rectangle _bounds; //Bounding rectangle that surrounds the object.
            protected int _speed;        //Scalar value to determine how fast an object should move.
            protected Dictionary<string, Component> _components;

            public bool collisionTest = false;
          
            //Properties
            public Vector2 Position { get { return this._position; } set { this._position = value; }}
            public Vector2 Velocity { get { return this._velocity; } set { this._velocity = value; } }
            public World World { get { return this._world; } set { this._world = value; } }
            //public Rectangle Bounds { get { return this._bounds; } set { this._bounds = value; } }

            //CONSTRUCTOR
            public GameObject(WormsGame parent, World world)
            {
                this._parent = parent;
                this._world = world;
                this._components = new Dictionary<string, Component>();
            }

            //Astract methods
            public abstract void Update(GameTime gameTime);
            public abstract void Draw(GameTime gameTime);
            public abstract void InitializeComponents();   

            //Standard methods
            public void AddComponent(string componentName, Component component)
            {
                this._components.Add(componentName.ToLower(), component);
            }

            public Component GetComponent(string componentName)
            {
                if(this._components.ContainsKey(componentName))
                {
                    return this._components[componentName];
                }
                Component error = null;
                return error;
            }

            public void Send(Message message)
            {
                foreach (KeyValuePair<string, Component> comp in this._components)
                {
                    if (message.ValidRecipients.Contains(comp.Key))
                    {
                        this._components[comp.Key].Recieve(message);
                    }
                }
            }
            public void Send(Message message, Dictionary<string, object> attachments)
            {

                foreach (KeyValuePair<string, Object> data in attachments)
                {
                    message.Attach(data.Key, data.Value);
                }

                foreach (KeyValuePair<string, Component> comp in this._components)
                {
                    if (message.ValidRecipients.Contains(comp.Key))
                    {
                        this._components[comp.Key].Recieve(message);
                    }
                }
            }
        }
    }
}
