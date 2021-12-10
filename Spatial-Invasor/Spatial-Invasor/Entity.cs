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
        public Rectangle Hitbox;

        public SpriteBatch SpriteBatch;
        public GraphicsDeviceManager Graphics;
        protected Texture2D SpriteSheet;


        public Entity(Game game) : base(game)
        {
            /*
            this.Graphics = Graphics;
            this.SpriteBatch = SpriteBatch;
            this.Position = Position;
            SpriteSheet = Spritesheet;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, spriteSheetPosition.Width, spriteSheetPosition.Height);
            */
        }

        protected override void LoadContent() {
            SpriteSheet = Game.Content.Load<Texture2D>("main-spritesheet");
        }
    }

}
