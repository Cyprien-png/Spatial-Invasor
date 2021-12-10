using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spatial_Invasor
{
    public class Entity : DrawableGameComponent
    {
        public List<Rectangle> SheetPositions;

        protected float Speed;
        protected Vector2 Position;
        protected Rectangle Hitbox;

        public SpriteBatch SpriteBatch;
        public GraphicsDeviceManager Graphics;
        protected Texture2D SpriteSheet;


        public Entity(Game game) : base(game)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, SheetPositions[0].Width, SheetPositions[0].Height);
        }

        protected override void LoadContent() {
            SpriteSheet = Game.Content.Load<Texture2D>("main-spritesheet");
            SpriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }
    }

}
