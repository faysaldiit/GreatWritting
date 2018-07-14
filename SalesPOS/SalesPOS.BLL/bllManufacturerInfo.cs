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
    public static class bllManufacturerInfo
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
                mi.ManufacturerID,
                mi.ManufacturarName,
                mi.ActivityID,
                mi.UpdatedDate,
                mi.UpdatedBy 
                from dbo.ManufacturerInfo mi left outer join dbo.ActivityInfo ai
                on ai.ActivityID = mi.ActivityID Where mi.IsDeleted=0 order by mi.ManufacturarName", param);
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
        public static DataTable getById(string ManufacturerID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@ManufacturerID", ManufacturerID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_manufacturerinfo_getbyId", param);
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
        public static bool Insert(ManufacturerInfo objManufacturerInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@ManufacturarName", objManufacturerInfo.ManufacturarName.ToString());
                param[1] = dbManager.getparam("@ActivityID", objManufacturerInfo.ActivityID.ToString());

                param[2] = dbManager.getparam("@CreatedDate", objManufacturerInfo.CreatedDate);
                param[3] = dbManager.getparam("@CreatedBy", objManufacturerInfo.CreatedBy.ToString());
                param[4] = dbManager.getparam("@IsDeleted", false);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_ManufacturerInfo_Add", param);

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
        public static bool Update(ManufacturerInfo objManufacturerInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);
                param[0] = dbManager.getparam("@ManufacturerID", objManufacturerInfo.ManufacturerID.ToString());
                param[1] = dbManager.getparam("@ManufacturarName", objManufacturerInfo.ManufacturarName.ToString());
                param[2] = dbManager.getparam("@ActivityID", objManufacturerInfo.ActivityID.ToString());
                param[3] = dbManager.getparam("@UpdatedDate", objManufacturerInfo.UpdatedDate);
                param[4] = dbManager.getparam("@UpdatedBy", objManufacturerInfo.UpdatedBy.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_ManufacturerInfo_Update", param);

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
        public static bool Delete(string ManufacturerID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@ManufacturerID", ManufacturerID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_manufacturerinfo_delete", param);

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

        public static DataTable IsDuplicate_Manufacturer_Name(string ManufacturerID, string ManufacturarName, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@ManufacturerID", ManufacturerID);
                param[1] = dbManager.getparam("@ManufacturarName", ManufacturarName);
                param[2] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.[USP_IsDuplicateManufacturerName]", param);
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
