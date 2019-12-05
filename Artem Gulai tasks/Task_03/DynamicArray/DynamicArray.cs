﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable
    {
        protected T[] _array;
        protected int _length;

        public int Length
        {
            get => _length;
        }

        public int Capacity
        {
            get => _array.Length;
        }

        /// <summary>
        /// Creates an array with default capacity.
        /// </summary>
        public DynamicArray()
        {
            _array = new T[8];
            _length = 0;
        }

        /// <summary>
        /// Creates an array with specified capacity.
        /// </summary>
        /// <param name="initialCapacity">Initial capacity.</param>
        public DynamicArray(int initialCapacity)
        {
            _array = new T[initialCapacity];
            _length = 0;
        }

        /// <summary>
        /// Creates an array with elements of specified collection.
        /// </summary>
        /// <param name="collection"></param>
        public DynamicArray(IEnumerable<T> collection)
        {
            int collectionLength = DynamicArrayService.GetCollectionLength(collection);
            _array = new T[collectionLength];
            _length = collectionLength;

            int index = 0;
            foreach (T item in collection)
            {
                _array[index++] = item;
            }
        }

        /// <summary>
        /// Creates new array of specified capacity and return a reference to the array.
        /// </summary>
        /// <param name="newCapacity"></param>
        /// <returns>Array of specified capacity.</returns>
        protected virtual T[] ReallocateArray(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            _array.CopyTo(newArray,0);
            return newArray;
        }

        /// <summary>
        /// Doubles the capacity of an array.
        /// </summary>
        private void DoubleCapacity()
        {
            _array = ReallocateArray(_array.Length * 2);
        }

        /// <summary>
        /// Changes the capacity of an array.
        /// </summary>
        private void ChangeCapacity(int newCapacity)
        {
            _array = ReallocateArray(newCapacity);
        } 

        /// <summary>
        /// Adds an item to the end of an array.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (Length == Capacity)
                DoubleCapacity();

            _array[_length++] = item;
        }

        /// <summary>
        /// Adds all elements of specified collection to the end of array.
        /// </summary>
        /// <param name="collection">Collection to add.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            int collectionLength = DynamicArrayService.GetCollectionLength(collection);

            if (Length + collectionLength > Capacity)
                ChangeCapacity(Length + collectionLength);

            foreach (T item in collection)
            {
                _array[_length++] = item;
            }
        }

        /// <summary>
        /// Removes the first entry of specified item.
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns>True if item is removed, else false.</returns>
        public bool Remove(T item)
        {
            int indexToRemove = -1;
            for (int i = 0; i < _length; i++)
            {
                if (_array[i].Equals(item))
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1)
                return false;

            for (int i = indexToRemove; i < _length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _length--;
            return true;
        }

        /// <summary>
        /// Removes all entries of specified item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item is removed, else false.</returns>
        public bool RemoveAll(T item)
        {
            bool isRemoved = false;

            while (Remove(item))
            {
                isRemoved = true;
            }

            return isRemoved;
        }

        /// <summary>
        /// Removes an item at specified position.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            DynamicArrayService.CheckIndexOutOfRange(index, this);

            for (int i = index; i < _length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _length--;
        }

        /// <summary>
        /// Insert a specified item into a specified position.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index">Index from 0 to Length-1.</param>
        /// <returns>True if an item is inserted, else false.</returns>
        public bool Insert(T item, int index)
        {
            DynamicArrayService.CheckIndexOutOfRange<T>(index,this);

            if (_length == _array.Length)
            {
                DoubleCapacity();
            }

            for (int i = _length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = item;
            _length++;
            return true;
        }

        public virtual T this[int index]
        {
            get 
            {
                DynamicArrayService.CheckIndexOutOfRange<T>(index,this);
                return _array[index];
            }
            set 
            {
                DynamicArrayService.CheckIndexOutOfRange<T>(index,this);
                _array[index] = value;
            }
        }

        /// <summary>
        /// Represents DynamicArray as string.
        /// </summary>
        /// <returns>String representation of DynamicArray.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            for (int i = 0; i < _length - 1; i++)
            {
                sb.Append(_array[i].ToString());
                sb.Append(", ");
            }
            sb.Append(_array[_length - 1].ToString());
            sb.Append('}');
            return sb.ToString();
        }

        /// <summary>
        /// Implements IEnumerable<> interface.
        /// </summary>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        /// <summary>
        /// Implements IEnumerable interface.
        /// </summary>
        public virtual IEnumerator GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }
    }
}
