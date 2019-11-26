using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    class Circle : Figure
    {
        protected Double _radius;
        protected Circle(Point center,Double radius) : base()
        {
            Center = new Point(center);
            Radius = radius;
        }
        public Point Center { get; set; }
        public Double Radius 
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

        public static Circle Create(Point center, Double radius) 
        {
            return new Circle(center,radius);
        }
    }
}
