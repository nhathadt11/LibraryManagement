using System.Data;
using BussinessLogic.DataTransferObjects;
using BussinessLogic.DatabaseAccessObjects;

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
        public int IsExisted(string Username)
        {
           return _userDAO.IsExisted(Username);
        }
    }
}
