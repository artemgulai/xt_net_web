using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.DAL
{
    /// <summary>
    /// DAO for awards stored in RAM.
    /// </summary>
    public class AwardMemoryDao : IAwardDao
    {
        private readonly Dictionary<int,Award> _awards;

        /// <summary>
        /// Creates an empty collection.
        /// </summary>
        public AwardMemoryDao()
        {
            _awards = new Dictionary<int,Award>();
        }

        /// <summary>
        /// Adds an Award into the collection.
        /// </summary>
        /// <param name="award">Award to be added.</param>
        /// <returns>Award with ID.</returns>
        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0 ? _awards.Keys.Max() : 0;

            award.Id = lastId + 1;

            _awards.Add(award.Id,award);

            return award;
        }

        /// <summary>
        /// Gets all Awards in the collection.
        /// </summary>
        /// <returns>The collection of Awards.</returns>
        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        /// <summary>
        /// Gets Award by ID.
        /// </summary>
        /// <param name="id">ID of Award.</param>
        /// <returns>Award with specified ID.</returns>
        public Award GetById(int id)
        {
            _awards.TryGetValue(id,out var award);
            return award;
        }

        public IEnumerable<Award> GetByIdList(IEnumerable<int> ids)
        {
            var awardsIds = _awards.Where((k) => ids.Contains(k.Key));
            List<Award> awards = new List<Award>(awardsIds.Count());
            foreach (var awardId in awardsIds)
            {
                awards.Add(awardId.Value);
            }
            return awards;
        }

        /// <summary>
        /// Removes Award with specified ID from the collection.
        /// </summary>
        /// <param name="id">ID of Award to be removed.</param>
        /// <returns>
        /// True if Award is removed. 
        /// False if removing is impossible.
        /// </returns>
        public bool RemoveById(int id)
        {
            Award awardToRemove = _awards[id];
            bool removeResult = _awards.Remove(id);

            if (removeResult)
            {
                DeleteAward?.Invoke(awardToRemove.Id);
            }

            return removeResult;
        }

        /// <summary>
        /// An event being invoked when Award is removed 
        /// from the collection.
        /// </summary>
        public event Action<int> DeleteAward;
    }
}