using EPAM.FootballForum.Common.Entities;
using System.Collections.Generic;

namespace EPAM.FootballForum.DAL.Interfaces
{
    public interface IUserDal
    {
        string[] CheckUserAuthData(string login, string email);

        bool AddUser(User user);

        string[] GetRolesForUser(string login);

        bool UserAuthentication(string login, string hpassword);

        User GetUser(string login);

        User GetUser(int id);

        bool UpdateUser(User user, string secondRole);

        IEnumerable<User> GetAllUsers();

        bool DeleteUser(int id);
    }
}
