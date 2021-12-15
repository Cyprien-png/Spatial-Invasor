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
        private Creature _shooter;
        private bool _isMoving;

        public LaserShot(Game game, Creature shooter) : base(game)
        {
            _shooter = shooter;

            // Défini la position de base du laser, qui est cachée en dehors de l'écran
            _initialPosition = new Vector2(700, 700);
            Position = _initialPosition;
            // Le laser n'a pas de sprite particulière, elle est donc récupérée sur une sprite de mur.
            SheetPositions = new List<Rectangle>() { new Rectangle(121, 7, 2, 8) };

            CreateHitbox();
        }

        public override void Update(GameTime gameTime)
        {
            if (_isMoving)
            {
                // TODO  : Implémenter la collision avec un mur où un ennemi
                if (Position.Y > 0)
                {
                    // Fait se déplacer le laser
                    Position.Y += _shooter.ShootingSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else {
                    _isMoving = false;
                    Position = _initialPosition;
                }
            }
            else {
                // La balle se lance lorsque le joueur tire, il ne peut plus tirer tant la balle est visible
                if (_shooter.IsPressingTrigger())
                {
                    Position = _shooter.GetCenterPosition();
                    _isMoving = true;
                }
            }
            
        }

        public override void Draw(GameTime gametime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.Red);
            SpriteBatch.End();
        }
    }
}
