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
        public List<Rectangle> spriteSheetPosition = new List<Rectangle>()
        {
            new Rectangle(152, 1, 21, 21)
        };

        private float[] Limits = { 250, 700 };


        public Player(GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, Vector2 Position, Texture2D Spritesheet) : base(Graphics, SpriteBatch, Position, Spritesheet)
        {
            speed = 250f;
        }

        public override void Initialize()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Left)) {
                _position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            if (kstate.IsKeyDown(Keys.Right)) {
                _position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (_position.X > Limits[1])
            {
                _position.X = Limits[1];
            }

            else if (_position.X < Limits[0]) {
                _position.X = Limits[0];
            }
                

            base.Update(gameTime);
        }

        public override void Draw()
        {
            
            _spriteBatch.Draw(_spriteSheet, _position, spriteSheetPosition[0], Color.White);
            base.Draw();
        }

    }
}
