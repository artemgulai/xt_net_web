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
        /// Generates an array, find the minimum, maximum, sorts the array
        /// and prints the result (minimum, maximum, sorted array)
        /// </summary>
        public static void ArrayProcessing_1_7()
        {
            int length = 100;
            double[] array = new double[length];
            Random rand = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = rand.NextDouble()*400 - 200;
            }

            // sorting
            for (int i = 0; i < array.Length - 1; i++)
            {
                double min = double.MaxValue;
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
                    double temp = array[i];
                    array[i] = array[minInd];
                    array[minInd] = temp;
                }
            }

            // printing results
            Console.WriteLine("Min value: " + $"{array[0],0:N2}.");
            Console.WriteLine("Min value: " + $"{array[array.Length-1],0:N2}.");
            Console.Write("Sorted array: \n{");
            for (var i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i],0:N2}, ");
            }
            Console.WriteLine($"{array[array.Length-1],0:N2}" + "}");
            Console.ReadLine();
        }

        /// <summary>
        /// Replaces all positive elements in 3D array by 0
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
