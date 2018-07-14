using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesPOS.DataAccessLayer;
using System.Data;
using System.Windows.Forms;

namespace SalesPOS.BLL
{
    public class bllAccountTransactions
    {
        public static bool Insert(AccountTransactions objTransaction)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);
                param[0] = dbManager.getparam("@account_number", objTransaction.AccountHolderCode);
                param[1] = dbManager.getparam("@account_head_id", objTransaction.AccountHead);
                param[2] = dbManager.getparam("@bill_type", "");
                param[3] = dbManager.getparam("@bill_amount", objTransaction.BillAmount);
                param[4] = dbManager.getparam("@paid_amount", objTransaction.PaidAmount);
                param[5] = dbManager.getparam("@ref_number", objTransaction.RefNumber);
                param[6] = dbManager.getparam("@remarks", objTransaction.Remarks);
                param[7] = dbManager.getparam("@transactionDate", "");
                param[8] = dbManager.getparam("@creator", "");

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_accountTransactions_Add", param);

                chk = dbManager.ExecuteQuery(cmd);
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

        public static DataTable get_account_wise_due_amount(string account_number)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@account_number", account_number);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_accountTransactions_account_wise_due_populate", param);
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

        public static DataTable get_account_trans_details(string from_date, string to_date)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@fromDate", from_date);
                param[1] = dbManager.getparam("@toDate", to_date);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_accountTransactions_populate", param);
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
        
    }
}
