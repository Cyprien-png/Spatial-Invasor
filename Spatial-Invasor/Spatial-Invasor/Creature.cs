using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace SpatialInvasor
{
    public abstract class Creature : Entity
    {
        // Défini les coordonnées limites d'axe X atteignable par une créature
        protected float[] Limits;
        // Défini la vitesse et la direction (nbr positif pour haut / l'inverse pour bas) d'un laser tiré par la créature
        public float ShootingSpeed;
        // Le centre d'un élément peut être décalé graphiquement par rapport au centre de la sprite
        public abstract Vector2 GetCenterPosition();
 

        public Creature(Game game) : base(game) {}
        // La façon de tirer change totalement entre le joueur et les aliens
        public abstract bool IsPressingTrigger();
    }
}
