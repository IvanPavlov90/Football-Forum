using EPAM.FootballForum.BLL.Interfaces;
using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;

namespace EPAM.FootballForum.BLL.Logic
{
    public class TopicLogic : ITopicBLL
    {
        private ITopicDal _topicDal;

        public TopicLogic(ITopicDal topicDal)
        {
            _topicDal = topicDal;
        }

        public bool AddTopic(Topic newTopic) => _topicDal.AddTopic(newTopic);
    }
}
