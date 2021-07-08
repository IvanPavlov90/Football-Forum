using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EPAM.FootballForum.DAL.Logic
{
    public class TopicDal : ITopicDal
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public bool AddTopic(Topic newTopic)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Topics_Add = "AddTopic";
                SqlCommand command = new SqlCommand(Topics_Add, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Creator_id", newTopic.CreatorID);
                command.Parameters.AddWithValue("@Text", newTopic.Text);
                command.Parameters.AddWithValue("@Created_At", newTopic.CreatedAt);
                command.Parameters.AddWithValue("@Update_At", newTopic.UpdatedAt);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Topics_GetAllTopics = "GetAllTopics";
                SqlCommand command = new SqlCommand(Topics_GetAllTopics, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Topic(
                        id: (int)reader["id"],
                        creatorid: (int)reader["Creator_id"],
                        author: (string)reader["Login"],
                        updatedAt: (DateTime)reader["Update_At"],
                        text: (string)reader["Text"]
                    );
                }
            }
        }
    }
}
