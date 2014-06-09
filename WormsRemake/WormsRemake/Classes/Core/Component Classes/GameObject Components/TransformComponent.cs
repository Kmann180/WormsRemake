using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        //CLASS NAME:TransformComponent
        //BRIEF:For containment in valid game objects.
        //      Handles manipulation of vertex data for its container.

        public abstract class TransformComponent : Component
        {
            //Constructor
            public TransformComponent(WormsGame parent, GameObject container)
                : base(parent, container)
            {

            }
        }
    }
}
