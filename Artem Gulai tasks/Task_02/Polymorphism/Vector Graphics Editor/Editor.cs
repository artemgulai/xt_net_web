using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Polymorphism.Vector_Graphics_Editor.Figure_Factories;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// Main class of "Vector Graphics Editor"
    /// </summary>
    internal class Editor
    {
        public static void Demo()
        {
            List<Figure> figures = new List<Figure>();

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
                        figures.Add(LineFactory.Create());
                        Console.Clear();
                        Console.WriteLine("Line added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 2:
                        figures.Add(CircleFactory.Create());
                        Console.Clear();
                        Console.WriteLine("Circle added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 3:
                        figures.Add(RectangleFactory.Create());
                        Console.Clear();
                        Console.WriteLine("Rectangle added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 4:
                        figures.Add(RoundFactory.Create());
                        Console.Clear();
                        Console.WriteLine("Round added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 5:
                        figures.Add(RingFactory.Create());
                        Console.Clear();
                        Console.WriteLine("Ring added. Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case 6:
                        figures.Add(RingAggregationFactory.Create());
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
