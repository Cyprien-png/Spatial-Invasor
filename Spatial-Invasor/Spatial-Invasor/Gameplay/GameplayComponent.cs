using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace SpatialInvasor
{
    class GameplayComponent : DrawableGameComponent
    {
        private MainGame _mainGame;

        private Texture2D SpriteSheet;

        private double _timeSinceLastSpawn = 0.0;
        private const double SPAWN_UFO_PERIOD = 1.0;
        private int score = 0;
        

        public GameplayComponent(MainGame game) : base(game)
        {
            _mainGame = game;

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteSheet = Game.Content.Load<Texture2D>("main-spritesheet");
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            if (_timeSinceLastSpawn + SPAWN_UFO_PERIOD <= gameTime.TotalGameTime.TotalMinutes)
            {
                _mainGame.Ufo = new UFO(_mainGame);
                _mainGame.Components.Add(_mainGame.Ufo);
                _timeSinceLastSpawn = gameTime.TotalGameTime.TotalMinutes;
            }

            List<LaserShot> lasersToKill = new List<LaserShot>();
            List<Wall> wallsToKill = new List<Wall>();
            List<Alien> aliensToKill = new List<Alien>();
            bool isTouchingLimit = false;

            foreach (LaserShot laser in _mainGame.LaserList)
            {
                foreach (Alien alien in _mainGame.Aliens)
                {
                    if (alien.Hitbox.Intersects(laser.Hitbox) && laser.Shooter == _mainGame.Player)
                    {
                        laser.Kill();
                        alien.Kill();
                        score += alien.GetScoreValue;
                        lasersToKill.Add(laser);
                        aliensToKill.Add(alien);
                    }
                    if (alien.TouchLimit(gameTime)) { isTouchingLimit = true; }
                }

                foreach (LaserShot secondLaser in _mainGame.LaserList)
                {
                    if (laser != secondLaser)
                    {
                        if (laser.Hitbox.Intersects(secondLaser.Hitbox))
                        {
                            laser.Kill();
                            secondLaser.Kill();
                            score += 10;
                            lasersToKill.Add(laser);
                            lasersToKill.Add(secondLaser);
                        }
                    }
                }

                foreach (Wall wall in _mainGame.Walls)
                {
                    if (wall.Hitbox.Intersects(laser.Hitbox))
                    {
                        laser.Kill();
                        wall.Hit();
                        lasersToKill.Add(laser);
                    }
                    if (wall.Life == 0)
                        wallsToKill.Add(wall);
                }


                if (laser.Hitbox.Intersects(_mainGame.Player.Hitbox) && laser.Shooter != _mainGame.Player)
                {
                    laser.Kill();
                    _mainGame.Player.kill();
                    _mainGame.EndingGame(score);
                    
                    
                }
                if (laser.Hitbox.Intersects(_mainGame.Ufo.Hitbox))
                {
                    laser.Kill();
                    score += _mainGame.Ufo.GetScoreValue;
                    _mainGame.Player.kill();
                }


                _mainGame.Aliens = _mainGame.Aliens.Except(aliensToKill).ToList();
                _mainGame.LaserList = _mainGame.LaserList.Except(lasersToKill).ToList();
                _mainGame.Walls = _mainGame.Walls.Except(wallsToKill).ToList();
            }

            foreach (Alien alien in _mainGame.Aliens)
            {
                if (alien.TouchLimit(gameTime)) { isTouchingLimit = true; }
            }

            if (isTouchingLimit)
            {
                foreach (Alien aliens in _mainGame.Aliens)
                {
                    aliens.ChangeDirection(gameTime);
                }
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainGame.SpriteBatch.Begin();
            _mainGame.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
