using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpatialInvasor
{
    public class Octopus : Alien
    {
        

        public Octopus(MainGame game) : base(game)
        {
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(36, 1, 36, 24)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.Purple);
            SpriteBatch.End();
        }

        protected override void Move(GameTime gametime)
        {
            throw new NotImplementedException();
        }
    }
}
