using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.Entities;

namespace Task06.MyDB.DataBase
{
    public class DataBase
    {
        private static string _dirPath = Path.Combine("C:/UsersAndAwardsApp","database");
        private static string _usersFile = @".users.json";
        private static string _awardsFile = @".awards.json";
        private static string _userAwardLinkFile = @".userAwardLink.json";
        private static string _authUsersFile = @".auth.json";

        private static DataBase _inst;
        private static Dictionary<int,User> _users;
        private static Dictionary<int,Award> _awards;
        private static List<UserAwardLink> _userAwardLink;
        private static Dictionary<string, AuthUser> _authUsers;

        private DataBase()
        {
            if (!Directory.Exists(_dirPath))
            {
                var dir = Directory.CreateDirectory(_dirPath);
                dir.Attributes |= FileAttributes.Hidden;
            }

            _users = new Dictionary<int,User>();
            foreach(var user in ReadOrCreate<User>(Path.Combine(_dirPath,_usersFile)))
            {
                _users.Add(user.Id,user);
            }

            _awards = new Dictionary<int,Award>();
            foreach (var award in ReadOrCreate<Award>(Path.Combine(_dirPath,_awardsFile)))
            {
                _awards.Add(award.Id,award);
            }

            _userAwardLink = ReadOrCreate<UserAwardLink>(Path.Combine(_dirPath,_userAwardLinkFile));

            _authUsers = new Dictionary<string, AuthUser>();
            //_authUsers.Add("admin",new AuthUser
            //{
            //    Login = "admin",
            //    Password = "admin",
            //    Roles = new HashSet<string> { "ADMIN" }
            //});
            //_authUsers.Add("user",new AuthUser
            //{
            //    Login = "user",
            //    Password = "user",
            //    Roles = new HashSet<string> { "USER" }
            //});
            foreach (var authUser in ReadOrCreate<AuthUser>(Path.Combine(_dirPath,_authUsersFile)))
            {
                _authUsers.Add(authUser.Login,authUser);
            }
            if (!_authUsers.ContainsKey("admin"))
            {
                _authUsers.Add("admin",new AuthUser
                {
                    Login = "admin",
                    Password = "admin",
                    Roles = new HashSet<string> { "ADMIN" }
                });
            }
        }

        public static DataBase Inst
        {
            get
            {
                return _inst ?? (_inst = new DataBase());
            }
        }
        public Dictionary<int,User> Users => _users;
        public Dictionary<int,Award> Awards => _awards;
        public List<UserAwardLink> UserAwardLink => _userAwardLink;

        public Dictionary<string,AuthUser> AuthUsers => _authUsers; 

        private List<T> ReadOrCreate<T>(string path)
        {
            if (File.Exists(path))
            {
                using (var streamReader = new StreamReader(File.Open(path,FileMode.Open)))
                {
                    string fileContent = streamReader.ReadLine();
                    return JsonConvert.DeserializeObject<List<T>>(fileContent);
                }
            }
            else
            {
                return new List<T>();
            }
        }

        private void Write<T>(string path,List<T> collection)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var streamWriter = new StreamWriter(File.Open(path,FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(collection));
            }
            File.SetAttributes(path,FileAttributes.Hidden);
        }

        public void SaveUsers()
        {
            Write(Path.Combine(_dirPath,_usersFile),_users.Values.ToList());
        }

        public void SaveAwards()
        {
            Write(Path.Combine(_dirPath,_awardsFile),_awards.Values.ToList());
        }

        public void SaveUserAwardLinks()
        {
            Write(Path.Combine(_dirPath,_userAwardLinkFile),_userAwardLink);
        }

        public void saveAuthUsers()
        {
            Write(Path.Combine(_dirPath,_authUsersFile),_authUsers.Values.ToList());
        }
    }
}
