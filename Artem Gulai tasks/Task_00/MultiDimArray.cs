using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_00
{
    class MultiDimArray
    {
        // создание массива
        public static Array ArrayCreation()
        {
            Console.WriteLine("Введите число N (размерность массива)");
            int arrayDim = int.Parse(Console.ReadLine());

            int[] arrayLength = new int[arrayDim];
            for (int i = 0; i < arrayDim; i++)
            {
                Console.WriteLine($"Введите число элементов по {i + 1}-й размерности.");
                arrayLength[i] = int.Parse(Console.ReadLine());
            }

            var array = System.Array.CreateInstance(typeof(int),arrayLength);
            Random random = new Random(42);
            int[] indices = new int[arrayDim];

            do
            {
                array.SetValue(random.Next(0,100),indices);
            } while (!Indices.getNextIndices(arrayLength,indices,false));

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
            } while (!Indices.getNextIndices(arrayLength,nextIndices,false));
            for (int i = 0; i < array.Rank; i++)
            {
                Console.Write("}");
            }
        }

        public static void ArraySorting(Array array)
        {
            // создаем одномерный массив из элементов многомерного, который будем сортировать
            int[] arrayToSort = new int[array.Length];
            int indexOfArrayToSort = 0;
            foreach (int i in array)
            {
                arrayToSort[indexOfArrayToSort++] = i;
            }

            // сортировка этого одномерного массива
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

            // заполнение исходного многомерного массива элементами по порядку
            int[] arrayLength = new int[array.Rank];
            int[] indices = new int[array.Rank];
            for (int i = 0; i < array.Rank; i++)
            {
                arrayLength[i] = array.GetLength(i);
                indices[i] = 0;
            }

            foreach (int i in arrayToSort)
            {
                array.SetValue(i,indices);
                Indices.getNextIndices(arrayLength,indices,false);
            }
        }
    }
}
