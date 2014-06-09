using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        class PlayerPhysics : PhysicsComponent
        {
            private float _gravity;
            private PlayerRendering _renderingLink;
          
            public PlayerPhysics(WormsGame parent, GameObject container, PlayerRendering renderingLink)
                : base(parent, container)
            {
                this._renderingLink = renderingLink;
                this._gravity = .0098f;
                List<Rectangle> boundingBoxes = new List<Rectangle>();
                boundingBoxes.Add( new Rectangle(   (int)this._container.Position.X, 
                                                    (int)this._container.Position.Y, 
                                                    this._renderingLink.ActiveTexture.Width, 
                                                    this._renderingLink.ActiveTexture.Height));
                this._container.World.AddCollisionData("player", boundingBoxes);
            }

            public override void Update(GameTime gameTime)
            {
                if (!_container.collisionTest)
                {
                    _container.Velocity = new Vector2(_container.Velocity.X, _container.Velocity.Y + _gravity);
                }
                else
                {
                    _container.Velocity = new Vector2(_container.Velocity.X, 0);
                }
            }

            public override void Recieve(Message message)
            {
                
            }
        }
    }
}
