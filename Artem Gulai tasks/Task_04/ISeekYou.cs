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
    }

    public class ISeekYouDemo
    {
        public static void Demo()
        {
            var stopWatch = new Stopwatch();

            var rnd = new Random();
            int numOfItems = 10000;
            int numOfMeasures = 1001;
            var array = new int[numOfItems];

            for (int i = 0; i < numOfItems; i++)
            {
                array[i] = rnd.Next(-1000,1000);
            }

            #region Measuring time of direct search
            List<int> searchTimes = new List<int>(numOfMeasures);
            IEnumerable<int> positivesDirect = ISeekYou.GetPositiveItemsDirectSearch(array);
            for (int i = 0; i < numOfMeasures; i++)
            {
                stopWatch.Start();
                positivesDirect = ISeekYou.GetPositiveItemsDirectSearch(array);
                positivesDirect.Count();
                stopWatch.Stop();
                searchTimes.Add((int)stopWatch.ElapsedTicks);
                stopWatch.Reset();
            }
            searchTimes.Sort();
            int directSearchTime = searchTimes[numOfMeasures/2];
            #endregion

            #region Measuring time of search by predicate using delegate instance
            searchTimes.Clear();
            Func<int,bool> deleg = new Func<int,bool>(x => x > 0);
            IEnumerable<int> positivesDelegate = ISeekYou.GetPositiveItemsByPredicate(array,deleg);
            for (int i = 0; i < numOfMeasures; i++)
            {
                stopWatch.Start();
                positivesDelegate = ISeekYou.GetPositiveItemsByPredicate(array,deleg);
                positivesDelegate.Count();
                stopWatch.Stop();
                searchTimes.Add((int)stopWatch.ElapsedTicks);
                stopWatch.Reset();
            }
            searchTimes.Sort();
            int delegateSearchTime = searchTimes[numOfMeasures/2];
            #endregion

            #region Measuring time of search by predicate using anonymous method
            searchTimes.Clear();
            IEnumerable<int> positivesAnonymous = ISeekYou.GetPositiveItemsByPredicate(array,delegate (int x) { return x > 0; });
            for (int i = 0; i < numOfMeasures; i++)
            {
                stopWatch.Start();
                positivesAnonymous = ISeekYou.GetPositiveItemsByPredicate(array,delegate (int x) { return x > 0; });
                positivesAnonymous.Count();
                stopWatch.Stop();
                searchTimes.Add((int)stopWatch.ElapsedTicks);
                stopWatch.Reset();
            }
            searchTimes.Sort();
            int anonymousSearchTime = searchTimes[numOfMeasures/2];
            #endregion

            #region Measuring time of search by predicate using lambda expression
            searchTimes.Clear();
            IEnumerable<int> positivesLambda = ISeekYou.GetPositiveItemsByPredicate(array,x => x > 0);
            for (int i = 0; i < numOfMeasures; i++)
            {
                stopWatch.Start();
                positivesLambda = ISeekYou.GetPositiveItemsByPredicate(array,x => x > 0);
                positivesLambda.Count();
                stopWatch.Stop();
                searchTimes.Add((int)stopWatch.ElapsedTicks);
                stopWatch.Reset();
            }
            searchTimes.Sort();
            int lambdaSearchTime = searchTimes[numOfMeasures/2];
            #endregion

            #region Measuring time of search using LINQ
            searchTimes.Clear();
            IEnumerable<int> positivesLinq = ISeekYou.GetPositiveItemsLinq(array);
            for (int i = 0; i < numOfMeasures; i++)
            {
                stopWatch.Start();
                positivesLinq = ISeekYou.GetPositiveItemsLinq(array);
                positivesLinq.Count();
                stopWatch.Stop();
                searchTimes.Add((int)stopWatch.ElapsedTicks);
                stopWatch.Reset();
            }
            searchTimes.Sort();
            int linqSearchTime = searchTimes[numOfMeasures/2];
            #endregion

            Console.WriteLine(Environment.NewLine + "Search times:");
            Console.WriteLine($"Direct search: {directSearchTime} ticks.");
            Console.WriteLine($"Delegate search: {delegateSearchTime} ticks.");
            Console.WriteLine($"Anonymous method search: {anonymousSearchTime} ticks.");
            Console.WriteLine($"Lambda method search: {lambdaSearchTime} ticks.");
            Console.WriteLine($"LINQ search: {linqSearchTime} ticks.");
            Console.ReadLine();
        }
    }
}
