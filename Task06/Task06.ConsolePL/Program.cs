using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Task06.BLL.Interfaces;
using Task06.Entities;
using Task06.Ioc;

namespace Task06.ConsolePL
{
    public class Program
    {
        private static IUserLogic _userLogic;
        private static IAwardLogic _awardLogic;
        private static string NO_USER_ID = "No user with such ID.";
        private static string NO_AWARD_ID = "No award with such ID.";

        static void Main(string[] args)
        {
            SelectDAL();
            _userLogic = DependencyResolver.UserLogic;
            _awardLogic = DependencyResolver.AwardLogic;
            Run();
        }

        private static void SelectDAL()
        {
            Console.WriteLine("Select the DAL realization:");
            Console.WriteLine("1. File on HDD.");
            Console.WriteLine("2. RAM.");
            Console.WriteLine("3. Setting in configuration file.");

            for(; ;)
            {
                int select;
                while (!int.TryParse(Console.ReadLine(),out select))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
                switch (select)
                {
                    case 1:
                        {
                            WriteDALSetting("File");
                            return;
                        }
                    case 2:
                        {
                            WriteDALSetting("Memory");
                            return;
                        }
                    case 3:
                        {
                            return;
                        }
                    default: 
                        {
                            Console.WriteLine("Wrong number. Try again.");
                            continue;
                        }
                }
            }
        }

        private static void WriteDALSetting(string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings["DAL"] == null)
                {
                    settings.Add("DAL",value);
                }
                else
                {
                    settings["DAL"].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
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
                            ShowAllUsers();
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
                    case 5:
                        {
                            ShowAllUsers();
                            Console.WriteLine("Select User to give Award to.");
                            User user = _userLogic.GetById(GetId());
                            if (user == null)
                            {
                                Console.WriteLine(NO_USER_ID);
                                break;
                            }

                            ShowAllAwards();
                            Console.WriteLine("Select Award to give to the User.");
                            Award award = _awardLogic.GetById(GetId());
                            if (award == null)
                            {
                                Console.WriteLine(NO_AWARD_ID);
                                break;
                            }

                            if (_userLogic.GiveAward(user.Id,award.Id))
                            {
                                Console.WriteLine($"The Award \"{award.Title}\" has been given to the User \"{user.Name}\".");
                            }
                            else
                            {
                                Console.WriteLine($"Can't give the Award \"{award.Title}\" to the User \"{user.Name}\".");
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            ShowAllUsers();
                            Console.WriteLine("Select User to take Award from.");
                            User user = _userLogic.GetById(GetId());
                            if (user == null)
                            {
                                Console.WriteLine(NO_USER_ID);
                                break;
                            }

                            ShowAllAwards();
                            Console.WriteLine("Select Award to take from the User.");
                            Award award = _awardLogic.GetById(GetId());
                            if (award == null)
                            {
                                Console.WriteLine(NO_AWARD_ID);
                                break;
                            }

                            if (_userLogic.TakeAwayAward(user.Id,award.Id))
                            {
                                Console.WriteLine($"The Award \"{award.Title}\" has been taken from the User \"{user.Name}\".");
                            }
                            else
                            {
                                Console.WriteLine($"Can't take the Award \"{award.Title}\" from the User \"{user.Name}\".");
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
            Console.WriteLine("5. Give Award to User.");
            Console.WriteLine("6. Take Award from User.");
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

        private static void ShowAllUsers()
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
                    ShowAwardsOfUser(_awardLogic.GetByIdList(user.Awards));
                }
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
            while (!DateTime.TryParse(Console.ReadLine(),out dateOfBirth))
            {
                Console.WriteLine("Incorrect date format. Try again.");
            }

            return new User() { Name = name,DateOfBirth = dateOfBirth };
        }

        private static void ShowUsersOfAward(IEnumerable<User> users)
        {
            if (users.Count() != 0)
            {
                Console.Write("Users: ");
                foreach (var user in users)
                {
                    Console.Write(user.Name + "; ");
                }
                Console.WriteLine();
            }
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
                            ShowAllAwards();
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

        private static void ShowAllAwards()
        {
            IEnumerable<Award> awards = _awardLogic.GetAll();
            if (awards.Count() == 0)
            {
                Console.WriteLine("No users.");
            }
            else
            {
                foreach (var award in awards)
                {
                    ShowAward(award);
                    ShowUsersOfAward(_userLogic.GetByIdList(award.Users));
                }
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

        private static void ShowAwardsOfUser(IEnumerable<Award> awards)
        {
            if (awards.Count() != 0)
            {
                Console.Write("Awards: ");
                foreach (var award in awards)
                {
                    Console.Write(award.Title + "; ");
                }
                Console.WriteLine();
            }
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
