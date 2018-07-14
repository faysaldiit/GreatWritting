using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.OleDb;
using SalesPOS.BOL;
using SalesPOS.DataAccessLayer;
//using Microsoft.VisualBasic.FileIO;

namespace SalesPOS.DataAccessLayer
{
    public class DataAccess
    {

        #region Common

        private static DataSet iDataSet = new DataSet();
        public static SqlConnection conn = GetConn();
        private static SqlCommand com;
        private static SqlDataReader iReader;
        private string BEGIN = "BEGIN";
        private string COMMIT = "COMMIT";
        private string ROLLBACK = "ROLLBACK";
        private static bool RiseError = false;
        private static string ErrMassege = "";
        private static bool IsTransactionAlive = false;

        private void Command_Initialize()
        {
            conn = GetConn();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (com != null)
                com.Dispose();
            com = new SqlCommand();
            com.CommandTimeout = 180;
            com.CommandType = CommandType.Text;
            com.Connection = conn;
            //com.CommandText = sql;
            //iTransaction = conn.BeginTransaction();
            com.Transaction = conn.BeginTransaction();
            //LastExecutedSqlString = sql;
        }

        private void Transaction(string TransactionType)
        {
            //if (conn.State != ConnectionState.Open)
            //    conn.Open();

            if (iReader != null)
            {
                if (!iReader.IsClosed)
                {
                    iReader.Close();
                }
            }

            switch (TransactionType.ToUpper())
            {
                case "BEGIN":
                    if (IsTransactionAlive == false)
                    {
                        Command_Initialize();
                        IsTransactionAlive = true;
                        RiseError = false;
                        ErrMassege = "";
                    }
                    break;
                case "COMMIT":
                    if (IsTransactionAlive == true)
                    {
                        com.Transaction.Commit();
                        //iTransaction.Commit();
                        IsTransactionAlive = false;
                        conn.Close();
                    }
                    break;
                case "ROLLBACK":
                    if (IsTransactionAlive == true)
                    {
                        com.Transaction.Rollback();
                        //iTransaction.Rollback();
                        IsTransactionAlive = false;
                        conn.Close();
                    }
                    break;
                default:
                    break;
            }
        }
        public void Transaction_Begin()
        {
            Transaction(BEGIN);
        }
        public void Transaction_Commit()
        {
            Transaction(COMMIT);
        }
        public void Transaction_Rollback()
        {
            Transaction(ROLLBACK);
        }

        private DataTable errorhandling(string Msg)
        {
            DataTable DT = new DataTable();
            DataRow row = DT.NewRow();
            DT.Columns.Add("msg");
            DT.Columns.Add("Tag");
            row[0] = Msg;
            row[1] = "Error";
            DT.Rows.Add(row);
            RiseError = true;
            ErrMassege = Msg;
            return DT;
        }

        public bool IsErrorRise()
        {
            bool error = RiseError;
            if (RiseError == true)
            {
                RiseError = false;
            }
            return error;
        }
        public string ErrorMassege()
        {
            string ErrMsg = ErrMassege;
            ErrMassege = "";
            return ErrMsg;
        }

        private static SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            
                conn = DAccessControl.Conn;
          
            return conn;
        }

        


