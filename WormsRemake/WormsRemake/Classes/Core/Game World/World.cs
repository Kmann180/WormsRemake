using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        public class World
        {
            private Dictionary<string, GameObject> _objects;
            private WormsGame _parent;
            private CollisionHandler _collisionHandler;

            public CollisionHandler CollisionHandler { get { return this._collisionHandler; } }
            //private Dictionary<string, List<Rectangle>> _collisionData;

            public Dictionary<string, GameObject> Objects { get { return this._objects; } } 

            public World(WormsGame parent)
            {
                //this._collisionData = new Dictionary<string, List<Rectangle>>();
                this._collisionHandler = new CollisionHandler(this);
                this._objects = new Dictionary<string, GameObject>();
                this._parent = parent;
                this._objects["player"] = new Player(this._parent, this);
                this._objects["terrain"] = new Terrain(this._parent, this);
            }

            public void InitializeObjectComponents()
            {
                this._objects["player"].InitializeComponents();
                this._objects["terrain"].InitializeComponents();
            }

            public void Update(GameTime gameTime)
            {
                this._objects["player"].Update(gameTime);
                this._objects["terrain"].Update(gameTime);
                this._collisionHandler.CheckCollisions();
                //this.UpdateCollisionData();
                //this.ResolveCollisions();
            }

            public void Draw(GameTime gameTime)
            {
                this._objects["terrain"].Draw(gameTime);
                this._objects["player"].Draw(gameTime);
            }

            //public void AddCollisionData(string dataName, List<Rectangle> boundingBoxes)
            //{
            //    dataName = dataName.ToLower();
            //    this._collisionData[dataName] = boundingBoxes;
            //}

            //public void UpdateCollisionData()
            //{
            //    for (int i = 0; i < this._collisionData["player"].Count; ++i)
            //    {
            //        ((this._collisionData["player"])[i]) = new Rectangle((int)this._objects["player"].Position.X, (int)this._objects["player"].Position.Y, 20, 35);
            //    }
            //}

            //public void ResolveCollisions()
            //{
            //    foreach (Rectangle playerRect in this._collisionData["player"])
            //    {
            //        foreach (Rectangle terrainRect in this._collisionData["terrain"])
            //        {
            //            if (playerRect.Intersects(terrainRect) && !this._objects["player"].collisionTest)
            //            {
            //                this._objects["player"].collisionTest = true;
            //                break;
            //            }
            //            else
            //            {
            //                this._objects["player"].collisionTest = false;
            //            }
            //        }
            //    }
            //}
            
        }
    }
}
