using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class CSharpLanguage
    {
        /// <summary>
        /// Generates 1D array of integers for ArrayProcessing1_7 and NonNegativeSum1_9.
        /// </summary>
        /// <returns>1D array of integers</returns>
        public static int[] Generate1DArray()
        {
            int length = -1;

            do
            {
                Console.WriteLine("Enter the length of an array.");
                if (int.TryParse(Console.ReadLine(),out length))
                {
                    if (length > 0) break;
                    Console.WriteLine("Length cannot be less than 1. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (true);

            int[] array = new int[length];

            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(-500,500);
            }

            return array;
        }

        /// <summary>
        /// Sorts 1D array of integers.
        /// </summary>
        /// <param name="array">1D array of integers</param>
        public static void Sort1DArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = int.MaxValue;
                int minInd = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minInd = j;
                    }
                }
                if (minInd != i)
                {
                    int temp = array[i];
                    array[i] = array[minInd];
                    array[minInd] = temp;
                }
            }
        }

        /// <summary>
        /// Displays 1D array.
        /// </summary>
        /// <param name="array">1D array</param>
        public static void Display1DArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ",array[i]);
            }
        }

        /// <summary>
        /// Generates 2D array of integers for NonNegativeSum1_9.
        /// </summary>
        /// <returns>2D array of integers</returns>
        public static int[,] Generate2DArray()
        {
            int dim1 = -1, dim2 = -1;
            do
            {
                Console.WriteLine("Enter the length of the first dimension.");
                if (int.TryParse(Console.ReadLine(),out dim1))
                {
                    if (dim1 > 0) break;
                    Console.WriteLine("Length cannot be less than 1. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Enter the length of the second dimension.");
                if (int.TryParse(Console.ReadLine(),out dim2))
                {
                    if (dim2 > 0) break;
                    Console.WriteLine("Length cannot be less than 1. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (true);

            int[,] array = new int[dim1,dim2];

            Random rand = new Random();
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    array[i,j] = rand.Next(-500,500);
                }
            }

            return array;
        }

        /// <summary>
        /// Displays 2D array.
        /// </summary>
        /// <param name="array">2D array</param>
        public static void Display2DArray<T>(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0}\t",array[i,j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Generates 3D array of integers for NoPositive_1_8.
        /// </summary>
        /// <returns>3D array of integers</returns>
        public static int[,,] Generate3DArray()
        {
            int dim1 = -1, dim2 = -1, dim3 = -1;
            do
            {
                Console.WriteLine("Enter the length of the first dimension.");
                if (int.TryParse(Console.ReadLine(),out dim1))
                {
                    if (dim1 > 0) break;
                    Console.WriteLine("Length cannot be less than 1. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Enter the length of the second dimension.");
                if (int.TryParse(Console.ReadLine(),out dim2))
                {
                    if (dim2 > 0) break;
                    Console.WriteLine("Length cannot be less than 1. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Enter the length of the first dimension.");
                if (int.TryParse(Console.ReadLine(),out dim3))
                {
                    if (dim3 > 0) break;
                    Console.WriteLine("Length cannot be less than 1. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (true);

            int[,,] array = new int[dim1,dim2,dim3];

            Random rand = new Random();
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    for (int k = 0; k < dim3; k++)
                    {
                        array[i,j,k] = rand.Next(-500,500);
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Displays 3D array.
        /// </summary>
        /// <param name="array">3D array</param>
        public static void Display3DArray<T>(T[,,] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{");
                    for (int k = 0; k < array.GetLength(2) - 1; k++)
                    {
                        Console.Write("{0} ",array[i,j,k]);
                    }
                    Console.Write("{0}",array[i,j,array.GetLength(2) - 1]);
                    Console.Write("}");
                }
                Console.Write("}");
            }
            Console.WriteLine("}");
        }

        /// <summary>
        /// Generates an array, find the minimum, maximum, sorts the array
        /// and prints the result (minimum, maximum, sorted array).
        /// </summary>
        public static void ArrayProcessing_1_7()
        {
            int[] array = Generate1DArray();
            Console.WriteLine("Unsorted Array:");
            Display1DArray(array);
            Console.WriteLine();

            Sort1DArray(array);

            Console.WriteLine("Min value: " + $"{array[0]}.");
            Console.WriteLine("Min value: " + $"{array[array.Length-1]}.");
            Console.WriteLine("Sorted array:");
            Display1DArray(array);
            Console.ReadLine();
        }

        /// <summary>
        /// Replaces all positive elements in 3D array by 0.
        /// </summary>
        public static void NoPositive_1_8(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(0); k++)
                    {
                        if (array[i,j,k] > 0)
                        array[i,j,k] = 0;
                    }
                }
            }
        } 

        /// <summary>
        /// Returns the sum of non-negative elements of 1-dimensional array.
        /// </summary>
        /// <param name="array">1-dimensional array of integers.</param>
        /// <returns>The sum of non-negative elements.</returns>
        public static int NonNegativeSum_1_9(int[] array)
        {
            int sum = 0;
            foreach(int a in array)
            {
                if (a > 0)
                {
                    sum += a;
                }
            }
            return sum;
        }

        /// <summary>
        /// Returns the sum of elements of 2-dimensional array at even positions.
        /// </summary>
        /// <param name="array">2-dimensional array of integers.</param>
        /// <returns>The sum of elements at even positions.</returns>
        public static int Array2D_1_10(int[,] array)
        {
            int sumEvenPos = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sumEvenPos += array[i,j];
                    }
                }
            }
            return sumEvenPos;
        }
    }
}
