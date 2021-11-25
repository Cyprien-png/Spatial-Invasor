using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spatial_Invasor
{
    public class Creature
    {
        // Position de la créature sur l'écran
        private Vector2 _position;
        // Une liste des sprites utilisés par la créature récupérés dans la spritesheet.
        private List<Rectangle> _sheetPositions = new List<Rectangle>();

        // Constructeur pour définir la position initial ainsi liste des sprites de la créature
        public Creature(Vector2 position, List<Rectangle> sheetPositions)
        {
            _position = position;
            _sheetPositions.AddRange(sheetPositions);
        }

        // 
        public Vector2 Position
        {
            get { return _position; }
            //set { _position = value; }
        }

        public List<Rectangle> SheetPosition
        {
            get { return _sheetPositions; }
        }



    }
}
