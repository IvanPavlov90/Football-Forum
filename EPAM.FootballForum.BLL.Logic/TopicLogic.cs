﻿using EPAM.FootballForum.BLL.Interfaces;
using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
using System.Collections.Generic;

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

        public IEnumerable<Topic> GetAllTopics() => _topicDal.GetAllTopics();

        public Topic GetTopicById(int id) => _topicDal.GetTopicById(id);
    }
}
