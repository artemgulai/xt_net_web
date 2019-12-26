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
        private static IAwardLogic _awardLogic = DependencyResolver.AwardLogic;
        private static string NO_USER_ID = "No user with such ID.";
        private static string NO_AWARD_ID = "No award with such ID.";

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                ShowMainMenu();
                if (!int.TryParse(Console.ReadLine(), out int selectMode))
                {
                    Console.WriteLine("Incorrect input. Try again:");
                    continue;
                }

                switch (selectMode)
                {
                    case 1:
                        {
                            UserMode();
                            break;
                        }
                    case 2:
                        {
                            AwardMode();
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 0:
                    default:
                        break;
                }

                if (selectMode == 0)
                {
                    break;
                }
            }
        }

        #region Main menu
        private static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Users and awards.");
            Console.WriteLine("Select mode:");
            Console.WriteLine("1. Users mode.");
            Console.WriteLine("2. Awards mode.");
            Console.WriteLine("3. Users and awards mode.");
            Console.WriteLine("0. Exit.");
        }
        #endregion

        #region User mode
        private static void UserMode()
        {
            while (true)
            {
                ShowUserMenu();
                if (!int.TryParse(Console.ReadLine(),out int selectUser))
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    continue;
                }

                switch (selectUser)
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
                        break;
                    default:
                        {
                            Console.WriteLine("Wrong number. Try again.");
                            Console.ReadLine();
                            break;
                        }
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
            Console.Clear();
            Console.WriteLine("User Mode. Select action:");
            Console.WriteLine("1. Add User.");
            Console.WriteLine("2. Show User with specified ID.");
            Console.WriteLine("3. Show all Users.");
            Console.WriteLine("4. Remove user by specified ID.");
            Console.WriteLine("0. Exit User mode.");
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
        #endregion

        #region Award mode
        private static void AwardMode()
        {
            while (true)
            {
                ShowAwardMenu();
                if (!int.TryParse(Console.ReadLine(),out int selectAward))
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    continue;
                }

                switch (selectAward)
                {
                    case 1:
                        {
                            Award award = CreateAward();
                            _awardLogic.Add(award);
                            Console.WriteLine($"Award added. Awards's ID is {award.Id}");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            int id = GetId();
                            Award award = _awardLogic.GetById(id);
                            ShowAward(award);
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            IEnumerable<Award> awards = _awardLogic.GetAll();
                            if (awards.Count() == 0)
                            {
                                Console.WriteLine("No awards.");
                            }
                            else
                            {
                                foreach (var award in awards)
                                {
                                    ShowAward(award);
                                }
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            int id = GetId();
                            if (_awardLogic.RemoveById(id))
                            {
                                Console.WriteLine($"Award with ID = {id} is removed.");
                            }
                            else
                            {
                                Console.WriteLine(NO_AWARD_ID);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                    default:
                        break;
                }

                if (selectAward == 0)
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static void ShowAwardMenu()
        {
            Console.Clear();
            Console.WriteLine("Award Mode. Select action:");
            Console.WriteLine("1. Add Award.");
            Console.WriteLine("2. Show Award with specified ID.");
            Console.WriteLine("3. Show all Awards.");
            Console.WriteLine("4. Remove Award by specified ID.");
            Console.WriteLine("0. Exit Award mode.");
        }

        private static void ShowAward(Award award)
        {
            if (award == null)
            {
                Console.WriteLine(NO_AWARD_ID);
            }
            else
            {
                Console.WriteLine(award);
            }
        }

        private static Award CreateAward()
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
        #endregion

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
    }
}
