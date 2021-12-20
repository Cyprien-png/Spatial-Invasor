using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SpatialInvasor
{
    public abstract class GameInfo : Entity
    {
        protected string DrawingText;
        protected int Value;
        
        protected SpriteFont font;

        public GameInfo(Game game) : base(game) {
            Value = 0;
        }

        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(font, DrawingText, Position, Color.White);
            SpriteBatch.End();
        }
    }

    public class Score : GameInfo {
        public Score(Game game) : base(game)
        {
            DrawingText = "Score : " + Value;
            Position = new Vector2(100, 430);
        }

        public void IncreaseScore(int value)
        {
            Value += value;
        }
    }
    
}
