using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tutorial
{
    internal class Player : Sprite
    {
        List<Sprite> collisionGroup;

        public Player(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
        {
            this.collisionGroup = collisionGroup;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            var keyboardState = Keyboard.GetState();

            float changeX = 0;
            if (keyboardState.IsKeyDown(Keys.D))
            {
                changeX += 5;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                changeX -= 5;
            }

            position.X += changeX;

            // Collision X
            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.X -= changeX;
                }
            }

            float changeY = 0;
            if (keyboardState.IsKeyDown(Keys.W))
            {
                changeY -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                changeY += 5;
            }

            position.Y += changeY;

            // Collision Y
            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.Y -= changeY;
                }
            }
        }
    }
}
