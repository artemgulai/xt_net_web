using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_04.Sorting_Unit;

namespace Task_04.Tests
{
    [TestFixture]
    class SortingTests
    {
        [Test]
        public static void TestSortInt()
        {
            var rand = new Random();
            var numOfItems = 1000;
            int[] arrayToSort = new int[numOfItems];
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = rand.Next(-numOfItems * 10,numOfItems * 10 + 1);
            }

            // Reference array, sorted using LINQ
            int[] sortedArray = (int[])arrayToSort.Clone();

            CustomSort sortingUnit = new CustomSort();
            sortingUnit.SortArray(arrayToSort,(x,y) => x < y);
            Assert.AreEqual(arrayToSort,sortedArray.OrderBy(a => a));
            sortingUnit.SortArray(arrayToSort,(x,y) => x > y);
            Assert.AreEqual(arrayToSort,sortedArray.OrderByDescending(a => a));
        }

        [Test]
        public static void TestSortDouble()
        {
            var rand = new Random();
            var numOfItems = 1000;
            double[] arrayToSort = new double[numOfItems];
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = rand.NextDouble() * numOfItems * 10 - numOfItems * 20;
            }

            // Reference array, sorted using LINQ
            double[] sortedArray = (double[])arrayToSort.Clone();

            CustomSort sortingUnit = new CustomSort();
            sortingUnit.SortArray(arrayToSort,(x,y) => x < y);
            Assert.AreEqual(arrayToSort,sortedArray.OrderBy(a => a));
            sortingUnit.SortArray(arrayToSort,(x,y) => x > y);
            Assert.AreEqual(arrayToSort,sortedArray.OrderByDescending(a => a));
        }

        [Test]
        public static void TestSortString()
        {
            var arrayToSort = new string[]
            {
                "abc", "a", "dsfs", "mnsw", "acb", "rcs", "saldkas"
            };

            var sortedArrayAsc = new string[]
            {
                "a", "abc", "acb", "rcs", "dsfs", "mnsw", "saldkas"
            };

            var sortedArrayDesc = new string[]
            {
                "saldkas", "mnsw", "dsfs", "rcs", "acb", "abc", "a"
            };

            // function for sorting strings by lengths by ascending order,
            // then by alphabetical order
            Func<string,string,bool> comparator = new Func<string,string,bool>((a,b) =>
            {
                if (a.Length != b.Length)
                    return a.Length < b.Length;

                for (int i = 0; i < a.Length; i++)
                    if (a[i] != b[i])
                        return a[i] < b[i];

                return true;
            });

            // function for sorting strings by lengths by descending order, 
            // then by reversed alphabetical order
            Func<string,string,bool> antiComparator = new Func<string,string,bool>((a,b) =>
            {
                return !comparator.Invoke(a,b);
            });

            CustomSort sortingUnit = new CustomSort();

            sortingUnit.SortArray(arrayToSort,comparator);
            Assert.AreEqual(sortedArrayAsc,arrayToSort);
            sortingUnit.SortArray(arrayToSort,antiComparator);
            Assert.AreEqual(sortedArrayDesc,arrayToSort);
        }
    }
}
