using EPAM.FootballForum.Common.Entities;
using System.Collections.Generic;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IUserBll
    {
        bool AddUser (User user);

        string[] GetRolesForUser(string login);

        bool UserAuthentication(string login, string hpassword);

        User GetUser(string login);

        User GetUser(int id);

        bool UpdateUser(User user, string secondRole);

        IEnumerable<User> GetAllUsers();

        bool DeleteUser(int id);

        bool SearchEmail(string email);

        bool SearchUserLogin(string login);
    }
}
