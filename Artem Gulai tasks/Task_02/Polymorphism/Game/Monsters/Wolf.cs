using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    internal class Wolf : Monster
    {
        public Wolf(int speed = 20 ) : base(speed) { }
    }
}
