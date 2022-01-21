using System;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    public abstract class Alien : Creature
    {
        protected float countDuration = 2f;
        protected float directionFactor = 1f;

        public Alien(MainGame game) : base(game) {
            Speed = 500f;
        }

        public override bool IsPressingTrigger()
        {
            return new Random().Next(1) == 0;
        }

        public bool TouchLimit(GameTime gameTime)
        {
            return (Position.X > Limits[1] || Position.X < Limits[0]);
        }

        public void ChangeDirection(GameTime gameTime)
        {
            Position.Y += 20f;
            directionFactor = directionFactor * -1;
            Position.X += directionFactor * 1941.25f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        protected override void Move(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds % (countDuration / 2)) < 0.01)
            {
                    Position.X += directionFactor * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
