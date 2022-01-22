using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace SpatialInvasor
{
    public class MenuItemsComponent : DrawableGameComponent
    {
        private MainGame _mainGame;

        private List<MenuItem> items;
        public MenuItem selectedItem;
        private Vector2 position;
        private Color _itemColor;
        private Color _selectedItemColor;

        private Texture2D _menuTitle;

        public MenuItemsComponent(MainGame game, Vector2 position) : base(game) {
            this._mainGame = game;
            this.position = position;

            _itemColor = Color.White;
            _selectedItemColor = Color.Red;

            items = new List<MenuItem>();
            selectedItem = null;

        }

        public void AddItem(string text)
        {
            // Choisi la position du nouvel object par rapport à celui avant lui
            Vector2 p = new Vector2(position.X, position.Y + items.Count * 50.0f);
            MenuItem item = new MenuItem(text, p);
            items.Add(item);
            // Choisi le premier objet qui est sélectionné
            if (selectedItem == null) {
                selectedItem = item;
            }
                
        }

        public void SelectNext()
        {
            int index = items.IndexOf(selectedItem);
            if (index < items.Count - 1)
            {
                selectedItem = items[index + 1];
            }
            else {
                selectedItem = items[0];
            }
        }

        public void SelectPrevious()
        {
            int index = items.IndexOf(selectedItem);
            if (index > 0)
            {
                selectedItem = items[index - 1];
            }
            else {
                selectedItem = items[items.Count - 1];
            }  
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _menuTitle = _mainGame.Content.Load<Texture2D>("titleScreen");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // key pressing
            if (_mainGame.NewKey(Keys.Up)) {
                SelectPrevious();
            }
            if (_mainGame.NewKey(Keys.Down)) {
                SelectNext();
            }   
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainGame.SpriteBatch.Begin();
            foreach (MenuItem item in items)
            {
                Color color = _itemColor;
                if (item == selectedItem) {
                    color = _selectedItemColor;
                }
                _mainGame.SpriteBatch.DrawString(_mainGame.Font, item.Text, item.Position, color);
            }
            _mainGame.SpriteBatch.Draw(_menuTitle, new Vector2(240, 20), Color.White);
            _mainGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
