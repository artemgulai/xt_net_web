using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor.Figure_Factories
{
    class RingAggregationFactory : FigureFactory
    {
        public static RingAggregation Create()
        {
            while (true)
            {
                RingAggregation ring = null;
                Console.WriteLine("Enter xCenter:");
                double xCenter;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yCenter:");
                double yCenter;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter inner radius:");
                double innerRadius;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out innerRadius))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter outer radius:");
                double outerRadius;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out outerRadius))
                    Console.WriteLine("Wrong input. Try again.");

                try
                {
                    ring = new RingAggregation(new Point(xCenter,yCenter),innerRadius,outerRadius);
                    Console.WriteLine("Ring created. Press enter to select colors.");
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
                        ring.LineColor = (Color)colorNumber;
                        Console.WriteLine(Environment.NewLine + "LineColor set to " + (Color)colorNumber);
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Wrong number. Try again.");
                }

                Console.Clear();
                ShowColors();
                Console.WriteLine(Environment.NewLine + "Select fill Color.");
                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(),out colorNumber))
                    {
                        Console.WriteLine("Wrong input. Try again.");
                    }
                    if (colorNumber > 0 && colorNumber <= 16)
                    {
                        ring.FillColor = (Color)colorNumber;
                        Console.WriteLine(Environment.NewLine + "FillColor set to " + (Color)colorNumber);
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Wrong number. Try again.");
                }

                return ring;
            }
        }
    }
}
