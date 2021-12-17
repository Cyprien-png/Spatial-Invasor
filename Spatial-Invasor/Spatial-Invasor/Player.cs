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

        public Player(Game game) : base(game)
        {
            Speed = 250f;

            // La valeure négative signifie que le laser se déplace vers le haut
            // environ -900 est une bonne vitesse
            ShootingSpeed = -900; 

            Position = new Vector2(250, 400);
            Limits = new float[2] { 100f, 700f };

            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(152, 1, 21, 21)
            };

            _currentState = Keyboard.GetState();

            CreateHitbox();
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
        }

        public override void Update(GameTime gameTime)
        {

            Move(gameTime);
            Shoot();

            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.White);
            SpriteBatch.End();
        }

    }
}
