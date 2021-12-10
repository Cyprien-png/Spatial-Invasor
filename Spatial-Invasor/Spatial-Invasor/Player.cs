using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spatial_Invasor
{
    public class Player : Entity
    {
        //private Rectangle _spriteSheetPosition = new Rectangle(152, 1, 21, 21);
        private float[] _limits = { 250, 700 };

        public Player(Game game) : base(game)
        {
            Speed = 250f;
            Position = new Vector2(250, 400);
            SheetPositions.Add(new Rectangle(152, 1, 21, 21));
        }

        public override void Initialize()
        {

        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();


            if (kstate.IsKeyDown(Keys.Left)) {
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right)) {
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (Position.X > _limits[1])
            {
                Position.X = _limits[1];
            }
            else if (Position.X < _limits[0]) {
                Position.X = _limits[0];
            }


            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.White);
            SpriteBatch.End();

        }

    }
}
