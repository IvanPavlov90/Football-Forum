using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
using System;
using System.Collections.Generic;
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
                command.Parameters.AddWithValue("@SecondRole", user.SecondRole);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public string[] GetRolesForUser(string login)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] result = new string[2];
                var Users_GetRole = "GetRole";
                SqlCommand command = new SqlCommand(Users_GetRole, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result[0] = (string)reader[0];
                    if (result[1] != "")
                    {
                        result[1] = (string)reader[1];
                        return result;
                    } else
                    {
                        result[1] = String.Empty;
                        return result;
                    }
                }
                return result;
            }
        }

        public bool UserAuthentication(string login, string hpassword)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_CheckLoginAndPassword = "ValidateAuthData";
                SqlCommand command = new SqlCommand(Users_CheckLoginAndPassword, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", hpassword);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (login == (string)reader[0] && hpassword == (string)reader[1])
                    return true;
                }
                return false;
            }
        }

        public User GetUser(string login)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_GetUser = "GetUserByLogin";
                SqlCommand command = new SqlCommand(Users_GetUser, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User(
                        id: (int)reader["id"],
                        login: (string)reader["Login"],
                        email: (string)reader["Email"],
                        age: (int)reader["Age"],
                        createdAt: (string)reader["CreatedAt"]
                    );
                }
                throw new InvalidOperationException("Cannot find user with such login = " + login);
            }
        }

        public User GetUser(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_GetUser = "GetUserById";
                SqlCommand command = new SqlCommand(Users_GetUser, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User(
                        id: (int)reader["id"],
                        login: (string)reader["Login"],
                        email: (string)reader["Email"],
                        age: (int)reader["Age"],
                        createdAt: (string)reader["CreatedAt"]
                    );
                }
                throw new InvalidOperationException("Cannot find user with such id = " + id);
            }
        }

        public bool UpdateUser(User user, string secondRole)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_Update = "UpdateUser";
                SqlCommand command = new SqlCommand(Users_Update, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", user.ID);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@SecondRole", secondRole);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_GetAllUsers = "GetAllUsers";
                SqlCommand command = new SqlCommand(Users_GetAllUsers, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new User(
                        id: (int)reader["id"],
                        login: (string)reader["Login"],
                        age: (int)reader["Age"],
                        email: (string)reader["Email"],
                        createdAt: (string)reader["CreatedAt"]
                    );
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Users_Delete = "DeleteUser";
                SqlCommand command = new SqlCommand(Users_Delete, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool SearchEmail(string email)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] result = new string[2];
                var Users_SearchEmail = "SearchEmail";
                SqlCommand command = new SqlCommand(Users_SearchEmail, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Email", email);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (email == (string)reader[0])
                        return true;
                }
                return false;
            }
        }

        public bool SearchUserLogin(string login)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] result = new string[2];
                var Users_SearchLogin = "SearchLogin";
                SqlCommand command = new SqlCommand(Users_SearchLogin, _connection)
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
