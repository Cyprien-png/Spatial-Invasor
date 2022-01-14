using System;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    public abstract class Alien : Creature
    {
        protected float countDuration = 2f;
        protected bool Direction;

        public Alien(MainGame game) : base(game) {
            Speed = 250f;
        }

        public override bool IsPressingTrigger()
        {
            return new Random().Next(100000) == 1;
        }

        protected void TouchLimit(GameTime gameTime)
        {
            if (Position.X > Limits[1])
            {
                Position.Y += 20f;
                Direction = false;
            }
            else if (Position.X < Limits[0])
            {
                Position.Y += 20f;
                Direction = true;
            }
        }

        protected override void Move(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds % (countDuration / 2)) < 0.01)
            {
                if (Direction)
                {
                    Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    TouchLimit(gameTime);
                }
                else
                {
                    Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    TouchLimit(gameTime);
                }
            }
        }

        public void killAlien()
        {
            Game.Components.Remove(this);
        }
    }
}
