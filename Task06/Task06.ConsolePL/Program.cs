using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.BLL.Interfaces;
using Task06.Entities;
using Task06.Ioc;

namespace Task06.ConsolePL
{
    class Program
    {
        private static IUserLogic _userLogic = DependencyResolver.UserLogic;
        private static string NO_USER_ID = "No user with such ID.";

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {   
            while (true)
            {
                ShowUserMenu();
                if (!int.TryParse(Console.ReadLine(), out int selectUser))
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    continue;
                }

                switch(selectUser)
                {
                    case 1:
                        {
                            User user = CreateUser();
                            _userLogic.Add(user);
                            Console.WriteLine($"User added. User's ID is {user.Id}");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            int id = GetId();
                            User user = _userLogic.GetById(id);
                            ShowUser(user);
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            IEnumerable<User> users = _userLogic.GetAll();
                            if (users.Count() == 0)
                            {
                                Console.WriteLine("No users.");
                            }
                            else
                            {
                                foreach (var user in users)
                                {
                                    ShowUser(user);
                                }
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            int id = GetId();
                            if (_userLogic.RemoveById(id))
                            {
                                Console.WriteLine($"User with ID = {id} is removed.");
                            }
                            else
                            {
                                Console.WriteLine(NO_USER_ID);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                    default:
                        break;
                }

                if (selectUser == 0)
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static void ShowUserMenu()
        {
            Console.WriteLine("Select action:");
            Console.WriteLine("1. Add User.");
            Console.WriteLine("2. Show User with specified ID.");
            Console.WriteLine("3. Show all Users.");
            Console.WriteLine("4. Remove user by specified ID.");
            Console.WriteLine("0. Exit User mode.");
        }

        private static User CreateUser()
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

            Console.WriteLine("Enter date of birth in the following format: DD.MM.YYYY:");
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Incorrect date format. Try again.");
            }

            return new User() { Name = name,DateOfBirth = dateOfBirth };
        }

        private static int GetId()
        {
            Console.WriteLine("Enter id (positive integer):");
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
                    Console.WriteLine("Id should be positive.");
                    continue;
                }
                break;
            }
            return id;
        }

        private static void ShowUser(User user)
        {
            if (user == null)
            {
                Console.WriteLine(NO_USER_ID);
            }
            else
            {
                Console.WriteLine(user);
            }
        }
    }
}
