using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Vector_Graphics_Editor;

namespace Task_02.Polymorphism.Game
{
    abstract class GameObject
    {
        protected GameObject()
        {
            Random random = new Random();
            Position = new Point(random.Next(1,Field.GetField().Width + 1),
                                 random.Next(1,Field.GetField().Height + 1));
        }
        public Point Position { get; private set; }

        public override String ToString()
        {
            return this.GetType().ToString() + Environment.NewLine +
                $"Position: ({Position.X:N0}, {Position.Y:N0}).";
            // TODO: Override ToString() for all game classes
        }
    }
}
