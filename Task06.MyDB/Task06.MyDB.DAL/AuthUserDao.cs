using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task06.MyDB.DAL
{
    public class AuthUserDao : IAuthUserDao
    {
        private DataBase.DataBase _db = DataBase.DataBase.Inst;

        public bool AddRole(string login,string roleName)
        {
            var authUsers = _db.AuthUsers;
            authUsers.TryGetValue(login, out var authUser);

            if (authUser != null && authUser.Roles.Add(roleName))
            {
                _db.saveAuthUsers();
                return true;
            }

            return false;
        }

        public bool AddUser(AuthUser authUser)
        {
            var authUsers = _db.AuthUsers;
            authUsers.TryGetValue(authUser.Login,out var authUserExist);

            if (authUserExist == null)
            {
                authUsers.Add(authUser.Login,authUser);
                _db.saveAuthUsers();
                return true;
            }

            return false;
        }

        public bool ChangePassword(string login,string oldPassword,string newPassword)
        {
            var authUsers = _db.AuthUsers;
            authUsers.TryGetValue(login,out var authUser);

            if (authUser != null && authUser.Password == oldPassword)
            {
                authUser.Password = newPassword;
                _db.saveAuthUsers();
                return true;
            }

            return false;
        }

        public IEnumerable<AuthUser> GetAll()
        {
            return _db.AuthUsers.Values;
        }

        public AuthUser GetByLogin(string login)
        {
            _db.AuthUsers.TryGetValue(login,out var authUser);
            return authUser;
        }

        public bool RemoveRole(string login,string roleName)
        {
            var authUsers = _db.AuthUsers;
            authUsers.TryGetValue(login,out var authUser);

            if (authUser == null)
            {
                return false;
            }

            if (authUser.Roles.Contains(roleName))
            {
                authUser.Roles.Remove(roleName);
                _db.saveAuthUsers();
                return true;
            }

            return false;
        }
    }
}
