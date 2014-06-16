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

        public int MinutesRemaining = 15;
        public int SecondsRemaining = 60;
        public int TurnRemaining = 45;

        public string TimerCharacters;
        public string TurnCharacters;


        public Timer (Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {

        }

        public void TrackGameTime()
        {
            if (SecondsRemaining - (int)gameTime.ElapsedGameTime.TotalSeconds <= 0 && MinutesRemaining > 0)
            {
                gameTime.Equals(0);
                MinutesRemaining--;
            }
        }

        public bool TimeLeftInTurn()
        {
            if (TurnRemaining - (int)gameTime.ElapsedGameTime.TotalSeconds <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //tracks the timer containing the time remaining in the game
        public void UpdateTimers()
        {
            TrackGameTime();
            TimeLeftInTurn();
            TimerCharacters = MinutesRemaining.ToString() + ":" + SecondsRemaining.ToString();
            TurnCharacters = TurnRemaining.ToString();
        }
    }
}
