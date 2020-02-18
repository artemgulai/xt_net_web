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
    public class AuthUserLogic : IAuthUserLogic
    {
        private IAuthUserDao _authUserDao;

        public AuthUserLogic(IAuthUserDao authUserDao)
        {
            _authUserDao = authUserDao;
        }

        public bool AddRole(string login,string roleName)
        {
            return _authUserDao.AddRole(login,roleName);
        }

        public bool AddUser(AuthUser authUser)
        {
            return _authUserDao.AddUser(authUser);
        }

        public bool ChangePassword(string login,string oldPassword,string newPassword)
        {
            return _authUserDao.ChangePassword(login,oldPassword,newPassword);
        }

        public IEnumerable<AuthUser> GetAll()
        {
            return _authUserDao.GetAll();
        }

        public AuthUser GetByLogin(string login)
        {
            return _authUserDao.GetByLogin(login);
        }

        public bool RemoveRole(string login,string roleName)
        {
            return _authUserDao.RemoveRole(login,roleName);
        }
    }
}
