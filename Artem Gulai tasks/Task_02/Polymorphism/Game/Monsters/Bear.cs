using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    class Bear : Monster
    {
        public Bear()
        {
            Speed = 10;
        }

        public override void Move() { /* moves like bear */ }

        public override void Hit(IMovable movable) 
        {
            if (movable.GetType() == typeof(Player))
            {
                /* decrease player's health*/
            }
        }
    }
}
