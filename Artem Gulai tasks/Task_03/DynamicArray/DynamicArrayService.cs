using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class DynamicArrayService
    {
        public static int GetCollectionLength<T>(IEnumerable<T> collection)
        {
            int collectionLength = 0;
            foreach (T item in collection)
            {
                collectionLength++;
            }
            return collectionLength;
        }

        public static void CheckIndexOutOfRange<T>(int index, DynamicArray.DynamicArray<T> array)
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException();
        }
    }
}
