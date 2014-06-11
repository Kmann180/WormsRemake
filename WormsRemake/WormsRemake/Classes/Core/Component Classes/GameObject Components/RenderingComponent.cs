using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WormsRemake
{
    public partial class WormsGame : Game
    {

        //CLASS:RenderingComponent
        //BRIEF:For containment in game objects.
        //      Handles rendering for its container.

        public abstract class RenderingComponent : Component
        {
            //Variables
            protected Dictionary<string, Texture2D> _textures; //Dictionary to organize textures by name. TODO: SpriteSheets & XML
            protected SpriteBatch _sourceBatch;                //The Sprite Batch that the active texture is going to render to,
            protected Texture2D _activeTexture;                //The current activate texture (animation, frame, whatever you want to call it)
            protected TextureData _activeTextureData;

            //Properties
            public TextureData ActiveTextureData { get { return this._activeTextureData; } set { this._activeTextureData = value; } }
            public Texture2D ActiveTexture { get { return this._activeTexture; } }

            //CONSTRUCTOR
            public RenderingComponent(WormsGame parent, GameObject container)
                : base(parent, container)
            {
                _textures = new Dictionary<string, Texture2D>();
                _sourceBatch = _parent._spriteBatch;
            }

            //FUNCTION: AddTexture
            //BRIEF: Adds a new texture from the "Content" folder to the _textures dictionary and indexes it with the argument provided.
            //REMEMBER TO DO THE STUPID ALWAYS COPY TO OUTPUT WHATEVER THING ON EVERY ASSET
            public void AddTexture(string textureFileName, string textureKeyName)
            {
               Texture2D newTexture = _parent.Content.Load<Texture2D>(textureFileName);
               this._textures.Add(textureKeyName, newTexture);
            }

            //FUNCTINON: SwitchActiveTexture
            //BRIEF: Changes the currently rendered texture.
            public void SwitchActiveTexture(string newActiveTextureName)
            {
                this._activeTexture = this._textures[newActiveTextureName];
                this._activeTextureData = new TextureData(new Rectangle(    (int)this._container.Position.X,
                                                                            (int)this._container.Position.Y,
                                                                            this._activeTexture.Width,
                                                                            this._activeTexture.Height),
                                                          new Color[(int)this._activeTexture.Width * (int)this.ActiveTexture.Height]);
                this._activeTexture.GetData(this._activeTextureData._colorData);
                //this._activeTexture.SetData(this._colorData);
            }
        }
    }
}
