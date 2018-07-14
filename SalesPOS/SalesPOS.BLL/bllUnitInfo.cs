using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;

namespace SalesPOS.BLL
{
    public static class bllUnitInfo
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
                ai.ActivityID,
                ai.Activity,
                ui.UnitId,
                ui.UnitName,
                ui.ActivityID,
                ui.UpdatedDate,
                ui.UpdatedBy 
                from dbo.UnitInfo ui left outer join dbo.ActivityInfo ai
                on ai.ActivityID = ui.ActivityID Where ui.IsDeleted=0", param);
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
        public static DataTable getById(long UnitInfoId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@UnitInfoId", UnitInfoId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_unitinfo_getbyId", param);
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
        public static bool Insert(UnitInfo objUnitInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                //param[0] = dbManager.getparam("@UnitId", objUnitInfo.UnitId.ToString());
                param[0] = dbManager.getparam("@UnitName", objUnitInfo.UnitName.ToString());
                param[1] = dbManager.getparam("@ActivityID", objUnitInfo.ActivityID.ToString());
              
                param[2] = dbManager.getparam("@CreatedDate", objUnitInfo.CreatedDate);
                param[3] = dbManager.getparam("@CreatedBy", objUnitInfo.CreatedBy.ToString());
                param[4] = dbManager.getparam("@IsDeleted", false);



                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_UnitInfo_Add", param);

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
        public static bool Update(UnitInfo objUnitInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);
                param[0] = dbManager.getparam("@UnitId", objUnitInfo.UnitId.ToString());
                param[1] = dbManager.getparam("@UnitName", objUnitInfo.UnitName.ToString());
                param[2] = dbManager.getparam("@ActivityID", objUnitInfo.ActivityID.ToString());
                param[3] = dbManager.getparam("@UpdatedDate", objUnitInfo.UpdatedDate);
                param[4] = dbManager.getparam("@UpdatedBy", objUnitInfo.UpdatedBy.ToString());
                


                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_UnitInfo_Update", param);

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
        public static bool Delete(long UnitId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@UnitId", UnitId);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_unitInfo_delete", param);

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

        public static DataTable IsDuplicateUnitName(long UnitId, string UnitName, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@UnitId", UnitId);
                param[1] = dbManager.getparam("@UnitName", UnitName);
                param[2] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.[USP_IsDuplicateUnitName]", param);
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
