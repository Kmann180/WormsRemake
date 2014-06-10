using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Classes;
using Microsoft.Xna.Framework.Input;

namespace ConsoleApplication1
{
    // Shell for a basic MonoGame game.

    public class Game1 : Game
    {

        GraphicsDeviceManager graphics; // Came with the code, don't mess with it.
        SpriteBatch spriteBatch; // We use these to draw textures, every texture will "belong" to one of these.

        Texture2D PlayerTexture; // texture for testing
        Player PlayerOne; //sprite for testing, see Sprite.cs

        Texture2D ReticleTexture;
        Reticle AimingReticle;

        TerrainDestroyer Destroyer;

        Level LevelOne;

        //Constructor for the game
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // This is a folder inside our project directory where all the images and shit go.
        }

        //Don't mess with this yet.
        protected override void Initialize()
        {
            base.Initialize();
        }

        //This is where we load in all our textures and stuff.
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load player data
            PlayerTexture = Content.Load<Texture2D>("RedPlayerWithShotgun");
            PlayerOne = new Player(PlayerTexture, new Vector2(50, 50), spriteBatch); //Again, see Sprite.cs

            //load data for aiming reticle
            ReticleTexture = Content.Load<Texture2D>("Rocket");
            AimingReticle = new Reticle(ReticleTexture, new Vector2(70, 50), spriteBatch);

            //create a terrain destroyer and the background for the level
            Destroyer = new TerrainDestroyer(Content.Load<Texture2D>("deform"), new Vector2(50, 50), spriteBatch);
            LevelOne = new Level(Content.Load<Texture2D>("FirstLand"), spriteBatch);

            this.IsMouseVisible = true;
        }

        protected override void UnloadContent()
        {
            
        }

        //This is where game logic will  be updated.
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (PlayerOne.IsAlive)
            {
                PlayerOne.Update(gameTime);
            }
        }
        
        //This is where drawing shit happens. 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); //Blue background
            spriteBatch.Begin(); //Everything that belongs to "spriteBatch" will be drawn between the .begin() & .end()
            base.Draw(gameTime);
            LevelOne.Draw();
            AimingReticle.Draw();
            if (PlayerOne.IsAlive)
            {
                PlayerOne.Draw(); //This actually draws the test image.
            }
            spriteBatch.End();
        }
    }
}
