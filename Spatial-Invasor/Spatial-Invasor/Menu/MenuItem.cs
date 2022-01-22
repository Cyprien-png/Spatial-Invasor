using Microsoft.Xna.Framework;

namespace SpatialInvasor
{
    public class MenuItem
    {
        public string Text;
        public float size;
        public Vector2 Position;
        public MenuItem(string text, Vector2 position)
        {
            Text = text;
            Position = position;
            size = 0.6f;
        }
    }
}
