using System.Collections.Generic;
using Task06.BLL.Interfaces;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.BLL
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

        public IEnumerable<User> GetByIdList(IEnumerable<int> ids)
        {
            return _userDao.GetByIdList(ids);
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return _userDao.RemoveById(id);
        }

        public bool GiveAward(int id, int awardId)
        {
            return _userDao.GiveAward(id, awardId);
        }

        public bool TakeAwayAward(int id, int awardId)
        {
            return _userDao.TakeAwayAward(id, awardId);
        }
    }
}
