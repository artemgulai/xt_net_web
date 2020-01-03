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
    /// DAO for Users stored on HDD.
    /// </summary>
    public class UserFileDao : IUserDao
    {
        private readonly Dictionary<int,User> _users;
        private static string _filePath = @".users.json";
        private static int _operationNumber;

        /// <summary>
        /// Reads the collection from JSON file on HDD.
        /// If there is no JSON on HDD, an empty
        /// collection is created.
        /// </summary>
        public UserFileDao()
        {
            if (File.Exists(_filePath))
            {
                using (var streamReader = new StreamReader(File.Open(_filePath,FileMode.Open)))
                {
                    string fileContent = streamReader.ReadLine();
                    _users = JsonConvert.DeserializeObject<Dictionary<int,User>>(fileContent);
                }
            }
            else
            {
                _users = new Dictionary<int,User>();
            }
            _operationNumber = 0;
        }

        /// <summary>
        /// Adds User into the collection.
        /// </summary>
        /// <param name="user">User to be added.</param>
        /// <returns>User with ID.</returns>
        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0 ? _users.Keys.Max() : 0;

            user.Id = lastId + 1;

            _users.Add(user.Id,user);

            IncrementOperationNumber();
            
            return user;
        }

        /// <summary>
        /// Gets User by ID.
        /// </summary>
        /// <param name="id">ID of User.</param>
        /// <returns>User with specified ID.</returns>
        public User GetById(int id)
        {
            _users.TryGetValue(id,out var user);
            return user;
        }

        /// <summary>
        /// Gets all Users in the collection.
        /// </summary>
        /// <returns>The collection of Users.</returns>
        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        /// <summary>
        /// Removes User with specified ID from the collection.
        /// </summary>
        /// <param name="id">ID od User to be removed.</param>
        /// <returns>
        /// True if User is removed.
        /// False if removing is impossible.
        /// </returns>
        public bool RemoveById(int id)
        {
            bool removeResult = _users.Remove(id);
            if (removeResult)
            {
                IncrementOperationNumber();
            }
            return removeResult;
        }

        /// <summary>
        /// Adds Award into User's collection of Awards.
        /// </summary>
        /// <param name="id">User's ID</param>
        /// <param name="award">Award to be added.</param>
        /// <returns>True if Award is added.
        /// False if Award cannot be added.</returns>
        public bool GiveAward(int id, int awardId)
        {
            bool giveResult = _users[id].AddAward(awardId);
            if (giveResult)
            {
                IncrementOperationNumber();
            }
            return giveResult;
        }

        /// <summary>
        /// Removes Award from User's collection of Awards.
        /// </summary>
        /// <param name="id">User's ID.</param>
        /// <param name="award">Award to be removed.</param>
        /// <returns>True if Award is removed.
        /// False if Award cannot be removed.</returns>
        public bool TakeAwayAward(int id, int awardId)
        {
            bool takeResult = _users[id].RemoveAward(awardId);
            if (takeResult)
            {
                IncrementOperationNumber();
            }
            return takeResult;
        }

        /// <summary>
        /// Removes Award from Users' collection of Awards.
        /// </summary>
        /// <param name="award">Removed Award.</param>
        public void OnDeleteAwardHandler(int awardId)
        {
            foreach (var user in _users)
            {
                user.Value.RemoveAward(awardId);
            }
            WriteUsers();
        }

        /// <summary>
        /// Serializes the collection and writes to HDD.
        /// </summary>
        private void WriteUsers()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            using (var streamWriter = new StreamWriter(File.Open(_filePath,FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_users));
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
                WriteUsers();
                _operationNumber = 0;
            }
        }

        /// <summary>
        /// Writes the collection on HDD at the
        /// program's exit.
        /// </summary>
        ~UserFileDao()
        {
            WriteUsers();
        }
    }
}