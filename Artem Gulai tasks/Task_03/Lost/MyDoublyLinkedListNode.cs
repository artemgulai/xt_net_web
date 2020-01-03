using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    internal class MyDoublyLinkedListNode<T>
    {
        public MyDoublyLinkedListNode<T> Next { get; set; }
        public MyDoublyLinkedListNode<T> Previous { get; set; }

        public T Value { get; private set; }

        public MyDoublyLinkedListNode(T value,MyDoublyLinkedListNode<T> next,MyDoublyLinkedListNode<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }

        public MyDoublyLinkedListNode(T value)
        {
            Value = value;
            Next = this;
            Previous = this;
        }

        public void RemoveNodeFromList()
        {
            Previous.Next = Next;
            Next.Previous = Previous;
        }
    }
}
