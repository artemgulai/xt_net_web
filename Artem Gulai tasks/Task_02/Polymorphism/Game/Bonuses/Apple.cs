using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Bonuses
{
    class Apple : Bonus
    {
        public override void GiveBonus(Player player) { /* increase health by 10 */ }
    }
}
