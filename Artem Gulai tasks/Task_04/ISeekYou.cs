using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class ISeekYou
    {
        private static void CheckArray(int[] array)
        {
            if (array == null)
                throw new ArgumentException("Array is null");
        }

        private static void CheckDelegate(Func<int,bool> condition)
        {
            if (condition == null)
                throw new ArgumentException("Delegate is null");
        }

        public static IEnumerable<int> GetPositiveItemsDirectSearch(int[] collection)
        {
            CheckArray(collection);

            List<int> positives = new List<int>();
            foreach (var item in collection)
            {
                if (item > 0)
                    positives.Add(item);
            }
            return positives;
        }

        // overloaded method for using in universal measuring method
        public static IEnumerable<int> GetPositiveItemsDirectSearch(int[] collection,Func<int,bool> condition)
        {
            CheckArray(collection);

            List<int> positives = new List<int>();
            foreach (var item in collection)
            {
                if (item > 0)
                    positives.Add(item);
            }
            return positives;
        }

        public static IEnumerable<int> GetPositiveItemsByPredicate(int[] collection, Func<int, bool> condition)
        {
            CheckArray(collection);
            CheckDelegate(condition);

            List<int> positives = new List<int>();
            foreach (var item in collection)
            {
                if (condition(item))
                    positives.Add(item);
            }
            return positives;
        }

        public static IEnumerable<int> GetPositiveItemsLinq(int[] collection)
        {
            CheckArray(collection);
            return collection.Where(a => a > 0);
        }

        // overloaded method for using in universal measuring method
        public static IEnumerable<int> GetPositiveItemsLinq(int[] collection,Func<int,bool> condition)
        {
            CheckArray(collection);
            return collection.Where(a => a > 0);
        }
    }

    public class ISeekYouDemo
    {
        public static void Demo()
        {
            var rnd = new Random();
            int numOfItems = 10000;
            int numOfMeasures = 1001;
            var array = new int[numOfItems];

            for (int i = 0; i < numOfItems; i++)
            {
                array[i] = rnd.Next(-1000,1000);
            }

            // Measuring time of direct search
            int directSearchTime = Measure(array,null,numOfMeasures,ISeekYou.GetPositiveItemsDirectSearch);

            // Measuring time of search by predicate using delegate instance
            Func<int,bool> deleg = new Func<int,bool>(x => x > 0);
            int delegateSearchTime = Measure(array,deleg,numOfMeasures,ISeekYou.GetPositiveItemsByPredicate);

            // Measuring time of search by predicate using anonymous method
            int anonymousSearchTime = Measure(array,delegate (int x) { return x > 0; },numOfMeasures,ISeekYou.GetPositiveItemsByPredicate);

            // Measuring time of search by predicate using lambda expression
            int lambdaSearchTime = Measure(array,x => x > 0,numOfMeasures,ISeekYou.GetPositiveItemsByPredicate);

            // Measuring time of search using LINQ
            int linqSearchTime = Measure(array,null,numOfMeasures,ISeekYou.GetPositiveItemsLinq);

            Console.WriteLine(Environment.NewLine + "Search times:");
            Console.WriteLine($"Direct search: {directSearchTime} ticks.");
            Console.WriteLine($"Delegate search: {delegateSearchTime} ticks.");
            Console.WriteLine($"Anonymous method search: {anonymousSearchTime} ticks.");
            Console.WriteLine($"Lambda method search: {lambdaSearchTime} ticks.");
            Console.WriteLine($"LINQ search: {linqSearchTime} ticks.");
            Console.ReadLine();
        }


        public static int Measure(int[] array, Func<int,bool> compare, int numOfMeasures, Func<int[],Func<int,bool>,IEnumerable<int>> searchFunction)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> searchTimes = new List<int>();
            IEnumerable<int> positives = searchFunction?.Invoke(array, compare);
            for (int i = 0; i < numOfMeasures; i++)
            {
                stopwatch.Start();
                positives = searchFunction?.Invoke(array,compare);
                positives.Count();
                stopwatch.Stop();
                searchTimes.Add((int)stopwatch.ElapsedTicks);
                stopwatch.Reset();
            }
            searchTimes.Sort();
            return searchTimes[numOfMeasures / 2];
        }
    }
}
