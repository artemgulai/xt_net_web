using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game.Monsters
{
    /// <summary>
    /// Base class for monsters. A monster can move and hit player.
    /// </summary>
    internal abstract class Monster : GameObject, IMovable, IHittable
    {
        public Monster(int speed)
        {
            Speed = speed;
        }
        public int Speed { get; private set; }
        public void Move()
        {
            Console.WriteLine(this.GetType() + $" moves with the speed of {Speed}.");
        }

        public void Hit(IMovable movable)
        {
            if (movable is Player)
            {
                Console.WriteLine(this.GetType() + " hit " + movable.GetType());
                ((Player)movable).Health -= 10;
            }
            else
            {
                Console.WriteLine(this.GetType() + " cannot hit " + movable.GetType());
            }
        }        

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Speed: {Speed}.";
        }
    }
}
