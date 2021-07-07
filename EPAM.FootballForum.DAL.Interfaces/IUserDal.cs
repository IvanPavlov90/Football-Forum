using EPAM.FootballForum.Common.Entities;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface IUserDal
    {
        bool CheckUserExistence(string login);

        bool AddUser(User user);

        string GetRolesForUser(string login);
    }
}
