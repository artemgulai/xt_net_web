using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.BLL;
using Task06.BLL.Interfaces;
using Task06.DAL;
using Task06.DAL.Interfaces;

namespace Task06.Ioc
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao = new UserFileDao();
        public static IUserDao UserDao => _userDao;

        private static IUserLogic _userLogic = new UserLogic(_userDao);
        public static IUserLogic UserLogic => _userLogic;

        private static IAwardDao _awardDao = new AwardFileDao();
        public static IAwardDao AwardDao => _awardDao;

        private static IAwardLogic _awardLogic = new AwardLogic(_awardDao);
        public static IAwardLogic AwardLogic => _awardLogic;

        static DependencyResolver()
        {
            _awardDao.DeleteAward += _userDao.OnDeleteAwardHandler;
        }
    }
}
