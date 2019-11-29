using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// A Line is defined by two points.
    /// </summary>
    class Line : Figure
    {
        public Line(Point p1, Point p2) : base()
        {
            P1 = new Point(p1);
            P2 = new Point(p2);
        }

        public Point P1 { get; private set; }
        public Point P2 { get; private set; }

        public override void ShowInfo()
        {
            Console.WriteLine("Line." + Environment.NewLine + $"P1 = {P1}, P2 = {P2}, LineColor = {LineColor}.");
        }
    }
}
