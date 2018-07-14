using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;

namespace SalesPOS.BLL
{
    public static class bllInvoiceList
    {
        public static DataTable LoadSalesInvoice(string SalesDateFrom,string SalesDateTo, string TerminalID,string customer_id)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);

                param[0] = dbManager.getparam("@SalesDateFrom", SalesDateFrom);
                param[1] = dbManager.getparam("@SalesDateTo", SalesDateTo);
                param[2] = dbManager.getparam("@TerminalId", TerminalID);
                param[3] = dbManager.getparam("@AccountNo", customer_id);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_ListOfSalesInvice]", param);
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

        public static DataTable LoadPurchaseInvoice(string FromDate,string ToDate)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@FromDate", FromDate);
                param[1] = dbManager.getparam("@ToDate", ToDate);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_ListOfPurchaseInvice]", param);
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
