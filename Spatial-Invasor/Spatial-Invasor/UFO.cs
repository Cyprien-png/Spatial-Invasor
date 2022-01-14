﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    class UFO : Alien
    {
        public UFO(MainGame game) : base(game)
        {
            Position = new Vector2(277, 70);
            Speed = 150f;
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(100, 23, 48, 21)
            };
        }

        public override Vector2 GetCenterPosition()
        {
            return Position + new Vector2(24, 5);
        }        

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();                        
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.Red);                        
            SpriteBatch.End();
        }

        protected override void TouchLimit(GameTime gameTime)
        {
            if (Position.X > Limits[1])
            {
                Game.Components.Remove(this);
            }
            
        }

        protected override void Move(GameTime gameTime)
        {            
            Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            TouchLimit(gameTime);                        
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }
    }
}
