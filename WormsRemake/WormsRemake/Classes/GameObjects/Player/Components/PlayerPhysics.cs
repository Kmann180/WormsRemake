using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        class PlayerPhysics : PhysicsComponent
        {
            private float _gravity = .98f;
            
            public PlayerPhysics(WormsGame parent, GameObject container)
                : base(parent, container)
            {

            }

            public override void Update(GameTime gameTime)
            {
                if (!_collision)
                {
                    _container.Velocity = new Vector2(_container.Velocity.X, _container.Velocity.Y + _gravity);
                }
            }

            public override void Recieve(Message message)
            {
                
            }
        }
    }
}
