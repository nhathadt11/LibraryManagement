using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess
{
    class DataProvider
    {
        private static readonly string CONNECTION_STRING
            = ConfigurationManager.ConnectionStrings["LibraryManagement"].ConnectionString;
        private static DataProvider _instance;
        public static DataProvider Instance
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
        public DataTable ExecuteSelectQuery(string sql,
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
                return dataSet.Tables[0];
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
