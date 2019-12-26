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
    public class AwardFileDao : IAwardDao
    {
        private static int operationNumber = 0;
        private static readonly Dictionary<int,Award> _awards;

        static AwardFileDao()
        {
            if (File.Exists("awards.txt"))
            {
                using (var streamReader = new StreamReader(File.Open("awards.txt",FileMode.Open)))
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
            bool removeResult = _awards.Remove(id);
            if (removeResult)
            {
                IncrementOperationNumber();
            }
            return removeResult;
        }

        private void WriteAwards()
        {
            if (File.Exists("awards.txt"))
            {
                File.Delete("awards.txt");
            }
            using (var streamWriter = new StreamWriter(File.Open("awards.txt",FileMode.OpenOrCreate)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_awards));
            }
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
