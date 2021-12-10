using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Spatial_Invasor
{
    public class SpatialInvasor : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Entity _player;
        private Texture2D _spriteSheet;
        private List<Wall> _walls; 

        Texture2D scoreWindow;

        public SpatialInvasor()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _walls = new List<Wall>();
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
            _spriteSheet = Content.Load<Texture2D>("main-spriteSheet");

            _player = new Player(_graphics, _spriteBatch, new Vector2(250, 400), _spriteSheet, new Rectangle(152, 1, 21, 21)); //Le réctangle contient les dimensions de la découpe du srpite dans le srpiteSheet
            _walls.Add(new Wall(_graphics, _spriteBatch, new Vector2(300, 350), _spriteSheet, new Rectangle(99, 1, 50, 21)));
            _walls.Add(new Wall(_graphics, _spriteBatch, new Vector2(400, 350), _spriteSheet, new Rectangle(99, 1, 50, 21)));
            _walls.Add(new Wall(_graphics, _spriteBatch, new Vector2(525, 350), _spriteSheet, new Rectangle(99, 1, 50, 21)));
            _walls.Add(new Wall(_graphics, _spriteBatch, new Vector2(625, 350), _spriteSheet, new Rectangle(99, 1, 50, 21)));
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(Wall wall in _walls)
            {
                wall.Update(gameTime);
            }
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(scoreWindow, new Vector2(100, 100), Color.White);

            _player.Draw();

            foreach(Wall wall in _walls)
            {
                wall.Draw();
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
