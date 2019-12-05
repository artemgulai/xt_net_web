using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Lost
{
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
                    Console.Clear();
                    Console.WriteLine("Task 3.1. Lost.");
                    Console.WriteLine($"Number of people: {numOfPeople}");
                    Console.WriteLine($"Each {eachNToRemove} is removed." + Environment.NewLine);
                    Console.WriteLine("List realization." + Environment.NewLine);
                    LostList.Lost(numOfPeople,eachNToRemove);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again.");
                    Console.ReadLine();
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Task 3.1. Lost.");
                Console.WriteLine($"Number of people: {numOfPeople}");
                Console.WriteLine($"Each {eachNToRemove} is removed." + Environment.NewLine);
                Console.WriteLine("Doubly linked list realization." + Environment.NewLine);
                LostDoublyLinkedList.Lost(numOfPeople,eachNToRemove);
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Task 3.1. Lost.");
                Console.WriteLine($"Number of people: {numOfPeople}");
                Console.WriteLine($"Each {eachNToRemove} is removed." + Environment.NewLine);
                Console.WriteLine("Singly linked list realization." + Environment.NewLine);
                LostSinglyLinkedList.Lost(numOfPeople,eachNToRemove);
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;
            }
        }
    }
}
