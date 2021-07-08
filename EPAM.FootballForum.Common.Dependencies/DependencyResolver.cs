using EPAM.FootballForum.BLL.Interfaces;
using EPAM.FootballForum.BLL.Logic;
using EPAM.FootballForum.DAL.Interfaces;
using EPAM.FootballForum.DAL.Logic;

namespace EPAM.FootballForum.Common.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();

                return _instance;
            }
        }

        public IUserDal UserDAL => new UserDal();

        public IUserBll UserBLL => new UserLogic(UserDAL);

        public ITopicDal TopicDAL => new TopicDal();

        public ITopicBLL TopicBLL => new TopicLogic(TopicDAL);

        public IMsgDal MessageDAL => new MessageDal();

        public IMsgBll MessageBLL => new MessageBll(MessageDAL);
    }
}
