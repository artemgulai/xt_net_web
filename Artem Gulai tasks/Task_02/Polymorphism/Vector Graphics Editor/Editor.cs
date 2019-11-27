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
                double xCenter;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out xCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yCenter:");
                double yCenter;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out yCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter the first radius:");
                double firstRadius;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out firstRadius))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter the second radius:");
                double secondRadius;
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out secondRadius))
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

        private static RingAggregation AddRingAggregation()
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
                    ring = RingAggregation.Create(new Point(xCenter,yCenter),innerRadius, outerRadius);
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

        private static Round AddRound()
        {
            while (true)
            {
                Round round = null;
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
                    round = Round.Create(new Point(xCenter,yCenter),radius);
                    Console.WriteLine("Round created. Press enter to select colors.");
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
                        round.LineColor = (Color)colorNumber;
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
                        round.FillColor = (Color)colorNumber;
                        Console.WriteLine(Environment.NewLine + "FillColor set to " + (Color)colorNumber);
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Wrong number. Try again.");
                }

                return round;
            }
        }

        private static Line AddLine()
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
                    line = Line.Create(new Point(xP1,yP1),new Point(xP2,yP2));
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


        private static Rectangle AddRectangle()
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
                    rectangle = Rectangle.Create(new Point(xTopLeft,yTopLeft),new Point(xBottomRight,yBottomRight));
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

        private static Circle AddCircle()
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
                    circle = Circle.Create(new Point(xCenter,yCenter),radius);
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
                Console.WriteLine("6. Add Ring (aggregation).");
                Console.WriteLine("7. Show figures.");
                Console.WriteLine("0. Exit.");

                int select;
                while (!int.TryParse(Console.ReadLine(), out select))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                switch (select)
                {
                    case 1:
                        figures.Add(AddLine());
                        Console.Clear();
                        Console.WriteLine("Line added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 2:
                        figures.Add(AddCircle());
                        Console.Clear();
                        Console.WriteLine("Circle added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 3:
                        figures.Add(AddRectangle());
                        Console.Clear();
                        Console.WriteLine("Rectangle added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 4:
                        figures.Add(AddRound());
                        Console.Clear();
                        Console.WriteLine("Round added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 5:
                        figures.Add(AddRing());
                        Console.Clear();
                        Console.WriteLine("Ring added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 6:
                        figures.Add(AddRingAggregation());
                        Console.Clear();
                        Console.WriteLine("Ring (aggregation) added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 7:
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
