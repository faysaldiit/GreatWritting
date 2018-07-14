using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;
using System.Data;

namespace SalesPOS.BLL
{
    public static class bllProductTransferInfo
    {
        public static DataTable GetProductMainStock(string ProductID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@ProductID", ProductID);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_GetProductMainStock]", param);
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

        public static bool InsertTransferProduct(string productID, string quantity)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                
                param[0] = dbManager.getparam("@ProductID", productID);
                param[1] = dbManager.getparam("@Quantity", Convert.ToInt32(quantity));
                param[2] = dbManager.getparam("@Creator", Convert.ToInt32(bllUtility.LoggedInSystemInformation.LoggedUserId));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_ProductTransferToDisplay]", param);
                chk=dbManager.ExecuteQuery(cmd);               

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
    }
}
