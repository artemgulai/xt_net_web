using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    class Line : Figure
    {
        private Line(Point p1, Point p2) : base()
        {
            P1 = new Point(p1);
            P2 = new Point(p2);
        }

        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public override void ShowInfo()
        {
            Console.WriteLine("Line." + Environment.NewLine + $"P1 = {P1}, P2 = {P2}, LineColor = {LineColor}.");
        }

        public static Line Create(Point p1,Point p2)
        {
            return new Line(p1,p2);
        }
    }

    class LineDemo
    {
        Line line = Line.Create(new Point(0,0),new Point(1,1));
    }
}
