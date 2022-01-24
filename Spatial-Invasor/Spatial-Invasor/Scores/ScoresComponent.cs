using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace SpatialInvasor
{
    public class ScoresComponent : DrawableGameComponent
    {
        private MainGame _mainGame;

        public ScoresComponent(MainGame game) : base(game) {
            _mainGame = game;
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainGame.SpriteBatch.Begin();
            //_mainGame.SpriteBatch.Draw(DeathTitle, new Vector2(150, 150), Color.White);
            _mainGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
