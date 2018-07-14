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
    public static class bllProductUnitPrice
    {
        public static DataTable Insert(ProductUnitPrice objProductUnitPrice)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);

                param[0] = dbManager.getparam("@ProductID", objProductUnitPrice.ProductID);
                param[1] = dbManager.getparam("@UnitID", objProductUnitPrice.UnitID);
                param[2] = dbManager.getparam("@UnitQty", objProductUnitPrice.UnitQty);
                param[3] = dbManager.getparam("@Price", objProductUnitPrice.Price);
                param[4] = dbManager.getparam("@ActivityID", objProductUnitPrice.ActivityID);
                param[5] = dbManager.getparam("@IsMinimumUnit", objProductUnitPrice.IsMinimumUnit);
                param[6] = dbManager.getparam("@CreatedBy", objProductUnitPrice.CreatedBy);
                param[7] = dbManager.getparam("@pk_code", "");
                param[8] = dbManager.getparam("@WholeSalePrice", objProductUnitPrice.WholeSalePrice);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ProductSalesPrice_Add", param);
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
        public static bool Update(ProductUnitPrice objProductUnitPrice)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);
                param[0] = dbManager.getparam("@PSPID", objProductUnitPrice.PSPID);
                param[1] = dbManager.getparam("@ProductID", objProductUnitPrice.ProductID);
                param[2] = dbManager.getparam("@UnitID", objProductUnitPrice.UnitID);
                param[3] = dbManager.getparam("@UnitQty", objProductUnitPrice.UnitQty);
                param[4] = dbManager.getparam("@Price", objProductUnitPrice.Price);
                param[5] = dbManager.getparam("@ActivityID", objProductUnitPrice.ActivityID);
                param[6] = dbManager.getparam("@IsMinimumUnit", objProductUnitPrice.IsMinimumUnit);
                param[7] = dbManager.getparam("@UpdatedBy", objProductUnitPrice.UpdatedBy);
                param[8] = dbManager.getparam("@WholeSalePrice", objProductUnitPrice.WholeSalePrice);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ProductSalesPrice_Update", param);
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
        public static DataTable getProductAllUnitPrice(string ProductID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@ProductID", ProductID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_getProductAllUnitPriceByID", param);
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
        public static DataTable getProductUnitPriceInfoByID(Int64 PSPID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@PSPID", PSPID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_getProductUnitPriceInfoByID", param);
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
        public static DataTable IsAlreadyHasMinimumUnit(string ProductID, Int64 PSPID, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@ProductID", ProductID);
                param[1] = dbManager.getparam("@PSPID", PSPID);
                param[2] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_isAlreadyHasMinimumUnit", param);
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
        public static bool UpdateIsMinimumUnitFalse(ProductUnitPrice objProductUnitPrice)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                param[0] = dbManager.getparam("@ProductID", objProductUnitPrice.ProductID);                
                param[1] = dbManager.getparam("@UpdatedBy", objProductUnitPrice.UpdatedBy);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_updateIsMinimumUnitFalse", param);
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
        public static DataTable IsDuplicateProductUnit(Int64 PSPID, string ProductID, Int64 UnitID, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);
                param[0] = dbManager.getparam("@PSPID", PSPID);
                param[1] = dbManager.getparam("@ProductID", ProductID);
                param[2] = dbManager.getparam("@UnitID", UnitID);
                param[3] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.[USP_IsDuplicateProductUnit]", param);
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
        public static DataTable GetMinimumUnitByID(string ProductID)
        { 
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"SELECT dbo.ProductSalesPrice.ProductID, dbo.UnitInfo.UnitName, dbo.ProductInfo.ProductName,dbo.UnitInfo.UnitId
                    FROM  dbo.ProductSalesPrice 
                    INNER JOIN   dbo.UnitInfo ON dbo.ProductSalesPrice.UnitID = dbo.UnitInfo.UnitId 
                    INNER JOIN   dbo.ProductInfo ON dbo.ProductSalesPrice.ProductID = dbo.ProductInfo.ProductID
                    WHERE (dbo.ProductSalesPrice.IsMinimumUnit = 1) AND (dbo.ProductSalesPrice.ProductID = '" + ProductID +"')", param);
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
        public static DataTable GetMinimumUnitByName(string ProductName)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"SELECT dbo.ProductSalesPrice.ProductID, dbo.UnitInfo.UnitName, dbo.ProductInfo.ProductName
                    FROM  dbo.ProductSalesPrice 
                    INNER JOIN   dbo.UnitInfo ON dbo.ProductSalesPrice.UnitID = dbo.UnitInfo.UnitId 
                    INNER JOIN   dbo.ProductInfo ON dbo.ProductSalesPrice.ProductID = dbo.ProductInfo.ProductID
                    WHERE (dbo.ProductSalesPrice.IsMinimumUnit = 1) AND (dbo.ProductSalesPrice.ProductName = '" + ProductName + "')", param);
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
