using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task06.MyDB.BLL.Interfaces;
using Task06.MyDB.Entities;
using Task06.MyDB.IoC;

namespace Task10.WebPL.Models
{
    public class AuthUserService
    {
        private IAuthUserLogic _authUserLogic;

        public AuthUserService()
        {
            _authUserLogic = DependencyResolver.AuthUserLogic;
        }

        public IEnumerable<AuthUser> GetAll()
        {
            return _authUserLogic.GetAll();
        }

        public bool RegisterUser(string login, string password)
        {
            if (login == null || string.IsNullOrWhiteSpace(login)
                || password == null || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var result = _authUserLogic.AddUser(new AuthUser
            {
                Login = login,
                Password = password,
                Roles = new HashSet<string> { "USER" }
            });
            return result;
        }

        public bool GiveRole(string login, string roleName)
        {
            if (login == null || string.IsNullOrWhiteSpace(login) 
                || roleName == null || string.IsNullOrWhiteSpace(roleName))
            {
                return false;
            }

            var result = _authUserLogic.AddRole(login,roleName);
            return result;
        }

        public bool TakeRole(string login, string roleName)
        {
            if (login == null || string.IsNullOrWhiteSpace(login)
                || roleName == null || string.IsNullOrWhiteSpace(roleName))
            {
                return false;
            }

            var result = _authUserLogic.RemoveRole(login,roleName);
            return result;
        }

        public bool CheckRole(string login, string roleName)
        {
            var authUser = _authUserLogic.GetByLogin(login);
            return authUser == null ? false : authUser.Roles.Contains(roleName);
        }

        public string[] GetRolesByLogin(string login)
        {
            var authUser = _authUserLogic.GetByLogin(login);
            return authUser == null ? new string[] { } : authUser.Roles.ToArray();
        }

        public bool CheckLoginPassword(string login, string password)
        {
            var authUser = _authUserLogic.GetByLogin(login);

            return authUser == null ? false : authUser.Password == password;
        }

        public IEnumerable<AuthUser> GetNonAdmins()
        {
            var authUsers = _authUserLogic.GetAll();
            return authUsers == null ? new AuthUser[] { } : authUsers.Where(a => !a.Roles.Contains("ADMIN"));
        }

        public IEnumerable<AuthUser> GetAdmins()
        {
            var authUsers = _authUserLogic.GetAll();
            return authUsers == null ? new AuthUser[] { } : authUsers.Where(a => a.Roles.Contains("ADMIN"));
        }
    }
}