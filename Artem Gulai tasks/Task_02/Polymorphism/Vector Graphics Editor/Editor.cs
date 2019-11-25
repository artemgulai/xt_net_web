using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    class Editor
    {
        private static void ShowColors()
        {
            for (int i = 1; i <= 16; i++)
            {
                Console.WriteLine($"{i}: {(Color)i}");
            }
        }

        private static Ring AddRing()
        {
            while (true)
            {
                Ring ring = null;
                Console.WriteLine("Enter xCenter:");
                Double xCenter;
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yCenter:");
                Double yCenter;
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter the first radius:");
                Double firstRadius;
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out firstRadius))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter the second radius:");
                Double secondRadius;
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out secondRadius))
                    Console.WriteLine("Wrong input. Try again.");

                try
                {
                    ring = Ring.Create(new Point(xCenter,yCenter),firstRadius,secondRadius);
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
                    while (!Int32.TryParse(Console.ReadLine(),out colorNumber))
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
                    while (!Int32.TryParse(Console.ReadLine(),out colorNumber))
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

        public static void Demo()
        {
            List<Figure> figures = new List<Figure>();
            //figures.Add(Line.Create(new Point(0,0), new Point(4, -1)));
            //figures.Add(Circle.Create(new Point(0,0),5.6));
            //figures.Add(Rectangle.Create(new Point(0,0),new Point(4,4)));
            //figures.Add(Round.Create(new Point(0,0),2));
            //figures.Add(Ring.Create(new Point(0,0),2,4));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Console graphical editor.");
                Console.WriteLine("Select option.");
                Console.WriteLine("1. Add Line.");
                Console.WriteLine("2. Add Circle.");
                Console.WriteLine("3. Add Rectangle.");
                Console.WriteLine("4. Add Round.");
                Console.WriteLine("5. Add Ring.");
                Console.WriteLine("6. Show figures.");
                Console.WriteLine("0. Exit.");

                int select;
                while (!Int32.TryParse(Console.ReadLine(), out select))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                switch (select)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        figures.Add(AddRing());
                        Console.Clear();
                        Console.WriteLine("Ring added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        foreach (Figure figure in figures)
                        {
                            figure.ShowInfo();
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Good luck!");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Wrong option. Try again.");
                        break;
                }
            }
        }
    }
}
