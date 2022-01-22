using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SpatialInvasor
{
    public abstract class HUD
    {
        public Vector2 Position;
        public int Value;

        protected SpriteFont font;
        public HUD(int value)
        {
            this.Value = value;
        }
    }

    public class Score : HUD
    {
        
        public Score(int value) : base(value)
        {
            Value = value;
            Position = new Vector2(100, 430);
        }

        public void IncreaseScore(int value)
        {
            Value += value;
        }
    }

    public class Life : HUD
    {
        
        public Life(int value) : base(value)
        {
            Value = value;
            Position = new Vector2(300, 430);
        }

        public void DecreaseLife()
        {
            Value -= 1;
        }
    }
}
