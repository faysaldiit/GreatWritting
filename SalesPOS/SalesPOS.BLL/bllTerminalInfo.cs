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
    public static class bllTerminalInfo
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
from dbo.TerminalInfo ti left outer join dbo.ActivityInfo ai
on ai.ActivityID = ti.ActivityID Where ti.IsDeleted=0 order by ti.TerminalID", param);
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

                param[0] = dbManager.getparam("@TerminalInfoId", TerminalInfoId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.usp_terminalinfo_getbyId", param);
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

        public static DataTable LoadTerminalList()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ListOfTerminal", param);
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

        public static bool Insert(TerminalInfo objTerminalInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);

                //param[0] = dbManager.getparam("@UnitId", objUnitInfo.UnitId.ToString());
                param[0] = dbManager.getparam("@TerminalName", objTerminalInfo.TerminalName.ToString());
                param[1] = dbManager.getparam("@Attribute", objTerminalInfo.Attribute.ToString());
                param[2] = dbManager.getparam("@ValueOfAttribute", objTerminalInfo.ValueOfAttribute.ToString());
                param[3] = dbManager.getparam("@ActivationDate", objTerminalInfo.ActivationDate);
                param[4] = dbManager.getparam("@ActivityID", objTerminalInfo.ActivityID.ToString());
                param[5] = dbManager.getparam("@ExpireDate", objTerminalInfo.ExpireDate);
                param[6] = dbManager.getparam("@CreatedDate", objTerminalInfo.CreatedDate);
                param[7] = dbManager.getparam("@CreatedBy", objTerminalInfo.CreatedBy.ToString());
                param[8] = dbManager.getparam("@IsDeleted", false);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_TerminalInfo_Add", param);

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

        public static bool Update(TerminalInfo objTerminalInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);

                param[0] = dbManager.getparam("@TerminalID", objTerminalInfo.TerminalID.ToString());
                param[1] = dbManager.getparam("@TerminalName", objTerminalInfo.TerminalName.ToString());
                param[2] = dbManager.getparam("@Attribute", objTerminalInfo.Attribute.ToString());
                param[3] = dbManager.getparam("@ValueOfAttribute", objTerminalInfo.ValueOfAttribute.ToString());
                param[4] = dbManager.getparam("@ActivationDate", objTerminalInfo.ActivationDate);
                param[5] = dbManager.getparam("@ActivityID", objTerminalInfo.ActivityID.ToString());
                param[6] = dbManager.getparam("@ExpireDate", objTerminalInfo.ExpireDate);                
                param[7] = dbManager.getparam("@UpdatedDate", objTerminalInfo.UpdatedDate);
                param[8] = dbManager.getparam("@UpdatedBy", objTerminalInfo.UpdatedBy.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_TerminalInfo_Update", param);

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
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }
    }
}
