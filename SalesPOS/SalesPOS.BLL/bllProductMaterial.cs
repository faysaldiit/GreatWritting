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
    public static class bllProductMaterial
    {
        public static DataTable Insert(int ConfigID, string ProductID, string MaterialID, double Qty)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);
                param[0] = dbManager.getparam("@ConfigID", ConfigID);                
                param[1] = dbManager.getparam("@ProductID", ProductID);                
                param[2] = dbManager.getparam("@MaterialID", MaterialID);
                param[3] = dbManager.getparam("@Qty", Qty);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.MaterialConfigure_InsertUpdate", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //return false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        
        public static DataTable getMaterialConfigure(string ProductID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@ProductID", ProductID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "get_material_configuration_by_pid", param);
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
        public static DataTable getMaterialByID(Int64 ConfigID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@ConfigID", ConfigID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "get_material_info_by_id", param);
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
