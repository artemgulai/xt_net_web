using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    class Ring : Round
    {
        private Double _secondRadius;
        public Double SecondRadius
        {
            get => _secondRadius;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Radius should be greater than 0.");
                _secondRadius = value;
            }
        }

        protected Ring(Point center,Double radius,Double secondRadius) : base(center,radius)
        {
            SecondRadius = secondRadius;
        }

        public static Ring Create(Point center,Double radius,Double secondRadius)
        {
            return new Ring(center,radius,secondRadius);
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Ring." + Environment.NewLine
                + $"Center = {Center}, FirstRadius = {Radius}, SecondRadius = {SecondRadius}, "
                + $"LineColor = {LineColor}, FillColor = {FillColor}.");
        }
    }
}
