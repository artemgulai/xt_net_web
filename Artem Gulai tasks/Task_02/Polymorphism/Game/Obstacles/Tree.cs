using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Obstacles
{
    class Tree : Obstacle
    {
        public override void Hit(IMovable movable) { /* decrease player's health by 10 and kills enemy */ }
    }
}
