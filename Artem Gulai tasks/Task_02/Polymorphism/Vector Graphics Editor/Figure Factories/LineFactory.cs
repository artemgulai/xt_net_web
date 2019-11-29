using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor.Figure_Factories
{
    class LineFactory : FigureFactory
    {
        public static Line Create()
        {
            while (true)
            {
                Line line = null;
                Console.WriteLine("Enter xP1:");
                double xP1;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xP1))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yP1:");
                double yP1;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yP1))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter xP2:");
                double xP2;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xP2))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yP2:");
                double yP2;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yP2))
                    Console.WriteLine("Wrong input. Try again.");

                try
                {
                    line = new Line(new Point(xP1,yP1),new Point(xP2,yP2));
                    Console.WriteLine("Line created. Press enter to select color.");
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
                        line.LineColor = (Color)colorNumber;
                        Console.WriteLine(Environment.NewLine + "LineColor set to " + (Color)colorNumber);
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Wrong number. Try again.");
                }

                return line;
            }
        }
    }
}
