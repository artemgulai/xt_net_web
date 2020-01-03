using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    internal class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(Point value)
        {
            X = value.X;
            Y = value.Y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return $"({X:N3}, {Y:N3})";
        }
    }
}
