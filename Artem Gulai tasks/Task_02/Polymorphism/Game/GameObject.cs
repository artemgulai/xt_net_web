using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Vector_Graphics_Editor;

namespace Task_02.Polymorphism.Game
{
    /// <summary>
    /// Base class for all objects in the Game (player, monsters, obstacles and bonuses).
    /// </summary>
    abstract class GameObject
    {
        /// <summary>
        /// Generates GameObject at random position.
        /// </summary>
        protected GameObject()
        {
            Random random = new Random();
            Position = new Point(random.Next(1,Field.GetField().Width + 1),
                                 random.Next(1,Field.GetField().Height + 1));
        }
        public Point Position { get; private set; }

        public override string ToString()
        {
            return this.GetType().ToString() + Environment.NewLine +
                $"Position: ({Position.X:N0}, {Position.Y:N0}).";
        }
    }
}
