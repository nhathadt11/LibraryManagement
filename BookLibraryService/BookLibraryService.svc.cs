using BookLibraryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookLibraryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookLibraryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookLibraryService.svc or BookLibraryService.svc.cs at the Solution Explorer and start debugging.
    public class BookLibraryService : IBookLibraryService
    {
        public int Add(Book obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(int objId)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Book obj)
        {
            throw new NotImplementedException();
        }
    }
}
