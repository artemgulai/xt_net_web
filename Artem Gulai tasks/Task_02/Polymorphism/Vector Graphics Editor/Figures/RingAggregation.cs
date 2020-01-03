using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// Ring (with a little help of aggregation.)
    /// </summary>
    internal class RingAggregation : Figure
    {
        private Circle _innerCircle;
        private Circle _outerCircle;
        public Point Center { get; set; }

        public RingAggregation(Point center,double innerRadius,double outerRadius)
        {
            Center = center;
            if (innerRadius >= outerRadius)
                throw new ArgumentException("Inner radius should be less than outer one.");
            try
            {
                _innerCircle = new Circle(Center,innerRadius);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Inner radius error.");
                throw ex;
            }
            try
            {
                _outerCircle = new Circle(Center,outerRadius);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "Outer radius error.");
                throw ex;

            }
            FillColor = Color.Black;
        }

        public double InnerRadius 
        {
            get => _innerCircle.Radius;
            set
            {
                if (value >= _outerCircle.Radius)
                {
                    throw new ArgumentException("Inner radius should be less than outer one.");
                }
                _innerCircle.Radius = value;
            }
        }

        public double OuterRadius
        {
            get => _outerCircle.Radius;
            set
            {
                if (value <= _innerCircle.Radius)
                {
                    throw new ArgumentException("Outer radius should be greater than inner one.");
                }
                _outerCircle.Radius = value;
            }
        }

        public Color FillColor { get; set; }

        public new Color LineColor 
        {
            get => _outerCircle.LineColor;
            set
            {
                _innerCircle.LineColor = value;
                _outerCircle.LineColor = value;
            }
        }

        public double Length
        {
            get => 2 * Math.PI * (InnerRadius + OuterRadius);
        }

        public double Area
        {
            get => Math.PI * (Math.Pow(OuterRadius,2) - Math.Pow(InnerRadius,2));
        }

        public double Width
        {
            get => OuterRadius - InnerRadius;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Ring (aggregate two circles)." + Environment.NewLine
                + $"Center = {Center}, OuterRadius = {OuterRadius}, InnerRadius = {InnerRadius}, "
                + $"LineColor = {LineColor}, FillColor = {FillColor}.");
        }
    }
}
