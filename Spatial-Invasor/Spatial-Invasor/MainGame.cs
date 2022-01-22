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
        public SpriteBatch SpriteBatch;
        public SpriteFont Font;

        private Player _player;
        private List<LaserShot> _laserList;
        private List<Wall> _walls;
        private List<Alien> _aliens;
        private UFO _ufo;

        private double _timeSinceLastSpawn = 0.0;
        private const double SPAWN_UFO_PERIOD = 1.0;
        private int _maxScore;


        public GameScene MainMenu;
        public KeyboardState CurrentState, previousKeyboardState;
        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);


            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            int positionX = 0;
            _aliens = new List<Alien>();
            _player = new Player(this);
            _ufo = new UFO(this);


            positionX = 103;
            for (int i = 0; i < 15; i++)
            {
                Crab crab = new Crab(this, positionX, 100);
                _aliens.Add(crab);
                positionX += 35;
            }

            positionX = 106;
            for (int i = 0; i < 18; i++)
            {
                Squid squid = new Squid(this, positionX, 130);
                _aliens.Add(squid);
                positionX += 29;
            }

            positionX = 101;
            for (int i = 0; i < 14; i++)
            {
                Octopus octopus = new Octopus(this, positionX, 160);
                _aliens.Add(octopus);
                positionX += 38;
            }

            positionX = 75;
            _walls = new List<Wall>();
            for (int i = 0; i < 5; i++)
            {
                _walls.Add(new Wall(this, new Vector2(positionX, 350)));
                positionX += 150;
            }

            CurrentState = Keyboard.GetState();

            _laserList = new List<LaserShot>() {
                new LaserShot(this, _player)
            };
        }

        protected override void Initialize()
        {

            Components.Add(new Playfield(this));
            Components.Add(_player);

            _aliens.ForEach(alien => Components.Add(alien));
            _walls.ForEach(wall => Components.Add(wall));

            MenuItemsComponent menuItems = new MenuItemsComponent(this, new Vector2(340, 200));
            menuItems.AddItem("Jouer");
            menuItems.AddItem("Scores");
            menuItems.AddItem("Quitter");

            MenuComponent menu = new MenuComponent(this, menuItems);

            MainMenu = new GameScene(this, menuItems);
            foreach (GameComponent component in Components)
            {
                ChangeComponentState(component, false);
            }

            SwitchScene(MainMenu);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        private void ChangeComponentState(GameComponent component, bool enabled)
        {
            component.Enabled = enabled;
            if (component is DrawableGameComponent)
                ((DrawableGameComponent)component).Visible = enabled;
        }

        public void SwitchScene(GameScene scene)
        {
            GameComponent[] usedComponents = scene.ReturnComponents();
            foreach (GameComponent component in Components)
            {
                bool isUsed = usedComponents.Contains(component);
                ChangeComponentState(component, isUsed);
            }
        }

        public bool NewKey(Keys key)
        {
            return CurrentState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        public void addShot(LaserShot laserShot)
        {
            _laserList.Add(laserShot);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            previousKeyboardState = CurrentState;
            CurrentState = Keyboard.GetState();

            if (_timeSinceLastSpawn + SPAWN_UFO_PERIOD <= gameTime.TotalGameTime.TotalMinutes)
            {
                _ufo = new UFO(this);
                Components.Add(_ufo);
                _timeSinceLastSpawn = gameTime.TotalGameTime.TotalMinutes;
            }

            List<LaserShot> lasersToKill = new List<LaserShot>();
            List<Wall> wallsToKill = new List<Wall>();
            List<Alien> aliensToKill = new List<Alien>();
            bool isTouchingLimit = false;

            foreach (LaserShot laser in _laserList)
            {
                foreach (Alien alien in _aliens)
                {
                    if (alien.Hitbox.Intersects(laser.Hitbox) && laser.Shooter == _player)
                    {
                        laser.Kill();
                        alien.Kill();
                        lasersToKill.Add(laser);
                        aliensToKill.Add(alien);
                    }

                    if (alien.TouchLimit(gameTime)) { isTouchingLimit = true; }


                }

                foreach (LaserShot secondLaser in _laserList)
                {
                    if (laser != secondLaser)
                    {
                        if (laser.Hitbox.Intersects(secondLaser.Hitbox))
                        {
                            laser.Kill();
                            secondLaser.Kill();
                            lasersToKill.Add(laser);
                            lasersToKill.Add(secondLaser);
                        }
                    }
                }

                foreach (Wall wall in _walls)
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


                if (laser.Hitbox.Intersects(_player.Hitbox) && laser.Shooter != _player)
                {
                    laser.Kill();
                    _player.kill();
                }

                _aliens = _aliens.Except(aliensToKill).ToList();
                _laserList = _laserList.Except(lasersToKill).ToList();
                _walls = _walls.Except(wallsToKill).ToList();
            }

            foreach (Alien alien in _aliens)
            {
                if (alien.TouchLimit(gameTime)) { isTouchingLimit = true; }
            }

            if (isTouchingLimit)
            {
                foreach (Alien aliens in _aliens)
                {
                    aliens.ChangeDirection(gameTime);
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }
}
