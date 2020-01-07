using System;
using System.Collections.Generic;
using Task06.Entities;

namespace Task06.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);
        
        User GetById(int id);
        
        IEnumerable<User> GetAll();

        IEnumerable<User> GetByIdList(IEnumerable<int> ids);

        bool RemoveById(int id);

        bool GiveAward(int id, int awardId);

        bool TakeAwayAward(int id, int awardId);

        event Action<int,int> AddAward;

        event Action<int,int> RemoveAward;
        
        event Action<int> DeleteUser;

        void OnDeleteAwardHandler(int awardId);
    }
}