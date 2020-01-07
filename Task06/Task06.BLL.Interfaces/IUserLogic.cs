using System.Collections.Generic;
using Task06.Entities;

namespace Task06.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetByIdList(IEnumerable<int> ids);

        bool RemoveById(int id);

        bool GiveAward(int id, int awardId);

        bool TakeAwayAward(int id, int awardId);
    }
}
