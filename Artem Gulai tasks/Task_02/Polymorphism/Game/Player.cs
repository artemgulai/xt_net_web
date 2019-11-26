using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game
{
    class Player : GameObject, IMovable
    {
        public Int32 Mana { get; set; }
        public Int32 Speed { get; set; }
        public Int32 Armor { get; set; }

        public void Move() { /* move according to user's command */ }

        public void HitEnemy() { /* decrease mana by 10, kills enemy */ }
    }
}
