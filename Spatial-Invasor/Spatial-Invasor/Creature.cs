using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace SpatialInvasor
{
    public class Creature : Entity
    {
        protected List<LaserShot> LaserList;

        private KeyboardState currentState;
        private KeyboardState previousState;

        public Creature(Game game) : base(game)
        {
            LaserList = new List<LaserShot>()  {
                // Le laser du joueur
                new LaserShot(game, this), 
                // Les lasers aliens
                new LaserShot(game, this), 
                new LaserShot(game, this),
                new LaserShot(game, this)
            };

        }
        private bool KeypressTest(Keys keys)
        {
            return (currentState.IsKeyDown(keys) && (previousState.IsKeyUp(keys)));
        }

        public void Shoot(KeyboardState kstate, LaserShot laser, GameTime gametime) {
            if (KeypressTest(Keys.Space)) {
                laser.Update(gametime);
            }
        }
    }
}
