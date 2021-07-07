using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IUserBll
    {
        string[] CheckUserAuthData(string login, string email);

        bool AddUser (User user);

        string GetRolesForUser(string login);
    }
}
