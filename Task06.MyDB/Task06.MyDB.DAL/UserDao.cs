using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task06.MyDB.DAL
{
    public class UserDao : IUserDao
    {
        private DataBase.DataBase _db = DataBase.DataBase.Inst;

        public User Add(User user)
        {
            var users = _db.Users;
            var nextId = users.Count != 0 ? users.Keys.Max() + 1 : 1;
            user.Id = nextId;
            users.Add(nextId,user);
            _db.SaveUsers();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.Values;
        }

        public User GetById(int id)
        {
            _db.Users.TryGetValue(id,out var user);
            return user;
        }

        public bool Update(User user)
        {
            var users = _db.Users;

            if (!users.ContainsKey(user.Id))
            {
                return false;
            }

            users[user.Id] = user;
            _db.SaveUsers();
            return true;
        }

        public bool GiveAward(int userId,int awardId)
        {
            if (!_db.Users.ContainsKey(userId) || !_db.Awards.ContainsKey(awardId))
            {
                return false;
            }

            var userAwardLink = _db.UserAwardLink;
            var newLink = new UserAwardLink(userId,awardId);
            if (userAwardLink.Contains(newLink))
            {
                return false;
            }

            userAwardLink.Add(newLink);
            _db.SaveUserAwardLinks();
            return true;
        }

        public bool RemoveById(int id)
        {
            var users = _db.Users;
            bool removeResult = users.Remove(id);
            if (removeResult)
            {
                var userAwardLink = _db.UserAwardLink;
                userAwardLink.RemoveAll(ual => ual.UserId == id);
                _db.SaveUsers();
                _db.SaveUserAwardLinks();
            }
            return removeResult;
        }

        public bool TakeAward(int userId,int awardId)
        {
            if (!_db.Users.ContainsKey(userId) || !_db.Awards.ContainsKey(awardId))
            {
                return false;
            }

            var userAwardLink = _db.UserAwardLink;
            var newLink = new UserAwardLink(userId,awardId);
            if (!userAwardLink.Contains(newLink)) 
            {
                return false;
            }

            userAwardLink.Remove(newLink);
            _db.SaveUserAwardLinks();
            return true;
        }

        public void RemoveAll()
        {
            _db.Users.Clear();
            _db.UserAwardLink.Clear();
            _db.SaveUsers();
            _db.SaveUserAwardLinks();
        }
    }
}
