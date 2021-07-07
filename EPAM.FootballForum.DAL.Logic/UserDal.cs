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
                var Users_Add = "AddUser";
                SqlCommand command = new SqlCommand(Users_Add, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@Password", user.HPassword);
                command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                command.Parameters.AddWithValue("@Role", user.Role);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public string GetRolesForUser(string login)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserExistence(string login)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_SearchByLogin = "SearchUserByLogin";
                SqlCommand command = new SqlCommand(Users_SearchByLogin, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (login == (string)reader[0])
                        return true;
                }
                return false;
            }
        }
    }
}
