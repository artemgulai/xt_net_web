﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Obstacles
{
    class Stone : Obstacle
    {
        /// <summary>
        /// Stone hits player and kills monsters.
        /// </summary>
        /// <param name="movable"></param>
        public override void Hit(IMovable movable)
        {
            if (movable is Player)
            {
                Console.WriteLine(this.GetType() + " hits " + movable.GetType() + " by 5 health points.");
            }
            else
            {
                Console.WriteLine(this.GetType() + " kills " + movable.GetType());
            }
        }
    }
}
