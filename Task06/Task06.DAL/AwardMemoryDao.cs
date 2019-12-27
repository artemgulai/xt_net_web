using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.DAL
{
    public class AwardMemoryDao : IAwardDao
    {
        private readonly Dictionary<int,Award> _awards = new Dictionary<int,Award>();

        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0 ? _awards.Keys.Max() : 0;

            award.Id = lastId + 1;

            _awards.Add(award.Id,award);

            return award;
        }

        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        public Award GetById(int id)
        {
            _awards.TryGetValue(id,out var award);
            return award;
        }

        public bool RemoveById(int id)
        {
            Award awardToRemove = _awards[id];
            bool removeResult = _awards.Remove(id);

            if (removeResult)
            {
                DeleteAward?.Invoke(awardToRemove);
            }

            return removeResult;
        }

        public event Action<Award> DeleteAward;
    }
}