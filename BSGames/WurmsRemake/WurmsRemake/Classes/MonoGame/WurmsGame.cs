using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WurmsRemake
{
    public partial class WurmsGame : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        StateManager _stateMan;

        public WurmsGame()
        {
            this._graphics = new GraphicsDeviceManager(this);
            this._graphics.PreferredBackBufferWidth = 640;
            this._graphics.PreferredBackBufferHeight = 480;
            this._graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            
            base.Initialize();
           
        }

        protected override void LoadContent()
        {
            this._spriteBatch = new SpriteBatch(GraphicsDevice);
            this._stateMan = new StateManager(this);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this._stateMan.ManageTransitions();
            this._stateMan.CurrentState.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this._spriteBatch.Begin();
            this._stateMan.CurrentState.RenderScene(gameTime);
            base.Draw(gameTime);
            this._spriteBatch.End();
           
        }
    }
}
