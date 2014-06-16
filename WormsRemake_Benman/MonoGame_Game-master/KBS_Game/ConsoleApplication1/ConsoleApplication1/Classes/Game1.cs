using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ConsoleApplication1.Classes;
using Microsoft.Xna.Framework.Input;

namespace ConsoleApplication1
{
    // Shell for a basic MonoGame game.

    public class Game1 : Game
    {
        GameTime gameTime = new GameTime();
        KeyboardState keyboardState = Keyboard.GetState();

        GraphicsDeviceManager graphics; // Came with the code, don't mess with it.
        SpriteBatch spriteBatch; // We use these to draw textures, every texture will "belong" to one of these.

        SpriteFont Font;

        Texture2D PlayerTexture;
        Player PlayerOne;

        Player[] Players = new Player[4];
        public int TurnNumber = 0;

        Timer GameTimer;

        //TerrainDestroyer Destroyer;

        Level LevelOne;

        //Constructor for the game
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // This is a folder inside our project directory where all the images and shit go.
        }

        public void PlayerController()
        {
            Players[TurnNumber].Update(gameTime);

            //if (!GameTimer.TimeLeftInTurn())
            if (keyboardState.IsKeyDown(Keys.T))
            {
                TurnNumber++;
                if (TurnNumber > 3)
                {
                    TurnNumber = 0;
                }
            }
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

            //Font = Content.Load<SpriteFont>("MyFont");

            //load player data
            PlayerTexture = Content.Load<Texture2D>("RedPlayerWithShotgun");
            for (int i = 0; i <= 3; i++)
            {
                Players[i] = new Player(PlayerTexture, new Vector2((i * 50), 50), spriteBatch); //Again, see Sprite.cs
            }
            //create a terrain destroyer and the background for the level
            //Destroyer = new TerrainDestroyer(Content.Load<Texture2D>("deform"), new Vector2(50, 50), spriteBatch);
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
            //PlayerController();

            for (int i = 0; i <= 3; i++)
            {
                if (Players[i].Position.Y < 400)
                {
                    Players[i].ApplyGravity();
                }
                else
                {
                    Players[i].OnGround = true;
                }
            }

            if (TurnNumber == 0)
            {
                Players[0].Update(gameTime);
            }
            if (TurnNumber > 10)
            {
                Players[1].Update(gameTime);
            }
        }
        
        //This is where drawing shit happens. 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); //Blue background
            spriteBatch.Begin(); //Everything that belongs to "spriteBatch" will be drawn between the .begin() & .end()
            base.Draw(gameTime);
            LevelOne.Draw();

            //draws the timer for the over all time
            //spriteBatch.DrawString(Font, GameTimer.TimerCharacters, new Vector2(50, 50), Color.White);
            for (int i = 0; i <= 3; i++)
            {
                if (Players[i].IsAlive)
                {
                    Players[i].Draw();
                }
            }
            spriteBatch.End();
        }
    }
}
