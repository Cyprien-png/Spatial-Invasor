using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpatialInvasor 
{
    public class MenuComponent : DrawableGameComponent
    {

        private MainGame _mainGame;
        private MenuItemsComponent _menuItems;
        

        public MenuComponent(MainGame maingame, MenuItemsComponent menuItems) : base(maingame)
        {
            this._mainGame = maingame;
            this._menuItems = menuItems;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}

