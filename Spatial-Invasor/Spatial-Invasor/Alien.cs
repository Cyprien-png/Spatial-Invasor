using System;
using System.Collections.Generic;
using System.Text;

namespace SpatialInvasor
{
    public abstract class Alien : Creature
    {
        public Alien(MainGame game) : base(game) {}

        public override bool IsPressingTrigger()
        {
            return new Random().Next(100) == 99;
        }
    }
}
