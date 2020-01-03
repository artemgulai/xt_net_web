using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor.Figure_Factories
{
    internal class RectangleFactory : FigureFactory
    {
        public static Rectangle Create()
        {
            while (true)
            {
                Rectangle rectangle = null;
                Console.WriteLine("Enter xTopLeft:");
                double xTopLeft;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xTopLeft))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yTopLeft:");
                double yTopLeft;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yTopLeft))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter xBottomRight:");
                double xBottomRight;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xBottomRight))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yBottomRight:");
                double yBottomRight;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yBottomRight))
                    Console.WriteLine("Wrong input. Try again.");

                try
                {
                    rectangle = new Rectangle(new Point(xTopLeft,yTopLeft),new Point(xBottomRight,yBottomRight));
                    Console.WriteLine("Rectangle created. Press enter to select colors.");
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
                        rectangle.LineColor = (Color)colorNumber;
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
                        rectangle.FillColor = (Color)colorNumber;
                        Console.WriteLine(Environment.NewLine + "FillColor set to " + (Color)colorNumber);
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Wrong number. Try again.");
                }

                return rectangle;
            }
        }
    }
}
