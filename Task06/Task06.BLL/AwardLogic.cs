using System.Collections.Generic;
using Task06.BLL.Interfaces;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.BLL
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

        public IEnumerable<Award> GetByIdList(IEnumerable<int> ids)
        {
            return _awardDao.GetByIdList(ids);
        }

        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return _awardDao.RemoveById(id);
        }
    }
}
