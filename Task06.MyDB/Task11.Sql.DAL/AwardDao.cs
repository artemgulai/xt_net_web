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
    public class AwardDao : IAwardDao
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString;

        public Award Add(Award award)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_InsertAward",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Title", award.Title);
                cmd.Parameters.AddWithValue("AwardImage",Convert.ToBase64String(award.AwardImage));

                int modified = (int)cmd.ExecuteScalar();

                award.Id = modified;
            }

            return award;
        }

        public IEnumerable<Award> GetAll()
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                List<Award> awards = new List<Award>();
                con.Open();
                var cmd = new SqlCommand("sp_GetAllAwards",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var res = cmd.ExecuteReader();

                while (res.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)res["Id"],
                        Title = (string)res["Title"],
                        AwardImage = Convert.FromBase64String((string)res["AwardImage"])
                    });
                }

                return awards;
            }
        }

        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                List<Award> awards = new List<Award>();
                con.Open();
                var cmd = new SqlCommand("sp_GetAwardsByUserId",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id",userId);

                var res = cmd.ExecuteReader();

                while (res.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)res["Id"],
                        Title = (string)res["Title"],
                        AwardImage = Convert.FromBase64String((string)res["AwardImage"])
                    });
                }

                return awards;
            }
        }

        public Award GetById(int id)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_GetAwardById",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id",id);

                var res = cmd.ExecuteReader();

                if (res.Read())
                {
                    return new Award
                    {
                        Id = (int)res["Id"],
                        Title = (string)res["Title"],
                        AwardImage = Convert.FromBase64String((string)res["AwardImage"])
                    };
                }

                return null;
            }
        }

        public void RemoveAll()
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_RemoveAllAwards",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var res = cmd.ExecuteNonQuery();
            }
        }

        public bool RemoveById(int id)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_RemoveAwardById",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                var res = cmd.ExecuteNonQuery();

                return res != 0;
            }
        }

        public bool Update(Award award)
        {
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                var cmd = new SqlCommand("sp_UpdateAward",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", award.Id);
                cmd.Parameters.AddWithValue("@Title", award.Title);
                cmd.Parameters.AddWithValue("@AwardImage",Convert.ToBase64String(award.AwardImage));

                var res = cmd.ExecuteNonQuery();

                return res != 0 ? true : false;
            }
        }
    }
}
