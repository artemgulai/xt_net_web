using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class DynamicArrayService
    {
        /// <summary>
        /// Counts the number of items in specified collection
        /// </summary>
        /// <param name="collection">A collection for which the number of items is count.</param>
        /// <returns>The number of items.</returns>
        public static int GetCollectionLength<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return 0;
            }

            int collectionLength = 0;
            foreach (T item in collection)
            {
                collectionLength++;
            }
            return collectionLength;
        }

        /// <summary>
        /// Checks the index of DynamicArray for being in the range of the underlying array.
        /// </summary>
        public static void CheckIndexOutOfRange<T>(int index, DynamicArray<T> array)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
