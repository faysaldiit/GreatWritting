using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Configuration;
using System.IO;
using SalesPOS.BOL;

namespace SalesPOS.DataAccessLayer
{
    public sealed class SalesPOSDBManager : ISalesPOSDBManager, IDisposable
    {
        private IDbConnection idbConnection;
        private IDataReader idataReader;
        private IDbCommand idbCommand;
        private List<IDbCommand> idbCommands = null;
        private DataProvider providerType;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private string strConnection;
        private Hashtable _objHashtable;
        private string _serverpath;
        private char _operationType;
        private static OleDbConnection con;

        public Hashtable objHashtable
        {
            get
            {
                return _objHashtable;
            }
            set
            {
                _objHashtable = value;
            }
        }
        public string serverpath
        {
            get
            {
                return _serverpath;
            }
            set
            {
                _serverpath = value;
            }
        }
        public char operationType
        {
            get { return _operationType; }
            set { _operationType = value; }
        }

        public SalesPOSDBManager()
        {
            try
            {
                
                ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
                string ProviderName = "System.Data.SqlClient"; //settings["QISSConnectionString"].ProviderName.ToString();

                this.ConnectionString = "Data Source=" + UserInfo.DB_Source + ";Initial Catalog=" + UserInfo.DB_Name + ";Persist Security Info=True;User ID=" + UserInfo.DB_User + ";  password=" + UserInfo.DB_Pass + ";Connect Timeout=0"; 
                
                if (ProviderName.ToString().Equals("System.Data.SqlClient"))
                {
                    this.providerType = DataProvider.SqlServer;
                }

                if (ProviderName.ToString().Equals("System.Data.OracleClient"))
                {
                    this.providerType = DataProvider.Oracle;
                }

                if (ProviderName.ToString().Equals("System.Data.Odbc"))
                {
                    this.providerType = DataProvider.Odbc;
                }             
                
            }
            catch (SqlException ex)
            {
                throw (ex);
            }

        }
        public SalesPOSDBManager(DataProvider providerType)
        {
            this.providerType = providerType;
        }
        public SalesPOSDBManager(DataProvider providerType, string connectionString)
        {
            this.providerType = providerType;
            this.strConnection = connectionString;
        }
        public IDbConnection Connection
        {
            get
            {
                return idbConnection;
            }
        }
        public IDataReader DataReader
        {
            get
            {
                return idataReader;
            }
            set
            {
                idataReader = value;
            }
        }

        public DataProvider ProviderType
        {
            get
            {
                return providerType;
            }
            set
            {
                providerType = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return idbCommand;
            }
        }

        public List<IDbCommand> Commands
        {
            get
            {
                return idbCommands;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return idbTransaction;
            }
        }

        public IDbDataParameter[] Parameters
        {
            get
            {
                return idbParameters;
            }
        }

        public void Open()
        {
            idbConnection = SalesPOSDBManagerFactory.GetConnection(this.providerType);
            idbConnection.ConnectionString = this.ConnectionString;
            if (idbConnection.State != ConnectionState.Open)
                idbConnection.Open();

        }

        public void Close()
        {
            if (idbConnection.State != ConnectionState.Closed)
                idbConnection.Close();
        }

        public void Dispose()
        {
            // GC.SupressFinalize(this);
            this.Close();
            this.idbCommand = null;
            this.idbTransaction = null;
            this.idbConnection = null;
        }

