using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.BLL.Interfaces
{
    public interface IAwardLogic
    {
        Award Add(Award award);

        Award GetById(int id);

        IEnumerable<Award> GetAll();

        IEnumerable<Award> GetByIdList(IEnumerable<int> ids);

        bool RemoveById(int id);
    }
}
