using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 01. C# BASICS.");
            int select;

            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task to check.");
                Console.WriteLine("1. Rectangle.");
                Console.WriteLine("2. Triangle.");
                Console.WriteLine("3. Another Triangle.");
                Console.WriteLine("4. Xmas Tree.");
                Console.WriteLine("5. Sum of Numbers.");
                Console.WriteLine("6. Font Adjustment.");
                Console.WriteLine("7. Array Processing.");
                Console.WriteLine("8. No Positive.");
                Console.WriteLine("9. Non-negative Sum.");
                Console.WriteLine("10. 2D Array.");
                Console.WriteLine("11. Average String Length.");
                Console.WriteLine("12. Char Doubler.");
                Console.WriteLine("0. Exit.");

                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 1.1. Rectangle.");
                            CSharpBasics.Rectangle_1_1();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 1.2. Triangle.");
                            CSharpBasics.Triangle_1_2();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 1.3. Another Triangle.");
                            CSharpBasics.AnotherTriangle_1_3();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 1.4. Xmas Tree.");
                            CSharpBasics.XmasTree_1_4();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Task 1.5. Sum of Numbers.");
                            CSharpBasics.SumOfNumbers_1_5();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Task 1.6. Font Adjustment.");
                            CSharpBasics.FontAdjustment_1_6();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Task 1.7. Array Processing.");
                            CSharpLanguage.ArrayProcessing_1_7();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Task 1.8. No Positive.");
                            int[,,] array3D = CSharpLanguage.Generate3DArray();
                            CSharpLanguage.Display3DArray(array3D);
                            Console.WriteLine("Replacing positive numbers by 0...");
                            CSharpLanguage.NoPositive_1_8(array3D);
                            Console.WriteLine("3D array without positive numbers:");
                            CSharpLanguage.Display3DArray(array3D);
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 9:
                            Console.Clear();
                            Console.WriteLine("Task 1.9. Non-negative Sum.");
                            int[] array1D = CSharpLanguage.Generate1DArray();
                            CSharpLanguage.Display1DArray(array1D);
                            Console.WriteLine("Calculating the sum of non-negative elements");
                            Console.WriteLine("The sum equals to " + CSharpLanguage.NonNegativeSum_1_9(array1D));
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 10:
                            Console.Clear();
                            Console.WriteLine("Task 1.10. 2D Array.");
                            int[,] array2D = CSharpLanguage.Generate2DArray();
                            CSharpLanguage.Display2DArray(array2D);
                            Console.WriteLine("The sum of elements at even positions: {0}",
                                CSharpLanguage.Array2D_1_10(array2D));
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 11:
                            Console.Clear();
                            Console.WriteLine("Task 1.11. Average String Length.");
                            CSharpStrings.AverageStringLength_1_11();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            break;
                        case 12:
                            Console.Clear();
                            Console.WriteLine("Task 1.12. Char Doubler.");
                            CSharpStrings.CharDoubler_1_12();
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
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
