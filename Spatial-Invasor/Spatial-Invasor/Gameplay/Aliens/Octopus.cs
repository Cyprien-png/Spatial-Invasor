using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpatialInvasor
{
    public class Octopus : Alien
    {
        public Octopus(MainGame game, int spawnX, int spawnY) : base(game)
        {
            ScoreValue = 10;
            Position = new Vector2(spawnX, spawnY);
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(36, 1, 36, 24),
                new Rectangle(36, 26, 36, 24)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            return Position + new Vector2(18, 5);
        }

        public override void Draw(GameTime gameTime)
        {
            int indexSheetPositions = (int)(gameTime.TotalGameTime.TotalSeconds % CountDuration);
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[indexSheetPositions], Color.Purple);
            SpriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            Shoot();
        }
    }
}
