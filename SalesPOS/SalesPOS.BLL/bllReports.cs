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
    public class bllReports
    {
        public static DataSet GetSalesInvoice(string _InvoiceNo)//, string _Status
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType,1);//, 2

                param[0] = dbManager.getparam("@InvoiceID", _InvoiceNo);
                //param[1] = dbManager.getparam("@Status", Convert.ToInt64(_Status));

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_RptSalesInvoice ", param);
                ds = dbManager.GetDataSet(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return ds;
        }

        public static DataSet CommissionStatement(string _AccountNo,string _CommisionID)//, string _Status
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);//, 2

                param[0] = dbManager.getparam("@account_number", _AccountNo);
                param[1] = dbManager.getparam("@curr_comm_id", _CommisionID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.rpt_commission_wise_stock_statement ", param);
                ds = dbManager.GetDataSet(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return ds;
        }
    }
}
