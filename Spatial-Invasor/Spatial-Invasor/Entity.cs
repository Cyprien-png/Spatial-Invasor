using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpatialInvasor
{
    public class Entity : DrawableGameComponent
    {
        // Ces attributs sont partagés par toutes les entitées
        public List<Rectangle> SheetPositions;
        public Rectangle CurrentSheetPosition;
        protected float Speed;
        protected Vector2 Position;
        protected int Life;
        protected Rectangle Hitbox;

        protected Texture2D SpriteSheet;

        public SpriteBatch SpriteBatch;
        
        public Entity(Game game) : base(game)
        {
            
        }

        public void CreateHitbox() {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, SheetPositions[0].Width, SheetPositions[0].Height);
        }

        protected override void LoadContent() {
            SpriteSheet = Game.Content.Load<Texture2D>("main-spritesheet");
            SpriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }
    }

}
