using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();

        bool RemoveById(int id);

        bool GiveAward(int id, int awardId);

        bool TakeAwayAward(int id, int awardId);
    }
}
