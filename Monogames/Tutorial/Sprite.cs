using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tutorial
{
    internal class Sprite
    {
        public Texture2D texture;
        public Vector2 position;

        public Sprite(Texture2D texture2D, Vector2 zero)
        {
            this.texture = texture2D;
            this.position = position;
        }

        public virtual void Update()
        {

        }
    }
}
