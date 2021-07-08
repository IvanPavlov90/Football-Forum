using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface ITopicDal
    {
        bool AddTopic(Topic newTopic);
    }
}
