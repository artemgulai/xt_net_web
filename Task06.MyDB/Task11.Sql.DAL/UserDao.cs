using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task11.Sql.DAL
{
    public class UserDao : IUserDao
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString;
        public User Add(User user)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_InsertUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var nameParam = new SqlParameter
                { 
                    ParameterName = "@Name",
                    Value = user.Name
                };
                cmd.Parameters.Add(nameParam);

                var dateParam = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth
                };
                cmd.Parameters.Add(dateParam);

                var imageParam = new SqlParameter
                {
                    ParameterName = "@UserImage",
                    Value = Convert.ToBase64String(user.UserImage)
                };
                cmd.Parameters.Add(imageParam);

                int modified = (int)cmd.ExecuteScalar();

                user.Id = modified;
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                List<User> users = new List<User>();
                con.Open();
                var cmd = new SqlCommand("sp_GetAllUsers",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var res = cmd.ExecuteReader();

                while(res.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)res["Id"],
                        Name = (string)res["Name"],
                        DateOfBirth = (DateTime)res["DateOfBirth"],
                        UserImage = Convert.FromBase64String((string)res["UserImage"])
                    });
                }

                return users;
            }
        }

        public User GetById(int id)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_GetUserById",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var idParam = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                };
                cmd.Parameters.Add(idParam);

                var res = cmd.ExecuteReader();

                if (res.Read())
                {
                    return new User
                    {
                        Id = (int)res["Id"],
                        Name = (string)res["Name"],
                        DateOfBirth = (DateTime)res["DateOfBirth"],
                        UserImage = Convert.FromBase64String((string)res["UserImage"])
                    };
                }

                return null;
            }
        }

        public bool GiveAward(int userId,int awardId)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_GiveAward",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserId",userId);
                cmd.Parameters.AddWithValue("AwardId",awardId);

                var res = cmd.ExecuteNonQuery();

                return res != 0;
            }
        }

        public void RemoveAll()
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_RemoveAllUsers",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var res = cmd.ExecuteNonQuery();
            }
        }

        public bool RemoveById(int id)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_RemoveUserById",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var idParam = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                };
                cmd.Parameters.Add(idParam);

                var res = cmd.ExecuteNonQuery();

                if (res != 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool TakeAward(int userId,int awardId)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_TakeAward",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserId",userId);
                cmd.Parameters.AddWithValue("AwardId",awardId);

                var res = cmd.ExecuteNonQuery();

                return res != 0;
            }
        }

        public bool Update(User user)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_UpdateUser",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = user.Id
                };
                cmd.Parameters.Add(idParam);

                var nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name
                };
                cmd.Parameters.Add(nameParam);

                var dateParam = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth
                };
                cmd.Parameters.Add(dateParam);

                var imageParam = new SqlParameter
                {
                    ParameterName = "@UserImage",
                    Value = Convert.ToBase64String(user.UserImage)
                };
                cmd.Parameters.Add(imageParam);

                var res = cmd.ExecuteNonQuery();

                return res != 0;
            }
        }
    }
}
