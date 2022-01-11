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
            Position = new Vector2(277, 160);
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(73, 1, 24, 24),
                new Rectangle(73, 26, 24, 24)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            return Position + new Vector2(12, 5);
        }

        public override void Draw(GameTime gameTime)
        {
            int indexSheetPositions = (int)(gameTime.TotalGameTime.TotalSeconds % countDuration);
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[indexSheetPositions], Color.LightGreen);
            SpriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            Shoot();
        }
    }
}

