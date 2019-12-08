using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_04.Sorting_Unit;
using Task_04.Exts;
using System.Threading;
using Task_01;

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

        static void Iseekyou()
        {
            var rnd = new Random();
            var array = new int[100];

            for (int i = 0; i < 100; i++)
            {
                array[i] = rnd.Next(-500,501);
            }

            IEnumerable<int> positivesDirect = ISeekYou.GetPositiveItemsDirectSearch(array);
            Console.WriteLine("Positives by direct search.");
            foreach (var item in positivesDirect)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();

            IEnumerable<int> positivesDelegate = ISeekYou.GetPositiveItemsByPredicate(array,new Func<int,bool>(x => x > 0));
            Console.WriteLine(Environment.NewLine + "Positives by delegate instance.");
            foreach (var item in positivesDelegate)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();

            IEnumerable<int> positivesAnonymous = ISeekYou.GetPositiveItemsByPredicate(array, delegate(int x) { return x > 0; });
            Console.WriteLine(Environment.NewLine + "Positives by anonymous method delegate.");
            foreach (var item in positivesAnonymous)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();

            IEnumerable<int> positivesLambda = ISeekYou.GetPositiveItemsByPredicate(array, x => x > 0 );
            Console.WriteLine(Environment.NewLine + "Positives by lambda delegate.");
            foreach (var item in positivesLambda)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();

            IEnumerable<int> positivesLinq = ISeekYou.GetPositiveItemsLinq(array);
            Console.WriteLine(Environment.NewLine + "Positives by LINQ.");
            foreach (var item in positivesLinq)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();

        }
    }
}
