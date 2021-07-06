using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EPAM.FootballForum.DAL.Logic
{
    public class UserDal : IUserDal
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddUser(User user)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {

            }
        }

        public string GetRolesForUser(string login)
        {
            throw new NotImplementedException();
        }

        public bool SearchUser(string login, string hpassword)
        {
            throw new NotImplementedException();
        }
    }
}
