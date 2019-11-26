using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Bonuses
{
    class Cherry : Bonus
    {
        public override void GiveBonus(Player player) { /* increase mana by 10 */ }
    }
}
