using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpatialInvasor
{
    public class Octopus : Alien
    {

        public Octopus(MainGame game) : base (game)
        {
            Speed = 250f;

            ShootingSpeed = 900f;

            Position = new Vector2(250, 100);
            Limits = new float[2] { 250f, 700f };

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
    }
}
