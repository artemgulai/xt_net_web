using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_02
{
    internal class User
    {
        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private DateTime _birthDate;

        public User(string lastName,string firstName,string patronymic,DateTime birthDate)
        {
            string errorMessage = CheckFields(lastName,firstName,patronymic,birthDate);
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

        private static string CheckFields(string lastName,string firstName,string patronymic, DateTime birthDate)
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
                    throw new ArgumentException("Wrong last name.");
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
                    throw new ArgumentException("Wrong first name.");
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
                    throw new ArgumentException("Wrong patronymic.");
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
                    throw new ArgumentException("Wrong date of birth.");
                }
            }
        }

        public string FullName => $"{_lastName} {_firstName} {_patronymic}";

        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - _birthDate.Year;
                if (DateTime.Today.AddYears(-age) < _birthDate) age--;
                return age;
            }
        }

        public override string ToString()
        {
            return $"Fullname: {FullName}" + Environment.NewLine + "Date of Birth: " + _birthDate.ToString("d") + 
                $", Age: {Age}";
        }
    }

    class UserDemo
    {
        public static void ChangeUser(User user,string type)
        {
            string typeUpper = type.Substring(0,1).ToUpper() + type.Substring(1);

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s last name.");
            Console.Write("Trying to change last name to null: ");
            try
            {
                user.LastName = null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change last name to empty string: ");
            try
            {
                user.LastName = "";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change last name to Mayakovskiy: ");
            try
            {
                user.LastName = "Mayakovskiy";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            try
            {
                user.FirstName = null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change first name to empty string: ");
            try
            {
                user.FirstName = "";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change first name to Vladimir: ");
            try
            {
                user.FirstName = "Vladimir";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            try
            {
                user.Patronymic = null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change patronymic to empty string: ");
            try
            {
                user.Patronymic = "";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change patronymic to Vladimirovich: ");
            try
            {
                user.Patronymic = "Vladimirovich";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            try
            {
                user.BirthDate = DateTime.Parse("07 01 2021");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change date of birth to another correct date: ");
            try
            {
                user.BirthDate = DateTime.Parse("19 07 1893");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
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

            string lastName, firstName, patronymic;
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
