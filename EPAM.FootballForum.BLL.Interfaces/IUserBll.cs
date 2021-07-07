using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IUserBll
    {
        bool CheckUserExistence(string login);

        bool AddUser (User user);

        string GetRolesForUser(string login);
    }
}
