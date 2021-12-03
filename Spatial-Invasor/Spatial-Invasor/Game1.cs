using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Spatial_Invasor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Entity Player;
        private Texture2D spriteSheet;

        Texture2D scoreWindow;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            scoreWindow = new Texture2D(GraphicsDevice, 80, 80);
            //scoreWindow.SetData(Color.White);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("main-spriteSheet");

            Player = new Player(_graphics, _spriteBatch, new Vector2(250, 400), spriteSheet, new Rectangle(152, 1, 21, 21)); //Le réctangle contient les dimensions de la découpe du srpite dans le srpiteSheet

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            Player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(scoreWindow, new Vector2(100, 100), Color.White);
            
            Player.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
