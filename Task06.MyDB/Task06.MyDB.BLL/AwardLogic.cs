using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.BLL.Interfaces;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task06.MyDB.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public Award Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            return _awardDao.GetAwardsByUserId(userId);
        }

        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return _awardDao.RemoveById(id);
        }

        public void RemoveAll()
        {
            _awardDao.RemoveAll();
        }

        public bool Update(Award award)
        {
            return _awardDao.Update(award);
        }
    }
}
