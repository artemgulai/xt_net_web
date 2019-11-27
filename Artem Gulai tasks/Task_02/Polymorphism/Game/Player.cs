using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Game.Bonuses;
using Task_02.Polymorphism.Game.Interfaces;

namespace Task_02.Polymorphism.Game
{
    /// <summary>
    /// Player class.
    /// </summary>
    class Player : GameObject, IMovable, IHittable
    {
        public Int32 Mana { get; set; }
        public Int32 Speed { get; set; }
        public Int32 Health { get; set; }

        public Player(Int32 health, Int32 mana, Int32 speed) : base()
        {
            Health = health;
            Mana = mana;
            Speed = speed;
        }

        public void Move() 
        {
            Console.WriteLine(this.GetType() + $" moves according to user's commands with the speed of {Speed}.");
        }
       
        /// <summary>
        /// Hitting costs 5 mana points.
        /// </summary>
        /// <param name="movable"></param>
        public void Hit(IMovable movable) 
        { 
            if (movable is Player)
            {
                Console.WriteLine(this.GetType() + " cannot hit " + movable.GetType());
            }
            else
            {
                Console.WriteLine(this.GetType() + " hit " + movable.GetType());
                Mana -= 5;
            }
        }

        public void CollectBonus(Bonus bonus)
        {
            Console.WriteLine("Collect " + bonus.GetType());
            bonus.GiveBonus(this);
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                $"Health: {Health}; Mana: {Mana}; Speed: {Speed}";
        }
    }
}
