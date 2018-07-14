using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;

namespace SalesPOS.BLL
{
    public static class bllZoneInfo
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;


                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select * from ZoneList", param);
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

        public static DataTable getById(long ZoneId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;

                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select * from ZoneList where ZoneID=" + ZoneId, param);
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
        public static string Insert(string ZoneID,string ZoneName)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            string id = "";
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@ZoneID",Convert.ToInt16(ZoneID));
                param[1] = dbManager.getparam("@ZoneName", ZoneName);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_Zone_InsertUpdate", param);

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
       
        //public static DataTable IsDuplicateUnitName(long UnitId, string UnitName, string EventType)
        //{
        //    ISalesPOSDBManager dbManager = new SalesPOSDBManager();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
        //        param[0] = dbManager.getparam("@UnitId", UnitId);
        //        param[1] = dbManager.getparam("@UnitName", UnitName);
        //        param[2] = dbManager.getparam("@EventType", EventType);
        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.[USP_IsDuplicateUnitName]", param);
        //        dt = dbManager.GetDataTable(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //        dbManager.Dispose();
        //    }
        //    return dt;
        //}
    }
}
