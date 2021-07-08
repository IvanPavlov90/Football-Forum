using EPAM.FootballForum.Common.Entities;
using System.Collections.Generic;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface ITopicDal
    {
        bool AddTopic(Topic newTopic);

        IEnumerable<Topic> GetAllTopics();

        Topic GetTopicById(int id);
    }
}
