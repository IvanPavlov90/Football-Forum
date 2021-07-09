using EPAM.FootballForum.Common.Entities;
using System.Collections.Generic;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface IMsgDal
    {
        bool AddMessage(Message newMessage);

        IEnumerable<Message> GetAllTopicMessages(int id);
    }
}
