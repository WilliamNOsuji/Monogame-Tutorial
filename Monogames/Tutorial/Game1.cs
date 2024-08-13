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

        /** Animation **/
        Texture2D enemy_idleTexturesSheet;
        //int counter;
        //int activeFrame;
        //int numFrame;

        AnimationManager _animationManager;
        AnimationManager am2;

        /** Animation END **/

        /** Fonts **/
        private SpriteFont font;
        private int score = 0;
        /** Fonts END **/


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

            /** Loading Texture Animations **/
            enemy_idleTexturesSheet = Content.Load<Texture2D>("enemy_idle_sheet");
            //activeFrame = 0;
            //numFrame = 2;
            //counter = 0;

            _animationManager = new(11,1, new Vector2(24,33));

            am2 = new(11, 1, new Vector2(24, 33))
            {
                OffsetX = 3, OffsetY = 3,
            };
            /** Loading Texture Animations END **/

            /** Loading the Fonts **/
            font = Content.Load<SpriteFont>("Fonts/tutorialFont");
            /** Loading the Fonts END **/

            Texture2D playerTexture = Content.Load<Texture2D>("__Idle");
            Texture2D enemyTexture = Content.Load<Texture2D>("enemy_idle");

            //sprites.Add(new Sprite(enemyTexture, new Vector2(20, 20)));
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

            /** The following code is for when an object collides with another then 
             * it deletes the other by adding it to a background list and removing it **/

            //List<Sprite> killList = new();
            //
            //foreach (var sprite in sprites)
            //{
            //    sprite.Update(gameTime);
            //
            //    if (sprite != player && sprite.Rect.Intersects(player.Rect))
            //    {
            //        killList.Add(sprite);
            //    }               
            //}
            //
            //foreach (var sprite in killList)
            //{
            //    sprites.Remove(sprite);
            //}

            // TODO: Add your update logic here

            //counter++;
            //if(counter > 22)
            //{
            //    counter = 0;
            //    activeFrame++;
            //    if(activeFrame == numFrame)
            //    {
            //        activeFrame = 0;
            //    }
            //}

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !space_pressed)
            {
                score++;
                space_pressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                space_pressed = false;
            }

            _animationManager.Update();

            /** This code is for forcefull collision (when you are unable to cross the object) **/
            foreach(var sprite in sprites)
            {
                sprite.Update(gameTime);
            }
            player.Update(gameTime);


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

            _spriteBatch.Draw(
                    enemy_idleTexturesSheet,
                    new Rectangle(100, 100, 75, 100),
                    _animationManager.GetFrame(),
                    Color.White);

            _spriteBatch.Draw(
                    enemy_idleTexturesSheet,
                    new Rectangle(200, 200, 75, 100),
                    _animationManager.GetFrame(),
                    Color.White);

            /** Drawing the Font **/
            _spriteBatch.DrawString(font, "Hello World", Vector2.Zero, Color.Red);
            _spriteBatch.DrawString(font, "(Press Space) Here is your score :" + score, new Vector2(100, 400), Color.Red);
           
            /** Drawing the Font **/


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
