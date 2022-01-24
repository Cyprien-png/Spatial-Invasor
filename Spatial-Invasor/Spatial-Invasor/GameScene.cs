using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SpatialInvasor
{
    public class GameScene
    {
        private List<GameComponent> _components;
        private MainGame _mainGame;

        public GameScene(MainGame maingame, params GameComponent[] components) {
            this._mainGame = maingame;
            this._components = new List<GameComponent>();
            foreach (GameComponent component in components)
            {
                AddComponent(component);
            }
        }

        public void AddComponent(GameComponent component)
        {
            _components.Add(component);
            if (!_mainGame.Components.Contains(component)) {
                _mainGame.Components.Add(component);
            }
        }

        public GameComponent[] ReturnComponents()
        {
            return _components.ToArray();
        }

    }
}
