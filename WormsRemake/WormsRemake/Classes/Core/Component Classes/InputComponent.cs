using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        //CLASS NAME:InputComponent
        //BRIEF:For containment in valid GameObjects( Worms, Projectiles, Terrain etc...).
        //      Handles user input from keyboard and mouse.

        public abstract class InputComponent : Component
        {
            //Variables

            //Constructor
            public InputComponent(WormsGame parent, GameObject container)
                : base(parent, container)
            {

            }
        }
    }
}
