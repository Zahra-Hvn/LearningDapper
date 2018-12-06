using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using LearningDapper.Models;

namespace LearningDapper.Repository
{
    public class UserRepo
    {
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public List<User> GetUsers()
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                return con.Query<User>(@"SELECT * FROM Tbl_User").ToList();
            }
        }
        public User GetUserbyId(int id)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                return con.Query<User>(@"SELECT * FROM Tbl_User where Id=@id", new { id }).FirstOrDefault();
            }
        }
        public bool Update(User user)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    var sqlQuery = "UPDATE Tbl_User SET Name = @Name, Family = @Family , Mail = @Mail WHERE Id = @Id";
                    con.Execute(sqlQuery, user);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool Delete(int id)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    var user = GetUserbyId(id);
                    if (user != null)
                    {
                        var sqlQuery = "Delete Tbl_User WHERE Id =" + @id + "";
                        con.Execute(sqlQuery, id);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }

        public bool Create(User user)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    var sqlQuery = "Insert Into Tbl_User(Name,Family,Mail) Values (@Name, @Family ,  @Mail)";
                    con.Execute(sqlQuery, user);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}