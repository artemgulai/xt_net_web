using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_01;

namespace Task_04.Sorting_Unit
{
    class CustomSort
    {
        /// <summary>
        /// Sorts generic array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array to sort</param>
        /// <param name="comparator">Comparator providing a method for
        /// comparing two items.</param>
        public void SortArray<T>(T[] array, Func<T,T,bool> comparator)
        {
            if (comparator == null)
            {
                throw new ArgumentException("Comparing method is null");
            }

            if (array == null)
            {
                throw new ArgumentException("Array is null");
            }

            T[] tempArray = new T[array.Length];
            // new merge sort
            int left = 0;
            int right = array.Length - 1;
            SplitAndSort(array,tempArray,comparator,left,right);

            for (int i = 0; i < array.Length; i++)
                array[i] = tempArray[i];
        }

        #region Merge sort methods
        private void SplitAndSort<T>(T[] array,T[] tempArray,Func<T,T,bool> comparator, int left, int right)
        {
            // array containing one element is sorted
            if (right - left == 0)
            {
                return;
            }

            int mid = (left + right) / 2;

            // sort left half
            SplitAndSort(array,tempArray,comparator,left,mid);
            // sort right half
            SplitAndSort(array,tempArray,comparator,mid + 1,right);
            // merge two halfs
            Merge(array,tempArray,comparator,left,mid,right);
        }

        private void Merge<T>(T[] a,T[] tempA, Func<T,T,bool> comparator,int left,int mid,int right)
        {
            int leftPointer = left;
            int rightPointer = mid + 1;
            
            int tempPointer = left;

            while (leftPointer <= mid && rightPointer <= right)
            {
                if (comparator(a[leftPointer], a[rightPointer]))
                    tempA[tempPointer++] = a[leftPointer++];
                else
                    tempA[tempPointer++] = a[rightPointer++];
            }

            while (leftPointer <= mid)
                tempA[tempPointer++] = a[leftPointer++];
            while (rightPointer <= right)
                tempA[tempPointer++] = a[rightPointer++];

            //for (int i = 0; i < tempPointer; i++)
            //    a[left + i] = temp[i];
        }
        #endregion

