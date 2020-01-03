using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Obstacles
{
    internal class Pit : Obstacle
    {
        /// <summary>
        /// Pit kills player and monsters.
        /// </summary>
        /// <param name="movable"></param>
        public override void Hit(IMovable movable) 
        {
            Console.WriteLine(this.GetType() + " kills " + movable.GetType());
        }
    }
}
