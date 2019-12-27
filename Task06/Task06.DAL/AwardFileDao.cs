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
    /// DAO for storing Awards on HDD.
    /// </summary>
    public class AwardFileDao : IAwardDao
    {
        private static int operationNumber = 0;
        private readonly Dictionary<int,Award> _awards;
        private static string filePath = @".awards.txt";

        public AwardFileDao()
        {
            if (File.Exists(filePath))
            {
                using (var streamReader = new StreamReader(File.Open(filePath,FileMode.Open)))
                {
                    string fileContent = streamReader.ReadLine();
                    _awards = JsonConvert.DeserializeObject<Dictionary<int,Award>>(fileContent);
                }
            }
            else
            {
                _awards = new Dictionary<int,Award>();
            }
        }

        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0 ? _awards.Keys.Max() : 0;

            award.Id = lastId + 1;

            _awards.Add(award.Id,award);

            IncrementOperationNumber();

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
                IncrementOperationNumber();
                DeleteAward?.Invoke(awardToRemove);
            }

            return removeResult;
        }

        public event Action<Award> DeleteAward;

        private void WriteAwards()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (var streamWriter = new StreamWriter(File.Open(filePath,FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_awards));
            }
            File.SetAttributes(filePath,FileAttributes.Hidden);
        }

        private void IncrementOperationNumber()
        {
            operationNumber++;

            if (operationNumber == 2)
            {
                WriteAwards();
                operationNumber = 0;
            }
        }

        ~AwardFileDao()
        {
            WriteAwards();
        }
    }
}