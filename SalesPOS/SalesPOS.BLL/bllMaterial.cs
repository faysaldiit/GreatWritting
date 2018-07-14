using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;

namespace SalesPOS.BLL
{
    public static class bllMaterial
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;


                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select * from Material_t", param);
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

        public static DataTable getById(string MaterialID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;

                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select * from Material_t where MaterialID='" + MaterialID+"'", param);
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
        public static string Insert(string MaterialID, string MaterialName,string UnitID,string ActivityID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            string id = "";
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@MaterialID", MaterialID);
                param[1] = dbManager.getparam("@MaterialName", MaterialName);
                param[2] = dbManager.getparam("@UnitID", Convert.ToInt16(UnitID));
                param[3] = dbManager.getparam("@ActivityID", ActivityID);
                param[4] = dbManager.getparam("@UserID", bllUtility.LoggedInSystemInformation.LoggedUserId);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[USP_Material_InsertUpdate]", param);

                id = Convert.ToString(dbManager.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                return "Err:"+ex.ToString();
            }
            finally
            {
                dbManager.Dispose();
            }
            return id;
        }
       
    }
}
