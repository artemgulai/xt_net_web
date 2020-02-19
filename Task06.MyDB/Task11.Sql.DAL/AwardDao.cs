using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task11.Sql.DAL
{
    public class AwardDao : IAwardDao
    {
        public Award Add(Award award)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Award GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Award award)
        {
            throw new NotImplementedException();
        }
    }
}
