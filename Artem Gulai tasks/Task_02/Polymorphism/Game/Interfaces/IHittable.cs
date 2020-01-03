using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game.Interfaces
{
    /// <summary>
    /// Interface for objects which can hit movables.
    /// </summary>
    internal interface IHittable
    {
        void Hit(IMovable movable);
    }
}
