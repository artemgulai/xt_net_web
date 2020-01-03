using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    internal class MySinglyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MySinglyLinkedListNode<T> Next { get; set; }

        public MySinglyLinkedListNode(T value,MySinglyLinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }

        public MySinglyLinkedListNode(T value)
        {
            Value = value;
            Next = this;
        }

        public void RemoveNodeFromList(MySinglyLinkedListNode<T> previous)
        {
            previous.Next = Next;
        }
    }
}
