using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Bonuses
{
    /// <summary>
    /// Base class for bonuses. Bonuses increase player's characteristics.
    /// </summary>
    abstract class Bonus : GameObject
    {
        abstract public void GiveBonus(Player player);
    }
}
