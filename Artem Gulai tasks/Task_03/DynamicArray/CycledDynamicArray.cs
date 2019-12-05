using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>
    {
        public CycledDynamicArray() : base() { }

        public CycledDynamicArray(int initialCapacity) : base(initialCapacity) { }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }

        public override IEnumerator GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }
    }
}
