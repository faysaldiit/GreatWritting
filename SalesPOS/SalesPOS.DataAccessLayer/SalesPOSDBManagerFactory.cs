using System;
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
    public sealed class SalesPOSDBManagerFactory
    {
        private SalesPOSDBManagerFactory()
        {
            //blank constructore.....
        }

        public static IDbConnection GetConnection(DataProvider providerType)
        {
            IDbConnection iDbConnection = null;

            switch (providerType)
            {
                case DataProvider.SqlServer:
                    iDbConnection = new SqlConnection();

                    break;

                case DataProvider.OleDb:
                    iDbConnection = new OleDbConnection();
                    break;

                case DataProvider.Odbc:
                    iDbConnection = new OdbcConnection();
                    break;

                //case DataProvider.MySQL:
                //    iDbConnection = new MySqlConnection();
                //    break;

                //case DataProvider.Oracle:
                //    iDbConnection = new OracleConnection();
                //    break;

                default:
                    return null;
            }
            return iDbConnection;
        }
        
        

        public static IDbDataAdapter GetDataAdapter(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    return new SqlDataAdapter();
                case DataProvider.OleDb:
                    return new OleDbDataAdapter();
                case DataProvider.Odbc:
                    return new OdbcDataAdapter();
                //case DataProvider.MySQL:
                //    return new MySqlDataAdapter();
                //case DataProvider.Oracle:
                //    return new OracleDataAdapter();
                default:
                    return null;
            }
        }

        public static IDbTransaction GetTransaction(DataProvider providerType)
        {
            IDbConnection iDbConnection = GetConnection(providerType);
            IDbTransaction iDbTransaction = iDbConnection.BeginTransaction();
            return iDbTransaction;
        }
        
        public static IDbTransaction GetTransaction(DataProvider providerType, IDbConnection iDbConnection)
        {
        
            IDbTransaction iDbTransaction = iDbConnection.BeginTransaction();
            return iDbTransaction;
        }
        
        public static IDbDataParameter GetParameter(DataProvider providerType)
        {
            IDbDataParameter iDataParameter = null;

            switch (providerType)
            {
                case DataProvider.SqlServer:
                    iDataParameter = new SqlParameter();
                    break;
                case DataProvider.OleDb:
                    iDataParameter = new OleDbParameter();
                    break;
                case DataProvider.Odbc:
                    iDataParameter = new OdbcParameter();
                    break;
                //case DataProvider.MySQL:
                //    iDataParameter = new MySqlParameter();
                //    break;
                //case DataProvider.Oracle:
                //    iDataParameter = new OracleParameter();
        //            break;

            }
            
            return iDataParameter;
        }

        public static IDbDataParameter[] GetParameters(DataProvider providerType, int paramsCount)
        {
            IDbDataParameter[] idbParams = new IDbDataParameter[paramsCount];

            switch (providerType)
            {
                case DataProvider.SqlServer:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new SqlParameter();
                    }
                    break;
                case DataProvider.OleDb:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new OleDbParameter();
                    }
                    break;
                case DataProvider.Odbc:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new OdbcParameter();
                    }
                    break;
                //case DataProvider.MySQL:
                //    for (int i = 0; i < paramsCount; ++i)
                //    {
                //        idbParams[i] = new MySqlParameter();
                //    }
                //    break;
                //case DataProvider.Oracle:
                //    for (int i = 0; i < paramsCount; ++i)
                //    {
                //        idbParams[i] = new OracleParameter();
                //    }
                //    break;
                default:
                    idbParams = null;
                    break;
            }
            return idbParams;
        }

        
        public static List<IDbCommand> GetCommandArray(DataProvider providerType)
        {
            List<IDbCommand> idbcommands = new List<IDbCommand>();
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    foreach(IDbCommand idbcommand in idbcommands)
                    {
                        idbcommands.Add(new SqlCommand());
                    }
                    break;
                case DataProvider.Oracle:
                    foreach (IDbCommand idbcommand in idbcommands)
                    {
                        idbcommands.Add(new OracleCommand());
                    }
                    break;
                case DataProvider.OleDb:
                    foreach (IDbCommand idbcommand in idbcommands)
                    {
                        idbcommands.Add(new OleDbCommand());
                    }
                    break;
                case DataProvider.Odbc:
                    foreach (IDbCommand idbcommand in idbcommands)
                    {
                        idbcommands.Add(new OdbcCommand());
                    }
                    break;
                //case DataProvider.MySQL:
                //    foreach (IDbCommand idbcommand in idbcommands)
                //    {
                //        idbcommands.Add(new MySqlCommand());
                //    }
                //    break;
            }
            return idbcommands;
 
        }
        

        public static IDbCommand GetCommand(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    return new SqlCommand();
                case DataProvider.OleDb:
                    return new OleDbCommand();
                case DataProvider.Odbc:
                    return new OdbcCommand();
                //case DataProvider.MySQL:
                //    return new MySqlCommand();
                //case DataProvider.Oracle:
                //    return new OracleCommand();
                default:
                    return null;
            }
        }
    }
}
