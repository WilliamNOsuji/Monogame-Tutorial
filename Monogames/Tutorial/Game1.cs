using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tutorial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //ScaledSprite sprite;
        //ColoredSprite sprite
        //MovingSprite sprite;

        bool space_pressed = false;
        bool a_left_pressed = false;
        bool d_right_pressed = false;

        List<Sprite> sprites = new List<Sprite>();
        Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sprites = new();

            // TODO: use this.Content to load your game content here

            Texture2D playerTexture = Content.Load<Texture2D>("__Idle");
            Texture2D enemyTexture = Content.Load<Texture2D>("enemy_idle");

            sprites.Add(new Sprite(enemyTexture, new Vector2(20, 20)));
            sprites.Add(new Sprite(enemyTexture, new Vector2(400, 200)));
            sprites.Add(new Sprite(enemyTexture, new Vector2(700, 300)));

            player = new Player(playerTexture, new Vector2(50, 50), sprites);

            sprites.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //// KEY SPACE
            //if (!space_pressed && Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    space_pressed = true;
            //    Debug.WriteLine("Space key pressed");
            //}
            //if (Keyboard.GetState().IsKeyUp(Keys.Space))
            //{
            //    space_pressed = false;
            //}

            // TODO: Add your update logic here

            List<Sprite> killList = new();

            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);

                if (sprite != player && sprite.Rect.Intersects(player.Rect))
                {
                    killList.Add(sprite);
                }
            }

            foreach (var sprite in killList)
            {
                sprites.Remove(sprite);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (var sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
