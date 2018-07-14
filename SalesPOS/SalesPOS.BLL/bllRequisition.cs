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
    public static class bllRequisition
    {
        public static bool InsertRequisition(string RequisitionID, string DealerID, string RequisitionDate, string PaymentMode, string PaymentAmount, string ProductID, string Quantity)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 8);

                param[0] = dbManager.getparam("@RequisitionID", RequisitionID);
                param[1] = dbManager.getparam("@DealerID", DealerID);
                param[2] = dbManager.getparam("@RequisitionDate", Convert.ToDateTime(RequisitionDate).ToString("dd/MM/yyyy"));
                param[3] = dbManager.getparam("@PaymentMode", PaymentMode);
                param[4] = dbManager.getparam("@PaymentAmount", PaymentAmount);
                param[5] = dbManager.getparam("@ProductID", ProductID);
                param[6] = dbManager.getparam("@Quantity", Quantity);
                param[7] = dbManager.getparam("@UserID", bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[insert_requisition_details]", param);
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

        public static bool Delete(string RequisitionID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isDeleted = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                param[0] = dbManager.getparam("@RequisitionID", RequisitionID);
                param[1] = dbManager.getparam("@UserID", bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[delete_requisition]", param);
                dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return isDeleted;
        }

        public static bool InsertClosing(string ClosingStockID,string DealerID, string Year, string Month, string ProductID, string Quantity)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 7);
                param[0] = dbManager.getparam("@DealerID", DealerID);
                param[1] = dbManager.getparam("@Year", Year);
                param[2] = dbManager.getparam("@Month", Month);
                param[3] = dbManager.getparam("@ProductID", ProductID);
                param[4] = dbManager.getparam("@Quantity",Convert.ToInt16(Quantity));                
                param[5] = dbManager.getparam("@ReceivedBy", bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
                param[6] = dbManager.getparam("@ClosingStockID", ClosingStockID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[import_closing_stock]", param);
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

        public static bool DeleteClosingStock(string ClosingStockID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isDeleted = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                param[0] = dbManager.getparam("@ClosingStockID", ClosingStockID);
                param[1] = dbManager.getparam("@UserID", bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[delete_closing_stock]", param);
                dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            finally
            {
                dbManager.Dispose();
            }
            return isDeleted;
        }
    }
}
