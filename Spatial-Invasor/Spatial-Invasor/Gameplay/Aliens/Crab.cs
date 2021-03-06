using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SpatialInvasor
{
    public class Crab : Alien
    {
        public Crab(MainGame game, int spawnX, int spawnY) : base(game)
        {
            Position = new Vector2(spawnX, spawnY);
            ScoreValue = 20;
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(1, 26, 33, 24),
                new Rectangle(1, 1, 33, 24)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            return Position + new Vector2(16, 5);
        }

        public override void Draw(GameTime gameTime)
        {
            int indexSheetPositions = (int)(gameTime.TotalGameTime.TotalSeconds % CountDuration);
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[indexSheetPositions], Color.LightBlue);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            Shoot();
        }

    }
}
