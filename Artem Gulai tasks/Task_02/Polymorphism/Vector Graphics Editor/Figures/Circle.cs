using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// A Circle is defined by a center point and a radius.
    /// </summary>
    internal class Circle : Figure
    {
        protected double _radius;
        public Circle(Point center,double radius) : base()
        {
            Center = new Point(center);
            Radius = radius;
        }
        public Point Center { get; set; }
        public double Radius 
        {
            get => _radius; 
            set
            {
                if (value == 0)
                    throw new ArgumentException("Radius should be greater than 0.");
                _radius = Math.Abs(value);
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Circle." + Environment.NewLine + $"Center = {Center}, Radius = {Radius}, LineColor = {LineColor}.");
        }
    }
}
