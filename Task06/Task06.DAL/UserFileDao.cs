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
    public class UserFileDao : IUserDao
    {
        private static string filePath = @"users.txt";
        private static int operationNumber = 0;
        private readonly Dictionary<int,User> _users;

        public UserFileDao()
        {
            if (File.Exists(filePath))
            {
                using (var streamReader = new StreamReader(File.Open(filePath,FileMode.Open)))
                {
                    string fileContent = streamReader.ReadLine();
                    _users = JsonConvert.DeserializeObject<Dictionary<int,User>>(fileContent);
                }
            }
            else
            {
                _users = new Dictionary<int,User>();
            }
        }

        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0 ? _users.Keys.Max() : 0;

            user.Id = lastId + 1;

            _users.Add(user.Id,user);

            IncrementOperationNumber();
            
            return user;
        }

        public User GetById(int id)
        {
            _users.TryGetValue(id,out var user);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public bool RemoveById(int id)
        {
            bool removeResult = _users.Remove(id);
            if (removeResult)
            {
                IncrementOperationNumber();
            }
            return removeResult;
        }

        public bool GiveAward(int id, Award award)
        {
            return _users[id].AddAward(award);
        }

        public bool TakeAwayAward(int id, Award award)
        {
            return _users[id].RemoveAward(award);
        }

        public void OnDeleteAwardHandler(Award award)
        {
            foreach (var user in _users)
            {
                user.Value.RemoveAward(award);
            }
        }

        private void WriteUsers()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (var streamWriter = new StreamWriter(File.Open(filePath,FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_users));
            }
        }

        private void IncrementOperationNumber()
        {
            operationNumber++;

            if (operationNumber == 2)
            {
                WriteUsers();
                operationNumber = 0;
            }
        }

        ~UserFileDao()
        {
            WriteUsers();
        }
    }
}
