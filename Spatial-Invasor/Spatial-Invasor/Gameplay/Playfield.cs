using Microsoft.Xna.Framework;

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

