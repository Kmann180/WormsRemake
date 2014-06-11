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
        GraphicsDeviceManager _graphics; // Came with the code, don't mess with it.
        SpriteBatch _spriteBatch; // We use these to draw textures, every texture will "belong" to one of these.

        Player _playerOne;
        Terrain _ground;
        TerrainDestroyer _destroyer;

        MouseState _currentMouseState;
        Vector2 _mousePosition;

        Level _levelOne;


        //Constructor for the game
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerOne = new Player(Content.Load<Texture2D>("red_square"), new Vector2(50, 50), _spriteBatch);
            _ground = new Terrain(Content.Load<Texture2D>("terrain"), new Vector2(0, 0), _spriteBatch);
            _destroyer = new TerrainDestroyer(Content.Load<Texture2D>("deform"), new Vector2(50, 50), _spriteBatch);
            _levelOne = new Level(Content.Load<Texture2D>("bg"), _spriteBatch);

            this.IsMouseVisible = true;
        }

        protected override void UnloadContent()
        {
          
        }

        //This is where game logic will  be updated.
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            _playerOne.Update(gameTime);
            UpdateMouse();
            _destroyer.Update(_mousePosition);
            
        }
        
        //This is where drawing shit happens. 
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue); //Blue background
            _spriteBatch.Begin(); //Everything that belongs to "spriteBatch" will be drawn between the .begin() & .end()
            base.Draw(gameTime);

            _levelOne.Draw();
            if( !Collision(_playerOne, _ground))
            {
                _playerOne.Draw(); //This actually draws the test image.
            }
            
            _ground.Draw();
            _destroyer.Draw();
            _spriteBatch.End();
        }

        void UpdateMouse()
        {
            MouseState previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mousePosition = new Vector2(_currentMouseState.X, _currentMouseState.Y);

            if (previousMouseState.LeftButton == ButtonState.Pressed && _currentMouseState.LeftButton == ButtonState.Released)
            {
                _destroyer.Deform(_ground);
            }

        }

        static bool IntersectsPixels(Rectangle rectangleA, Color[] dataA,
                                    Rectangle rectangleB, Color[] dataB)
        {
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }   
            }
            return false;
        }

        bool Collision(Sprite spriteA, Sprite spriteB)
        {
            if (IntersectsPixels(spriteA.Bounds, spriteA.ColorData, spriteB.Bounds, spriteB.ColorData))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
