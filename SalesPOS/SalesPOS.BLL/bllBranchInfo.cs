using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;
using System.Windows.Forms;

namespace SalesPOS.BLL
{
    public static class bllBranchInfo
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
from dbo.BranchInfo bi left outer join dbo.ActivityInfo ai
on ai.ActivityID = bi.ActivityID --Where bi.IsDeleted=0", param);
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

        public static DataTable GetVatRegNo()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"SELECT bi.VatRegistrationNo FROM BranchInfo bi", param);
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

        public static DataTable getById(long TerminalInfoId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@BranchID", TerminalInfoId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_BranchInfo_getbyId", param);
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

        public static bool Insert(BranchInfo objBranchInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 14);

                param[0] = dbManager.getparam("@ActivationDate", objBranchInfo.ActivationDate);
                param[1] = dbManager.getparam("@ActivityID", objBranchInfo.ActivityID.ToString());
                param[2] = dbManager.getparam("@Address", objBranchInfo.Address.ToString());
                param[3] = dbManager.getparam("@BranchCode", objBranchInfo.BranchCode.ToString());
                param[4] = dbManager.getparam("@BranchName", objBranchInfo.BranchName.ToString());
                param[5] = dbManager.getparam("@CompanyID", objBranchInfo.CompanyID.ToString());
                param[6] = dbManager.getparam("@ContactNumber", objBranchInfo.ContactNumber.ToString());
                param[7] = dbManager.getparam("@CreatedBy", objBranchInfo.CreatedBy.ToString());
                param[8] = dbManager.getparam("@CreatedDate", objBranchInfo.CreatedDate);
                param[9] = dbManager.getparam("@Email", objBranchInfo.Email.ToString());
                param[10] = dbManager.getparam("@ExpireDate", objBranchInfo.ExpireDate);
                param[11] = dbManager.getparam("@FAX", objBranchInfo.FAX.ToString());
                param[12] = dbManager.getparam("@VatRegistrationNo", objBranchInfo.VatRegistrationNo.ToString());
                param[13] = dbManager.getparam("@WebURL", objBranchInfo.WebURL.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_BranchInfo_Add", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }

        public static bool Update(BranchInfo objBranchInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 15);

                param[0] = dbManager.getparam("@ActivationDate", objBranchInfo.ActivationDate);
                param[1] = dbManager.getparam("@ActivityID", objBranchInfo.ActivityID.ToString());
                param[2] = dbManager.getparam("@Address", objBranchInfo.Address.ToString());
                param[3] = dbManager.getparam("@BranchCode", objBranchInfo.BranchCode.ToString());
                param[4] = dbManager.getparam("@BranchName", objBranchInfo.BranchName.ToString());
                param[5] = dbManager.getparam("@CompanyID", objBranchInfo.CompanyID.ToString());
                param[6] = dbManager.getparam("@ContactNumber", objBranchInfo.ContactNumber.ToString());
                param[7] = dbManager.getparam("@UpdatedBy", objBranchInfo.UpdatedBy.ToString());
                param[8] = dbManager.getparam("@UpdatedDate", objBranchInfo.UpdatedDate);
                param[9] = dbManager.getparam("@Email", objBranchInfo.Email.ToString());
                param[10] = dbManager.getparam("@ExpireDate", objBranchInfo.ExpireDate);
                param[11] = dbManager.getparam("@FAX", objBranchInfo.FAX.ToString());
                param[12] = dbManager.getparam("@VatRegistrationNo", objBranchInfo.VatRegistrationNo.ToString());
                param[13] = dbManager.getparam("@WebURL", objBranchInfo.WebURL.ToString());
                param[14] = dbManager.getparam("@BranchID", objBranchInfo.BranchID.ToString());


                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_BranchInfo_Update", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }
        //public static bool Delete(long TerminalID)
        //{
        //    ISalesPOSDBManager dbManager = new SalesPOSDBManager();
        //    Boolean chk = false;
        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
        //        param[0] = dbManager.getparam("@TerminalID", TerminalID);
        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_terminalInfo_delete", param);

        //        chk = dbManager.ExecuteQuery(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        dbManager.Dispose();

        //    }
        //    return chk;
        //}
    }
}
