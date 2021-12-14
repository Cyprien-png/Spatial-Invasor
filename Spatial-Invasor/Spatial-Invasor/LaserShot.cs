using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace SpatialInvasor
{
    public class LaserShot : Entity
    {
        
        private Vector2 _initialPosition;
        private Creature Shooter;

        public LaserShot(Game game, Creature shooter) : base(game)
        {
            Speed = 1;

            this.Shooter = shooter;
            Shooter.CurrentState = Keyboard.GetState();
            Position = Shooter.GetPosition;

            SheetPositions = new List<Rectangle>() { new Rectangle(1, 1, 50, 50) };

            CreateHitbox();
        }

        public override void Update(GameTime gameTime)
        {
            Shooter.PreviousState = Shooter.CurrentState;
            Shooter.CurrentState = Keyboard.GetState();

            //if (Shooter.IsShooting) {
                

                //Position = Shooter.GetPosition;

            Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Lorsque le laser quitte l'écran ou touche une cible, 
                // il est redirigé dans sa zone chachée
                // TODO : Ajouter collision laser à la condition ------------------------------------
                /*
                if (Position.Y < 0)
                {
                    Position = new Vector2(700, 700);
                }
                */
            //}
            
            
        }

        public override void Draw(GameTime gametime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.White);
            SpriteBatch.End();
        }
    }
}
