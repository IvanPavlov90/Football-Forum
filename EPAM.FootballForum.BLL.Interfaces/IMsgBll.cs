using EPAM.FootballForum.Common.Entities;
using System.Collections.Generic;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IMsgBll
    {
        bool AddMessage(Message newMessage);

        IEnumerable<Message> GetAllTopicMessages(int id);

        bool DeleteMessage(int id);
    }
}