        #region Selection sort
        /// <summary>
        /// Selection sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array to sort</param>
        /// <param name="comparator">Comparator providing a method for
        /// comparing two items.</param>
        private void SelectionSort<T>(T[] array, Func<T,T,bool> comparator)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int changeIndex = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (comparator(array[j],array[changeIndex]))
                    {
                        changeIndex = j;
                    }
                }
                if (changeIndex != i)
                {
                    Swap<T>(ref array[i],ref array[changeIndex]);
                }
            }
        }

        /// <summary>
        /// Additional method for swapping to items in an array.
        /// </summary>
        /// <typeparam name="T">Type of elements in the array.</typeparam>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        private void Swap<T>(ref T var1,ref T var2)
        {
            T temp = var1;
            var1 = var2;
            var2 = temp;
        }
        #endregion

        /// <summary>
        /// This field is for identification different threads, in which 
        /// SortArray is being executed.
        /// </summary>
        private static int _threadID = 0;

        /// <summary>
        /// Creates new thread and sorts an array in this thread. 
        /// </summary>
        /// <typeparam name="T">Type of elements in array to sort.</typeparam>
        /// <param name="array">Array to sort.</param>
        /// <param name="comparator">Comparator providing a method for
        /// comparing two items.</param>
        public void SortInAdditionalThread<T>(T[] array,Func<T,T,bool> comparator)
        {
            int threadId = ++_threadID;
            new Thread(() => {
                SortArray(array,comparator);
                OnSortIsFinished?.Invoke($"Sorting is finished in Thread with ID {threadId}.");
            }).Start(); 
        }

        /// <summary>
        /// Event invoked at the end of sorting. 
        /// </summary>
        public event Action<string> OnSortIsFinished = delegate { };
    }

    class CustomSortDemo
    {
        public static void DoubleIntSortDemo()
        {
            var sortUnit = new CustomSort();
            var rand = new Random();
            var arrayLength = 20;
            Console.Clear();
            Console.WriteLine("Task 4.1. Custom Sort.");

            Console.WriteLine("You can sort array of ints and doubles, in ascending and descending order using one method.");
            Thread.Sleep(1000);
            Console.WriteLine("Let's start with the following array of doubles." + Environment.NewLine);
            var arrayDouble = new double[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arrayDouble[i] = rand.NextDouble() * 2 * arrayLength - arrayLength;
            }
            CSharpLanguage.Display1DArray<double>(arrayDouble);

            Console.WriteLine();
            Thread.Sleep(2000);

            Console.WriteLine(Environment.NewLine + "It can be sorted in ascending order by calling the following method:");
            Console.WriteLine("SortArray <double> ( arrayDouble, (a,b) => a < b );");
            Console.WriteLine("Press enter to sort.");
            Console.ReadLine();
            sortUnit.SortArray<double>(arrayDouble,(a,b) => a < b);
            CSharpLanguage.Display1DArray<double>(arrayDouble);

            Console.WriteLine();
            Console.WriteLine(Environment.NewLine + "It can be sorted in descending order by calling the following method:");
            Console.WriteLine("SortArray <double> ( arrayDouble, (a,b) => a > b );");
            Console.WriteLine("Press enter to sort.");
            Console.ReadLine();
            sortUnit.SortArray<double>(arrayDouble,(a,b) => a > b);
            CSharpLanguage.Display1DArray<double>(arrayDouble);

            Console.WriteLine();

            Console.WriteLine(Environment.NewLine + "Press enter to perform these operations with an array of ints.");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Array of ints:" + Environment.NewLine);

            var arrayInt = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arrayInt[i] = rand.Next(-arrayLength,arrayLength + 1);
            }
            CSharpLanguage.Display1DArray<int>(arrayInt);
            Console.WriteLine();

            Console.WriteLine(Environment.NewLine + "Press enter to sort ascending.");
            Console.WriteLine("SortArray <int> ( arrayInt, (a,b) => a < b );");
            Console.ReadLine();
            sortUnit.SortArray<int>(arrayInt,(a,b) => a < b);

            CSharpLanguage.Display1DArray<int>(arrayInt);
            Console.WriteLine();

            Console.WriteLine(Environment.NewLine + "Press enter to sort descending.");
            Console.WriteLine("SortArray <int> ( arrayInt, (a,b) => a > b );");
            Console.ReadLine();
            sortUnit.SortArray<int>(arrayInt,(a,b) => a > b);

            CSharpLanguage.Display1DArray<int>(arrayInt);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("The end. Press enter to exit.");
            Console.ReadLine();
        }

        public static void StringSortDemo()
        {
            Console.Clear();
            Console.WriteLine("Task 4.2. Custom Sort Demo.");
            Console.WriteLine("Sorting an array of strings in ascending order. Strings of equal lengths are sorted in alphabetical order."
                + Environment.NewLine);

            Console.WriteLine("Let's take the following string and split it into an array:" + Environment.NewLine);
            string line = "How I wish, how I wish you were here\n" + "We're just two lost souls\n" + 
                "Swimming in a fish bowl,\n" + "Year after year";
            Console.WriteLine(line);

            var words = line.Split(new char[] { ' ', '.', ',', '\n'});
            new CustomSort().SortArray<string>(words,(a,b) =>
           {
               if (a.Length != b.Length)
               {
                   return a.Length < b.Length;
               }
               for (int i = 0; i < a.Length; i++)
               {
                   if (a[i] != b[i])
                   {
                       return a[i] < b[i];
                   }
               }
               return false;
           });

            Console.WriteLine(Environment.NewLine + "Press enter to sort.");
            CSharpLanguage.Display1DArray<string>(words);

            Console.WriteLine(Environment.NewLine + Environment.NewLine + 
                "The end. Press enter to exit.");
            Console.ReadLine();
        }

        private static int _threadsNumber = 0;

        public static void OnSortIsFinishedEventHandler(string obj)
        {
            Console.WriteLine('\r' + obj + Environment.NewLine);
            _threadsNumber++;
        }
        public static void ThreadsSortDemo()
        {
            Console.Clear();
            Console.WriteLine("Task 4.3. Sorting Unit." + Environment.NewLine);
            Console.WriteLine("Sorting Unit consists of three parts:");
            Console.WriteLine("1. The sorting method from Task 4.1.");
            Console.WriteLine("2. A method, running the sorting method in an additional Thread.");
            Console.WriteLine("3. Event signalizing that sorting is finished." + Environment.NewLine);
            Console.WriteLine("Press enter to start a demonstration.");
            Console.ReadLine();

            var numberOfElements = 100000;

            Console.WriteLine($"Let's create two arrays of {numberOfElements} elements and fill them with random numbers." +
                "The first one is of ints, the second one is of doubles.");
            
            var sortUnit = new CustomSort();
            
            sortUnit.OnSortIsFinished += OnSortIsFinishedEventHandler;

            var arr1 = new int[numberOfElements];
            var arr2 = new double[numberOfElements];
            var rand = new Random();

            for (int i = 0; i < numberOfElements; i++)
            {
                arr1[i] = rand.Next(-numberOfElements,numberOfElements);
                arr2[i] = rand.NextDouble() * numberOfElements * 2 - numberOfElements;
            }

            Console.WriteLine($"arr1: {arr1}; arr1.Length = {arr1.Length}");
            Console.WriteLine($"arr2: {arr2}; arr2.Length = {arr2.Length}");

            Console.WriteLine(Environment.NewLine + "Sort parameter: arr1 - ascending order, arr2 - descending order.");

            sortUnit.SortInAdditionalThread<int>(arr1,(a,b) => a < b);
            sortUnit.SortInAdditionalThread<double>(arr2,(a,b) => a > b);

            Console.WriteLine("While the sorting is being performed in additional threads, " +
                "we are seeing some activity in the main thread.");

            while (_threadsNumber != 2)
            {
                Console.Write("\rSorting");
                Thread.Sleep(500);
                if (_threadsNumber != 2)
                {
                    Console.Write("\r       ");
                    Thread.Sleep(500);
                }
            }
            _threadsNumber = 0;

            sortUnit.OnSortIsFinished -= OnSortIsFinishedEventHandler;

            Console.WriteLine("Press enter to show first and last 50 elements of sorted arrays:");
            Console.ReadLine();
            Console.WriteLine("arr1 first 50:");
            for (int i = 0; i < 50; i++)
            {
                Console.Write($"{arr1[i]}; ");
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "arr1 last 50:");
            for (int i = arr1.Length - 50; i < arr1.Length; i++)
            {
                Console.Write($"{arr1[i]}; ");
            }

            Console.WriteLine(Environment.NewLine + Environment.NewLine + "arr2 first 50:");
            for (int i = 0; i < 50; i++)
            {
                Console.Write($"{arr2[i]:N2}; ");
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "arr2 last 50:");
            for (int i = arr2.Length - 50; i < arr2.Length; i++)
            {
                Console.Write($"{arr2[i]:N2}; ");
            }

            Console.WriteLine(Environment.NewLine + Environment.NewLine + 
                "Press enter to exit");

            Console.ReadLine();
        }
    }
}
