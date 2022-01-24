using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpatialInvasor
{
    public class EndGameComponent : DrawableGameComponent
    {
        private MainGame _mainGame;
        public Texture2D FinalTitle;
        public int FinalScore;
        public bool HasWon;

        Color MessageColor;

        public EndGameComponent(MainGame game, int finalScore, bool hasWon) : base(game) {
            _mainGame = game;
            FinalScore = finalScore;
            HasWon = hasWon;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            if (HasWon)
            {
                FinalTitle = _mainGame.Content.Load<Texture2D>("you_won");
                MessageColor = Color.DarkGreen;
            }
            else {
                FinalTitle = _mainGame.Content.Load<Texture2D>("you_died");
                MessageColor = Color.Red;
            }
            
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainGame.SpriteBatch.Begin();
            _mainGame.SpriteBatch.Draw(FinalTitle, new Vector2(150, 100), Color.White);
            _mainGame.SpriteBatch.DrawString(_mainGame.Font, "Score final : " + FinalScore.ToString(), new Vector2(285, 260), MessageColor);
            _mainGame.SpriteBatch.DrawString(_mainGame.Font, "Appuyez sur ESPACE", new Vector2(270, 300), MessageColor);
            _mainGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
