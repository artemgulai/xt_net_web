using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Bonuses
{
    /// <summary>
    /// Cherry increases player's mana.
    /// </summary>
    class Cherry : Bonus
    {
        public override void GiveBonus(Player player)
        {
            Console.WriteLine(this.GetType() + " increases mana by 10");
            player.Mana += 10;
        }
    }
}
