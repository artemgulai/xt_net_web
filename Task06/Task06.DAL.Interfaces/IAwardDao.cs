using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);

        Award GetById(int id);

        IEnumerable<Award> GetAll();

        event Action<Award> DeleteAward;

        bool RemoveById(int id);
    }
}