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

        public string GetRolesForUser(string login)
        {
            throw new System.NotImplementedException();
        }

        public string[] CheckUserAuthData(string login, string email) => _userDal.CheckUserAuthData(login, email);
    }
}
