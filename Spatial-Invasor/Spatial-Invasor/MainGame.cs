using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SpatialInvasor
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        List<Vector2> WallPositions;
        private Player player;
        private List<LaserShot> _laserList;
        private List<Wall> _walls;
        private List<Crab> _crabs;
        private List<Squid> _squids;
        private List<Octopus> _octopus;
        private UFO _ufo;

        private double _timeSinceLastSpawn = 0.0;
        private const double SPAWN_UFO_PERIOD = 1.0;
        private int _maxScore;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _crabs = new List<Crab>()
            {
                new Crab(this)
            };

            _squids = new List<Squid>()
            {
                new Squid(this)
            };

            _octopus = new List<Octopus>()
            {
                new Octopus(this)

            };

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

            _ufo = new UFO(this);
        }

        protected override void Initialize()
        {
            Components.Add(new Playfield(this));
            Components.Add(player);

            _crabs.ForEach(crab => Components.Add(crab));
            _squids.ForEach(squid => Components.Add(squid));
            _octopus.ForEach(octopus => Components.Add(octopus));
            _walls.ForEach(wall => Components.Add(wall));

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
            
            if (_timeSinceLastSpawn + SPAWN_UFO_PERIOD <= gameTime.TotalGameTime.TotalMinutes) {
                _ufo = new UFO(this);
                Components.Add(_ufo);
                _timeSinceLastSpawn = gameTime.TotalGameTime.TotalMinutes;
            }

            List<LaserShot> lasersToKill = new List<LaserShot>();
            List<Wall> wallsToKill = new List<Wall>();
            List<Crab> crabsToKill = new List<Crab>();
            List<Squid> squidsToKill = new List<Squid>();
            List<Octopus> octopusToKill = new List<Octopus>();

            foreach (LaserShot laser in _laserList)
            {
                foreach (Crab crab in _crabs)
                {
                    if (crab.Hitbox.Intersects(laser.Hitbox) && laser.Shooter == player)
                    {
                        laser.killLaser();
                        crab.killAlien();
                        lasersToKill.Add(laser);
                        crabsToKill.Add(crab);
                        _maxScore += crab.GetScoreValue;
                    }
                }

                foreach (Squid squid in _squids)
                {
                    if (squid.Hitbox.Intersects(laser.Hitbox) && laser.Shooter == player)
                    {
                        laser.killLaser();
                        squid.killAlien();
                        lasersToKill.Add(laser);
                        squidsToKill.Add(squid);
                        _maxScore += squid.GetScoreValue;
                    }
                }

                foreach (Octopus octopus in _octopus)
                {
                    if (octopus.Hitbox.Intersects(laser.Hitbox) && laser.Shooter == player)
                    {
                        laser.killLaser();
                        octopus.killAlien();
                        lasersToKill.Add(laser);
                        octopusToKill.Add(octopus);
                        _maxScore += octopus.GetScoreValue;
                    }
                }

                foreach (LaserShot secondLaser in _laserList)
                {
                    if(laser != secondLaser)
                    {
                        if (laser.Hitbox.Intersects(secondLaser.Hitbox))
                        {
                            laser.killLaser();
                            secondLaser.killLaser();
                            lasersToKill.Add(laser);
                            lasersToKill.Add(secondLaser);
                        }
                    }
                }

                if (laser.Hitbox.Intersects(player.Hitbox) && laser.Shooter != player)
                {
                    laser.killLaser();
                    player.kill();
                }

                if (_ufo.Hitbox.Intersects(laser.Hitbox) && laser.Shooter == player)
                {
                    laser.killLaser();
                    _ufo.killAlien();
                    lasersToKill.Add(laser);
                    _maxScore += _ufo.GetScoreValue;
                }

                _laserList = _laserList.Except(lasersToKill).ToList();
                _crabs = _crabs.Except(crabsToKill).ToList();
                _squids = _squids.Except(squidsToKill).ToList();
                _octopus = _octopus.Except(octopusToKill).ToList();
            }

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
