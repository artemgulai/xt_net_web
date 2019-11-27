using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Obstacles
{
    /// <summary>
    /// Base class for obstacles. An obstacle can "hit" player or monster 
    /// when they smash the obstacle.
    /// </summary>
    abstract class Obstacle : GameObject, IHittable
    {
        public abstract void Hit(IMovable movable);
    }
}