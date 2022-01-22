using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpatialInvasor
{
    public class Player : Creature
    {

        private KeyboardState _currentState;
        private KeyboardState _previousState;

        public Player(MainGame game) : base(game)
        {
            Speed = 250f;

            // inverse le signe de la valeure pour que le laser se déplace vers le haut
            ShootingSpeed = ~ShootingSpeed;

            Position = new Vector2(350, 400);
            

            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(152, 1, 21, 21)
            };

            _currentState = Keyboard.GetState();
        }

        public override Vector2 GetCenterPosition()
        {
            return Position + new Vector2(10, 0);
        }

        // Cette méthode est constamment appelée par l'update du laser. Elle pourait être implémentée différemment
        public override bool IsPressingTrigger()
        {
            _previousState = _currentState;
            _currentState = Keyboard.GetState();

            return (_currentState.IsKeyDown(Keys.Space) && (_previousState.IsKeyUp(Keys.Space)));
        }

        protected override void Move(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Left))
            {
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (Position.X > Limits[1])
            {
                Position.X = Limits[1];
            }
            else if (Position.X < Limits[0])
            {
                Position.X = Limits[0];
            }
            ShootingSpeed = -400;
        }

        public override void Update(GameTime gameTime)
        {

            Move(gameTime);
            Shoot();

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.White);
            SpriteBatch.End();
        }

        public void kill()
        {
            Game.Components.Remove(this);
        }

    }
}
