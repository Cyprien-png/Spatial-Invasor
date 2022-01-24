using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace SpatialInvasor
{
    public class DeadScreenComponent : DrawableGameComponent
    {
        private MainGame _mainGame;
        public Texture2D DeathTitle;
        public int FinalScore;

        public DeadScreenComponent(MainGame game, int finalScore) : base(game) {
            _mainGame = game;
            FinalScore = finalScore;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            DeathTitle = _mainGame.Content.Load<Texture2D>("you_died");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainGame.SpriteBatch.Begin();
            _mainGame.SpriteBatch.Draw(DeathTitle, new Vector2(150, 100), Color.White);
            _mainGame.SpriteBatch.DrawString(_mainGame.Font, "Score final : " + FinalScore.ToString(), new Vector2(285, 260), Color.Red);
            _mainGame.SpriteBatch.DrawString(_mainGame.Font, "Appuyez sur ESPACE", new Vector2(270, 300), Color.Red);
            _mainGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
