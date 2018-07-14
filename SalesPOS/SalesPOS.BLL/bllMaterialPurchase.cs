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
    public static class bllMaterialPurchase
    {
        public static DataTable InsertPurchaseMaster(string PurchaseDate, string MemoNo, double TotalAmount, double TotalPaid, string SupplierAccountNo, long CreatedBy, string TransactionType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);

                param[0] = dbManager.getparam("@PurchaseDate", PurchaseDate);
                param[1] = dbManager.getparam("@MemoNo", MemoNo);
                param[2] = dbManager.getparam("@TotalAmount", TotalAmount);
                param[3] = dbManager.getparam("@TotalPaid", TotalPaid);
                param[4] = dbManager.getparam("@SupplierAccountNo", SupplierAccountNo);
                param[5] = dbManager.getparam("@CreatedBy", CreatedBy);
                param[6] = dbManager.getparam("@pk_code", "");
                param[7] = dbManager.getparam("@TerminalID",bllUtility.LoggedInSystemInformation.TerminalID.ToString());
                param[8] = dbManager.getparam("@TransactionType", TransactionType);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_MaterialPurchaseMasterInfo_Add", param);
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
        
        public static bool InsertPurchaseMasterDetails(string purchaseID, string MaterialID, string purchaseQty, string purchasePrice, string createdBy)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@PurchaseID", purchaseID);
                param[1] = dbManager.getparam("@MaterialID", MaterialID);                
                param[2] = dbManager.getparam("@PurchaseQty", Convert.ToDouble(purchaseQty));
                param[3] = dbManager.getparam("@PurchasePrice", Convert.ToDouble(purchasePrice));
                param[4] = dbManager.getparam("@CreatedBy", Convert.ToInt32(createdBy));
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_MaterialLotDetailsEntry", param);
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
