using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;

namespace Service
{
    public class PublisherService : ICommonService<Publisher>
    {
        private PublisherDAO _publisherDAO;
        public PublisherService()
        {
            _publisherDAO = PublisherDAO.Instance;
        }

        public int Add(Publisher publisher)
        {
            return _publisherDAO.Add(publisher);
        }

        public int Delete(int publisherId)
        {
            return _publisherDAO.Delete(publisherId);
        }

        public DataTable GetAll()
        {
            return _publisherDAO.GetAll();
        }

        public int Update(Publisher publisher)
        {
            return _publisherDAO.Update(publisher);
        }
    }
}
