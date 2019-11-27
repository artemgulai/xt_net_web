using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game
{
    /// <summary>
    /// Class defining a game field.
    /// </summary>
    class Field
    {
        private static Field field = null;

        private Field()
        {
            Width = 30;
            Height = 30;
        }

        public static Field GetField()
        {
            if (field == null)
            {
                field = new Field();
            }
            return field;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
