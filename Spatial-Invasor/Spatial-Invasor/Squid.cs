using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    class Squid : Alien
    {
        bool Direction = true;
        public Squid(MainGame game) : base(game)
        {
            Speed = 250f;

            ShootingSpeed = 900f;

            Position = new Vector2(250, 200);
            Limits = new float[2] { 250f, 700f };

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

