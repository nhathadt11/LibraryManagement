using System.Data;
using DatabaseAccess.DataTransferObjects;
using DatabaseAccess.DatabaseAccessObjects;

namespace Service
{
    public class UserService : ICommonService<User>
    {
        private UserDAO _userDAO;
        public UserService()
        {
            _userDAO = UserDAO.Instance;
        }
        public int Add(User user)
        {
            return _userDAO.Add(user);
        }

        public int Delete(int userId)
        {
            return _userDAO.Delete(userId);
        }

        public DataTable GetAll()
        {
            return _userDAO.GetAll();
        }

        public int Update(User user)
        {
            return _userDAO.Update(user);
        }
        public int CheckUserById(int userId)
        {
            return _userDAO.CheckUserById(userId);
        }
        public DataTable GetAllLibrarians()
        {
            return _userDAO.GetAllLibrarians();
        }
        public int HasExisted(string Username)
        {
           return _userDAO.HasExisted(Username);
        }
    }
}
