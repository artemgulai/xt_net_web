using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DAL.Interfaces;
using Task06.Entities;
using System.IO;
using Newtonsoft.Json;

namespace Task06.DAL
{
    /// <summary>
    /// Dao for storing Users in RAM
    /// </summary>
    public class UserMemoryDao : IUserDao
    {
        private static readonly Dictionary<int,User> _users = new Dictionary<int,User>();

        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0 ? _users.Keys.Max() : 0;
            
            user.Id = _users.Keys.Count + 1;
            
            _users.Add(user.Id,user);
            
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
            return _users.Remove(id);
        }
    }
}
