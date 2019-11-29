using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// Ring is defined by Round with one more radius.
    /// </summary>
    class Ring : Round
    {
        private double _secondRadius;
        public double SecondRadius
        {
            get => _secondRadius;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Radius should be greater than 0.");
                _secondRadius = value;
            }
        }

        public Ring(Point center,double radius,double secondRadius) : base(center,radius)
        {
            SecondRadius = secondRadius;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Ring." + Environment.NewLine
                + $"Center = {Center}, FirstRadius = {Radius}, SecondRadius = {SecondRadius}, "
                + $"LineColor = {LineColor}, FillColor = {FillColor}.");
        }
    }
}
