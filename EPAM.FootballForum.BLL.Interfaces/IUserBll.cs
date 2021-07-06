using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IUserBll
    {
        bool SearchUser(string login, string hpassword);

        bool AddUser (User user);

        string GetRolesForUser(string login);
    }
}
