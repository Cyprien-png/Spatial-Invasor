using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SpatialInvasor
{
    public class LaserShot : Entity
    {
        private Creature _shooter;

        public LaserShot(Game game, Creature shooter) : base(game)
        {
            _shooter = shooter;
            Position = _shooter.GetCenterPosition();

            // Le laser n'a pas de sprite particulière, elle est donc récupérée sur une sprite de mur.
            SheetPositions = new List<Rectangle>() { new Rectangle(121, 7, 2, 8) };
        }

        private bool isInBounds() {
            return (Position.Y >= 0 && Position.Y <= 450);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO  : Implémenter la collision avec un mur où un ennemi
            if (isInBounds())
            {
                // Fait se déplacer le laser
                Position.Y += _shooter.ShootingSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                // TODO : Implémenter un ajout de score si un alien est touché
                Kill();
                
            }
        }

        public override void Draw(GameTime gametime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(SpriteSheet, Position, SheetPositions[0], Color.Red);
            SpriteBatch.End();
        }

        public Creature Shooter
        {
           get{ return _shooter; }
        }
    }
}