        public DataTable IUD(string SP)
        {
            try
            {
                DataTable dt = new DataTable();
                string Sql = String.Format("EXEC {0}", SP);
                com.CommandText = Sql;
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " ");
            }
        }
        public DataTable IUD(string SP, string Param)
        {
            try
            {
                DataTable dt = new DataTable();
                string Sql = String.Format("EXEC {0}{1}", SP, Param);
                com.CommandText = Sql;
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " ");
            }
        }
        public DataTable IUD(string SP, string[] ColParams)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder Sqlstr = new StringBuilder();
                foreach (string Params in ColParams)
                {
                    Sqlstr.Append(String.Format(" EXEC {0}{1}", SP, Params));
                }
                com.CommandText = Sqlstr.ToString();
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " ");
            }
        }
        public DataTable IUD(string SP, List<string> ColParams)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder Sqlstr = new StringBuilder();
                //conn.Open();
                //using (SqlCommand com = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                //{
                // Start a local transaction

                //com.Transaction = myTrans;

                foreach (string Params in ColParams)
                {
                    Sqlstr.Append(String.Format(" EXEC {0}{1}", SP, Params));
                }
                com.CommandText = Sqlstr.ToString();
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                dt.Load(reader);
                reader.Close();
                //com.ExecuteNonQuery();
                //myTrans.Commit();
                //com.Dispose();
                //}
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " \r\n");

                //try
                //{
                //    Transaction("ROLLBACK");

                //}
                //catch (SqlException ex)
                //{
                //    if (conn != null)
                //    {
                //        return errorhandling("An exception of type " + ex.GetType() +
                //        " was encountered while attempting to roll back the transaction.");
                //    }
                //}

                //return errorhandling("An exception of type " + e.GetType() +
                //                  " was encountered while inserting the data.");
                //return errorhandling("Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }
        public DataTable IUD(string SP, string MstParam, string[] ChdParamsCol)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder Sqlstr = new StringBuilder();

                string Sql = String.Format("EXEC {0}{1}", SP, MstParam);
                com.CommandText = Sql;
                com.ExecuteReader();
                foreach (string Params in ChdParamsCol)
                {
                    Sqlstr.Append(String.Format(" EXEC {0}{1}", SP, Params));
                }
                com.CommandText = Sqlstr.ToString();
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                    return null;
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " ");
            }
        }
        public DataTable IUD(string SP, string MstParam, List<string> ChdParamsCol)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder Sqlstr = new StringBuilder();
                string Sql = String.Format("EXEC {0}{1}", SP, MstParam);
                com.CommandText = Sql;
                com.ExecuteNonQuery();
                foreach (string Params in ChdParamsCol)
                {
                    Sqlstr.Append(String.Format(" EXEC {0}{1}", SP, Params));
                }
                com.CommandText = Sqlstr.ToString();
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                    return null;
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public DataTable IUD(List<string> CommandText)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder Sqlstr = new StringBuilder();
                foreach (string Params in CommandText)
                {
                    Sqlstr.Append(String.Format(" EXEC {0} ", Params));
                }
                com.CommandText = Sqlstr.ToString();
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " \r\nNeither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable GetData(string SP)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    string Sql = String.Format("EXEC {0}", SP);
                    comm.CommandText = Sql;
                    SqlDataAdapter oDap = new SqlDataAdapter(comm);
                    oDap.SelectCommand.CommandTimeout = 3000; //Added by : Bikash on 27-02-2008
                    oDap.Fill(dt);
                    comm.Dispose();
                    return dt;

                    //iReader = comm.ExecuteReader();
                    //if (!iReader.HasRows)
                    //    return null;
                    //dt.Load(iReader);
                    //iReader.Close();
                    //comm.Dispose();
                    //return dt;
                }
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was Read From database.");
            }
        }
        public DataSet GetData(string SP, string Parameter)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    DataSet ds = new DataSet();
                    string Sql = String.Format("EXEC {0}{1}", SP, Parameter);
                    comm.CommandText = Sql;
                    //iReader = comm.ExecuteReader();
                    //if (!iReader.HasRows)
                    //    return null;
                    //dt.Load(iReader);
                    //iReader.Close();
                    //comm.Dispose();
                    //return dt;

                    SqlDataAdapter oDap = new SqlDataAdapter(comm);
                    oDap.SelectCommand.CommandTimeout = 60000;
                    oDap.Fill(ds);
                    oDap.Dispose();
                    comm.Dispose();
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                string dd = ex.Message;
                iDataSet = new DataSet();
                DataTable dt2 = errorhandling(ex.Message + " Neither record was Read From database.");
                iDataSet.Tables.Add(dt2);
                return iDataSet;
                //return errorhandling("An exception of type " + ex.GetType() + " was encountered." + ex.Message + " Neither record was Read From database.");
            }
            //return dt;
        }

        
        


        public DataSet GetDataSet(string SP, string Parameter)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    string Sql = String.Format("EXEC {0}{1}", SP, Parameter);
                    comm.CommandText = Sql;
                    SqlDataAdapter oDap = new SqlDataAdapter(comm);
                    oDap.SelectCommand.CommandTimeout = 3000; //Added by : Bikash on 27-02-2008
                    oDap.Fill(ds);
                    comm.Dispose();
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                iDataSet = new DataSet();
                DataTable dt2 = errorhandling("An exception of type " + ex.GetType() + " was encountered." + ex.Message + " Neither record was Read From database.");
                iDataSet.Tables.Add(dt2);
                return iDataSet;
            }
            //return dt;
        }
        public DataSet GetDatabyQuery(string CommandText)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    DataSet ds = new DataSet();
                    string Sql = CommandText;
                    comm.CommandText = Sql;
                    //iReader = comm.ExecuteReader();
                    //if (!iReader.HasRows)
                    //    return null;
                    //dt.Load(iReader);
                    //iReader.Close();
                    //comm.Dispose();
                    //return dt;

                    SqlDataAdapter oDap = new SqlDataAdapter(comm);
                    oDap.SelectCommand.CommandTimeout = 3000;
                    oDap.Fill(ds);
                    comm.Dispose();
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                string dd = ex.Message;
                iDataSet = new DataSet();
                DataTable dt2 = errorhandling(ex.Message + " Neither record was Read From database.");
                iDataSet.Tables.Add(dt2);
                return iDataSet;
                //return errorhandling("An exception of type " + ex.GetType() + " was encountered." + ex.Message + " Neither record was Read From database.");
            }
            //return dt;
        }
        public DataTable ExecuteQueryWOTrans(string command)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    comm.CommandText = command;
                    SqlDataReader reader = com.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        return null;
                    }
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                dt = errorhandling("An exception of type " + ex.GetType() + " was encountered." + ex.Message + " Neither record was Read From database.");
                return dt;
            }
            //return dt;
        }


        public DataTable IUDwoTrans(string SP, string Parameter)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    DataTable dts = new DataTable();
                    string Sql = String.Format("EXEC {0}{1}", SP, Parameter);
                    comm.CommandText = Sql;
                    set_max_time_for_transaction(5000);
                    //com.CommandText = Sql;
                    SqlDataReader reader = comm.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        return null;
                    }
                    dts.Load(reader);
                    reader.Close();
                    return dts;
                }
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
            //return dt;
        }

        public DataTable InsertImage(string ImageName, byte[] Image, string Code)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder Sqlstr = new StringBuilder();
                com.Parameters.AddWithValue("@ImageName", ImageName);
                com.Parameters.AddWithValue("@Image", Image);
                com.Parameters.AddWithValue("@check_point_number", Code);
                if (Code != "")
                    com.CommandText = "update qcl_qc_checkPoint_t set Images=@Image,image=@ImageName  where check_point_number=@check_point_number";
                else
                    com.CommandText = "update qcl_qc_checkPoint_t set Images=@Image where image=@ImageName";
                SqlDataReader reader = com.ExecuteReader();
                com.Parameters.Clear();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public byte[] GetImage(string ImageName)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {

                    Byte[] Image = new Byte[0];

                    comm.Parameters.AddWithValue("@ImageName", ImageName);
                    comm.CommandText = "select Images from qcl_qc_checkPoint_t where image=@ImageName";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        string ss = dataSet.Tables[0].Rows[0]["Images"].ToString();
                        if (dataSet.Tables[0].Rows[0]["Images"].ToString() != "")
                            Image = (Byte[])(dataSet.Tables[0].Rows[0]["Images"]);
                        //MemoryStream mem = new MemoryStream(data);
                    }
                    return Image;

                }

            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return null;
            }
        }

        public DataTable staff_image_insert(string staff_pin, string company_id, byte[] Image)
        {
            DataTable dt = new DataTable();
            try
            {


                DataTable dt_success = new DataTable();
                com.CommandType = CommandType.StoredProcedure;
                //com.CommandText = @"RecOrderMSTSLGet";
                //decimal MSTSL = Convert.ToDecimal(com.ExecuteScalar());
                com.CommandText = @"crm_staff_photo_insert";
                com.Parameters.AddWithValue("@staff_pin", staff_pin);
                com.Parameters.AddWithValue("@company_id", company_id);
                com.Parameters.AddWithValue("@photo", Image);

                SqlDataReader reader = com.ExecuteReader();
                com.Parameters.Clear();
                com.CommandType = CommandType.Text;
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                dt.Load(reader);
                reader.Close();
                return dt;


                //StringBuilder Sqlstr = new StringBuilder();
                //com.Parameters.AddWithValue("@product_code", product_code);
                //com.Parameters.AddWithValue("@design_number", design_number);
                //com.Parameters.AddWithValue("@image", Image);
                ////if (Code != "")
                ////    com.CommandText = "update qcl_qc_checkPoint_t set Images=@Image,image=@ImageName  where check_point_number=@check_point_number";
                ////else
                //    com.CommandText = "INSERT INTO [dbo].[product_image]([product_code],[design_number],[Images]) VALUES (@product_code,@design_number,@image)";
                //SqlDataReader reader = com.ExecuteReader();
                //com.Parameters.Clear();
                //if (!reader.HasRows)
                //{
                //    reader.Close();
                //    return null;
                //}
                //reader.Close();
                //dt.Load(reader);
                //reader.Close();
                //return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }

        public DataTable image_insert(string product_code, string design_number, byte[] Image)
        {
            DataTable dt = new DataTable();
            try
            {


                DataTable dt_success = new DataTable();
                com.CommandType = CommandType.StoredProcedure;
                //com.CommandText = @"RecOrderMSTSLGet";
                //decimal MSTSL = Convert.ToDecimal(com.ExecuteScalar());
                com.CommandText = @"image_insert";
                com.Parameters.AddWithValue("@product_code", product_code);
                com.Parameters.AddWithValue("@design_number", design_number);
                com.Parameters.AddWithValue("@image", Image);

                SqlDataReader reader = com.ExecuteReader();
                com.Parameters.Clear();
                com.CommandType = CommandType.Text;
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                dt.Load(reader);
                reader.Close();
                return dt;


                //StringBuilder Sqlstr = new StringBuilder();
                //com.Parameters.AddWithValue("@product_code", product_code);
                //com.Parameters.AddWithValue("@design_number", design_number);
                //com.Parameters.AddWithValue("@image", Image);
                ////if (Code != "")
                ////    com.CommandText = "update qcl_qc_checkPoint_t set Images=@Image,image=@ImageName  where check_point_number=@check_point_number";
                ////else
                //    com.CommandText = "INSERT INTO [dbo].[product_image]([product_code],[design_number],[Images]) VALUES (@product_code,@design_number,@image)";
                //SqlDataReader reader = com.ExecuteReader();
                //com.Parameters.Clear();
                //if (!reader.HasRows)
                //{
                //    reader.Close();
                //    return null;
                //}
                //reader.Close();
                //dt.Load(reader);
                //reader.Close();
                //return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public DataTable image_update_without_trans(string product_code, byte[] Image)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection connect = new SqlConnection() { ConnectionString = "Data Source=172.29.50.10;" + "Initial Catalog=AARONG_WAREHOUSE;" + "user id=common;password=com123;" };
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                DataTable dt_success = new DataTable();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = @"image_update";
                command.Parameters.AddWithValue("@product_code", product_code);
                command.Parameters.AddWithValue("@image", Image);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                //SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
                //if (!reader.HasRows)
                //{
                //    reader.Close();
                //    return null;
                //}
                //reader.Close();
                //dt.Load(reader);
                //reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public DataTable replace_warehouse_image_without_trans(string product_code, string base_product_code, string design_number, string image_url, string replace_image, byte[] Image)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection connect = new SqlConnection() { ConnectionString = "Data Source=172.29.50.10;" + "Initial Catalog=AARONG_WAREHOUSE;" + "user id=common;password=com123;" };
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                DataTable dt_success = new DataTable();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = @"replace_image";
                command.Parameters.AddWithValue("@product_code", product_code);
                command.Parameters.AddWithValue("@base_product_code", base_product_code);
                command.Parameters.AddWithValue("@design_number", design_number);
                command.Parameters.AddWithValue("@image_url", image_url);
                command.Parameters.AddWithValue("@delete_full_design_codes", replace_image);
                command.Parameters.AddWithValue("@image", Image);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                //SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
                //if (!reader.HasRows)
                //{
                //    reader.Close();
                //    return null;
                //}
                //reader.Close();
                //dt.Load(reader);
                //reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public DataTable image_process_on_warehouse_db()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection connect = new SqlConnection() { ConnectionString = "Data Source=203.100.203.205;" + "Initial Catalog=AARONG_WAREHOUSE;" + "user id=common;password=com123;" };
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = 7200;
                command.Connection = connect;
                DataTable dt_success = new DataTable();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = @"image_process";
                //command.Parameters.AddWithValue("@product_code", product_code);
                //command.Parameters.AddWithValue("@image", Image);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                //SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
                //if (!reader.HasRows)
                //{
                //    reader.Close();
                //    return null;
                //}
                //reader.Close();
                //dt.Load(reader);
                //reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public DataTable import_new_path_to_warehouse_db()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection connect = new SqlConnection() { ConnectionString = "Data Source=172.29.50.10;" + "Initial Catalog=AARONG_WAREHOUSE;" + "user id=common;password=com123;" };
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                DataTable dt_success = new DataTable();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = @"image_prepare_pending_url";
                //command.Parameters.AddWithValue("@product_code", product_code);
                //command.Parameters.AddWithValue("@image", Image);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                //SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
                //if (!reader.HasRows)
                //{
                //    reader.Close();
                //    return null;
                //}
                //reader.Close();
                //dt.Load(reader);
                //reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }
        public DataTable image_update(string product_code, byte[] Image)
        {
            DataTable dt = new DataTable();
            try
            {
                DataTable dt_success = new DataTable();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = @"image_update";
                com.Parameters.AddWithValue("@product_code", product_code);
                com.Parameters.AddWithValue("@image", Image);

                SqlDataReader reader = com.ExecuteReader();
                com.Parameters.Clear();
                com.CommandType = CommandType.Text;
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                dt.Load(reader);
                reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }


        public byte[] ImageGet(string product_code)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comm = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    StringBuilder Sqlstr = new StringBuilder();

                    Byte[] Image = new Byte[0];

                    comm.Parameters.AddWithValue("@product_code", product_code);
                    comm.CommandText = "select Images from product_image where product_code=@product_code";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        string ss = dataSet.Tables[0].Rows[0]["Images"].ToString();
                        if (dataSet.Tables[0].Rows[0]["Images"].ToString() != "")
                            Image = (Byte[])(dataSet.Tables[0].Rows[0]["Images"]);
                        //MemoryStream mem = new MemoryStream(data);
                    }
                    return Image;
                }

            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return null;
            }
        }


        public DataTable pr_delete_from_warehouse(string command)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection connect = new SqlConnection() { ConnectionString = "Data Source=172.29.50.10;" + "Initial Catalog=AARONG_WAREHOUSE;" + "user id=common;password=com123;" };
                SqlCommand com = new SqlCommand();
                com.CommandTimeout = 7200;
                com.Connection = connect;
                com.CommandType = CommandType.Text;
                com.CommandText = command;
                com.Connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                com.Parameters.Clear();
                com.Connection.Close();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                dt.Load(reader);
                reader.Close();

                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }

        public DataTable pr_data_pull_to_warehouse(string command)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection connect = new SqlConnection() { ConnectionString = "Data Source=172.29.50.10;" + "Initial Catalog=AARONG_WAREHOUSE;" + "user id=common;password=com123;" };
                SqlCommand com = new SqlCommand();
                com.CommandTimeout = 7200;
                com.Connection = connect;
                com.CommandType = CommandType.Text;
                com.CommandText = command;
                com.Connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                com.Parameters.Clear();
                com.Connection.Close();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                dt.Load(reader);
                reader.Close();

                return dt;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return errorhandling(ex.Message + " Neither record was written to database.");
            }
        }

        #endregion

        public void testTransIUD(int Order)
        {
            SqlConnection conn = GetConn();
            SqlTransaction myTrans;
            conn.Open();
            myTrans = conn.BeginTransaction("TSC");
            try
            {
                StringBuilder Sqlstr = new StringBuilder();

                using (SqlCommand com = new SqlCommand() { Connection = conn, CommandType = CommandType.Text })
                {
                    // Start a local transaction

                    com.Transaction = myTrans;
                    com.CommandText = "insert into test1 values(1,'Name1')";
                    com.ExecuteNonQuery();
                    com.CommandText = "insert into test1 values(2,'Name2')";
                    com.ExecuteNonQuery();
                    com.CommandText = "insert into test1 values(3,'Name3')";
                    com.ExecuteNonQuery();
                    com.CommandText = "insert into test2 values(1,'Name1')";
                    com.ExecuteNonQuery();
                    if (Order == 2)
                        myTrans.Commit();
                    com.Dispose();
                }

            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback("TSC");
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_IUD(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("code", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CProductCost", "new_cost"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("TagVale", "new_sales"));//tag_price
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("proposed_with_vat", "tag_price"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "NewPrice";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                //Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_req_post_IUD(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("process_id", "process_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("section_code", "section_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("product_code", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("requisition_number", "requisition_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("event_id", "event_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("shop_code", "shop_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("is_ware", "is_ware"));

                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "ReqPost";
                    bulk.WriteToServer(dt_source);
                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_req_ware_stock_shortage_IUD(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("process_id", "process_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("product_code", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("requisition_number", "requisition_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("shop_code", "shop_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("quantity", "quantity"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "ReqPostWareStockShortage";
                    bulk.WriteToServer(dt_source);
                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_cs_audit_scan(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("central_audit_id", "central_audit_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("computer_id", "computer_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("product_code", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_number", "bill_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("requisition_number", "requisition_no"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("shop_code", "shop_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("tr_Qty", "audit_qty"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("cost_price", "cost_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("creator", "creator"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("scan_by_packet", "scan_by_packet"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("packet_number", "packet_number"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "ad_cst_audit_scan_product_bulk_t";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_cs_yet_to_audit_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("central_audit_id", "central_audit_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("computer_id", "computer_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("product_code", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("shop_code", "shop_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_number", "bill_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("requisition_no", "requisition_no"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("cost_price", "cost_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("audit_qty", "audit_qty"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("system_qty", "system_qty"));
                    bulk.BatchSize = 1000;
                    bulk.BulkCopyTimeout = 300;
                    bulk.DestinationTableName = "ad_cst_yet_to_audit_bulk_t";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }
        public DataTable bulk_product_list_stock_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("product_code", "product_code"));
                    bulk.BatchSize = 1000;
                    bulk.BulkCopyTimeout = 300;
                    bulk.DestinationTableName = "frc_product_list_for_report";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }
        public DataTable bulk_cs_audit_scan_edit(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("central_audit_id", "central_audit_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("computer_id", "computer_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("product_code", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_number", "bill_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("requisition_no", "requisition_no"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("shop_code", "shop_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("audit_qty", "audit_qty"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("cost_price", "cost_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("creator", "creator"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("scan_by_packet", "scan_by_packet"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("packet_number", "packet_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("serial_no", "serial_no"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "ad_cst_audit_scan_edit_product_bulk_t";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_acc_yet_to_audit_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {


                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("audit_id", "audit_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("accessory_code", "accessory_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_no", "bill_no"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("shelf_number", "shelf_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bin_no", "bin_no"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("audit_qty", "audit_qty"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("system_qty", "system_qty"));
                    bulk.BatchSize = 1000;
                    bulk.BulkCopyTimeout = 300;
                    bulk.DestinationTableName = "ad_acc_audit_yet_accessory_shelf_bin_t_bulk";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                //Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_outlet_distribution_ratio_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Association", "association_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S001", "S001"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S002", "S002"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S003", "S003"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S004", "S004"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S005", "S005"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S006", "S006"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S007", "S007"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S008", "S008"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S010", "S010"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S011", "S011"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S013", "S013"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S014", "S014"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S015", "S015"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S016", "S016"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S017", "S017"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S018", "S018"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S019", "S019"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S020", "S020"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("S021", "S021"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "frc_shop_distribution_template_excel_t_step_1";
                    bulk.WriteToServer(dt_source);
                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }


        public DataTable bulk_staff_list_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ComputerID", "ComputerID"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CompanyID", "CompanyID"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("StaffPIN", "StaffPIN"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("StaffName", "StaffName"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DesignationName", "DesignationName"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ProgramName", "ProgramName"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("MobileNo", "MobileNo"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("EmailID", "EmailID"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DateOfBirth", "DateOfBirth"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("is_active", "is_active"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ProgramID", "ProgramID"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "crm_staff_list_bulk_import_t";
                    bulk.WriteToServer(dt_source);
                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        #region oparate with outer Data (Excel,csv)

        public DataSet Read_excell_Data(string Path, string sheet_name)
        {
            try
            {

                DataSet ds = new DataSet();
                //string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\"+Path+";Extended Properties='Excel 8.0;HDR=Yes;'";
                string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
                //string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";" + "Extended Properties=" + "\"" + "Excel 12.0;IME" + "\"";
                //string con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""", Path);
                using (OleDbConnection connection = new OleDbConnection(con))
                {
                    //DataSet dss = Read_csv_Data("", "");
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    OleDbCommand command = new OleDbCommand("select * from [" + dt.Rows[0]["TABLE_NAME"] + "]", connection);
                    OleDbDataAdapter oDap = new OleDbDataAdapter(command);
                    oDap.Fill(ds);
                    connection.Close();
                    return ds;
                }
                return ds;
            }
            catch (Exception ex)
            {
                string dd = ex.Message;
                iDataSet = new DataSet();
                DataTable dt2 = errorhandling(ex.Message + "\r\nNeither record was Read From database.");
                iDataSet.Tables.Add(dt2);
                return iDataSet;
            }
        }

        
        

        public DataTable bulk_IUD_outer(DataTable dt_source)
        {
            //DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;

            //try
            //{
            //    using (SqlBulkCopy bulk = new SqlBulkCopy(DAccessControl.Conn.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            //    {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping(0, 1));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, 2));
                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, 3));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "NewPrice_outer";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_ecom_import_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billNo", "bill_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billDate", "bill_date"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_from", "bill_from"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billTo", "bill_to"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ProductCode", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("costPrice", "cost_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("SalePrice", "sale_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("quantity", "qty"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("is_received", "is_received"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("imported_by", "imported_by"));
                    bulk.BatchSize = 1000;
                    //bulk.BulkCopyTimeout = 300;
                    bulk.DestinationTableName = "ecom_purchase_return_t";
                    bulk.WriteToServer(dt_source);

                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("code", "product_code"));
                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CProductCost", "new_cost"));
                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("TagVale", "new_sales"));
                    //bulk.BatchSize = 1000;
                    //bulk.DestinationTableName = "NewPrice";
                    //bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                //Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }



            ////[bill_number],[bill_date],[bill_from],[bill_to] ,[product_code],[cost_price],[sale_price]
            //// ,[qty],[is_received],[imported_by],[imported_date],[received_by],[received_date]
            //DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;

            //try
            //{
            //    using (SqlBulkCopy bulk = new SqlBulkCopy(DAccessControl.Conn.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            //    {
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billNo", "bill_number"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billDate", "bill_date"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_from", "bill_from"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billTo", "bill_to"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ProductCode", "product_code"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("costPrice", "cost_price"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("SalePrice", "sale_price"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("quantity", "qty"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("is_received", "is_received"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("imported_by", "imported_by"));
            //        bulk.BatchSize = 1000;
            //        bulk.BulkCopyTimeout = 300;
            //        bulk.DestinationTableName = "ecom_purchase_return_t";
            //        bulk.WriteToServer(dt_source);

            //    }
            //    return dt;
            //}
            //catch (Exception e)
            //{
            //    Transaction("ROLLBACK");
            //    return errorhandling(e.Message + " Neither record was written to database.");
            //}
            //finally
            //{
            //    //conn.Close();
            //}
        }

        public DataTable bulk_inter_transfer_import_insert(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billNo", "bill_number"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billDate", "bill_date"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ProductCode", "product_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("costPrice", "cost_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("SalePrice", "sale_price"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("quantity", "qty"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("imported_by", "imported_by"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "pos_erp_ecom_purchase_return_t";
                    bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                //Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public DataTable bulk_scpr_producer_wise_line_map_by_outer_date(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("producer_code", "producer_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("profile_id", "profile_id"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("line_code", "line_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("is_primary", "is_primary"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("creator", "creator"));
                    bulk.BatchSize = 1000;
                    //bulk.BulkCopyTimeout = 300;
                    bulk.DestinationTableName = "scpd_producer_wise_line_map_by_outer_data_t";
                    bulk.WriteToServer(dt_source);

                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("code", "product_code"));
                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CProductCost", "new_cost"));
                    //bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("TagVale", "new_sales"));
                    //bulk.BatchSize = 1000;
                    //bulk.DestinationTableName = "NewPrice";
                    //bulk.WriteToServer(dt_source);

                }
                return dt;
            }
            catch (Exception e)
            {
                //Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }



            ////[bill_number],[bill_date],[bill_from],[bill_to] ,[product_code],[cost_price],[sale_price]
            //// ,[qty],[is_received],[imported_by],[imported_date],[received_by],[received_date]
            //DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;

            //try
            //{
            //    using (SqlBulkCopy bulk = new SqlBulkCopy(DAccessControl.Conn.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            //    {
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billNo", "bill_number"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billDate", "bill_date"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("bill_from", "bill_from"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("billTo", "bill_to"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ProductCode", "product_code"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("costPrice", "cost_price"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("SalePrice", "sale_price"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("quantity", "qty"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("is_received", "is_received"));
            //        bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("imported_by", "imported_by"));
            //        bulk.BatchSize = 1000;
            //        bulk.BulkCopyTimeout = 300;
            //        bulk.DestinationTableName = "ecom_purchase_return_t";
            //        bulk.WriteToServer(dt_source);

            //    }
            //    return dt;
            //}
            //catch (Exception e)
            //{
            //    Transaction("ROLLBACK");
            //    return errorhandling(e.Message + " Neither record was written to database.");
            //}
            //finally
            //{
            //    //conn.Close();
            //}
        }

        #endregion

        private void truncate_table(string table_name)
        {

        }

        public string max_id(string table_id)
        {
            try
            {
                DataTable dt = new DataTable();
                string Sql = "select dbo.sa_getMaxSL('" + table_id + "')";
                com.CommandText = Sql;
                string max_num = com.ExecuteScalar().ToString();

                return max_num;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return ex.Message + " Neither record was written to database.";
            }
        }

        public string get_max_id(string date, string prefix, int table_id)
        {
            try
            {
                DataTable dt = new DataTable();
                string Sql = "";
                if (date == "")
                    Sql = " SELECT dbo.[Get_aging_max_number](GETDATE(), '" + prefix + "', " + table_id + ")";
                else Sql = " SELECT dbo.[Get_aging_max_number](convert(datetime,'" + date + "',103), '" + prefix + "', " + table_id + ")";
                com.CommandText = Sql;
                string max_num = com.ExecuteScalar().ToString();

                Sql = "exec spUpdht_maxsl '" + table_id + "', '" + max_num + "'";
                com.CommandText = Sql;
                com.ExecuteNonQuery();

                return max_num;
            }
            catch (SqlException ex)
            {
                Transaction("ROLLBACK");
                return ex.Message + " Neither record was written to database.";
            }
        }

        public DataTable bulk_line_wise_stock(DataTable dt_source)
        {
            DataTable dt = new DataTable();
            //com.CommandType = CommandType.StoredProcedure;
            SqlConnection conn = GetConn();
            conn.Open();
            try
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    com.CommandType = CommandType.Text;
                    com.CommandText = "delete from rpt_line_wise_stock_report_lines";// where cr_user='" + dt_source.Rows[0]["user"] + "'";
                    com.ExecuteNonQuery();
                    //com.CommandType = CommandType.StoredProcedure;
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("line_code", "line_code"));
                    bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("user", "cr_user"));
                    bulk.BatchSize = 1000;
                    bulk.DestinationTableName = "rpt_line_wise_stock_report_lines";
                    bulk.WriteToServer(dt_source);
                }
                return dt;
            }
            catch (Exception e)
            {
                Transaction("ROLLBACK");
                return errorhandling(e.Message + " Neither record was written to database.");
            }
            finally
            {
                //conn.Close();
            }
        }

        public void set_max_time_for_transaction(int time_is_second)
        {
            com.CommandTimeout = time_is_second;
        }
    }

}
