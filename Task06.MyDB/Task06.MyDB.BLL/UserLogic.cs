using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.BLL.Interfaces;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task06.MyDB.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;
        
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User Add(User user)
        {
            return _userDao.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return _userDao.RemoveById(id);
        }

        public bool GiveAward(int userId,int awardId)
        {
            return _userDao.GiveAward(userId,awardId);
        }

        public bool TakeAward(int userId,int awardId)
        {
            return _userDao.TakeAward(userId,awardId);
        }
    }
}
