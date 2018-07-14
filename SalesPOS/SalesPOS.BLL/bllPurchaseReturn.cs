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
    public static class bllPurchaseReturn
    {
        public static DataTable InsertPurchaseReturnParent(string _PRDate, string _SupplierID, double _TotalPRAmount)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 5);

                param[0] = dbManager.getparam("@PRDate", _PRDate);
                param[1] = dbManager.getparam("@SupplierID", _SupplierID);
                param[2] = dbManager.getparam("@CreatedBy", bllUtility.LoggedInSystemInformation.LoggedUserId);
                param[3] = dbManager.getparam("@TerminalID", bllUtility.LoggedInSystemInformation.TerminalID);
                param[4] = dbManager.getparam("@TotalPRAmount", _TotalPRAmount);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_PurchaseReturnParent_Add]", param);
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

        public static bool InsertPurchaseReturnChild(Int32 _PRID,string _ProductID, Int32 _UnitID,decimal _Quantity,decimal _ReturnUnitPrice,decimal _ReturnTotalPrice)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSave = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);

                param[0] = dbManager.getparam("@PRID", _PRID);
                param[1] = dbManager.getparam("@ProductID", _ProductID);
                param[2] = dbManager.getparam("@UnitID", _UnitID);
                param[3] = dbManager.getparam("@Quantity", _Quantity);
                param[4] = dbManager.getparam("@ReturnUnitPrice", _ReturnUnitPrice);
                param[5] = dbManager.getparam("@TotalReturnPrice", _ReturnTotalPrice);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[USP_PurchaseReturnChild_Add]", param);
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
