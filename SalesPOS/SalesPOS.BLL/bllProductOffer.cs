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
    public static class bllProductOffer
    {
        public static DataTable Insert(int OfferID, string StartDate, string EndDate, string ProductID, int Qty, string FreeProductID, int FreeQty, string GiftName, int GiftQty, string GiftUnitID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 10);

                param[0] = dbManager.getparam("@OfferID", OfferID);
                param[1] = dbManager.getparam("@StartDate", StartDate);
                param[2] = dbManager.getparam("@EndDate", EndDate);
                param[3] = dbManager.getparam("@ProductID", ProductID);
                param[4] = dbManager.getparam("@Qty", Qty);
                param[5] = dbManager.getparam("@FreeProductID", FreeProductID);
                param[6] = dbManager.getparam("@FreeQty", FreeQty);
                param[7] = dbManager.getparam("@GiftName", GiftName);
                param[8] = dbManager.getparam("@GiftQty", GiftQty);
                param[9] = dbManager.getparam("@GiftUnitID", GiftUnitID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ProductOffer_InsertUpdate", param);
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
        
        public static DataTable getProductAllOffer(string ProductID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@ProductID", ProductID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_getProductAllOfferByID", param);
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
        public static DataTable getProductOfferInfoByID(Int64 OfferID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@OfferID", OfferID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_getProductOfferInfoByID", param);
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
