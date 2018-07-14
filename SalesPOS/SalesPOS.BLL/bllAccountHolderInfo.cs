using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;
using System.Data;
using System.Windows.Forms;

namespace SalesPOS.BLL
{
    public static class bllAccountHolderInfo
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;


                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"SELECT *
from dbo.AccountHolderInfo ahi left outer join dbo.ActivityInfo ai
on ai.ActivityID = ahi.ActivityID
left outer join dbo.AccountHolderType aht on ahi.AccountHolderTypeID  = aht.AccountHolderTypeID 
Where ahi.IsDeleted=0", param);
                dt = dbManager.GetDataTable(cmd);


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }
            return dt;
        }
        
        public static DataTable getAllCustomer()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;

                string sql = @"SELECT *
                                from dbo.AccountHolderInfo ahi left outer join dbo.ActivityInfo ai
                                on ai.ActivityID = ahi.ActivityID
                                left outer join dbo.AccountHolderType aht on ahi.AccountHolderTypeID  = aht.AccountHolderTypeID 
                                Where ahi.IsDeleted=0 AND aht.AccountHolderTypeID = " + (Int64)bllUtility.GlobalEnum.AccountHolderType.Customer + "";
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, sql, param);
                dt = dbManager.GetDataTable(cmd);
                dt.Columns.Add("ActivityName");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            if (dr["ActivityID"].ToString().Equals("1"))
                            {
                                dr["ActivityName"] = "Active";
                            }
                            else
                            {
                                dr["ActivityName"] = "Inactive";

                            }
                        }
                        catch { }
                    }
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }
            return dt;
        }

        public static DataTable getAllCustomerOrSupplier(Int64 TypeCustOrSupp)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;

                string sql = @"SELECT *
                                from dbo.AccountHolderInfo ahi left outer join dbo.ActivityInfo ai
                                on ai.ActivityID = ahi.ActivityID
                                left outer join dbo.AccountHolderType aht on ahi.AccountHolderTypeID  = aht.AccountHolderTypeID 
                                Where ahi.IsDeleted=0 AND aht.AccountHolderTypeID = " + TypeCustOrSupp + "";
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, sql, param);
                dt = dbManager.GetDataTable(cmd);
                dt.Columns.Add("ActivityName");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            if (dr["ActivityID"].ToString().Equals("1"))
                            {
                                dr["ActivityName"] = "Active";
                            }
                            else
                            {
                                dr["ActivityName"] = "Inactive";

                            }
                        }
                        catch { }
                    }
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }
            return dt;
        }

        public static DataTable getById(long AccHolderInfoId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@AccHolderInfoId", AccHolderInfoId);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[usp_AccHolderInfo_getbyId]", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }
            return dt;
        }

        public static bool Insert(AccountHolderInfo objAccountHolderInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 10);

                param[0] = dbManager.getparam("@AccHolderName", objAccountHolderInfo.AccHolderName.ToString());
                param[1] = dbManager.getparam("@AccountHolderTypeID", objAccountHolderInfo.AccountHolderTypeID.ToString());
                //param[2] = dbManager.getparam("@AccountNo", objAccountHolderInfo.AccountNo.ToString());
                param[2] = dbManager.getparam("@ActivityID", objAccountHolderInfo.ActivityID);
                param[3] = dbManager.getparam("@Address", objAccountHolderInfo.Address.ToString());
                param[4] = dbManager.getparam("@ContactNo", objAccountHolderInfo.ContactNo);
                param[5] = dbManager.getparam("@CreatedDate", objAccountHolderInfo.CreatedDate);
                param[6] = dbManager.getparam("@CreatedBy", objAccountHolderInfo.CreatedBy.ToString());
                param[7] = dbManager.getparam("@IsDeleted", false);
                param[8] = dbManager.getparam("@ZoneID", objAccountHolderInfo.ZoneID);
                param[9] = dbManager.getparam("@RSMID", objAccountHolderInfo.RSMID);
                //objAccountHolderInfo.AccountNo.ToString().Substring(3);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_AccountHolderInfo_Add", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }

        public static bool Update(AccountHolderInfo objAccountHolderInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);

                param[0] = dbManager.getparam("@AccHolderInfoId", objAccountHolderInfo.AccHolderInfoId.ToString());
                param[1] = dbManager.getparam("@AccHolderName", objAccountHolderInfo.AccHolderName.ToString());
                param[2] = dbManager.getparam("@Address", objAccountHolderInfo.Address.ToString());
                param[3] = dbManager.getparam("@ContactNo", objAccountHolderInfo.ContactNo.ToString());                
                param[4] = dbManager.getparam("@ActivityID", objAccountHolderInfo.ActivityID.ToString());                
                param[5] = dbManager.getparam("@UpdatedDate", objAccountHolderInfo.UpdatedDate);
                param[6] = dbManager.getparam("@UpdatedBy", objAccountHolderInfo.UpdatedBy.ToString());
                param[7] = dbManager.getparam("@ZoneID", objAccountHolderInfo.ZoneID);
                param[8] = dbManager.getparam("@RSMID", objAccountHolderInfo.RSMID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_AccountHolderInfo_Update", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }

        public static bool Delete(long TerminalID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@TerminalID", TerminalID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_terminalInfo_delete", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }

        public static DataTable GetAccountHolderInfo(string AccountNo, string AccountHolderTypeID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                param[0] = dbManager.getparam("@AccountNo", AccountNo);
                param[1] = dbManager.getparam("@AccountHolderTypeID", AccountHolderTypeID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[USP_GetAccountHolderInfoByAccountNo]", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }
            return dt;
        }
    }
}
