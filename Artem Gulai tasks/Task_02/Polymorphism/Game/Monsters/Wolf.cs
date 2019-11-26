using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    class Wolf : Monster
    {
        public Wolf()
        {
            Speed = 20;
        }

        public override void Move() { /* moves like Wolf */ }

        public override void Hit(IMovable movable) 
        {
            if (movable.GetType() == typeof(Player))
            {
                /* decrease player's health*/
            }
        }
    }
}
