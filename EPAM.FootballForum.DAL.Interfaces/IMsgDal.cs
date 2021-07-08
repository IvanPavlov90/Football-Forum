using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface IMsgDal
    {
        bool AddMessage(Message newMessage);
    }
}
