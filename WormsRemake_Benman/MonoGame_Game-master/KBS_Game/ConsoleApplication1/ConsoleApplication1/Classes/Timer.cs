using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1.Classes
{
    class Timer : Sprite
    {
        public GameTime gameTime;
        private int TotalMinutes = 15;
        public int MinutesRemaining;

        //used to activate sudden death mode after the timer runs out
        private int WaterLevel;

        public int[] PlayerOrder;


        public Timer (Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        //tracks the timer containing the time remaining in the game
        public void UpdateTimer()
        {
            int SecondsRemaining = 60 - (int)gameTime.ElapsedGameTime.TotalSeconds;

            if (SecondsRemaining <= 0 && MinutesRemaining > 0)
            {
                gameTime.Equals(0);
                MinutesRemaining--;
            }
        }
    }
}
