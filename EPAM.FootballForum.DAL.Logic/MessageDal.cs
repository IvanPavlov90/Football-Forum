using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace EPAM.FootballForum.DAL.Logic
{
    public class MessageDal : IMsgDal
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddMessage(Message newMessage)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var Messages_Add = "AddMessage";
                SqlCommand command = new SqlCommand(Messages_Add, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Topic_id", newMessage.TopicID);
                command.Parameters.AddWithValue("@Creator_id", newMessage.CreatorID);
                command.Parameters.AddWithValue("@Text", newMessage.Text);
                command.Parameters.AddWithValue("@Created_At", newMessage.CreatedAt);
                command.Parameters.AddWithValue("@Update_At", newMessage.UpdatedAt);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
