using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IUserBll
    {
        string[] CheckUserAuthData(string login, string email);

        bool AddUser (User user);

        string[] GetRolesForUser(string login);

        bool UserAuthentication(string login, string hpassword);

        User GetUser(string login);

        User GetUser(int id);

        bool UpdateUser(int id, string login, string email);
    }
}
