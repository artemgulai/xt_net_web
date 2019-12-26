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
    // TODO implement these methods
    /// <summary>
    /// Dao for storing Users in a text file on HDD.
    /// </summary>
    public class UserFileDao : IUserDao
    {
        private static int operationNumber = 0;
        private static readonly Dictionary<int,User> _users;

        static UserFileDao()
        {
            if (File.Exists(@"users.txt"))
            {
                using (var streamReader = new StreamReader(File.Open(@"users.txt",FileMode.Open)))
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

        private void WriteUsers()
        {
            if (File.Exists(@"users.txt"))
            {
                File.Delete(@"users.txt");
            }
            using (var streamWriter = new StreamWriter(File.Open(@"users.txt",FileMode.OpenOrCreate)))
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
