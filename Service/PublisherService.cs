using DatabaseAccess.DatabaseAccessObjects;
using DatabaseAccess.DataTransferObjects;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PublisherService : ICommonService<Publisher>,IPublisherService
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

        public List<Publisher> GetPublishers()
        {
            return _publisherDAO.GetAll().Rows.Cast<DataRow>().Select<DataRow,Publisher>(r=>new Publisher {
                PublisherId = Convert.ToInt32(r["PublisherId"]),
                Name = Convert.ToString(r["Name"]),
                Contact = Convert.ToString(r["Contact"]),
                Address = Convert.ToString(r["Address"]),
                Description = Convert.ToString(r["Description"])
            }).ToList();
        }

        public int Update(Publisher publisher)
        {
            return _publisherDAO.Update(publisher);
        }
    }
}
