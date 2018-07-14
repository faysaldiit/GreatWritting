using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
//using MySql.Data.MySqlClient;
using System.Data.OracleClient; 


namespace SalesPOS.DataAccessLayer
{
    public enum DataProvider
    {
        SqlServer, OleDb, Odbc, MySQL, Oracle
    }
    public interface ISalesPOSDBManager
    {

        DataProvider ProviderType
        {
            get;
            set;
        }
        String ConnectionString
        {
            get;
            set;
        }
        IDbConnection Connection
        {
            get;
        }
        IDbTransaction Transaction
        {
            get;
        }
        IDataReader DataReader
        {
            get;
        }
        IDbCommand Command
        {
            get;
        }
        List<IDbCommand> Commands
        {
            get;
        }
        IDbDataParameter[] Parameters
        {
            get;
        }
        //List<string> file_location
        //{
        //    get;
        //    set;
        //}
        //List<string> file_name
        //{
        //    get;
        //    set;
        //}
        Hashtable objHashtable
        {
            get;
            set;
        }
        string serverpath
        {
            get;
            set;
        }
        char operationType
        {
            get;
            set;
        }

        void Open();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        void CreateParameters(int paramsCount);
        void AddParameters(int index, string paramName, object objValue);
        void AddParameters(int index, string paramName);
        IDataReader ExecuteReader(CommandType commandType, string commandText);
        DataSet GetDataSet(IDbCommand cmd);
        DataTable GetDataTable(IDbCommand cmd);       
        object ExecuteScalar( IDbCommand cmd);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        IDbCommand getCommand(CommandType commandType, string commandText, IDbDataParameter[] commandParameters);
        Boolean ExecuteTransaction(List<IDbCommand> cmd);
        Boolean ExecuteQuery(IDbCommand cmd);
        void CloseReader();
        void Close();
        void Dispose();
        IDbDataParameter getparam(string paramName, object objValue);
        string GetMaxId(string tbName, string field);
    }

}
