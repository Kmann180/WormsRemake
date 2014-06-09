using Microsoft.Xna.Framework;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {
        //CLASS NAME:Component
        //BRIEF:Virtual class that serves as a base for other "Components". 
        //      "Components" are a a decoupling method used to organize the different
        //      the different types of processes that GameObjects need to perform into
        //      categories.
        //      For example, rather than have a GameObject class that has a ton of different
        //      disorganized function calls in one "Update Method" , the update method will 
        //      simply call the update method for each component; each component will handle
        //      only its own relevant tasks. (A graphics component would handle rendering only,
        //      a physics component would handle only collision/gravity etc...).

        public abstract class Component
        {
            //Variables
            public WormsGame _parent;       //Parent should always be the single "WormGame"
            public GameObject _container;   //Parent will be a valid GameObject
   
            //CONSTRUCTOR
            public Component(WormsGame parent, GameObject container)
            {
                _parent = parent;
                _container = container;
            }

            //Abstract Methods
            public abstract void Update(GameTime gameTime);           
            public abstract void Recieve(Message message);
        }
    }
}
