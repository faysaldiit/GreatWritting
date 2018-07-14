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
    public static class bllSalesReturnInfo
    {
        public static bool InsertSalesReturnLotWise(string TransactionID, string ProductID, string UnitID, string Quantity, string AccountNo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@TransactionID",TransactionID);
                param[1] = dbManager.getparam("@ProductID",ProductID);
                param[2] = dbManager.getparam("@UnitID",UnitID);
                param[3] = dbManager.getparam("@Quantity",Quantity);
                param[4] = dbManager.getparam("@AccountNo",AccountNo);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_SalesReturnLotWise_insert]", param);
                dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                isSave = false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return isSave;
        }

        public static DataTable InsertSalesReturnParent(SalesReturnParent objSalesReturnParent, string AccountNo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);

                param[0] = dbManager.getparam("@SalesNo", objSalesReturnParent.InvoiceNo);
                param[1] = dbManager.getparam("@TotalAmount", Convert.ToDouble(objSalesReturnParent.TotalAmount));
                param[2] = dbManager.getparam("@CreatedBy", Convert.ToInt64(objSalesReturnParent.CreatedBy));
                param[3] = dbManager.getparam("@TerminalID", objSalesReturnParent.TerminalID);                                
                param[4] = dbManager.getparam("@pk_code", "");
                param[5] = dbManager.getparam("@AccountNo", AccountNo);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_SalesReturnParent_Add]", param);
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

        public static bool InsertSalesReturnPayment(SalesReturnParent objSalesReturnParent)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@InvoiceNo", objSalesReturnParent.InvoiceNo);
                param[1] = dbManager.getparam("@SalesReturnNo", objSalesReturnParent.SalesReturnNo);
                param[2] = dbManager.getparam("@PaidAmount", Convert.ToDouble(objSalesReturnParent.TotalAmount));
                param[3] = dbManager.getparam("@TerminalID", objSalesReturnParent.TerminalID);
                param[4] = dbManager.getparam("@CreatedBy", Convert.ToInt64(objSalesReturnParent.CreatedBy));


                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_SalesReturn_PaymentInfo_Add]", param);                
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

        public static bool InsertSalesReturnDetails(SalesReturnDetails objSalesReturnDetails)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 7);

                param[0] = dbManager.getparam("@InvoiceNo", objSalesReturnDetails.InvoiceNo);
                param[1] = dbManager.getparam("@SalesReturnNo", objSalesReturnDetails.SalesReturnNo);
                param[2] = dbManager.getparam("@ProductID", objSalesReturnDetails.ProductID);
                param[3] = dbManager.getparam("@Quantity", Convert.ToInt64(objSalesReturnDetails.ReturnQuantity));
                param[4] = dbManager.getparam("@UnitID", Convert.ToInt64(objSalesReturnDetails.UnitID));
                param[5] = dbManager.getparam("@UnitSalesPrice", Convert.ToDouble(objSalesReturnDetails.UnitSalesPrice));
                param[6] = dbManager.getparam("@VatPercentage", Convert.ToDouble(objSalesReturnDetails.VatPerchantage));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[USP_SalesReturnProcess]", param);
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
    }
}