        public void CreateParameters(int paramsCount)
        {
            idbParameters = new IDbDataParameter[paramsCount];
            idbParameters = SalesPOSDBManagerFactory.GetParameters(this.ProviderType, paramsCount);
        }


        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
            }
        }


        public void AddParameters(int index, string paramName)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
            }
        }


        public IDbDataParameter getparam(string paramName, object objValue)
        {
            IDbDataParameter param = SalesPOSDBManagerFactory.GetParameter(this.providerType);
            param.Value = objValue;
            param.ParameterName = paramName;

            return param;

        }



        public void BeginTransaction()
        {
            try
            {
                if (this.idbTransaction == null)
                    idbTransaction = SalesPOSDBManagerFactory.GetTransaction(this.ProviderType, this.idbConnection); // rasoo

                // this.idbCommand.Transaction = idbTransaction;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
        }


        public void RollBackTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Rollback();
            idbTransaction = null;
        }


        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            this.idbCommand = SalesPOSDBManagerFactory.GetCommand(this.ProviderType);
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            this.DataReader = idbCommand.ExecuteReader();
            idbCommand.Parameters.Clear();
            return this.DataReader;
        }


        public void CloseReader()
        {
            if (this.DataReader != null)
                this.DataReader.Close();
        }


        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput)
                &&
                  (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }



        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        public IDbCommand getCommand(CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            IDbCommand command = SalesPOSDBManagerFactory.GetCommand(this.providerType);
            try
            {

                command.Connection = this.idbConnection;

                command.CommandText = commandText;
                command.CommandType = commandType;
                if (commandParameters != null)
                {
                    AttachParameters(command, commandParameters);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
            return command;
        }


        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            BeginTransaction();
            try
            {
                this.idbCommand = SalesPOSDBManagerFactory.GetCommand(this.ProviderType);
                PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
                int returnValue = idbCommand.ExecuteNonQuery();
                idbCommand.Parameters.Clear();
                CommitTransaction();
                return returnValue;
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw (ex);
                //return -2;
            }
        }


        public Boolean ExecuteTransaction(List<IDbCommand> cmd)
        {

            BeginTransaction();
            try
            {
                foreach (IDbCommand command in cmd)
                {
                    command.Transaction = this.idbTransaction;
                    command.Connection = this.idbConnection;
                    command.ExecuteNonQuery();
                }
                #region For_File_Attachment_Transaction

                //bool chk = true;
                try
                {
                    UploadFilesToServer();

                }
                catch
                {
                    //chk = false;
                    RollBackTransaction();
                    DeleteUploadedFilesForRolback();
                    return false;
                }


                #endregion

                CommitTransaction();
                return true;
            }
            //catch (Exception ex)
            //{

            //    RollBackTransaction();
            //    return false;

            //}
            catch (SqlException ex)
            {
                RollBackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        /// this potion is done to upload file/ attachment  to the server.
        /// RASEL
        /// </summary>
        private void UploadFilesToServer()
        {

            #region
            try
            {

                if (this.objHashtable != null)
                {
                    if (this.operationType == 'I' || this.operationType == 'U')
                    {
                        if (this.objHashtable.Count > 0)
                        {
                            IDictionaryEnumerator objEnumeratore = this.objHashtable.GetEnumerator();

                            while (objEnumeratore.MoveNext())
                            {
                                //string str_Source = objEnumeratore.Value.ToString();
                                //string str_Destination = objEnumeratore.Key.ToString();// serverpath.ToString() + objEnumeratore.Key.ToString();
                                //File.Copy(str_Source, str_Destination);

                                //added by azam
                                string str_Source = objEnumeratore.Key.ToString();
                                byte[] Buffer1 = (byte[])objEnumeratore.Value;// serverpath.ToString() + objEnumeratore.Key.ToString();
                                //File.Copy(str_Source, str_Destination);
                                FileStream newFile = new FileStream(str_Source, FileMode.Create);
                                // Write data to the file
                                newFile.Write(Buffer1, 0, Buffer1.Length);
                                // Close file
                                Buffer1 = null;
                                newFile.Close();

                            }
                        }
                    }

                    else if (this.operationType == 'D')
                    {
                        if (this.objHashtable.Count > 0)
                        {
                            IDictionaryEnumerator objEnumeratore = this.objHashtable.GetEnumerator();
                            while (objEnumeratore.MoveNext())
                            {
                                string FileName = objEnumeratore.Value.ToString();
                                File.Delete(FileName); //this.serverpath + 

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
        }
        private void DeleteUploadedFilesForRolback()
        {
            if (this.objHashtable.Count > 0)
            {
                IDictionaryEnumerator objEnumeratore = this.objHashtable.GetEnumerator();
                while (objEnumeratore.MoveNext())
                {
                    try
                    {
                        string FileName = objEnumeratore.Value.ToString();
                        File.Delete(FileName); //this.serverpath +                                    
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
        }
        public Boolean ExecuteQuery(IDbCommand cmd)
        {
            BeginTransaction();
            try
            {
                cmd.Transaction = this.idbTransaction;
                cmd.Connection = this.idbConnection;
                cmd.ExecuteNonQuery();
                bool chk = true;
                try
                {

                    UploadFilesToServer();

                }
                catch (Exception ex)
                {
                    //chk = false;
                    RollBackTransaction();
                    DeleteUploadedFilesForRolback();
                    throw (ex);
                    //return false;
                }
                CommitTransaction();
                return chk;
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw (ex);
                //return false;
            }

        }

        public object ExecuteScalar(IDbCommand cmd)
        {

            try
            {
                // this.Open();
                cmd.Connection = this.idbConnection;
                return cmd.ExecuteScalar();
            }

            catch (Exception ex)
            {
                //return cmd.ExecuteScalar();
                throw (ex);
            }
            finally
            {
                //this.Dispose();   


            }

        }


        public DataSet GetDataSet(IDbCommand cmd)
        {

            DataSet dataset = new DataSet();
            try
            {
                cmd.Connection = this.idbConnection;
                IDbDataAdapter dataadapter = SalesPOSDBManagerFactory.GetDataAdapter(this.ProviderType);
                dataadapter.SelectCommand = cmd;
                dataadapter.Fill(dataset);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dataset.Dispose();
            }

            return dataset;
        }


        public DataTable GetDataTable(IDbCommand cmd)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd.Connection = this.idbConnection;
                IDbDataAdapter dataadapter = SalesPOSDBManagerFactory.GetDataAdapter(this.ProviderType);
                dataadapter.SelectCommand = cmd;
                dataadapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ds.Dispose();
            }
            return (DataTable)ds.Tables[0];



        }


        public string GetMaxId(string tbName, string field)
        {

            string thisyeaar = string.Empty;
            try
            {
                this.Open();
                String maxIDField = "";
                int num = 0;
                string substr = "";
                DateTime dt = DateTime.Now;
                string y = dt.Year.ToString();
                string m = dt.Month.ToString();
                string d = dt.Day.ToString();
                m = m.PadLeft(2, '0');
                d = d.PadLeft(2, '0');
                thisyeaar = y + "" + m + "" + d;
                string strSQL = "select max(" + field + ") from " + tbName + " where " + field + " Like'" + thisyeaar + "%'";
                this.idbCommand = SalesPOSDBManagerFactory.GetCommand(this.ProviderType);
                idbCommand.Connection = this.idbConnection;
                idbCommand.CommandType = CommandType.Text;
                idbCommand.CommandText = strSQL;


                if (Convert.IsDBNull(idbCommand.ExecuteScalar()))
                {
                    thisyeaar = thisyeaar + "0001";

                }
                else
                {
                    maxIDField = Convert.ToString(idbCommand.ExecuteScalar());
                    int intCardLength = Convert.ToInt32(maxIDField.Length);
                    substr = maxIDField.Substring(intCardLength - 4).ToString();
                    num = Convert.ToInt16(substr) + 1;
                    thisyeaar = thisyeaar + num.ToString().PadLeft(4, '0');
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Dispose();
            }
            return thisyeaar;

        }



    }
}
