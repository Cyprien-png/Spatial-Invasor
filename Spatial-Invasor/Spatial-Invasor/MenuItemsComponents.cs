using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace SpatialInvasor
{
    class MenuItemsComponents : DrawableGameComponent
    {
        private MainGame _mainGame;

        private List<MenuText> items;
        public MenuText selectedItem;
        private Vector2 position;
        private Color _itemColor;
        private Color _selectedItemColor;

        public SpriteBatch SpriteBatch;

        public MenuItemsComponents(MainGame game, Vector2 position) : base(game) {
            this._mainGame = game;
            this.position = position;
            items = new List<MenuText>();
            selectedItem = null;

            SpriteBatch = new SpriteBatch()
        }

        public void AddItem(string text)
        {
            // setting up the position according to the item's collection index
            Vector2 p = new Vector2(position.X, position.Y + items.Count * 0.5f);
            MenuText item = new MenuText(text, p);
            items.Add(item);
            // selecting the first item
            if (selectedItem == null)
                selectedItem = item;
        }

        public void SelectNext()
        {
            int index = items.IndexOf(selectedItem);
            if (index < items.Count - 1)
                selectedItem = items[index + 1];
            else
                selectedItem = items[0];
        }

        public void SelectPrevious()
        {
            int index = items.IndexOf(selectedItem);
            if (index > 0)
                selectedItem = items[index - 1];
            else
                selectedItem = items[items.Count - 1];
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
            // key pressing
            if (_mainGame.NewKey(Keys.Up)) 
                SelectPrevious();
            if (_mainGame.NewKey(Keys.Down))
                SelectNext();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            foreach (MenuItem item in items)
            {
                //Color color = itemColor;
                if (item == selectedItem)
                    color = selectedItemColor;
                _mainGame.spriteBatch.TextWithShadowScaled(_mainGame.fontBlox, item.text, item.position, color, item.textSize);
            }
            _mainGame.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
