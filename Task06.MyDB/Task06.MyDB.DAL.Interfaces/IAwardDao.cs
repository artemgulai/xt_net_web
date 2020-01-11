using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.Entities;

namespace Task06.MyDB.DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);

        Award GetById(int id);

        IEnumerable<Award> GetAll();

        IEnumerable<Award> GetAwardsByUserId(int userId);

        bool RemoveById(int id);
    }
}
