using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// Round is defined by its base circle and Fill color.
    /// </summary>
    class Round : Circle
    {
        public Color FillColor {get; set;}

        public Round(Point center,double radius) : base(center,radius)
        {
            FillColor = Color.Black;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Round." + Environment.NewLine + $"Center = {Center}, Radius = {Radius}, "
                + $"LineColor = {LineColor}, FillColor = {FillColor}.");
        }
    }
}
