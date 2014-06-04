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
        Projectile PlayerOne; //sprite for testing, see Sprite.cs

        //Level LevelOne;

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
            PlayerTexture = Content.Load<Texture2D>("Grenade");
            PlayerOne = new Projectile(PlayerTexture, new Vector2(50, 50), spriteBatch , "Grenade");

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
            if (PlayerOne.IsAlive)
            {
                PlayerOne.Draw(); //This actually draws the test image.
            }
            spriteBatch.End();
        }
    }
}
