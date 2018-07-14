using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;

namespace SalesPOS.BLL
{
    public static class bllPurposeInfo
    {
        public static DataTable LoadPurpose()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[USP_LoadPurpose]", param);
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
