using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_02
{
    class User
    {
        private String _lastName;
        private String _firstName;
        private String _patronymic;
        private DateTime _birthDate;

        public User(String lastName,String firstName,String patronymic,DateTime birthDate)
        {
            String errorMessage = CheckFields(lastName,firstName,patronymic,birthDate);
            Console.Write("Checking fields.");
            for (int i = 0; i < 10; i++)
            {
                Console.Write('.');
                Thread.Sleep(50);
            }
            Console.WriteLine();
            if (errorMessage.Length != 0)
                throw new ArgumentException(errorMessage);

            _lastName = lastName;
            _firstName = firstName;
            _patronymic = patronymic;
            _birthDate = birthDate;
        }

        private static String CheckFields(String lastName, String firstName, String patronymic, DateTime birthDate)
        {
            StringBuilder errorMessage = new StringBuilder();
            if (lastName == null || lastName.Length == 0)
                errorMessage.Append("Wrong last name." + Environment.NewLine);
            if (firstName == null || firstName.Length == 0)
                errorMessage.Append("Wrong first name." + Environment.NewLine);
            if (patronymic == null || patronymic.Length == 0)
                errorMessage.Append("Wrong patronymic.");
            if (birthDate > DateTime.Today)
                errorMessage.Append("Wrong date of birth.");
            return errorMessage.ToString();
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != null && value.Length != 0)
                {
                    _lastName = value;
                }
                else
                {
                    Console.WriteLine("Wrong last name.");
                }
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != null && value.Length != 0)
                {
                    _firstName = value;
                }
                else
                {
                    Console.WriteLine("Wrong first name.");
                }
            }
        }

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (value != null && value.Length != 0)
                {
                    _patronymic = value;
                }
                else
                {
                    Console.WriteLine("Wrong patronymic.");
                }
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (value <= DateTime.Today)
                {
                    _birthDate = value;
                }
                else
                {
                    Console.WriteLine("Wrong date of birth.");
                }
            }
        }

        public string FullName => $"{_lastName} {_firstName} {_patronymic}";

        public Int32 Age
        {
            get
            {
                Int32 age = DateTime.Today.Year - _birthDate.Year;
                if (DateTime.Today.AddYears(-age) < _birthDate) age--;
                return age;
            }
        }

        public override String ToString()
        {
            return $"Fullname: {FullName}" + Environment.NewLine + "Date of Birth: " + _birthDate.ToString("d") + 
                $", Age: {Age}";
        }
    }

    class UserDemo
    {
        public static void ChangeUser(User user,String type)
        {
            String typeUpper = type.Substring(0,1).ToUpper() + type.Substring(1);

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s last name.");
            Console.Write("Trying to change last name to null: ");
            user.LastName = null;
            Console.Write("Trying to change last name to empty string: ");
            user.LastName = "";
            Console.Write("Trying to change last name to Mayakovskiy: ");
            user.LastName = "Mayakovskiy";
            Console.WriteLine($"{typeUpper}'s last name changed.");
            Console.WriteLine(user);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s first name.");
            Console.Write("Trying to change first name to null: ");
            user.FirstName = null;
            Console.Write("Trying to change first name to empty string: ");
            user.FirstName = "";
            Console.Write("Trying to change first name to Vladimir: ");
            user.FirstName = "Vladimir";
            Console.WriteLine($"{typeUpper}'s first name changed: ");
            Console.WriteLine(user);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s patronymic.");
            Console.Write("Trying to change patronymic to null: ");
            user.Patronymic = null;
            Console.Write("Trying to change patronymic to empty string: ");
            user.Patronymic = "";
            Console.Write("Trying to change patronymic to Vladimirovich: ");
            user.Patronymic = "Vladimirovich";
            Console.WriteLine($"{typeUpper}'s patronymic changed.");
            Console.WriteLine(user);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s date of birth.");
            Console.Write("Trying to change date of birth to the future date: ");
            user.BirthDate = DateTime.Parse("07 01 2021");
            Console.Write("Trying to change date of birth to another correct date: ");
            user.BirthDate = DateTime.Parse("19 07 1893");
            Console.WriteLine($"{typeUpper}'s date of birth changed.");
            Console.WriteLine(user);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }

        public static void Demo()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write('*');
                Thread.Sleep(70);
            }
            Console.WriteLine(Environment.NewLine + "User demo.");
            Thread.Sleep(100);
            Console.WriteLine("Enter user's data. Note: you have to enter data until the input is correct.");

            String lastName, firstName, patronymic;
            DateTime birthDate;
            User user = null;

            while (true)
            {
                Console.Write("Enter last name: ");
                while (true)
                {
                    lastName = Console.ReadLine();
                    if (lastName == null || lastName.Length == 0)
                    {
                        Console.WriteLine("Wrong last name. Try again.");
                        continue;
                    }
                    break;
                }

                Console.Write("Enter first name: ");
                while (true)
                {
                    firstName = Console.ReadLine();
                    if (firstName == null || firstName.Length == 0)
                    {
                        Console.WriteLine("Wrong first name. Try again.");
                        continue;
                    }
                    break;
                }

                Console.Write("Enter patronymic: ");
                while (true)
                {
                    patronymic = Console.ReadLine();
                    if (patronymic == null || patronymic.Length == 0)
                    {
                        Console.WriteLine("Wrong patronymic. Try again.");
                        continue;
                    }
                    break;
                }

                Console.Write("Enter birthdate: ");
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(),out birthDate))
                    {
                        break;
                    }
                    Console.WriteLine("Wrong date input. Try again.");
                }

                try
                {
                    user = new User(lastName,firstName,patronymic,birthDate);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error. " + Environment.NewLine + ex.Message);
                    continue;
                }

                break;
            }

            Console.WriteLine("User has been created:");
            Console.WriteLine(user.ToString() + Environment.NewLine);

            ChangeUser(user,"user");
        }
    }
}
