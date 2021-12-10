using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spatial_Invasor
{
    public class Entity
    {
        public List<Rectangle> SheetPositions;

        public float Speed;
        public Vector2 Position;
        public Rectangle Hitbox;

        public SpriteBatch SpriteBatch;
        public GraphicsDeviceManager Graphics;
        public Texture2D SpriteSheet;


        public Entity(GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, Vector2 Position, Texture2D Spritesheet, Rectangle spriteSheetPosition)
        {
            this.Graphics = Graphics;
            this.SpriteBatch = SpriteBatch;
            this.Position = Position;
            SpriteSheet = Spritesheet;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, spriteSheetPosition.Width, spriteSheetPosition.Height);
        }


        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw() { }
    }

}
