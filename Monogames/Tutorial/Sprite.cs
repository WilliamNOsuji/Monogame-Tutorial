using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tutorial
{
    internal class Sprite
    {
        private static readonly float SCALE = 2.5f;

        public Texture2D texture;
        public Vector2 position;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    (int)(texture.Width * SCALE), 
                    (int)(texture.Height * SCALE) 
                );
            }
        }

        public Sprite(Texture2D texture2D, Vector2 position)
        {
            this.texture = texture2D;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rect, Color.White);
        }
    }
}
