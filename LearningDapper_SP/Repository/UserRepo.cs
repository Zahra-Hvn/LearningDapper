using LearningDapper_SP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;


namespace LearningDapper_SP.Repository
{
    public class UserRepo
    {
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public User GetUsers()
        {
            using (var con=new SqlConnection(_ConnectionString))
            {
                //con.Query<>
            }
           
        }

    }
}