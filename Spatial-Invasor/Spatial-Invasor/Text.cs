using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SpatialInvasor
{
    public abstract class Text : Entity
    {
        protected string DrawingText;
        public int Value;
        protected SpriteFont font;

        public Text(Game game) : base(game)
        {
            
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

    public class Score : Text
    {
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

    public class Life : Text
    {
        public Life(Game game) : base(game)
        {
            DrawingText = "Vies : " + Value;
            Position = new Vector2(300, 430);
        }

        public void DecreaseLife()
        {
            Value -= 1;
        }
    }
}
