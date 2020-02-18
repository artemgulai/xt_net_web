using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.Entities;

namespace Task06.MyDB.BLL.Interfaces
{
    public interface IAuthUserLogic
    {
        IEnumerable<AuthUser> GetAll();
        AuthUser GetByLogin(string login);
        bool AddUser(AuthUser authUser);
        bool ChangePassword(string login,string oldPassword,string newPassword);
        bool AddRole(string login,string roleName);
        bool RemoveRole(String login,string roleName);
    }
}
