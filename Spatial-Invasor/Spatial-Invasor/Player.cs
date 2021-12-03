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
        public List<Rectangle> SpriteSheetPosition = new List<Rectangle>()
        {
            new Rectangle(152, 1, 21, 21)
        };

        public float[] Limits = { 250, 700 };


        public Player(GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, Vector2 Position, Texture2D Spritesheet) : base(Graphics, SpriteBatch, Position, Spritesheet)
        {
            Speed = 250f;
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

            if (Position.X > Limits[1])
            {
                Position.X = Limits[1];
            }

            else if (Position.X < Limits[0]) {
                Position.X = Limits[0];
            }
                

            base.Update(gameTime);
        }

        public override void Draw()
        {            
            spriteBatch.Draw(SpriteSheet, Position, SpriteSheetPosition[0], Color.White);
            base.Draw();
        }

    }
}
