using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class MainMenu
    {
        public static void Menu()
        {
            var select = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Task 03. Collections.");
                Console.WriteLine("Select the number of a task to check.");
                Console.WriteLine("1. Lost.");
                //Console.WriteLine("2. Triangle.");
                //Console.WriteLine("3. User.");
                //Console.WriteLine("4. My String.");
                //Console.WriteLine("5. Employee.");
                //Console.WriteLine("6. Ring.");
                //Console.WriteLine("7. Vector Graphics Editor.");
                //Console.WriteLine("8. Game.");
                Console.WriteLine("0. Exit.");

                if (int.TryParse(Console.ReadLine(),out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 3.1. Lost.");
                            Lost.LostDemo() ;
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        //case 2:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.2. Triangle.");
                        //    TriangleDemo.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
                        //case 3:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.3. User.");
                        //    UserDemo.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
                        //case 4:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.4. My String.");
                        //    MyStringDemo.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
                        //case 5:
                        //    Console.Clear();
                        //    Console.WriteLine("Task 2.5. Employee.");
                        //    EmployeeDemo.Demo();
                        //    Console.WriteLine("Press enter to continue.");
                        //    Console.ReadLine();
                        //    break;
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
