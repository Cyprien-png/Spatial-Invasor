using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace SpatialInvasor
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        List<Vector2> WallPositions;
        private Player player;
        private List<LaserShot> _laserList;
        private List<Wall> _walls;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _walls = new List<Wall>()
            {
                new Wall(this, new Vector2(75, 350)),
                new Wall(this, new Vector2(225, 350)),
                new Wall(this, new Vector2(375, 350)),
                new Wall(this, new Vector2(525, 350)),
                new Wall(this, new Vector2(675, 350))
            };
            player = new Player(this);

            _laserList = new List<LaserShot>() {
                new LaserShot(this, player)
            };
        }

        protected override void Initialize()
        {
            Components.Add(new Playfield(this));
            Components.Add(player);            
            foreach (Wall wall in _walls) {
                Components.Add(wall);
            }
            base.Initialize();
        }

        public void addShot(LaserShot laserShot)
        {
            _laserList.Add(laserShot);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            List<LaserShot> lasersToKill = new List<LaserShot>();
            List<Wall> wallsToKill = new List<Wall>();
            foreach (Wall wall in _walls)
            {
                foreach (LaserShot laser in _laserList)
                {
                    if (wall.Hitbox.Intersects(laser.Hitbox))
                    {
                        laser.killLaser();
                        wall.Hit();
                        lasersToKill.Add(laser);
                        wallsToKill.Add(wall);
                    }
                }
                if (wall.Life == 0)
                    _walls = _walls.Except(wallsToKill).ToList();
            }
            _laserList = _laserList.Except(lasersToKill).ToList();



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
