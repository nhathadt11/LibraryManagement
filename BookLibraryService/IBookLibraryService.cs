﻿using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace BookLibraryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBookLibraryService
    {

        [OperationContract]
        DataTable GetAll();
        [OperationContract]
        int Add(Book obj);
        [OperationContract]
        int Update(Book obj);
        [OperationContract]
        int Delete(int objId);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
