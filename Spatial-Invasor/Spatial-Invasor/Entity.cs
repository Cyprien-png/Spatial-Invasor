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
        public Vector2 _position;

        public SpriteBatch _spriteBatch;
        public GraphicsDeviceManager _graphics;
        public Texture2D _spriteSheet;

        
        public Entity(GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, Vector2 Position, Texture2D Spritesheet)
        {
            _graphics = Graphics;
            _spriteBatch = SpriteBatch;
            _position = Position;
            _spriteSheet = Spritesheet;
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
