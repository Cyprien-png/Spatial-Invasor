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
        public int ShootingSpeed;
        // Une créature ne peut posséder plus d'un laser sur l'écran à la fois
        private LaserShot _shot;
        MainGame _maingame;

        public Creature(MainGame game) : base(game)
        {
            Limits = new float[2] { 40f, 750f };
            ShootingSpeed = 250; //400 par défaut
            _maingame = game;
        }

        protected void Shoot() {
            if (IsPressingTrigger())
            {
                // Une créature ne peut tirer que si le précédent tir est terminé
                if (!Game.Components.Contains(_shot))
                {
                    _shot = new LaserShot(_maingame, this);
                    _maingame.addShot(_shot);
                    _maingame.GamePlay.AddComponent(_shot);
                }
            }
        }

        protected abstract void Move(GameTime gametime);

        // Le centre d'un élément peut être décalé graphiquement par rapport au centre de la sprite
        public abstract Vector2 GetCenterPosition();
        
        // La façon de tirer change totalement entre le joueur et les aliens
        public abstract bool IsPressingTrigger();
    }
}
