using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpatialInvasor
{
    public class Crab : Alien
    {
        bool Direction = true;

        public Crab(MainGame game) : base(game)
        {
            Speed = 250f;

            ShootingSpeed = 900f;

            Position = new Vector2(250, 130);
            Limits = new float[2] { 250f, 700f };

            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(1, 26, 33, 24),
                new Rectangle(1, 1, 33, 24)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime)
        {
            int indexSheetPositions = (int)(gameTime.TotalGameTime.TotalSeconds % countDuration);
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[indexSheetPositions], Color.LightBlue);
            SpriteBatch.End();
        }

        protected override void Move(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds % countDuration) < 0.01)
            {
                if (Direction)
                {
                    Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    TouchLimit(gameTime);
                }
                else
                {
                    Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    TouchLimit(gameTime);
                }
            }           
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public void TouchLimit(GameTime gameTime)
        {
            if (Position.X > Limits[1])
            {
                Position.Y += 20f;
                Direction = false;
            } else if (Position.X < Limits[0]) 
            {
                Position.Y += 20f;
                Direction = true;
            }
        }
    }
}
