using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExs
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();
                if (!int.TryParse(Console.ReadLine(),out int selectMode))
                {
                    Console.WriteLine("Incorrect input. Try again:");
                    continue;
                }

                switch (selectMode)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Task 7.1. Date existence.");
                            DateExistence.Demo();
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Task 7.2. HTML replacer.");
                            HtmlReplacer.Demo();
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Task 7.3. Email finder.");
                            EmailFinder.Demo();
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Task 7.4. Number validator.");
                            NumberValidator.Demo();
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Task 7.5. Time counter.");
                            TimeCounter.Demo();
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input.");
                            break;
                        }
                }

                if (selectMode == 0)
                {
                    break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Task 7. Regular Expressions.");
            Console.WriteLine("Select the number of task to check.");
            Console.WriteLine("1. Date existence.");
            Console.WriteLine("2. HTML replacer.");
            Console.WriteLine("3. Email finder.");
            Console.WriteLine("4. Number valiadtor.");
            Console.WriteLine("5. Time counter.");
            Console.WriteLine("0. Exit.");
        }
    }
}
