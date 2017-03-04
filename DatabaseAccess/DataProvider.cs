using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess
{
    public class DataProvider
    {
        private readonly string CONNECTION_STRING
            = Properties.Settings.Default.LibraryManagementConnectionString;
        private static DataProvider _instance;
        public string ConnectionString
        {
            get
            {
                return CONNECTION_STRING;
            }
        }
        private DataProvider() { }
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
        public DataTable ExecuteQuery(string sql,
                                      CommandType cmdType,
                                      params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = cmdType;
                command.Parameters.AddRange(sqlParameters);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public int ExecuteNonQuery(string sql,
                                   CommandType cmdType,
                                   params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = cmdType;
                command.Parameters.AddRange(sqlParameters);
                command.Parameters.Add("@ReturnValue", SqlDbType.Int);
                command.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue; 
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return Convert.ToInt32(command.Parameters["@ReturnValue"].Value);
                }
                catch (Exception e)
                {
                    throw new Exception("DataProvider - error: " + e.Message);
                }
            }
        }
        public int ExecuteScalar(string sql,
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
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    throw new Exception("DataProvider - error: " + e.Message);
                }
            }
        }
    }
}
