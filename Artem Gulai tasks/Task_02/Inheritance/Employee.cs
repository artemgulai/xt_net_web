using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_02
{
    class Employee : User
    {
        private String _post;
        private Int32 _experience;

        public Employee(String lastName,String firstName,String patronymic,DateTime birthDate, String post, Int32 experience) : 
            base(lastName, firstName, patronymic, birthDate)
        {
            String error = CheckFields(post,experience);
            if (error.Length != 0)
                throw new ArgumentException(error);

            _post = post;
            _experience = experience;
        }

        private String CheckFields(String post, Int32 experience)
        {
            StringBuilder errorMessage = new StringBuilder();
            if (post == null || post.Length == 0)
                errorMessage.Append("Wrong post." + Environment.NewLine);
            if (experience > Age)
                errorMessage.Append("Wrong experience.");
            return errorMessage.ToString();
        }

        public String Post
        {
            get => _post;
            set
            {
                if (value != null && value.Length != 0)
                {
                    _post = value;
                }
                else
                {
                    throw new ArgumentException("Wrong post.");
                }
            }
        }

        public Int32 Experience
        {
            get => _experience;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Experience cannot be less than 0.");
                }
                else if (value > Age)
                {
                    throw new ArgumentException("Experience cannot be greater than age.");
                }
                else
                {
                    _experience = value;
                }
            }
        }

        public override string ToString()
        {
            String years = "years";
            if (_experience == 1)
                years = "year";
            return base.ToString() + Environment.NewLine + 
                $"Post: {_post}, {_experience} {years} of experience";
        }
    }

    class EmployeeDemo
    {
        public static void ChangeEmployee(Employee employee, String type)
        {
            String typeUpper = type.Substring(0,1).ToUpper() + type.Substring(1);

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s post.");
            Console.Write("Trying to change post to null: ");
            try
            {
                employee.Post = null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change post to empty string: ");
            try
            {
                employee.Post = "";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change patronymic to Senior Developer: ");
            try
            {
                employee.Post = "Senior Developer";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"{typeUpper}'s post changed.");
            Console.WriteLine(employee);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write('*');
                Thread.Sleep(100);
            }

            Console.WriteLine(Environment.NewLine + $"Changing {type}'s experience.");
            Console.Write("Trying to change experience to -5: ");
            try
            {
                employee.Experience = -5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change experience to 150 (greater than age): ");
            try
            {
                employee.Experience = 150;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Trying to change experience to 25: ");
            try
            {
                employee.Experience = 25;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"{typeUpper}'s experience changed.");
            Console.WriteLine(employee);
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void Demo()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write('*');
                Thread.Sleep(70);
            }
            Console.WriteLine(Environment.NewLine + "Employee demo.");
            Thread.Sleep(100);
            Console.WriteLine("Enter employee's data. Note: you have to enter data until the input is correct.");

            String lastName, firstName, patronymic, post;
            Int32 experience;
            DateTime birthDate;
            Employee employee = null;

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

                Console.Write("Enter post: ");
                while (true)
                {
                    post = Console.ReadLine();
                    if (post == null || post.Length == 0)
                    {
                        Console.WriteLine("Wrong post. Try again.");
                        continue;
                    }
                    break;
                }

                Console.Write("Enter experience: ");
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out experience))
                    {
                        if (experience >= 0)
                        {
                            break;
                        }
                        Console.WriteLine("Experience must be greater than or equal to zero.");
                        continue;
                    }
                    Console.WriteLine("Wrong experience. Try again.");
                }

                try
                {
                    employee = new Employee(lastName,firstName,patronymic,birthDate, post, experience);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error. " + Environment.NewLine + ex.Message);
                    continue;
                }

                break;
            }

            Console.WriteLine("Employee has been created:");
            Console.WriteLine(employee.ToString() + Environment.NewLine);

            UserDemo.ChangeUser(employee,"employee");
            ChangeEmployee(employee,"employee");
        }
    }
}
