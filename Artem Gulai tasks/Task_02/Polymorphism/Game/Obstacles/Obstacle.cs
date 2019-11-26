using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Obstacles
{
    abstract class Obstacle : GameObject, IHittable
    {
        abstract public void Hit(IMovable movable); //Hits player and kills enemy
    }
}