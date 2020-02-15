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
    public class UserService
    {
        private IUserLogic _userLogic;
        private IAwardLogic _awardLogic;
        private StringBuilder _sb;
        
        public UserService()
        {
            _userLogic = Task06.MyDB.IoC.DependencyResolver.UserLogic;
            _awardLogic = Task06.MyDB.IoC.DependencyResolver.AwardLogic;
            _sb = new StringBuilder();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userLogic.GetAll();
        }

        public MvcHtmlString ShowUserAndAwards(User user)
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

        public String AddUser(string name, DateTime dateOfBirth)
        {
            var user = _userLogic.Add(new User { 
                Name = name,
                DateOfBirth = dateOfBirth
            });

            return $"User has been added to DB. ID = {user.Id}";
        }

        public bool RemoveUser(int id)
        {
            return _userLogic.RemoveById(id);
        }

        public bool GiveAward(int userId, int awardId)
        {
            return _userLogic.GiveAward(userId,awardId);
        }

        public bool TakeAward(int userId,int awardId)
        {
            return _userLogic.TakeAward(userId,awardId);
        }

        public void RemoveAll()
        {
            _userLogic.RemoveAll();
        }

        public User GetUserById(int id)
        {
            return _userLogic.GetById(id);
        }

        public bool UpdateUser(User user)
        {
            return _userLogic.Update(user);
        }
    }
}