using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.DataBase;
using Task06.MyDB.Entities;

namespace Task06.MyDB.DAL
{
    public class AwardDao : IAwardDao
    {
        private DataBase.DataBase _db = DataBase.DataBase.Inst;

        public Award Add(Award award)
        {
            var awards = _db.Awards;
            var nextId = awards.Count != 0 ? awards.Keys.Max() + 1 : 1;
            award.Id = nextId;
            awards.Add(nextId,award);
            _db.SaveAwards();
            return award;
        }

        public IEnumerable<Award> GetAll()
        {
            return _db.Awards.Values;
        }

        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            var awardIds = _db.UserAwardLink.Where(ual => ual.UserId == userId).Select(ual => ual.AwardId);
            return _db.Awards.Values.Where(a => awardIds.Contains(a.Id));
        }

        public bool Update(Award award)
        {
            var awards = _db.Awards;
            if (!awards.ContainsKey(award.Id))
            {
                return false;
            }

            awards[award.Id] = award;
            _db.SaveAwards();
            return true;
        }

        public Award GetById(int id)
        {
            _db.Awards.TryGetValue(id,out var award);
            return award;
        }

        public bool RemoveById(int id)
        {
            var awards = _db.Awards;
            bool removeResult = awards.Remove(id);
            if (removeResult)
            {
                var userAwardLink = _db.UserAwardLink;
                userAwardLink.RemoveAll(ual => ual.AwardId == id);
                _db.SaveAwards();
                _db.SaveUserAwardLinks();
            }
            return removeResult;
        }

        public void RemoveAll()
        {
            _db.Awards.Clear();
            _db.UserAwardLink.Clear();
            _db.SaveAwards();
            _db.SaveUserAwardLinks();
        }
    }
}
