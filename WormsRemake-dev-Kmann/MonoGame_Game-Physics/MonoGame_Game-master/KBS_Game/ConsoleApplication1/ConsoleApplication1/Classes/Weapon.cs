using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApplication1.Classes
{
    public class Projectile : Sprite
    {
        public bool IsAlive = true;
        private bool OnGround = false;
        private float Velocity = 0;
        public Vector2 Movement { get; set; }
        public string PType;

               public Projectile (Texture2D texture, Vector2 position, SpriteBatch spritebatch, string PType)
            : base(texture, position, spritebatch)
        {

        }

        public void ApplyGravity(GameTime gametime)
        {
            if (!OnGround)
            {
                float i = 1;
                Velocity += 0.1f * i;
                Position += new Vector2(0, Velocity);
            }
        }

        public void Bounce(string PType)
        {
        }

        public void GrenadeUpdate()
        {

        }
        public void RocketUpdate()
        {

        }
        public void BulletUpdate()
        {

        }

        public void Update(GameTime gameTime)
        {

            switch (PType)
            {
                case "Grenade":
                    GrenadeUpdate();
                    break;
                case "Rocket":
                    RocketUpdate();
                    break;
                case "Bullet":
                    BulletUpdate();
                    break;

            }

            Movement -= Movement * new Vector2(.1f, .1f);
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;

            ApplyGravity(gameTime);


        }
  
    }

}
