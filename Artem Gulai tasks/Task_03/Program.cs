using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
        }

        static void StartProgram()
        {
            var select = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Task 03. Collections.");
                Console.WriteLine("Select the number of a task to check.");
                Console.WriteLine("1. Lost.");
                Console.WriteLine("2. Word Frequency.");
                Console.WriteLine("3. Dynamic Array.");
                Console.WriteLine("4. Dynamic Array Hardcore.");
                Console.WriteLine("5. Cycled Dynamic Array.");
                Console.WriteLine("0. Exit.");

                if (int.TryParse(Console.ReadLine(),out select))
                {
                    switch (select)
                    {
                        case 1:
                            Lost.LostDemo.Demo();
                            break;
                        case 2:
                            WordFrequency.WordFrequencyDemo.Demo();
                            break;
                        case 3:
                            DynamicArray.DynamicArrayDemo.SimpleDemo();
                            break;
                        case 4:
                            DynamicArray.DynamicArrayDemo.HardcoreDemo();
                            break;
                        case 5:
                            DynamicArray.DynamicArrayDemo.CycledDemo();
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
