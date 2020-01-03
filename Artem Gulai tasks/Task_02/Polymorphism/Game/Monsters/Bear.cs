using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    internal class Bear : Monster
    {
        public Bear(int speed = 10) : base(speed) { }
    }
}
