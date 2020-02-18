using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task06.MyDB.IoC;
using Task06.MyDB.BLL.Interfaces;
using System.Text;
using Task06.MyDB.Entities;
using System.Web.Mvc;

namespace Task10.WebPL.Models
{
    public static class UserService
    {
        private static IUserLogic _userLogic;
        private static IAwardLogic _awardLogic;
        private static StringBuilder _sb;

        static UserService()
        {
            _userLogic = Task06.MyDB.IoC.DependencyResolver.UserLogic;
            _awardLogic = Task06.MyDB.IoC.DependencyResolver.AwardLogic;
            _sb = new StringBuilder();
        }

        public static IEnumerable<User> GetAllUsers()
        {
            return _userLogic.GetAll();
        }

        public static MvcHtmlString ShowUserAndAwards(User user)
        {
            _sb.Clear();
            _sb.Append($"{user.ToString()}<br>");
            var awards = _awardLogic.GetAwardsByUserId(user.Id);
            if (awards.Any())
            {
                _sb.Append("Awards:");
                foreach (var award in awards)
                {
                    _sb.Append($" {award.Title},");
                }
                _sb.Remove(_sb.Length - 1,1);
                _sb.Append(".");
            }
            else
            {
                _sb.Append("No Awards.");
            }
            return MvcHtmlString.Create(_sb.ToString());
        }

        public static MvcHtmlString ShowUserAwards(User user)
        {
            _sb.Clear();
            var awards = _awardLogic.GetAwardsByUserId(user.Id);
            if (awards.Any())
            {
                foreach (var award in awards)
                {
                    _sb.Append($"{award.Title}, ");
                }
                _sb.Remove(_sb.Length - 2,2);
                _sb.Append(".");
            }
            else
            {
                _sb.Append("No Awards.");
            }
            return MvcHtmlString.Create(_sb.ToString());
        }

        public static IEnumerable<Award> GetUserAwards(User user)
        {
            var awards = _awardLogic.GetAwardsByUserId(user.Id);
            return awards ?? (new Award[] { });
        }

        public static String AddUser(string name, DateTime dateOfBirth, byte[] image = null)
        {
            var user = new User
            {
                Name = name,
                DateOfBirth = dateOfBirth,
            };

            if (image != null)
            {
                user.UserImage = image;
            }

            user = _userLogic.Add(user);

            return $"User has been added to DB. ID = {user.Id}";
        }

        public static bool RemoveUser(int id)
        {
            return _userLogic.RemoveById(id);
        }

        public static bool GiveAward(int userId, int awardId)
        {
            return _userLogic.GiveAward(userId,awardId);
        }

        public static bool TakeAward(int userId,int awardId)
        {
            return _userLogic.TakeAward(userId,awardId);
        }

        public static void RemoveAll()
        {
            _userLogic.RemoveAll();
        }

        public static User GetUserById(int id)
        {
            return _userLogic.GetById(id);
        }

        public static bool UpdateUser(User user)
        {
            return _userLogic.Update(user);
        }
    }
}