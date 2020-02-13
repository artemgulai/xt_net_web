using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.Entities;

namespace Task06.MyDB.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);
        
        User GetById(int id);

        IEnumerable<User> GetAll();

        bool Update(User user);

        bool RemoveById(int id);

        bool GiveAward(int userId,int awardId);

        bool TakeAward(int userId,int awardId);

        void RemoveAll();
    }
}
