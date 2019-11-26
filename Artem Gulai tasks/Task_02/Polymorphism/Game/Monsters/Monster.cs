using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    abstract class Monster : GameObject, IMovable, IHittable
    {
        public int Speed { get; set; }
        abstract public void Move();
        abstract public void Hit(IMovable movable);
    }
}
