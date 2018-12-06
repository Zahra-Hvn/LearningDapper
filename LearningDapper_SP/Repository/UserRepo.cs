using LearningDapper_SP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using static Dapper.SqlMapper;

namespace LearningDapper_SP.Repository
{
    public class UserRepo
    {
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public List<User> GetUsers()
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                return con.Query<User>("GetUsers", CommandType.StoredProcedure).ToList();
            }
        }
        public User GetUserById(int id)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                //IDynamicParameters 
                return con.Query<User>("GetUserById", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public bool UpdateUser(User user)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Execute("UpdateUser", user, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool DeleteUser(int id)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Execute("DeleteUser", new { id }, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool InsertUser(User user)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name",user.Name);
                    param.Add("@Family",user.Family);
                    param.Add("@Mail",user.Mail);
                    con.Execute("AddUser", param, commandType: CommandType.StoredProcedure);
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