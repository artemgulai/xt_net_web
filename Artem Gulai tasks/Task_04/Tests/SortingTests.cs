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
            int[] arrayToSort = new int[] { 1,4,7,-1,9,54 };
            CustomSort sortingUnit = new CustomSort();
            sortingUnit.SortArray(arrayToSort,(x,y) => x < y);
            Assert.AreEqual(arrayToSort,new int[] { -1,1,4,7,9,54 });
            sortingUnit.SortArray(arrayToSort,(x,y) => x > y);
            Assert.AreEqual(arrayToSort,new int[] { 54,9,7,4,1,-1 });
        }
    }
}
