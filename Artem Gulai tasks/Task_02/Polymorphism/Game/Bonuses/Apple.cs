using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Bonuses
{
    /// <summary>
    /// Apple increase player's health.
    /// </summary>
    class Apple : Bonus
    {
        public override void GiveBonus(Player player) 
        {
            Console.WriteLine(this.GetType() + " increases health by 10");
            player.Health += 10;
        }
    }
}
