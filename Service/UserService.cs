using System.Data;
using BussinessLogic.DataTransferObjects;
using BussinessLogic.DatabaseAccessObjects;

namespace Service
{
    class UserService : ICommonService<User>
    {
        private UserDAO _userDAO;
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
    }
}
