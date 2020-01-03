using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    internal class MyDoublyLinkedList<T>
    {
        public MyDoublyLinkedListNode<T> First { get; private set; }
        public MyDoublyLinkedListNode<T> Last { get; private set; }

        public MyDoublyLinkedList()
        {
        }

        public bool AddToEnd(T value)
        {
            if (First != null)
            {
                var newNode = new MyDoublyLinkedListNode<T>(value,First,Last);
                Last.Next = newNode;
                First.Previous = newNode;
                newNode.Next = First;
                newNode.Previous = Last;
                Last = newNode;
                return true;
            }
            if (First == null)
            {
                var newNode = new MyDoublyLinkedListNode<T>(value);
                Last = newNode;
                First = newNode;
                return true;
            }
            return false;
        }

        public T RemoveEachGetLast(int eachN)
        {
            int num = 1;
            var nodeToRemove = First;
            while (true)
            {
                if (num != eachN)
                {
                    nodeToRemove = nodeToRemove.Next;
                    num++;
                }
                else
                {
                    if (nodeToRemove == First)
                    {
                        First = nodeToRemove.Next;
                    }
                    if (nodeToRemove == Last)
                    {
                        Last = nodeToRemove.Previous;
                    }
                    var tempNode = nodeToRemove.Next;
                    nodeToRemove.RemoveNodeFromList();
                    nodeToRemove = tempNode;

                    if (nodeToRemove.Next == nodeToRemove)
                    {
                        break;
                    }
                    ShowList();
                    num = 1;
                }
            }
            return nodeToRemove.Value;
        }

        public void ShowList()
        {
            var nodeToShow = First;
            var firstNode = nodeToShow;
            do
            {
                Console.Write(nodeToShow.Value + " ");
                nodeToShow = nodeToShow.Next;
            } while (nodeToShow != firstNode);
            Console.WriteLine();
        }
    }
}
