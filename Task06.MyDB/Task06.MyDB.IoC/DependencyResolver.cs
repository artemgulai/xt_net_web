using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.BLL;
using Task06.MyDB.BLL.Interfaces;
using Task06.MyDB.DAL;
using Task06.MyDB.DAL.Interfaces;
using Task11.Sql.DAL;

namespace Task06.MyDB.IoC
{
    public class DependencyResolver
    {
        private static IUserDao _userDao = new Task11.Sql.DAL.UserDao();
        private static IAwardDao _awardDao = new Task06.MyDB.DAL.AwardDao();
        private static IAuthUserDao _authUserDao = new Task06.MyDB.DAL.AuthUserDao();
        private static IUserLogic _userLogic = new UserLogic(_userDao);
        private static IAwardLogic _awardLogic = new AwardLogic(_awardDao);
        private static IAuthUserLogic _authUserLogic = new AuthUserLogic(_authUserDao);
        
        public static IUserLogic UserLogic => _userLogic;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IAuthUserLogic AuthUserLogic => _authUserLogic;
    }
}
