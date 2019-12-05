using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    class LostLinkedList
    {
        public static void Lost(int numOfPeople, int eachN)
        {
            // check values of parameters
            if (numOfPeople < 2)
                throw new ArgumentException("Number of people cannot be less than 2.","numOfPeople");

            if (eachN < 1)
                throw new ArgumentException("The number of human to remove cannot be less than 1.","eachN");

            MyLinkedList<int> list = new MyLinkedList<int>();

            for (int i = 1; i <= numOfPeople; i++)
            {
                list.AddToEnd(i);
            }

            list.ShowList();
            Console.WriteLine("Press enter to get last human.");
            Console.ReadLine();

            var last = list.RemoveEachGetLast(eachN);
            Console.WriteLine(last);
            Console.ReadLine();
        }
    }

    class MyLinkedListNode<T>
    {   
        public MyLinkedListNode<T> Next { get; set; }
        public MyLinkedListNode<T> Previous { get; set; }

        public T Value { get; private set; }

        public MyLinkedListNode(T value, MyLinkedListNode<T> next, MyLinkedListNode<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }

        public MyLinkedListNode(T value)
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

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> First { get; private set; }
        public MyLinkedListNode<T> Last { get; private set; }

        public MyLinkedList()
        {
        }

        public bool AddToEnd(T value)
        {
            if (First != null)
            {
                var newNode = new MyLinkedListNode<T>(value,First,Last);
                Last.Next = newNode;
                First.Previous = newNode;
                newNode.Next = First;
                newNode.Previous = Last;
                Last = newNode;
                return true;
            }
            if (First == null)
            {
                var newNode = new MyLinkedListNode<T>(value);
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
                        First = nodeToRemove.Next;
                    if (nodeToRemove == Last)
                        Last = nodeToRemove.Previous;
                    var tempNode = nodeToRemove.Next;
                    nodeToRemove.RemoveNodeFromList();
                    nodeToRemove = tempNode;
                    
                    if (nodeToRemove.Next == nodeToRemove)
                        break;
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
