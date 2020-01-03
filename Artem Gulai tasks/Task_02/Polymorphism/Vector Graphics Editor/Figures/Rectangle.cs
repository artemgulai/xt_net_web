using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// A rectangle is defined by two points (Left top and right bottom points).
    /// </summary>
    internal class Rectangle : Figure
    {
        public Color FillColor { set; get; }
        public Point TopLeft { set; get; }
        public Point BottomRight { set; get; }

        public Rectangle(Point topLeft, Point bottomRight) : base()
        {
            TopLeft = new Point(topLeft);
            BottomRight = new Point(bottomRight);
            FillColor = Color.Black;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Rectangle." + Environment.NewLine + $"TopLeft = {TopLeft}, BottomRight = {BottomRight}, LineColor = {LineColor}, " +
                $"FillColor = {FillColor}.");
        }
    }
}
