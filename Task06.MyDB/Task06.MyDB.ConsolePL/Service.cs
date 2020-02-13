using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.Entities;

namespace Task06.MyDB.ConsolePL
{
    internal class Service
    {
        internal static int GetId()
        {
            Console.WriteLine("Enter ID (positive integer):");
            int id;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(),out id))
                {
                    Console.WriteLine("Try again.");
                    continue;
                }
                if (id < 1)
                {
                    Console.WriteLine("ID should be positive.");
                    continue;
                }
                break;
            }
            return id;
        }

        internal static User CreateUser()
        {
            string name;
            DateTime dateOfBirth;

            Console.WriteLine("Enter name:");
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Enter name:");
                    continue;
                }
                break;
            }



            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Console.WriteLine("Enter date of birth in the following format: DD.MM.YYYY:");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", cultureInfo, DateTimeStyles.AllowWhiteSpaces, out dateOfBirth))
            {
                Console.WriteLine("Incorrect date format. Try again.");
            }

            return new User() { Name = name,DateOfBirth = dateOfBirth };
        }

        internal static Award CreateAward()
        {
            string title;

            Console.WriteLine("Enter title:");
            while (true)
            {
                title = Console.ReadLine();
                if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty. Enter title:");
                    continue;
                }
                break;
            }

            return new Award() { Title = title };
        }
    }
}
