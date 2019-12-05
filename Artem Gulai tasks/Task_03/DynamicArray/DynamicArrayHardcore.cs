using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class DynamicArrayHardcore<T> : DynamicArray<T>, ICloneable
    {
        public DynamicArrayHardcore() : base() { }

        public DynamicArrayHardcore(int initialCapacity) : base(initialCapacity) { }

        public DynamicArrayHardcore(IEnumerable<T> collection) : base(collection) { }

        public new int Capacity
        {
            get => base.Capacity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Capacity should be a positive integer.");
                _array = ReallocateArray(value);
                if (_length > value)
                    _length = value;
            }
        }

        protected override T[] ReallocateArray(int newCapacity)
        {
            if (newCapacity >= Capacity || newCapacity <= 0)
                return base.ReallocateArray(newCapacity);

            T[] newArray = new T[newCapacity];
            for (int i = 0; i < newCapacity; i++)
            {
                newArray[i] = _array[i];
            }
            return newArray;
        }

        public override T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    return base[index];
                }
                else if (index >= -Length)
                {
                    return base[Length + index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0)
                {
                    base[index] = value;
                }
                else if (index >= -Length)
                {
                    base[Length + index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public object Clone()
        {
            DynamicArrayHardcore<T> newDynamicArray = new DynamicArrayHardcore<T>(this);
            return newDynamicArray;
        }

        public T[] ToArray()
        {
            return ReallocateArray(_length);
        }


    }
}
