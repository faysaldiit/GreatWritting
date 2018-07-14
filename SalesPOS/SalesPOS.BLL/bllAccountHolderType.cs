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
    public static class bllAccountHolderType
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;


                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select 
* 
from dbo.AccountHolderType aht left outer join dbo.ActivityInfo ai
on ai.ActivityID = aht.ActivityID order by AccountHolderType", param);
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
        public static DataTable getById(long AccountHolderTypeID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@AccountHolderTypeID", AccountHolderTypeID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_accountholdertype_getbyId", param);
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
        public static bool Insert(AccountHolderType objAccountHolderType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                //param[0] = dbManager.getparam("@UnitId", objUnitInfo.UnitId.ToString());
                param[0] = dbManager.getparam("@AccountHolderType", objAccountHolderType.AccountHolderTypeName.ToString());
                param[1] = dbManager.getparam("@ActivityID", objAccountHolderType.ActivityID.ToString());
                param[2] = dbManager.getparam("@CreatedDate", objAccountHolderType.CreatedDate);
                param[3] = dbManager.getparam("@CreatedBy", objAccountHolderType.CreatedBy.ToString());
                param[4] = dbManager.getparam("@AccountHolderTypePrefix", objAccountHolderType.AccountHolderTypePrefix.ToString());
               



                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_AccountHolderType_Add", param);

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
        public static bool Update(AccountHolderType objAccountHolderType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);
                param[0] = dbManager.getparam("@AccountHolderTypeID", objAccountHolderType.AccountHolderTypeID.ToString());
                param[1] = dbManager.getparam("@AccountHolderType", objAccountHolderType.AccountHolderTypeName.ToString());
                param[2] = dbManager.getparam("@ActivityID", objAccountHolderType.ActivityID.ToString());
                param[3] = dbManager.getparam("@UpdatedDate", objAccountHolderType.UpdatedDate);
                param[4] = dbManager.getparam("@UpdatedBy", objAccountHolderType.UpdatedBy.ToString());
                param[5] = dbManager.getparam("@AccountHolderTypePrefix", objAccountHolderType.AccountHolderTypePrefix.ToString());




                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_AccountHolderType_Update", param);

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
        public static DataTable IsDuplicate_AccountHolder_Type(long AccountHolderTypeID, string AccountHolderType, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@AccountHolderTypeID", AccountHolderTypeID);
                param[1] = dbManager.getparam("@AccountHolderType", AccountHolderType);
                param[2] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.[USP_IsDuplicate_AccountHolder_Type]", param);
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
