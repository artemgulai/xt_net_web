using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
    class Lost
    {
        public static void Lost_3_1(int numOfPeople, int eachN)
        {
            // check values of parameters
            if (numOfPeople < 2)
                throw new ArgumentException("Number of people cannot be less than 2.","numOfPeople");

            if (eachN < 1)
                throw new ArgumentException("The number of human to remove cannot be less than 1.", "eachN");

            // Initial set of people numbered from 1 to numOfPeople.
            List<int> people = new List<int>(numOfPeople);
            for (int i = 0; i < numOfPeople; i++)
            {
                people.Add(i + 1);
            }

            int indexToRemove = 0;
            int indexShift = eachN - 1;
            int numOfPeopleLeft = numOfPeople;

            while (true)
            {
                indexToRemove = (indexToRemove + indexShift) % numOfPeopleLeft--;
                people.RemoveAt(indexToRemove);

                foreach (var item in people)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                if (numOfPeopleLeft == 1)
                    break;
            }
            Console.ReadLine();
        }
    }

    public class LostDemo
    {
        public static void Demo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task 3.1. Lost.");

                int numOfPeople = 0;
                Console.WriteLine("Enter the Number of people:");
                while (!int.TryParse(Console.ReadLine(),out numOfPeople))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                int eachNToRemove = 0;
                Console.WriteLine("Each N-th human is removed. Enter N:");
                while (!int.TryParse(Console.ReadLine(),out eachNToRemove))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                try
                {
                    Lost.Lost_3_1(numOfPeople,eachNToRemove);
                    Console.WriteLine("Press enter to continue.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again.");
                    Console.ReadLine();
                    continue;
                }
                break;
            }
        }
    }
}
