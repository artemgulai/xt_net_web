using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor.Figure_Factories
{
    internal class CircleFactory : FigureFactory
    {
        public static Circle Create()
        {
            while (true)
            {
                Circle circle = null;
                Console.WriteLine("Enter xCenter:");
                double xCenter;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yCenter:");
                double yCenter;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter radius:");
                double radius;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out radius))
                    Console.WriteLine("Wrong input. Try again.");

                try
                {
                    circle = new Circle(new Point(xCenter,yCenter),radius);
                    Console.WriteLine("Round created. Press enter to select color.");
                    Console.ReadLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                Console.Clear();
                ShowColors();
                Console.WriteLine(Environment.NewLine + "Select line Color.");
                int colorNumber;
                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(),out colorNumber))
                    {
                        Console.WriteLine("Wrong input. Try again.");
                    }
                    if (colorNumber > 0 && colorNumber <= 16)
                    {
                        circle.LineColor = (Color)colorNumber;
                        Console.WriteLine(Environment.NewLine + "LineColor set to " + (Color)colorNumber);
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Wrong number. Try again.");
                }

                return circle;
            }
        }
    }
}
