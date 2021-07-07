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

        public string[] CheckUserAuthData(string login, string email)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] result = new string[2];
                var Users_SearchByLogin = "SearchAuthData";
                SqlCommand command = new SqlCommand(Users_SearchByLogin, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Email", email);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (login == (string)reader[0])
                        result[0] = login;
                    if (email == (string)reader[1])
                        result[1] = email;
                    return result;
                }
                return result; ;
            }
        }
    }
}
