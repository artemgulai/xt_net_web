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
            //Lost.LostLinkedList.Lost(10,4);
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
                        //case 6:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.6. Ring.");
                        //    RingDemo.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
                        //case 7:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.7. Vector Graphics Editor.");
                        //    Polymorphism.Vector_Graphics_Editor.Editor.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
                        //case 8:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.8. Game.");
                        //    Polymorphism.Game.GameDemo.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
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
