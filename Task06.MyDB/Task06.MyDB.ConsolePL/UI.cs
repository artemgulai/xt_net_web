using System;
using System.Linq;
using Task06.MyDB.BLL.Interfaces;
using Task06.MyDB.IoC;

namespace Task06.MyDB.ConsolePL
{
    class UI
    {
        private static IUserLogic _userLogic  = DependencyResolver.UserLogic;
        private static IAwardLogic _awardLogic = DependencyResolver.AwardLogic;

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();
                if (!int.TryParse(Console.ReadLine(),out int selectMode))
                {
                    Console.WriteLine("Incorrect input. Try again:");
                    continue;
                }

                switch (selectMode)
                {
                    //"1. Show all Users in DB"
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("List of Users in DB.");
                            ShowUsersWithAwards();
                            Console.ReadLine();
                            break;
                        }
                    //"2. Add User to DB."
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Adding User to DB.");
                            var userToAdd = Service.CreateUser();
                            _userLogic.Add(userToAdd);
                            Console.WriteLine($"User has been added to DB. ID = {userToAdd.Id}");
                            Console.ReadLine();
                            break;
                        }
                    //"3. Remove User with specified."
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Removing User from DB.");
                            ShowUsersWithAwards();
                            var idToRemove = Service.GetId();
                            if (_userLogic.RemoveById(idToRemove))
                            {
                                Console.WriteLine($"User with ID = {idToRemove} is removed from DB.");
                            }
                            else
                            {
                                Console.WriteLine($"User with ID = {idToRemove} not found.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    //"4. Show all Awards in DB"
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("List of Awards in DB.");
                            ShowAwards();
                            Console.ReadLine();
                            break;
                        }
                    //"5. Add Award to DB."
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Adding Award to DB.");
                            var awardToAdd = Service.CreateAward();
                            _awardLogic.Add(awardToAdd);
                            Console.WriteLine($"Award has been added to DB. ID = {awardToAdd.Id}");
                            Console.ReadLine();
                            break;
                        }
                    //"6. Remove Award with specified ID."
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Removing Award from DB.");
                            ShowAwards();
                            var idToRemove = Service.GetId();
                            if (_awardLogic.RemoveById(idToRemove))
                            {
                                Console.WriteLine($"Award with ID = {idToRemove} is removed from DB.");
                            }
                            else
                            {
                                Console.WriteLine($"Award with ID = {idToRemove} not found.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    //"7. Give Award to User."
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("Give Award to User." + Environment.NewLine);

                            ShowUsersWithAwards();
                            Console.WriteLine();
                            Console.WriteLine("Select User to be given Award:");
                            var userId = Service.GetId();
                            Console.WriteLine();

                            ShowAwards();
                            Console.WriteLine();
                            Console.WriteLine("Select Award to be given to User:");
                            var awardId = Service.GetId();

                            if (_userLogic.GiveAward(userId, awardId))
                            {
                                Console.WriteLine("Award has been given to User.");
                            }
                            else
                            {
                                Console.WriteLine("Award cannot be given to User.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    //"8. Take Award from User."
                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine("Take Award from User." + Environment.NewLine);

                            ShowUsersWithAwards();
                            Console.WriteLine();
                            Console.WriteLine("Select User to be taken Award:");
                            var userId = Service.GetId();
                            Console.WriteLine();

                            if (!ShowAwardsOfUser(userId))
                            {
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine();
                            Console.WriteLine("Select Award to be taken from User:");
                            var awardId = Service.GetId();

                            if (_userLogic.TakeAward(userId,awardId))
                            {
                                Console.WriteLine("Award has been taken from User.");
                            }
                            else
                            {
                                Console.WriteLine("Award cannot be taken from User.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    //"0. Exit."
                    case 0:
                    default:
                        {
                            break;
                        }
                }

                if (selectMode == 0)
                {
                    break;
                }
            }
        }

        private static void ShowUsersWithAwards()
        {
            var users = _userLogic.GetAll();

            if (users.Count() == 0)
            {
                Console.WriteLine("No users in DB.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine(user);
                var awards = _awardLogic.GetAwardsByUserId(user.Id);
                Console.Write("Awards: ");
                if (awards.Count() != 0)
                {
                    foreach (var award in awards)
                    {
                        Console.Write($"{award.Title}; ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("No awards.");
                }
            }
        }

        private static void ShowAwards()
        {
            var awards = _awardLogic.GetAll();
            if (awards.Count() == 0)
            {
                Console.WriteLine("No awards in DB.");
                return;
            }

            foreach (var award in _awardLogic.GetAll())
            {
                Console.WriteLine(award);
            }
        }

        private static bool ShowAwardsOfUser(int id)
        {
            var awards = _awardLogic.GetAwardsByUserId(id);
            if (awards.Count() == 0)
            {
                Console.WriteLine("User don't have Awards.");
                return false;
            }

            foreach (var award in awards)
            {
                Console.WriteLine(award);
            }
            return true;
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Task 6. Users and awards. Custom \"database\" realization.");
            Console.WriteLine($"{Environment.NewLine}Select what to do:");
            Console.WriteLine("1. Show all Users in DB");
            Console.WriteLine("2. Add User to DB.");
            Console.WriteLine("3. Remove User with specified ID.");
            Console.WriteLine("4. Show all Awards in DB");
            Console.WriteLine("5. Add Award to DB.");
            Console.WriteLine("6. Remove Award with specified ID.");
            Console.WriteLine("7. Give Award to User.");
            Console.WriteLine("8. Take Award from User.");
            Console.WriteLine("0. Exit.");
        }
    }
}
