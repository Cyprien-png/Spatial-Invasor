using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace SpatialInvasor
{
    public class LaserShot : Entity
    {
        private Texture2D laserTexture;
        private Vector2 _initialPosition;
        private Entity shooter;

        private bool _isRemoved;

        

        private float _timer;

        // constructeur pour la classe LaserShot, l'argument le plus important est laserSpeed car il définira la vitesse du laser    
        public LaserShot(Game game, Creature shooter) : base(game)
        {
            Speed = 300;

            this.shooter = shooter;

            SheetPositions = new List<Rectangle>() { new Rectangle(152, 1, 5, 1) };

            CreateHitbox();
        }

        public new void Update(GameTime gameTime)
        {
            Position = shooter.GetPosition;
            Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Lorsque le laser quitte l'écran ou touche une cible, 
            // il est redirigé dans sa zone chachée
            // TODO : Ajouter collision laser à la condition ------------------------------------
            if (Position.Y < 0) {
                Position = new Vector2(700, 700);
            }
            
        }

        public new void Draw(GameTime gametime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(laserTexture, Position, CurrentSheetPosition, Color.White);
            SpriteBatch.End();
        }
    }
}
