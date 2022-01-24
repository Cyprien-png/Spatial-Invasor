using System;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    public abstract class Alien : Creature
    {
        protected float CountDuration = 2f;
        protected float DirectionFactor = 1f;
        protected int ScoreValue;

        public Alien(MainGame game) : base(game)
        {
            Speed = 1200f;
        }

        public override bool IsPressingTrigger()
        {
            return new Random().Next(300) == 0;
        }

        public bool TouchLimit(GameTime gameTime)
        {
            return (Position.X > Limits[1] || Position.X < Limits[0]);
        }

        public void ChangeDirection(GameTime gameTime)
        {
            Position.Y += 20f;
            DirectionFactor = DirectionFactor * -1;
            Position.X += DirectionFactor * 2500 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        protected override void Move(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds % (CountDuration / 2)) < 0.01)
            {
                Position.X += DirectionFactor * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public int GetScoreValue
        {
            get { return ScoreValue; }
        }
    }
}
