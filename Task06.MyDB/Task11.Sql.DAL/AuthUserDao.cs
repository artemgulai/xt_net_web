using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task11.Sql.DAL
{
    public class AuthUserDao : IAuthUserDao
    {
        public bool AddRole(string login,string roleName)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(AuthUser authUser)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string login,string oldPassword,string newPassword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuthUser GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRole(string login,string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
