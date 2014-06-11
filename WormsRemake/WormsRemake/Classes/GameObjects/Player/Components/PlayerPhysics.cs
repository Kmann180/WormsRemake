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
            private bool _applyGravity;

            public PlayerPhysics(WormsGame parent, GameObject container, PlayerRendering renderingLink)
                : base(parent, container)
            {
                this._renderingLink = renderingLink;
                this._gravity = .0098f;
                this._applyGravity = true;
                //List<Rectangle> boundingBoxes = new List<Rectangle>();
                //boundingBoxes.Add( new Rectangle(   (int)this._container.Position.X, 
                //                                    (int)this._container.Position.Y, 
                //                                    this._renderingLink.ActiveTexture.Width, 
                //                                    this._renderingLink.ActiveTexture.Height));
                //this._container.World.AddCollisionData("player", boundingBoxes);
            }

            public override void Update(GameTime gameTime)
            {
                if (this._applyGravity)
                {
                    _container.Velocity = new Vector2(_container.Velocity.X, _container.Velocity.Y + _gravity);
                }
            }

            public override void Recieve(Message message)
            {
                if (message.Content == "COLLISION")
                {
                    Vector2 collisionPoint = (Vector2)message.Attachment;
                    
                    if (collisionPoint.X > this._container.Position.X)
                    {
                        _container.Send(new Message("COLLISION_RIGHT", "input"));
                    }
                    if (collisionPoint.X < this._container.Position.X)
                    {
                        _container.Send(new Message("COLLISION_LEFT",  "input"));
                    }
                    if (collisionPoint.Y < this._container.Position.Y)
                    {
                        _container.Send(new Message("COLLISION_ABOVE", "input"));
                    }
                    if (collisionPoint.Y > this._container.Position.Y)
                    {
                        this._applyGravity = false;
                    }
                }
            }
        }
    }
}
