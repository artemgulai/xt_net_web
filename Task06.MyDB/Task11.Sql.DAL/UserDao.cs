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
        private static string _connectionString = "Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
        + "Integrated Security=true;";

        public User Add(User user)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString))
            {
                con.Open();
                var cmd = new SqlCommand();
                cmd.CommandText = $"insert into dbo.users (Name, DateOfBirth) output inserted.Id values ('{user.Name}', '{user.DateOfBirth.ToString("yyyy-MM-dd")}')";
                cmd.Connection = con;;

                int modified = (int)cmd.ExecuteScalar();

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                user.Id = modified;
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool GiveAward(int userId,int awardId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public bool TakeAward(int userId,int awardId)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
