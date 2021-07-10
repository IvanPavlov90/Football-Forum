using EPAM.FootballForum.BLL.Interfaces;
using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace EPAM.FootballForum.BLL.Logic
{
    public class MessageBll : IMsgBll
    {
        private IMsgDal _messageDal;

        public MessageBll(IMsgDal messageDal)
        {
            _messageDal = messageDal;
        }

        public bool AddMessage(Message newMessage) => _messageDal.AddMessage(newMessage);

        public bool DeleteMessage(int id) => _messageDal.DeleteMessage(id);

        public IEnumerable<Message> GetAllTopicMessages(int id) => _messageDal.GetAllTopicMessages(id);
    }
}
