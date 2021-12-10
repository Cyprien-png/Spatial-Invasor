using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spatial_Invasor
{
    public class Wall : Entity
    {
        private Rectangle _spriteSheetPosition;
        private int _life;



        public Wall(GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, Vector2 Position, Texture2D Spritesheet, Rectangle spriteSheetPosition) : base(Graphics, SpriteBatch, Position, Spritesheet, spriteSheetPosition)
        {
            _life = 4;
            _spriteSheetPosition = spriteSheetPosition;

        }

        public override void Initialize()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
    
           
             var kstate = Keyboard.GetState();


            if (kstate.IsKeyDown(Keys.Up)) {            // a remplacer par qqc comme ça :
                                                        // if (Hitbox.Intersects(laser)){

                _life -= 1;
 
                switch (_life)
                {
                    case 3 :
                        _spriteSheetPosition = new Rectangle(1, 52, 50, 21);
                    break;
                    case 2 :
                        _spriteSheetPosition = new Rectangle(53, 52, 50, 21);
                    break;
                     case 1 :
                        _spriteSheetPosition = new Rectangle(106, 52, 50, 21);
                    break;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw()
        {       
            if(_life > 0)
            SpriteBatch.Draw(SpriteSheet, Position, _spriteSheetPosition, Color.White);

            base.Draw();
        }

    }
}
