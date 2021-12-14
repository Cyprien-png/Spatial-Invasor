using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpatialInvasor
{
    public class Wall : Entity
    {
        
        public Wall(Game game, Vector2 Coordinate) : base(game)
        {
            Life = 4;
            Position = Coordinate;
            SheetPositions = new List<Rectangle>()
            {
                new Rectangle(99, 1, 50, 21), // 4 pv
                new Rectangle(1, 52, 50, 21), // 3 pv
                new Rectangle(53, 52, 50, 21), // 2 pv
                new Rectangle(106, 52, 50, 21) // 1 pv
            };
            CurrentSheetPosition = SheetPositions[0];
            CreateHitbox();

        }

        public override void Update(GameTime gameTime)
        {
             var kstate = Keyboard.GetState();
          
            // à remplacer par qqc comme ça : if (Hitbox.Intersects(laser)){
            if (kstate.IsKeyDown(Keys.Up)) {            
                Life -= 1;
 
                switch (Life)
                {
                    case 4:
                        CurrentSheetPosition = SheetPositions[0];
                        break;
                    case 3 :
                        CurrentSheetPosition = SheetPositions[1];
                        break;
                    case 2 :
                        CurrentSheetPosition = SheetPositions[2];
                        break;
                     case 1 :
                        CurrentSheetPosition = SheetPositions[3];
                        break;
                }
            }
        }

        public override void Draw(GameTime gametime)
        {       
            if(Life > 0)
            {
                SpriteBatch.Begin();
                SpriteBatch.Draw(SpriteSheet, Position, CurrentSheetPosition, Color.White);
                SpriteBatch.End();
            }
        }

    }
}
