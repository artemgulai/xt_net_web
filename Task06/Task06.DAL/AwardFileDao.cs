using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.DAL
{
    /// <summary>
    /// DAO for Awards stored on HDD.
    /// </summary>
    public class AwardFileDao : IAwardDao
    {
        private readonly IDictionary<int,Award> _awards;
        private const string _filePath = @".awards.json";
        private int _operationNumber;

        /// <summary>
        /// Reads the collection from JSON file on HDD.
        /// If there is no JSON on HDD, an empty
        /// collection is created.
        /// </summary>
        public AwardFileDao()
        {
            if (File.Exists(_filePath))
            {
                using (var streamReader = new StreamReader(File.Open(_filePath,FileMode.Open)))
                {
                    string fileContent = streamReader.ReadLine();
                    _awards = JsonConvert.DeserializeObject<Dictionary<int,Award>>(fileContent);
                }
            }
            else
            {
                _awards = new Dictionary<int,Award>();
            }
            _operationNumber = 0;
        }

        /// <summary>
        /// Adds Award into the collection.
        /// </summary>
        /// <param name="award">Award to be added.</param>
        /// <returns>Award with ID.</returns>
        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0 ? _awards.Keys.Max() : 0;

            award.Id = lastId + 1;

            _awards.Add(award.Id,award);

            IncrementOperationNumber();

            return award;
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

        /// <summary>
        /// Gets all Awards in the collection.
        /// </summary>
        /// <returns>The collection of Awards.</returns>
        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        /// <summary>
        /// Gets a collection of Awards with specified IDs
        /// </summary>
        /// <param name="ids">A collection of Awards' IDs</param>
        /// <returns>A collection of Awards</returns>
        public IEnumerable<Award> GetByIdList(IEnumerable<int> ids)
        {
            return _awards.Values.Where(a => ids.Contains(a.Id));
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
            bool removeResult = _awards.Remove(id);

            if (removeResult)
            {
                IncrementOperationNumber();
                DeleteAward?.Invoke(id);
            }

            return removeResult;
        }

        /// <summary>
        /// An event being invoked when Award is removed 
        /// from the collection.
        /// </summary>
        public event Action<int> DeleteAward = delegate { };

        /// <summary>
        /// Adds User to Award's collection of Users
        /// </summary>
        /// <param name="awardId">ID of an Award</param>
        /// <param name="userId">ID of a User</param>
        public void AddUserToAward(int awardId, int userId)
        {
            IncrementOperationNumber();
            _awards[awardId].Users.Add(userId);
        }

        /// <summary>
        /// Removes User from Award's collection of Users
        /// </summary>
        /// <param name="awardId">ID of an Award</param>
        /// <param name="userId">ID of a User</param>
        public void RemoveUserFromAward(int awardId,int userId)
        {
            IncrementOperationNumber();
            _awards[awardId].Users.Remove(userId);
        }

        /// <summary>
        /// Remove User from all Awards' collection of Users
        /// </summary>
        /// <param name="userId"></param>
        public void OnDeleteUserHandler(int userId)
        {
            foreach (var award in _awards)
            {
                award.Value.Users.Remove(userId);
            }
            WriteAwards();
        }

        /// <summary>
        /// Serializes the collection and writes to HDD.
        /// </summary>
        private void WriteAwards()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            using (var streamWriter = new StreamWriter(File.Open(_filePath,FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_awards));
            }
            File.SetAttributes(_filePath,FileAttributes.Hidden);
        }

        /// <summary>
        /// Increments the number of operations by 1.
        /// Writes the collection to HDD on every 2nd operation.
        /// </summary>
        private void IncrementOperationNumber()
        {
            _operationNumber++;

            if (_operationNumber == 2)
            {
                WriteAwards();
                _operationNumber = 0;
            }
        }

        /// <summary>
        /// Writes the collection on HDD at the 
        /// program's exit.
        /// </summary>
        ~AwardFileDao()
        {
            WriteAwards();
        }
    }
}