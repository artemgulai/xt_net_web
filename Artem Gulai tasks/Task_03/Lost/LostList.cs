using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    class LostList
    {
        public static void ShowList<T>(List<T> people)
        {
            foreach (var item in people)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void Lost(int numOfPeople,int eachN)
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

            // Initial set of people numbered from 1 to numOfPeople.
            List<int> people = new List<int>(numOfPeople);
            for (int i = 0; i < numOfPeople; i++)
            {
                people.Add(i + 1);
            }

            Console.WriteLine("Initial set of people:" + Environment.NewLine);
            ShowList(people);
            Console.WriteLine("Press enter to get last human.");
            Console.ReadLine();

            int indexToRemove = 0;
            int indexShift = eachN - 1;
            int numOfPeopleLeft = numOfPeople;

            while (true)
            {
                indexToRemove = (indexToRemove + indexShift) % numOfPeopleLeft--;
                people.RemoveAt(indexToRemove);

                ShowList(people);

                if (numOfPeopleLeft == 1)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
