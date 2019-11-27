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
                    continue;
                }
                Console.WriteLine(fullString);
            }
        }

        static int[][] ArrayCreation()
        {
            Console.WriteLine("Введите число размерностей массива");
            int arrayDim = int.Parse(Console.ReadLine());
            int[][] array = new int[arrayDim][];
            Random random = new Random();

            for (int i = 0; i < arrayDim; i++)
            {
                Console.WriteLine($"Введите размерность {i+1}-го массива.");
                int dim = int.Parse(Console.ReadLine());
                array[i] = new int[dim];
                for (int j = 0; j < dim; j++)
                {
                    array[i][j] = random.Next(0,101);
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
            Console.WriteLine("Нажмите enter.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int select = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Выберите номер задания для проверки:");
                Console.WriteLine("Задание 1. Последовательность чисел.");
                Console.WriteLine("Задание 2. Проверка простоты числа.");
                Console.WriteLine("Задание 3. Квадрат с пустым центром.");
                Console.WriteLine("Задание 4. Создание, заполнение и сортировка массива.");
                Console.WriteLine("Нажмите 0 для выхода.");

                try
                {
                    select = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    Console.WriteLine("Что-то пошло не так. Попробуйте снова.");
                    PressEnterWait();
                    continue;
                }
                switch (select)
                {
                    case 1:
                        Console.WriteLine("\nЗадание 1. Последовательность чисел.");
                        Console.WriteLine("Введите целое положительное число:");
                        int number = int.Parse(Console.ReadLine());
                        if (number <= 0)
                        {
                            Console.WriteLine("Введено неверное число.\n");
                        }
                        else
                        {
                            Console.WriteLine("Строка-результат: " + Sequence(number));
                        }
                        PressEnterWait();
                        break;
                    case 2:
                        Console.WriteLine("\nЗадание 2. Проверка простоты числа.");
                        Console.WriteLine("Введите целое положительное число:");
                        int isSimple = int.Parse(Console.ReadLine());
                        if (isSimple <= 0)
                        {
                            Console.WriteLine("Введено неверное число.");
                            PressEnterWait();
                            break;
                        }
                        
                        if (Simple(isSimple))
                        {
                            Console.WriteLine($"Число {isSimple} является простым.");
                        } else
                        {
                            Console.WriteLine($"Число {isSimple} не является простым.");
                        }
                        PressEnterWait();
                        break;
                    case 3:
                        Console.WriteLine("\nЗадание 3. Квадрат с пустым центром.");
                        Console.WriteLine("Введите целое нечетное положительное число:");
                        int oddNumber = int.Parse(Console.ReadLine());
                        if (oddNumber % 2 != 1)
                        {
                            Console.WriteLine("Введено неверное число.");
                        } else
                        {
                            Square(oddNumber);
                        }
                        PressEnterWait();
                        break;
                    case 4:
                        Console.WriteLine("\nЗадание 4. Создание, заполнение и сортировка массива.");
                        Console.WriteLine('\n' + new string('*',20));
                        Console.WriteLine("Создание массива");
                        int[][] array = ArrayCreation();
                        Console.WriteLine("Созданный массив:");
                        ArrayDisplay(array);
                        Console.WriteLine();
                        PressEnterWait();
                        Console.WriteLine(new string('*',20));
                        Console.WriteLine("Нажмите enter для сортировки массива.");
                        Console.ReadLine();
                        ArraySorting(array);
                        Console.WriteLine("Отсортированный массив:");
                        ArrayDisplay(array);
                        Console.WriteLine();
                        PressEnterWait();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Введено неверное число.");
                        Console.WriteLine("Нажмите enter.");
                        Console.ReadLine();
                        break;
                }
            } while (select != 0);
        }
    }
}
