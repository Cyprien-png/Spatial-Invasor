using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpatialInvasor
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        List<Vector2> WallPositions;
        List<LaserShot> LaserList;
        private Player player;
        LaserShot plLaser;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            WallPositions = new List<Vector2>()
            {
                new Vector2(300, 350),
                new Vector2(400, 350),
                new Vector2(525, 350),
                new Vector2(625, 350)
            };
            player = new Player(this);
            //plLaser = new LaserShot(this, player);

            LaserList = new List<LaserShot>() {
                new LaserShot(this, player)
            };
            //LaserList.Add(plLaser);
            

        }

        protected override void Initialize()
        {
            
            
            
            Components.Add(new Playfield(this));
            //Components.Add(LaserList[0]);
            Components.Add(player);

            foreach (LaserShot lasers in LaserList)
            {
                Components.Add(lasers);
            }

            foreach (Vector2 wallCoordinate in WallPositions) {
                Components.Add(new Wall(this, wallCoordinate));
            }
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
