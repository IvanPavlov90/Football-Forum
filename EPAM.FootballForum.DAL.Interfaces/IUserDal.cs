using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface IUserDal
    {
        string[] CheckUserAuthData(string login, string email);

        bool AddUser(User user);

        string[] GetRolesForUser(string login);

        bool UserAuthentication(string login, string hpassword);
    }
}
