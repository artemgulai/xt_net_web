using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Bonuses
{
    /// <summary>
    /// Banana increases player's speed.
    /// </summary>
    class Banana : Bonus
    {
        public override void GiveBonus(Player player)
        {
            Console.WriteLine(this.GetType() + " increases speed by 1");
            player.Speed += 1;
        }
    }
}
