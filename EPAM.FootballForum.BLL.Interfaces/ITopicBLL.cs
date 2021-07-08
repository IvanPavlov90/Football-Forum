using EPAM.FootballForum.Common.Entities;
using System.Collections.Generic;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface ITopicBLL
    {
        bool AddTopic(Topic newTopic);

        IEnumerable<Topic> GetAllTopics();

        Topic GetTopicById(int id);
    }
}
