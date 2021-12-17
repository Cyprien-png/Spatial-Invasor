using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    class UFO : Alien
    {
        public UFO(MainGame game) : base(game)
        {
            Speed = 250f;

            ShootingSpeed = 900f;

            Position = new Vector2(250, 30);
            Limits = new float[2] { 250f, 700f };

            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(100, 23, 48, 21)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.Red);
            SpriteBatch.End();
        }

        protected override void Move(GameTime gametime)
        {
            throw new NotImplementedException();
        }
    }
}

