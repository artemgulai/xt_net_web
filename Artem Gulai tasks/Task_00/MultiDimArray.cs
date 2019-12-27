using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_00
{
    class MultiDimArray
    {
        // Array creation
        public static Array ArrayCreation()
        {
            Console.WriteLine("Enter N (dimension of array)");
            int arrayDim;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(),out arrayDim))
                {
                    Console.WriteLine("Wrong number. Try again.");
                }
                if (arrayDim < 1)
                {
                    Console.WriteLine("Dimension of array should be positive.");
                    continue;
                }
                break;
            }

            int[] arrayLength = new int[arrayDim];
            for (int i = 0; i < arrayDim; i++)
            {
                Console.WriteLine($"Enter the number of items in the {i + 1} dimension.");
                int arrLength;
                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(),out arrLength))
                    {
                        Console.WriteLine("Wrong number");
                    }
                    if (arrLength < 1)
                    {
                        Console.WriteLine("Number of items should be positive.");
                        continue;
                    }
                    break;
                }
                arrayLength[i] = int.Parse(Console.ReadLine());
            }

            var array = Array.CreateInstance(typeof(int),arrayLength);
            Random random = new Random();
            int[] indices = new int[arrayDim];

            do
            {
                array.SetValue(random.Next(0,100),indices);
            } while (!Indices.getNextIndices(arrayLength,indices));

            return array;
        }

        public static void ArrayDisplay(Array array)
        {
            int[] nextIndices = new int[array.Rank];
            int[] arrayLength = new int[array.Rank];
            int[] previousIndices = new int[array.Rank];

            for (int i = 0; i < array.Rank; i++)
            {
                arrayLength[i] = array.GetLength(i);
                nextIndices[i] = 0;
                previousIndices[i] = 0;
            }
            for (int i = 0; i < array.Rank; i++)
            {
                Console.Write("{");
            }
            do
            {
                int numberOfBrace = 0; ;
                for (int i = 0; i < array.Rank; i++)
                {
                    if (nextIndices[i] == 0 && nextIndices[i] != previousIndices[i])
                        numberOfBrace++;
                }
                for (int i = 0; i < numberOfBrace; i++)
                {
                    Console.Write("}");
                }
                for (int i = 0; i < numberOfBrace; i++)
                {
                    Console.Write("{");
                }
                Console.Write($"{array.GetValue(nextIndices)},");
                for (int i = 0; i < array.Rank; i++)
                {
                    previousIndices[i] = nextIndices[i];
                }
            } while (!Indices.getNextIndices(arrayLength,nextIndices));
            for (int i = 0; i < array.Rank; i++)
            {
                Console.Write("}");
            }
        }

        public static void ArraySorting(Array array)
        {
            // create 1d array containing items from multi-d array to be sorted
            int[] arrayToSort = new int[array.Length];
            int indexOfArrayToSort = 0;
            foreach (int i in array)
            {
                arrayToSort[indexOfArrayToSort++] = i;
            }

            // sort 1d array
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

            // fulfill multidimensional array with sorted items
            int[] arrayLength = new int[array.Rank];
            int[] indices = new int[array.Rank];
            for (int i = 0; i < array.Rank; i++)
            {
                arrayLength[i] = array.GetLength(i);
                indices[i] = 0;
            }

            foreach (var item in arrayToSort)
            {
                array.SetValue(item,indices);
                Indices.getNextIndices(arrayLength,indices);
            }
        }
    }
}
