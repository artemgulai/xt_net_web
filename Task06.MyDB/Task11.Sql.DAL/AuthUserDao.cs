using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.MyDB.DAL.Interfaces;
using Task06.MyDB.Entities;

namespace Task11.Sql.DAL
{
    public class AuthUserDao : IAuthUserDao
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString;

        public bool AddRole(string login,string roleName)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_GiveRole",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var loginParam = new SqlParameter
                {
                    ParameterName = "Login",
                    Value = login,
                    SqlDbType = SqlDbType.NVarChar
                };

                var roleParam = new SqlParameter
                {
                    ParameterName = "RoleName",
                    Value = roleName,
                    SqlDbType = SqlDbType.NVarChar
                };

                cmd.Parameters.Add(loginParam);
                cmd.Parameters.Add(roleParam);

                int res = cmd.ExecuteNonQuery();

                return res != 0;
            }
        }

        public bool AddUser(AuthUser authUser)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_InsertAuthUser",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Login",authUser.Login);
                cmd.Parameters.AddWithValue("Password",authUser.Password);

                int res = cmd.ExecuteNonQuery();

                if (res == 0)
                {
                    return false;
                }
            }

            foreach (var roleName in authUser.Roles)
            {
                AddRole(authUser.Login,roleName);
            }

            return true;
        }

        public bool ChangePassword(string login,string oldPassword,string newPassword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthUser> GetAll()
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_GetAllAuthUser",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var res = cmd.ExecuteReader();

                List<AuthUser> authUsers = new List<AuthUser>();

                bool nextAvailable = res.Read();

                while (nextAvailable)
                {
                    var authUser = new AuthUser
                    {
                        Login = (string)res["Login"],
                        Password = (string)res["Password"],
                        Roles = new HashSet<string>()
                    };

                    while ((string)res["Login"] == authUser.Login)
                    {
                        authUser.Roles.Add((string)res["Name"]);
                        if (!res.Read())
                        {
                            nextAvailable = false;
                            break;
                        }
                    }
                    authUsers.Add(authUser);
                }

                return authUsers;
            }
        }

        public AuthUser GetByLogin(string login)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_GetAuthUserByLogin",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Login",login);

                var res = cmd.ExecuteReader();

                AuthUser authUser = null;
                if (res.Read())
                {
                    authUser = new AuthUser
                    {
                        Login = (string)res["Login"],
                        Password = (string)res["Password"],
                        Roles = new HashSet<string>()
                    };

                    authUser.Roles.Add((string)res["Name"]);
                    while (res.Read())
                    {
                        authUser.Roles.Add((string)res["Name"]);
                    }
                }

                return authUser;
            }
        }

        public bool RemoveRole(string login,string roleName)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_RemoveRole",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Login",login);
                cmd.Parameters.AddWithValue("RoleName",roleName);

                int res = cmd.ExecuteNonQuery();

                return res != 0;
            }
        }
    }
}
