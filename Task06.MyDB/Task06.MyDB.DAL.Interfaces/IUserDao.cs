using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.Entities;

namespace Task06.MyDB.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();

        bool RemoveById(int id);

        bool GiveAward(int userId,int awardId);

        bool TakeAward(int userId,int awardId);
    }
}
