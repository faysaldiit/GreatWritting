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
    public static class bllProductSales
    {
        public static DataTable PopulateSalesGrid(string _ProductID,string _UnitID,string _Quantity,string _UnitSalePrice, string _StoreID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@ProductID", _ProductID);
                param[1] = dbManager.getparam("@ProductQuantity", Convert.ToInt64(_Quantity));
                param[2] = dbManager.getparam("@UnitID", Convert.ToInt64(_UnitID));
                param[3] = dbManager.getparam("@UnitSalesPrice", Convert.ToDecimal(_UnitSalePrice));
                param[4] = dbManager.getparam("@AreaID", Convert.ToInt16(_StoreID));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_PopulateSalesGrid", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }

        public static DataTable GetSalesPrice(string _ProductID, string _UnitID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"SELECT psp.Price as Retail, psp.WholeSalePrice as WholeSale FROM ProductSalesPrice psp WHERE psp.ProductID='" + _ProductID + "' AND psp.UnitID=" + _UnitID + "", param);
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

        public static bool IsAvailableStock(string _ProductID, string _Quantity,string _AreaID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            bool chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);

                param[0] = dbManager.getparam("@ProductID", _ProductID);
                param[1] = dbManager.getparam("@Quantity", Convert.ToInt64(_Quantity));
                param[2] = dbManager.getparam("@AreaId", Convert.ToInt64(_AreaID));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_StockCheckForSale]", param);
                dt = dbManager.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    chk = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbManager.Dispose();
            }
            return chk;
        }

        public static string GetQtyInMinimumUnit(string _ProductID, string _UnitID, string _Quantity)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            string convertedQty = "";
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);

                param[0] = dbManager.getparam("@ProductID", _ProductID);
                param[1] = dbManager.getparam("@UnitID", Convert.ToInt64(_UnitID));
                param[2] = dbManager.getparam("@Quantity", Convert.ToInt64(_Quantity));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_ConvertToMinimumQty", param);
                dt = dbManager.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    convertedQty = dt.Rows[0]["ConvertedQty"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbManager.Dispose();
            }
            return convertedQty;
        }

        public static DataTable InsertSalesParent(ProductSalesInfo objProductSalesInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 16);

                param[0] = dbManager.getparam("@TerminalID", objProductSalesInfo.TerminalID);
                param[1] = dbManager.getparam("@MemoNoteNo", Convert.ToInt64(objProductSalesInfo.MemoNoteNo));                
                param[2] = dbManager.getparam("@TotalAmount", Convert.ToDouble(objProductSalesInfo.TotalAmount));
                param[3] = dbManager.getparam("@DiscountAmount", Convert.ToDouble(objProductSalesInfo.DiscountAmount));
                param[4] = dbManager.getparam("@TotalGrossAmount",Convert.ToDouble( objProductSalesInfo.TotalGrossAmount));
                param[5] = dbManager.getparam("@ReceivedAmount", Convert.ToDouble(objProductSalesInfo.ReceivedAmount));
                double ChangeAmount = Convert.ToDouble(objProductSalesInfo.ChangeAmount);
                if (ChangeAmount<0)
                {
                    ChangeAmount = 0;
                }
                param[6] = dbManager.getparam("@ChangeAmount", ChangeAmount);
                param[7] = dbManager.getparam("@CreatedBy", Convert.ToInt64(objProductSalesInfo.CreatedBy));                
                param[8] = dbManager.getparam("@pk_code", "");
                param[9] = dbManager.getparam("@SalesType", objProductSalesInfo.SalesType);
                param[10] = dbManager.getparam("@CustomerID", objProductSalesInfo.CustomerID);
                param[11] = dbManager.getparam("@SalesReturn", Convert.ToDouble(objProductSalesInfo.SalesReturn));
                param[12] = dbManager.getparam("@RtlManager", objProductSalesInfo.RtlManager);
                param[13] = dbManager.getparam("@ZoneID", objProductSalesInfo.ZoneID);
                param[14] = dbManager.getparam("@CommissionAdjustAmount", Convert.ToDouble(objProductSalesInfo.CommissionAdjustAmount));
                param[15] = dbManager.getparam("@AreaID", Convert.ToInt64(objProductSalesInfo.AreaID));    

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_SalesParentInfo_Add]", param);
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
        public static bool InsertSalesRequisitionList(string InvoiceID, string RequisitionID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSaved =true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@InvoiceID", InvoiceID);
                param[1] = dbManager.getparam("@RequisitionID", RequisitionID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[insert_SalesRequisitionList]", param);
                dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                isSaved = false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return isSaved;
            
        }
        public static DataTable InsertProductOutParentInfo(string TransactionType, string CreatedBy)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                               
                param[0] = dbManager.getparam("@TransactionType", TransactionType);
                param[1] = dbManager.getparam("@CreatedBy", CreatedBy);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_ProductOutParentInfo_Add]", param);
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



        public static bool InsertSalesPayment(SalesPaymentInfo objSalesPaymentInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 8);

                param[0] = dbManager.getparam("@InvoiceNo", objSalesPaymentInfo.InvoiceNo);
                param[1] = dbManager.getparam("@PayTypeId", Convert.ToInt64(objSalesPaymentInfo.PayTypeId));
                param[2] = dbManager.getparam("@PaidAmount", Convert.ToDouble(objSalesPaymentInfo.PaidAmount));
                param[3] = dbManager.getparam("@CardNo", objSalesPaymentInfo.CardNo);
                param[4] = dbManager.getparam("@ExpDate", objSalesPaymentInfo.ExpDate);
                param[5] = dbManager.getparam("@CustomerID", objSalesPaymentInfo.CustomerID);
                param[6] = dbManager.getparam("@TerminalID", objSalesPaymentInfo.TerminalID);
                param[7] = dbManager.getparam("@CreatedBy", Convert.ToInt64(objSalesPaymentInfo.CreatedBy));
                
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_SalesPaymentInfo_Add]", param);
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

        public static bool InsertAccountTransactionBySystem(string TransactionType, string Amount, string RefNo, string Description, string TerminalID, string AccountNo, string CreatedBy, string TransactionDate, Int16 IsEditable)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);
                param[0] = dbManager.getparam("@TransactionType", TransactionType);
                param[1] = dbManager.getparam("@Amount", Convert.ToDouble(Amount));
                param[2] = dbManager.getparam("@RefNo", RefNo);
                param[3] = dbManager.getparam("@TerminalID", TerminalID);
                param[4] = dbManager.getparam("@AccountNo", AccountNo);
                param[5] = dbManager.getparam("@CreatedBy", Convert.ToInt16(CreatedBy));
                param[6] = dbManager.getparam("@TransactionDate", TransactionDate);
                param[7] = dbManager.getparam("@Description", Description);
                param[8] = dbManager.getparam("@IsEditable", IsEditable);                
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_AccountTransactionBySystem]", param);
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

        public static bool InsertSalesDetails(ProductSalesDetailsInfo objProductSalesDetailsInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();                
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 15);

                param[0] = dbManager.getparam("@InvoiceNo", objProductSalesDetailsInfo.InvoiceNo);
                param[1] = dbManager.getparam("@ProductID", objProductSalesDetailsInfo.ProductID);
                param[2] = dbManager.getparam("@ActualQty", bllUtility.Val(objProductSalesDetailsInfo.ActualQty));
                param[3] = dbManager.getparam("@ActualUnitID", Convert.ToInt64(objProductSalesDetailsInfo.ActualUnitID));
                param[4] = dbManager.getparam("@ActualUnitSalesPrice", Convert.ToDouble(objProductSalesDetailsInfo.ActualUnitSalesPrice));
                param[5] = dbManager.getparam("@TotalPriceWithoutVat", Convert.ToDouble(objProductSalesDetailsInfo.TotalPriceWithoutVat));
                param[6] = dbManager.getparam("@VatID", Convert.ToInt64(objProductSalesDetailsInfo.VatID));
                param[7] = dbManager.getparam("@VatPerchantage", Convert.ToDouble(objProductSalesDetailsInfo.VatPerchantage));
                param[8] = dbManager.getparam("@VatAmount", Convert.ToDouble(objProductSalesDetailsInfo.VatAmount));
                param[9] = dbManager.getparam("@TotalPriceWithVat", Convert.ToDouble(objProductSalesDetailsInfo.TotalPriceWithVat));
                param[10] = dbManager.getparam("@DiscountAmount", Convert.ToDouble(objProductSalesDetailsInfo.DiscountAmount));
                param[11] = dbManager.getparam("@ConvertedUnitID", Convert.ToInt64(objProductSalesDetailsInfo.ConvertedUnitID));
                param[12] = dbManager.getparam("@CovertedQuantity", bllUtility.Val(objProductSalesDetailsInfo.CovertedQuantity));
                param[13] = dbManager.getparam("@ItemType", Convert.ToInt64(objProductSalesDetailsInfo.ItemType));
                param[14] = dbManager.getparam("@DiscountPercent", Convert.ToDouble(objProductSalesDetailsInfo.DiscountPercent));
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_SalesProcess]", param);
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

        public static bool InsertProductOutDetails(string TransactionID, string ProductID, string UnitID, string Quantity)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);

                param[0] = dbManager.getparam("@TransactionID", TransactionID);
                param[1] = dbManager.getparam("@ProductID", ProductID);
                param[2] = dbManager.getparam("@UnitID", UnitID);
                param[3] = dbManager.getparam("@Quantity", Quantity);                
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[usp_ProductOutChildInfo_insert]", param);
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

        
        public static bool InsertGiftItem(string InvoiceNo, string ProductName, string UnitID, string Qty)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);

                param[0] = dbManager.getparam("@InvoiceNo", InvoiceNo);
                param[1] = dbManager.getparam("@ProductName", ProductName);
                param[2] = dbManager.getparam("@UnitID",Convert.ToInt64(UnitID));
                param[3] = dbManager.getparam("@Qty", Convert.ToDouble(Qty));
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[gift_item_insert]", param);
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

        public static DataTable GetSalesInvoiceParentInfo(string strInvoiceNo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@InvoiceNo", strInvoiceNo);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_GetSalesInvoiceParentInfo", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }

        public static bool DeleteSalesInvoice(string strInvoiceNo,long PurposeID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isDelete = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);
                param[0] = dbManager.getparam("@InvoiceNo", strInvoiceNo);
                param[1] = dbManager.getparam("@PurposeID", Convert.ToInt64(PurposeID));
                param[2] = dbManager.getparam("@DeletedBy", Convert.ToInt64(bllUtility.LoggedInSystemInformation.LoggedUserId));
                param[3] = dbManager.getparam("@TerminalID", Convert.ToInt64(bllUtility.LoggedInSystemInformation.TerminalID));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_DeleteSalesInvoice]", param);
                dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                isDelete = false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return isDelete;
        }

        public static DataTable GetSalesInvoiceDetails(string strInvoiceNo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@InvoiceNo", strInvoiceNo);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_GetSalesInvoiceDetails]", param);
                dt = dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
    }
}
