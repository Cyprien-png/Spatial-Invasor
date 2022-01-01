using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    class Squid : Alien
    {
        
        public Squid(MainGame game) : base(game)
        {
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(73, 1, 24, 24)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.LightGreen);
            SpriteBatch.End();
        }

        protected override void Move(GameTime gametime)
        {
            throw new NotImplementedException();
        }
    }
}

