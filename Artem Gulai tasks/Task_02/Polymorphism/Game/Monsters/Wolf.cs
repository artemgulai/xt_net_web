﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    class Wolf : Monster
    {
        public Wolf(Int32 speed = 20 ) : base(speed) { }
    }
}
