using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SpatialInvasor
{
    public abstract class Text : DrawableGameComponent
    {
        protected string DrawingText;
        public Vector2 Position;
        protected SpriteFont font;
        protected SpriteBatch SpriteBatch;

        public Text(Game game, SpriteBatch spritebatch) : base(game)
        {
            this.SpriteBatch = spritebatch;
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
        public int Value;
        public Score(Game game, SpriteBatch spritebatch, int value) : base(game, spritebatch)
        {
            Value = value;
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
        public int Value;
        public Life(Game game, SpriteBatch spritebatch, int value) : base(game, spritebatch)
        {
            Value = value;
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
        private bool _wasChoosenLast;

        private string _originalText;

        public MenuText(Game game, SpriteBatch spritebatch, string originalText) : base(game, spritebatch)
        {
            _originalText = DrawingText;
            Position = new Vector2(300, 430);
        }

        public override void Update(GameTime gameTime)
        {
            if (ISChoosen && !_wasChoosenLast)
            {
                DrawingText = ">" + DrawingText;
                _wasChoosenLast = true;
            }
            else if(!ISChoosen)  {
                DrawingText = _originalText;
            }
            
            
        }
    }
}
