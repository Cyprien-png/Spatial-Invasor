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
        public List<Rectangle> sheetPositions;
        
        public float speed;
        public Vector2 Position;

        public SpriteBatch spriteBatch;
        public GraphicsDeviceManager Graphics;
        public Texture2D SpriteSheet;

        
        public Entity(GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, Vector2 Position, Texture2D Spritesheet)
        {
            this.Graphics = Graphics;
            spriteBatch = SpriteBatch;
            this.Position = Position;
            SpriteSheet = Spritesheet;
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
