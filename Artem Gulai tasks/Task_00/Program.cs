using System;
using System.Text;
using System.Threading;

namespace Task_00
{
    internal sealed class Program
    {
        private static string Sequence(int N)
        {
            StringBuilder numberSequence = new StringBuilder();
            for (int i = 1; i < N; i++)
            {
                numberSequence.Append(i + ", ");
            }
            numberSequence.Append(N);
            return numberSequence.ToString();
        }

        private static bool Simple(int N)
        {
            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0) return false;
            }
            return true;
        }

        private static void Square(int N)
        {
            if (N % 2 == 0 || N <= 0)
            {
                Console.WriteLine("Incorrect input number.");
                return;
            }
            // full string
            string fullString = new string('*',N);
            // string with missing central char
            string gapString = string.Concat(new string('*',N / 2),' ',new string('*',N / 2));
            // вывод строк
            for (int i = 0; i < N; i++)
            {
                if (i == N / 2)
                {
                    Console.WriteLine(gapString);
                    continue;
                }
                Console.WriteLine(fullString);
            }
        }

        private static int[][] ArrayCreation()
        {
            Console.WriteLine("Enter the number of array's dimensions");
            int arrayDim;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out arrayDim))
                {
                    Console.WriteLine("Wrong input.");
                }
                if (arrayDim < 1)
                {
                    Console.WriteLine("The number should be positive.");
                    continue;
                }
                break;
            }
            int[][] array = new int[arrayDim][];
            Random random = new Random();

            for (int i = 0; i < arrayDim; i++)
            {
                Console.WriteLine($"Enter dimension of the {i+1} array.");
                int dim;
                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(), out dim))
                    {
                        Console.WriteLine("Wrong input.");
                    }
                    if (dim < 1)
                    {
                        Console.WriteLine("The number should be positive.");
                        continue;
                    }
                    break;
                }
                array[i] = new int[dim];
                for (int j = 0; j < dim; j++)
                {
                    array[i][j] = random.Next(0,101);
                }
            }
            return array;
        }

        private static void ArraySorting(int[][] array)
        {
            int numberOfElements = 0;
            foreach (int[] arr in array)
            {
                numberOfElements += arr.Length;
            }

            int indexOfArrayToSort = 0;
            int[] arrayToSort = new int[numberOfElements];
            foreach (int[] arr in array)
            {
                foreach (int a in arr)
                {
                    arrayToSort[indexOfArrayToSort++] = a;
                }
            }

            // sorting 
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                int min = int.MaxValue;
                int minInd = i;
                for (int j = i; j < arrayToSort.Length; j++)
                {
                    if (arrayToSort[j] < min)
                    {
                        min = arrayToSort[j];
                        minInd = j;
                    }
                }
                if (minInd != i)
                {
                    int temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[minInd];
                    arrayToSort[minInd] = temp;
                }
            }

            indexOfArrayToSort = 0;
            // fulfill the jagged array with sorted items
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = arrayToSort[indexOfArrayToSort++];
                }
            }
        }

        static void ArrayDisplay(int[][] array)
        {
            Console.Write("{");
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write("{");
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]},");
                }
                Console.Write("},");
            }
            Console.Write("}");
        }

        static void PressEnterWait()
        {
            Console.WriteLine("Press enter.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int select = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter the number of task to check:");
                Console.WriteLine("Task 1. Sequence.");
                Console.WriteLine("Task 2. Simple.");
                Console.WriteLine("Task 3. Square.");
                Console.WriteLine("Task 4. Array.");
                Console.WriteLine("Enter 0 to exit.");

                try
                {
                    select = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    Console.WriteLine("Something went wrong. Try again.");
                    PressEnterWait();
                    continue;
                }
                switch (select)
                {
                    case 1:
                        Console.WriteLine("\nTask 1. Sequence.");
                        Console.WriteLine("Enter the positive number:");
                        int number;
                        while (!int.TryParse(Console.ReadLine(), out number))
                        {
                            Console.WriteLine("Wrong input.");
                        }

                        if (number <= 0)
                        {
                            Console.WriteLine("Wrong number.\n");
                        }
                        else
                        {
                            Console.WriteLine("Result sequence: " + Sequence(number));
                        }
                        PressEnterWait();
                        break;
                    case 2:
                        Console.WriteLine("\nTask 2. Simple.");
                        Console.WriteLine("Enter positive integer number:");
                        int isSimple;
                        while (!int.TryParse(Console.ReadLine(),out isSimple))
                        {
                            Console.WriteLine("Wrong input");
                        }

                        if (isSimple <= 0)
                        {
                            Console.WriteLine("Wrong number has been entered.");
                            PressEnterWait();
                            break;
                        }
                        
                        if (Simple(isSimple))
                        {
                            Console.WriteLine($"The number {isSimple} is prime.");
                        } else
                        {
                            Console.WriteLine($"The number {isSimple} is not prime.");
                        }
                        PressEnterWait();
                        break;
                    case 3:
                        Console.WriteLine("\nTask 3. Square.");
                        Console.WriteLine("Enter positive odd number:");
                        int oddNumber;
                        while (!int.TryParse(Console.ReadLine(), out oddNumber))
                        {
                            Console.WriteLine("Wrong input.");
                        }

                        if (oddNumber % 2 != 1)
                        {
                            Console.WriteLine("Wrong number has been entered.");
                        } else
                        {
                            Square(oddNumber);
                        }
                        PressEnterWait();
                        break;
                    case 4:
                        Console.WriteLine("\nTask 4. Array.");
                        Console.WriteLine('\n' + new string('*',20));
                        Console.WriteLine("Array creation");
                        int[][] array = ArrayCreation();
                        Console.WriteLine("Created array:");
                        ArrayDisplay(array);
                        Console.WriteLine();
                        PressEnterWait();
                        Console.WriteLine(new string('*',20));
                        Console.WriteLine("Press enter to sort the array.");
                        Console.ReadLine();
                        ArraySorting(array);
                        Console.WriteLine("Sorted array:");
                        ArrayDisplay(array);
                        Console.WriteLine();
                        PressEnterWait();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Wrong number has been entered.");
                        Console.WriteLine("Press enter.");
                        Console.ReadLine();
                        break;
                }
            } while (select != 0);
        }
    }
}
