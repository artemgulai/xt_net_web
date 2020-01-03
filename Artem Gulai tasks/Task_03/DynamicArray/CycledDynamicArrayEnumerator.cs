using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    /// <summary>
    /// Custom Enumerator class for CycledDynamicArray
    /// </summary>
    public class CycledDynamicArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] arrayEnum;
        private int position;
        public CycledDynamicArrayEnumerator(DynamicArray<T> array)
        {
            arrayEnum = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayEnum[i] = array[i];
            }

            position = array.Length;
        }
        public T Current
        {
            get
            {
                if (position == -1 || position >= arrayEnum.Length)
                {
                    throw new InvalidOperationException();
                }
                return arrayEnum[position];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (position < arrayEnum.Length - 1)
            {
                position++;
            }
            else
            {
                Reset();
            }

            return true;
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
