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
        public class MainGame : GameState
        {
            Dictionary<string, GameObject> _objects;
            Reticle _reticle;
            Player _activePlayer;
            CollisionManager _collisionMan;

            public MainGame(WurmsGame parent)
                :base(parent)
            {
                this._objects = new Dictionary<string, GameObject>();
                this._reticle = new Reticle(this._parent.Content.Load<Texture2D>("CrossHair"), this._parent._spriteBatch, new Vector2(0.0f, 0.0f));

                this._objects["water"] = new Water(this._parent, this._parent.Content.Load<Texture2D>("Water"), new Vector2(0.0f, 300.0f));
                this._objects["terrain"] = new Terrain(this._parent, this._parent.Content.Load<Texture2D>("FirstLand"), new Vector2(0.0f, 0.0f));
                this._objects["player_one"] = new Player(this._parent, this._parent.Content.Load<Texture2D>("RedPlayerWithShotgun"), new Vector2(240.0f, 100.0f));
                

                this._activePlayer = (Player)this._objects["player_one"];
                this._collisionMan = new CollisionManager(ref this._objects, ref this._reticle);
            }

            public override void Update(GameTime gameTime)
            {
                this._collisionMan.Manage();
                foreach (KeyValuePair<string, GameObject> obj in this._objects)
                {
                    this._objects[obj.Key].Update(gameTime);
                }
                this._reticle.Update(gameTime);
            }

            public void ToggleInput(Player player)
            {
                player.InputEnabled = !player.InputEnabled;
            }

            public override void RenderScene(GameTime gameTime)
            {
                foreach (KeyValuePair<string, GameObject> obj in this._objects)
                {
                    this._objects[obj.Key].Render(gameTime);
                }
                this._reticle.Render(gameTime);
            }
        }
    }
}
