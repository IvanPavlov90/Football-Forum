using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
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
    }
}
