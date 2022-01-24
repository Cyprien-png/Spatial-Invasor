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

        public Player Player;
        public List<LaserShot> LaserList;
        public List<Wall> Walls;
        public List<Alien> Aliens;
        public UFO Ufo;
        private int positionX;

        public GameScene MainMenu, GamePlay, DeadScreen;
        public KeyboardState CurrentState, previousKeyboardState;

        bool IsWaiting;
        
        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            CurrentState = Keyboard.GetState();
        }

        public void EndingGame(int score)
        {
            DeadScreenComponent deadScreen = new DeadScreenComponent(this, score);
            DeadScreen = new GameScene(this, deadScreen);

            SwitchScene(DeadScreen);
            IsWaiting = true;
        }

        private void ChangeComponentState(GameComponent component, bool enabled)
        {
            component.Enabled = enabled;
            if (component is DrawableGameComponent)
            {
                ((DrawableGameComponent)component).Visible = enabled;
            }
        }
        // Permet de changer de scène en activant ou pas certains composants
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
            LaserList.Add(laserShot);
        }

        

        protected override void Initialize()
        {
            // Ajout des composants du menu --------------------------------------------
            MenuItemsComponent menuItems = new MenuItemsComponent(this, new Vector2(340, 200));
            menuItems.AddItem("Jouer");
            menuItems.AddItem("Scores");
            menuItems.AddItem("Quitter");

            MainMenu = new GameScene(this, menuItems);
            foreach (GameComponent component in Components)
            {
                ChangeComponentState(component, false);
            }

            // Ajout des composants du GamePlay ---------------------------------------------
            Aliens = new List<Alien>();
            Walls = new List<Wall>();
            Player = new Player(this);
            Ufo = new UFO(this);
            LaserList = new List<LaserShot>();

            GameplayComponent gameplayComponent = new GameplayComponent(this);
            

            //Scores ----------
            ScoresComponent scoreComponent = new ScoresComponent(this);

            // Les composants sont ajoutées en deux étapes :
            // 1. Les composants solo (player, ufo)
            // 2. Les composants en liste (walls, aliens, lasers) pendant la création des objets dans la liste.
            GamePlay = new GameScene(this, gameplayComponent, Player, Ufo);
            

            positionX = 103;
            for (int i = 0; i < 15; i++)
            {
                Crab crab = new Crab(this, positionX, 100);
                Aliens.Add(crab);
                GamePlay.AddComponent(crab);
                positionX += 35;
            }

            positionX = 106;
            for (int i = 0; i < 18; i++)
            {
                Squid squid = new Squid(this, positionX, 130);
                Aliens.Add(squid);
                GamePlay.AddComponent(squid);
                positionX += 29;
            }

            positionX = 101;
            for (int i = 0; i < 14; i++)
            {
                Octopus octopus = new Octopus(this, positionX, 160);
                Aliens.Add(octopus);
                GamePlay.AddComponent(octopus);
                positionX += 38;
            }

            positionX = 75;
            for (int i = 0; i < 5; i++)
            {
                Wall wall_E = new Wall(this, new Vector2(positionX, 350));
                Walls.Add(wall_E);
                GamePlay.AddComponent(wall_E);
                positionX += 150;
            }

            // Choix de la première scène
            SwitchScene(MainMenu);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            previousKeyboardState = CurrentState;
            CurrentState = Keyboard.GetState();

            //Attends que le joueur appuye sur la touche entrée pour revenir au menu principal
            if (IsWaiting) {
                if (NewKey(Keys.Space)) {
                    Components.Clear();
                    Initialize();
                    
                    IsWaiting = false;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }
}
