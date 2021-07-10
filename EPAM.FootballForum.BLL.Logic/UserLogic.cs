using EPAM.FootballForum.BLL.Interfaces;
using EPAM.FootballForum.Common.Entities;
using EPAM.FootballForum.DAL.Interfaces;

namespace EPAM.FootballForum.BLL.Logic
{
    public class UserLogic : IUserBll
    {
        private IUserDal _userDal;

        public UserLogic(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool AddUser(User user) => _userDal.AddUser(user);

        public string[] GetRolesForUser(string login) => _userDal.GetRolesForUser(login);

        public string[] CheckUserAuthData(string login, string email) => _userDal.CheckUserAuthData(login, email);

        public bool UserAuthentication(string login, string hpassword) => _userDal.UserAuthentication(login, hpassword);

        public User GetUser(string login) => _userDal.GetUser(login);

        public User GetUser(int id) => _userDal.GetUser(id);

        public bool UpdateUser(int id, string login, string email) => _userDal.UpdateUser(id, login, email);
    }
}
