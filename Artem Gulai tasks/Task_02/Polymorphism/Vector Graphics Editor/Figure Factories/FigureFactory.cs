using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor.Figure_Factories
{
    internal abstract class FigureFactory
    {
        protected static void ShowColors()
        {
            for (int i = 1; i <= 16; i++)
            {
                Console.WriteLine($"{i}: {(Color)i}");
            }
        }
    }
}
