using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    class Round : Circle
    {
        public Color FillColor {get; set;}

        protected Round(Point center, Double radius) : base(center,radius)
        {
            FillColor = Color.Black;
        }

        public new static Round Create(Point center, Double radius)
        {
            return new Round(center,radius);
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Round. Center = {Center}, Radius = {Radius}, "
                + $"LineColor = {LineColor}, FillColor = {FillColor}.");
        }
    }
}
