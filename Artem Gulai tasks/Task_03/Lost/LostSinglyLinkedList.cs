using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    class LostSinglyLinkedList
    {
        public static void Lost(int numOfPeople, int eachN)
        {
            // check values of parameters
            if (numOfPeople < 2)
            {
                throw new ArgumentException("Number of people cannot be less than 2.","numOfPeople");
            }

            if (eachN < 1)
            {
                throw new ArgumentException("The number of human to remove cannot be less than 1.","eachN");
            }

            MySinglyLinkedList<int> list = new MySinglyLinkedList<int>();

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

    class MySinglyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MySinglyLinkedListNode<T> Next { get; set; }

        public MySinglyLinkedListNode(T value, MySinglyLinkedListNode<T> next)
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

    class MySinglyLinkedList<T>
    {
        public MySinglyLinkedListNode<T> First { get; set; }
        public MySinglyLinkedListNode<T> Last { get; set; }

        public MySinglyLinkedList() {}
        public bool AddToEnd(T value)
        {
            if (First != null)
            {
                var newNode = new MySinglyLinkedListNode<T>(value,First);
                Last.Next = newNode;
                Last = newNode;
                return true;
            }
            else if (First == null)
            {
                var newNode = new MySinglyLinkedListNode<T>(value);
                First = newNode;
                Last = First;
                return true;
            }
            return false;            
        } 

        public T RemoveEachGetLast(int eachN)
        {
            int num = 1;
            var nodeToRemove = First;
            MySinglyLinkedListNode<T> previousNode = null;

            while (true)
            {
                if (num != eachN)
                {
                    previousNode = nodeToRemove;
                    nodeToRemove = nodeToRemove.Next;
                    num++;
                }
                else
                {
                    if (nodeToRemove == First)
                        First = nodeToRemove.Next;
                    if (nodeToRemove == Last)
                        Last = previousNode;

                    nodeToRemove.RemoveNodeFromList(previousNode);
                    nodeToRemove = previousNode.Next;
                    if (nodeToRemove == nodeToRemove.Next)
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
