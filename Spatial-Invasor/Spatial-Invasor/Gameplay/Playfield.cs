using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpatialInvasor
{
    class Playfield : DrawableGameComponent
    {
        public Playfield(Game game) : base(game)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
        }
    }
}

