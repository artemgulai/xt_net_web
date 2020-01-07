using System;
using System.Collections.Generic;
using Task06.Entities;

namespace Task06.DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);

        Award GetById(int id);

        IEnumerable<Award> GetAll();

        IEnumerable<Award> GetByIdList(IEnumerable<int> ids);

        bool RemoveById(int id);

        event Action<int> DeleteAward;
        
        void OnAddAwardHandler(int awardId,int userId);
        
        void OnRemoveAwardHandler(int awardId,int userId);

        void OnDeleteUserHandler(int userId);
    }
}