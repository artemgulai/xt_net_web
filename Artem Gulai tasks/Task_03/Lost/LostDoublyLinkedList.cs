using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    public class LostDoublyLinkedList
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

            MyDoublyLinkedList<int> list = new MyDoublyLinkedList<int>();

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
}
