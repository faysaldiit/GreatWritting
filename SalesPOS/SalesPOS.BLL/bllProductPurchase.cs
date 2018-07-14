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
    public static class bllProductPurchase
    {
        public static DataTable InsertPurchaseMaster(ProductPurchaseInfo objProductPurchaseInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);

                param[0] = dbManager.getparam("@PurchaseDate", objProductPurchaseInfo.PurchaseDate);
                param[1] = dbManager.getparam("@MemoNo", objProductPurchaseInfo.MemoNo);
                param[2] = dbManager.getparam("@TotalAmount", objProductPurchaseInfo.TotalAmount);
                param[3] = dbManager.getparam("@TotalPaid", objProductPurchaseInfo.TotalPaid);
                param[4] = dbManager.getparam("@SupplierAccountNo", objProductPurchaseInfo.SupplierAccountNo);
                param[5] = dbManager.getparam("@CreatedBy", objProductPurchaseInfo.CreatedBy);
                param[6] = dbManager.getparam("@pk_code", "");
                param[7] = dbManager.getparam("@TerminalID",bllUtility.LoggedInSystemInformation.TerminalID.ToString());
                param[8] = dbManager.getparam("@TransactionType", objProductPurchaseInfo.TransactionType);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_PurchaseMasterInfo_Add", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                //return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        public static DataTable InsertPurchaseMaster_For_SalesReturn(ProductPurchaseInfo objProductPurchaseInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 10);

                param[0] = dbManager.getparam("@PurchaseDate", objProductPurchaseInfo.PurchaseDate);
                param[1] = dbManager.getparam("@MemoNo", objProductPurchaseInfo.MemoNo);
                param[2] = dbManager.getparam("@TotalAmount", objProductPurchaseInfo.TotalAmount);
                param[3] = dbManager.getparam("@TotalPaid", objProductPurchaseInfo.TotalPaid);
                param[4] = dbManager.getparam("@SupplierAccountNo", objProductPurchaseInfo.SupplierAccountNo);
                param[5] = dbManager.getparam("@CreatedBy", objProductPurchaseInfo.CreatedBy);
                param[6] = dbManager.getparam("@pk_code", "");
                param[7] = dbManager.getparam("@TerminalID", bllUtility.LoggedInSystemInformation.TerminalID.ToString());
                param[8] = dbManager.getparam("@TransactionType", objProductPurchaseInfo.TransactionType);
                param[9] = dbManager.getparam("@PurchaseID", objProductPurchaseInfo.PurchaseID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_PurchaseMasterInfo_Add_From_Sales", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                //return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        public static bool InsertPurchaseMasterDetails(string purchaseID, string productID, string unitID, string purchaseQty, string purchasePrice, string createdBy, string isExpDate, string expDate, int areaId, string UnitPurchasePrice)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 10);

                param[0] = dbManager.getparam("@PurchaseID", purchaseID);
                param[1] = dbManager.getparam("@ProductID", productID);
                param[2] = dbManager.getparam("@UnitID", Convert.ToInt32(unitID));
                param[3] = dbManager.getparam("@PurchaseQty", Convert.ToDouble(purchaseQty));
                param[4] = dbManager.getparam("@PurchasePrice", Convert.ToDouble(purchasePrice));
                param[5] = dbManager.getparam("@CreatedBy", Convert.ToInt32(createdBy));
                param[6] = dbManager.getparam("@IsExpDate", isExpDate);
                param[7] = dbManager.getparam("@ProductExpireDate", expDate);
                param[8] = dbManager.getparam("@AreaID", areaId);
                param[9] = dbManager.getparam("@UnitPurchasePrice", Convert.ToDouble(UnitPurchasePrice));

               IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ProductLotDetailsEntry", param);
               dbManager.ExecuteQuery(cmd);
               chk = true;

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


        public static bool InsertPurchasePayment(PurchasePaymentInfo objPurchasePaymentInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@PurchaseID", objPurchasePaymentInfo.PurchaseID);
                param[1] = dbManager.getparam("@PaidAmount", Convert.ToDouble(objPurchasePaymentInfo.PaidAmount));
                param[2] = dbManager.getparam("@SupplierID", objPurchasePaymentInfo.SupplierID);
                param[3] = dbManager.getparam("@TerminalID", objPurchasePaymentInfo.TerminalID);
                param[4] = dbManager.getparam("@CreatedBy", Convert.ToInt64(objPurchasePaymentInfo.CreatedBy));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_PurchasePaymentInfo_Add]", param);
                dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                isSave = false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return isSave;
        }

        public static DataTable CheckDeletePurchase(string purchaseID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@PurchaseID", purchaseID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.CheckDeletePurchaseInfo", param);                
                dt = dbManager.GetDataTable(cmd);

            }
            catch (Exception ex)
            {
                //return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }

        public static DataTable LoadPurchase_For_Delete(string purchaseID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@PurchaseID", purchaseID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.LoadPurchaseInformation_Delete", param);
                dt = dbManager.GetDataTable(cmd);

            }
            catch (Exception ex)
            {
                //return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
    }
}
