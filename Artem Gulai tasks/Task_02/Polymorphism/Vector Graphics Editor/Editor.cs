using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    class Editor
    {
        public static void Demo()
        {
            List<Figure> figures = new List<Figure>();
            figures.Add(Line.Create(new Point(0,0), new Point(4, -1)));
            figures.Add(Circle.Create(new Point(0,0),5.6));
            figures.Add(Rectangle.Create(new Point(0,0),new Point(4,4)));
            figures.Add(Round.Create(new Point(0,0),2));
            figures.Add(Ring.Create(new Point(0,0),2,4));

            foreach(Figure figure in figures)
            {
                figure.ShowInfo();
            }
            Console.ReadLine();
        }
    }
}
