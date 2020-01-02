using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task06.DAL
{
    /// <summary>
    /// DAO for Awards stored on HDD.
    /// </summary>
    public class AwardFileDao : IAwardDao
    {
        private readonly Dictionary<int,Award> _awards;
        private static string _filePath = @".awards.json";
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
                IncrementOperationNumber();
                DeleteAward?.Invoke(awardToRemove);
            }

            return removeResult;
        }

        /// <summary>
        /// An event being invoked when Award is removed 
        /// from the collection.
        /// </summary>
        public event Action<Award> DeleteAward = delegate { };

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