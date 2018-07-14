using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;

namespace SalesPOS.BLL
{
    public static class bllProductInfo
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"Select pi.ProductID,pi.ProductName,ai.Activity, pi.SerialNo,pi.OtherCode from dbo.ProductInfo pi left outer join dbo.ActivityInfo ai on ai.ActivityID = pi.ActivityID where pi.IsDeleted = 0 order by pi.ProductID asc", param);
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
        public static DataTable getAll_Active()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"Select pi.ProductID,pi.ProductName,ai.Activity, pi.SerialNo from dbo.ProductInfo pi left outer join dbo.ActivityInfo ai on ai.ActivityID = pi.ActivityID where pi.IsDeleted = 0 and pi.ActivityID=1 order by pi.ProductName asc", param);
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
        public static DataTable Insert(ProductInfo objProductInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 13);

                param[0]    = dbManager.getparam("@ActivityID", objProductInfo.ActivityID);
                param[1]    = dbManager.getparam("@ProductDescription", objProductInfo.ProductDescription.ToString());                
                param[2]    = dbManager.getparam("@ProductName", objProductInfo.ProductName.ToString());
                param[3]    = dbManager.getparam("@ReorderLevel", objProductInfo.ReorderLevel);
                param[4]    = dbManager.getparam("@SectionId", objProductInfo.SectionId);
                param[5]    = dbManager.getparam("@SubSectionID", objProductInfo.SubSectionID);
                param[6]    = dbManager.getparam("@VatId", objProductInfo.VatId);
                param[7]    = dbManager.getparam("@ManufacturerID", objProductInfo.ManufacturerID);
                param[8]    = dbManager.getparam("@CreatedBy", objProductInfo.CreatedBy.ToString());
                //param[9]    = dbManager.getparam("@pk_code", "");
                param[9] = dbManager.getparam("@IsFractionAllow", objProductInfo.IsFractionAllow);
                param[10] = dbManager.getparam("@TypeID", objProductInfo.TypeID);
                param[11] = dbManager.getparam("@OtherCode", objProductInfo.OtherCode.ToString());
                param[12] = dbManager.getparam("@ProductID", objProductInfo.ProductID.ToString());
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ProductInfo_Add", param);

                //dt = dbManager.ExecuteQuery(cmd);  
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                //return false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        public static bool Update(ProductInfo objProductInfo,string old_product_code)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 15);
                param[0] = dbManager.getparam("@ActivityID", objProductInfo.ActivityID);
                param[1] = dbManager.getparam("@ProductDescription", objProductInfo.ProductDescription.ToString());
                param[2] = dbManager.getparam("@ProductName", objProductInfo.ProductName);
                param[3] = dbManager.getparam("@ReorderLevel", objProductInfo.ReorderLevel);
                param[4] = dbManager.getparam("@SectionId", objProductInfo.SectionId);
                param[5] = dbManager.getparam("@ProductID", objProductInfo.ProductID);
                param[6] = dbManager.getparam("@SubSectionID", objProductInfo.SubSectionID);
                param[7] = dbManager.getparam("@VatId", objProductInfo.VatId.ToString());
                param[8] = dbManager.getparam("@ManufacturerID", objProductInfo.ManufacturerID.ToString());
                param[9] = dbManager.getparam("@UpdatedBy", objProductInfo.UpdatedBy.ToString());
                param[10] = dbManager.getparam("@IsFractionAllow", objProductInfo.IsFractionAllow);
                param[11] = dbManager.getparam("@TypeID", objProductInfo.TypeID);
                param[12] = dbManager.getparam("@OtherCode", objProductInfo.OtherCode);
                param[13] = dbManager.getparam("@SerialNo", objProductInfo.SerialNo);
                param[14] = dbManager.getparam("@old_product_code", old_product_code);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_productInfo_Update", param);

                chk = dbManager.ExecuteQuery(cmd);
                //dbManager.ExecuteReader(cmd);
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
        public static DataTable getById(string ProductID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@ProductID", ProductID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_productinfo_getbyId", param);
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
        public static string getProductID(string ProductName)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            string ProductID = "";
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"Select ProductID From ProductInfo Where ProductName='"+ ProductName +"'", param);
                dt = dbManager.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    ProductID = dt.Rows[0][0].ToString();
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
            return ProductID;
        }
        public static DataTable IsDuplicateProductCode(string SerialNo, string ProductID, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@SerialNo", SerialNo);
                param[1] = dbManager.getparam("@ProductID", ProductID);
                param[2] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_IsDuplicateProductCode", param);
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
