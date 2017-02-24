using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class DataProvider
    {
        private static readonly string CONNECTION_STRING
            = ConfigurationManager.ConnectionStrings["LibraryManagement"].ConnectionString;
        private DataProvider _instance;
        public DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataProvider();
                }
                return _instance;
            }
        }
        public DataSet ExecuteSelectQuery(string sql,
                                          CommandType cmdType = CommandType.StoredProcedure,
                                          params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = cmdType;
                command.Parameters.AddRange(sqlParameters);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
        }
        public int ExecuteNonSelectQuery(string sql,
                                         CommandType cmdType = CommandType.StoredProcedure,
                                         params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = cmdType;
                command.Parameters.AddRange(sqlParameters);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("DataProvider - error: " + e.Message);
                }
            }
        }
    }
}
