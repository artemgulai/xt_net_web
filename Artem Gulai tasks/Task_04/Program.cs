using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_04.Sorting_Unit;
using Task_04.Exts;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
        }

        static void StartProgram()
        {
            int select;

            do
            {
                Console.Clear();
                Console.WriteLine("Task 04. Delegates and Extensions.");
                Console.WriteLine("Select the number of a task to check.");
                Console.WriteLine("1. Custom Sort.");
                Console.WriteLine("2. Custom Sort Demo.");
                Console.WriteLine("3. Sorting Unit.");
                Console.WriteLine("4. Number Array Sum.");
                Console.WriteLine("5. To Int Or Not To Int.");
                Console.WriteLine("6. I Seek You.");
                Console.WriteLine("0. Exit.");

                if (int.TryParse(Console.ReadLine(),out select))
                {
                    switch (select)
                    {
                        case 1:
                            CustomSortDemo.DoubleIntSortDemo();
                            break;
                        case 2:
                            CustomSortDemo.StringSortDemo();
                            break;
                        case 3:
                            CustomSortDemo.ThreadsSortDemo();
                            break;
                        case 4:
                            MyExtensionsDemo.NumberArrayDemo();
                            break;
                        case 5:
                            MyExtensionsDemo.StringToIntParseDemo();
                            break;
                        case 6:
                            ISeekYouDemo.Demo();
                            break;
                        case 0:
                            Console.WriteLine("Good luck!");
                            Console.WriteLine("Press enter to exit.");
                            break;
                        default:
                            Console.WriteLine("Wrong number. Try again.");
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    select = -1;
                    Console.WriteLine("Invalid input. Try again.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
            }
            while (select != 0);

            Console.ReadLine();
        }
    }
}
