using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface IUserDal
    {
        bool SearchUser(string login, string hpassword);

        bool AddUser(User user);

        string GetRolesForUser(string login);
    }
}
