using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.BLL;
using Task06.MyDB.BLL.Interfaces;
using Task06.MyDB.DAL;
using Task06.MyDB.DAL.Interfaces;

namespace Task06.MyDB.IoC
{
    public class DependencyResolver
    {
        private static IUserDao _userDao = new UserDao();
        private static IAwardDao _awardDao = new AwardDao();
        private static IUserLogic _userLogic = new UserLogic(_userDao);
        private static IAwardLogic _awardLogic = new AwardLogic(_awardDao);
        public static IUserLogic UserLogic => _userLogic;
        public static IAwardLogic AwardLogic => _awardLogic;
    }
}
