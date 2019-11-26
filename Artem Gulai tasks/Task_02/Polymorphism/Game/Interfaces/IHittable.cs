using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Interfaces
{
    interface IHittable
    {
        void Hit(IMovable movable);
    }
}
