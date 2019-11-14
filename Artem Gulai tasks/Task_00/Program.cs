using System;
using System.Text;
using System.Threading;

namespace Task_00
{
    class Program
    {
        static string Sequence(int N)
        {
            StringBuilder numberSequence = new StringBuilder();
            for (int i = 1; i < N; i++)
            {
                numberSequence.Append(i + ", ");
            }
            numberSequence.Append(N);
            return numberSequence.ToString();
        }

        static bool Simple(int N)
        {
            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0) return false;
            }
            return true;
        }

        static void Square(int N)
        {
            if (N % 2 == 0 || N <= 0)
            {
                Console.WriteLine("Incorrect input number.");
                return;
            }
            // формирование полной строки
            string fullString = new string('*',N);
            // формирование строки с отсутствующей центральной звездочкой
            string gapString = string.Concat(new string('*',N / 2),' ',new string('*',N / 2));
            // вывод строк
            for (int i = 0; i < N; i++)
            {
                if (i == N / 2)
                {
                    Console.WriteLine(gapString);
                }
                Console.WriteLine(fullString);
            }
        }

        static int[][] ArrayCreation()
        {
            Console.WriteLine("Введите число размерностей массива");
            int arrayDim = int.Parse(Console.ReadLine());
            int[][] array = new int[arrayDim][];
            Random random = new Random(42);

            for (int i = 0; i < arrayDim; i++)
            {
                Console.WriteLine($"Введите размерность {i+1}-го массива.");
                int dim = int.Parse(Console.ReadLine());
                array[i] = new int[dim];
                for (int j = 0; j < dim; j++)
                {
                    array[i][j] = random.Next(0,100);
                }
            }
            return array;
        }

        static void ArraySorting(int[][] array)
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

            // сортировка массива
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
            // запись отсортированных элементов обратно в зубчатый массив
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
            for(int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        

        static void Main(String[] args)
        {
            //int[][] array = ArrayCreation();
            Array array = MultiDimArray.ArrayCreation();
            MultiDimArray.ArrayDisplay(array);
            MultiDimArray.ArraySorting(array);
            Console.WriteLine();
            MultiDimArray.ArrayDisplay(array);
            Console.ReadKey();
        }
    }
}
