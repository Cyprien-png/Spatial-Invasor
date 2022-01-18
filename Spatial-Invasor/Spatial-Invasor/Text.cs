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

        public Text(Game game, int value) : base(game)
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
        public Score(Game game, int value) : base(game, value)
        {
            DrawingText = "Score : " + Value;
            Position = new Vector2(100, 430);
        }

        public void IncreaseScore(int value)
        {
            Value += value;
        }
        public override void Update(GameTime gameTime)
        {
            DrawingText = "Score : " + Value;
        }

    }

    public class Life : Text
    {
        public Life(Game game, int value) : base(game, value)
        {
            DrawingText = "Vies : " + Value;
            Position = new Vector2(300, 430);
        }

        public void DecreaseLife()
        {
            Value -= 1;
        }

        public override void Update(GameTime gameTime)
        {
            DrawingText = "Vies : " + Value;
        }
    }

    public class MenuText : Text {
        public bool ISChoosen;
        private bool WasChoosenLast;
        public MenuText(Game game, int value) : base(game, value)
        {
            DrawingText = "Vies : " + Value;
            Position = new Vector2(300, 430);
        }

        public void DecreaseLife()
        {
            Value -= 1;
        }

        public override void Update(GameTime gameTime)
        {
            if (ISChoosen && !WasChoosenLast)
            {
                DrawingText = ">" + DrawingText;
                WasChoosenLast = true;
            }
            
            
        }
    }
}
