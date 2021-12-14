using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace SpatialInvasor
{
    public class Creature : Entity
    {

        public bool IsShooting;

        public KeyboardState CurrentState;
        public KeyboardState PreviousState;

        public Creature(Game game) : base(game)
        {
        }
        private bool KeypressTest(Keys keys)
        {
            return (CurrentState.IsKeyDown(keys) && (PreviousState.IsKeyUp(keys)));
        }
        // KeyboardState kstate, LaserShot laser, GameTime gametime
        public void Shoot() {
            if (KeypressTest(Keys.Space))
            {
                IsShooting = true;
            }
            else {
                IsShooting = false;
            }
        }
    }
}
