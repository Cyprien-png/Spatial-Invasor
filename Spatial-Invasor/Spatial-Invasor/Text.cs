using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SpatialInvasor
{
    public abstract class Text
    {
        protected string DrawingText;
        public Vector2 Position;
        /*
        protected SpriteFont font;
        protected SpriteBatch SpriteBatch;
        */
        public Text(string drawingText, Vector2 position)
        {
            this.DrawingText = drawingText;
            this.Position = position;
        }
        /*
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
        */
    }

    public class Score : Text
    {
        public int Value;
        public Score(string drawingText, Vector2 position, int value) : base(drawingText, position)
        {
            Value = value;
            DrawingText = "Score : " + Value;
            Position = new Vector2(100, 430);
        }

        public void IncreaseScore(int value)
        {
            Value += value;
        }
        /*
        public override void Update(GameTime gameTime)
        {
            DrawingText = "Score : " + Value;
        }
        */
    }

    public class Life : Text
    {
        public int Value;
        public Life(string drawingText, Vector2 position, int value) : base(drawingText, position)
        {
            Value = value;
            DrawingText = "Vies : " + Value;
            Position = new Vector2(300, 430);
        }

        public void DecreaseLife()
        {
            Value -= 1;
        }
        /*
        public override void Update(GameTime gameTime)
        {
            DrawingText = "Vies : " + Value;
        }
        */
    }

    public class MenuText : Text {
        public bool ISChoosen;
        private bool _wasChoosenLast;
        private float size;
        private string _originalText;

        public MenuText(string drawingText, Vector2 position) : base(drawingText, position)
        {
            _originalText = DrawingText;
            Position = position;
            size = 0.6f;
        }
       /*
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
       */
    }
}
