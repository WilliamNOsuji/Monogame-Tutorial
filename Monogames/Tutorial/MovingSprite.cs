using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Tutorial
{
    internal class MovingSprite : ScaledSprite
    {
        private float speed;
        public MovingSprite(Texture2D texture, Vector2 position, float speed) : base(texture, position) 
        { 
            this.speed = speed;
        }

        public override void Update()
        {
            base.Update();
            position.X += speed;
        }
    }
}
