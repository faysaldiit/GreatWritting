using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesPOS.DataAccessLayer;
using System.Data;
using System.Windows.Forms;

namespace SalesPOS.BLL
{
    public class bllCommissionCalc
    {
      

        public static DataTable get_account_holder(string account_holder_type)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@AccountHolderType", account_holder_type);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_account_holder_list_populate", param);
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

        public static DataTable get_pending_sale_qty(string account_no, string product_code)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@AccountNo", account_no);
                param[1] = dbManager.getparam("@ProductCode", product_code);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_pending_sale_qty_get", param);
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

        public static DataTable get_commission_adjustment_due_details(string account_no, string product_code)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@AccountNo", account_no);
                param[1] = dbManager.getparam("@ProductCode", product_code);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_adjustment_due_get", param);
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

        public static string Insert_parent(CommissionCalc objTransaction, string created_by)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            string chk;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@AccountNo", objTransaction.AccountNo);
                param[1] = dbManager.getparam("@CreatedBy", created_by);
                param[2] = dbManager.getparam("@commission_date", objTransaction.CommissionCalcDate);
                

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_parent_insert", param);
                chk = Convert.ToString(dbManager.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }
        public static bool Insert_child(CommissionCalc objTransaction)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 7);
                param[0] = dbManager.getparam("@CommissionCalcID", objTransaction.CommissionCalcID);
                param[1] = dbManager.getparam("@InvoiceNO", objTransaction.InvoiceNo);
                param[2] = dbManager.getparam("@ProductCode", objTransaction.ProductCode);
                param[3] = dbManager.getparam("@AdjustmentQty", objTransaction.AdjustmentQty);
                param[4] = dbManager.getparam("@AverageRate", objTransaction.AverageRate);
                param[5] = dbManager.getparam("@CommissionPercent", objTransaction.CommissionPercent);
                param[6] = dbManager.getparam("@CommissionAmount", objTransaction.CommissionAmount);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_child_insert", param);
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

        public static bool Insert_clossing_qty(CommissionCalc objTransaction)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);
                param[0] = dbManager.getparam("@CommissionCalcID", objTransaction.CommissionCalcID);
                param[1] = dbManager.getparam("@AccountNo", objTransaction.AccountNo);
                param[2] = dbManager.getparam("@ProductCode", objTransaction.ProductCode);
                param[3] = dbManager.getparam("@ClossingQty", objTransaction.ClossingQty);
                param[4] = dbManager.getparam("@CalcDate", objTransaction.CalcDate);
                param[5] = dbManager.getparam("@IsLastClossing", objTransaction.IsLastClossing);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_clossing_qty_insert", param);
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


        //public static bool Insert(AccountTransactions objTransaction)
        //{
        //    ISalesPOSDBManager dbManager = new SalesPOSDBManager();
        //    Boolean chk = false;
        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);
        //        param[0] = dbManager.getparam("@account_number", objTransaction.AccountHolderCode);
        //        param[1] = dbManager.getparam("@account_head_id", objTransaction.AccountHead);
        //        param[2] = dbManager.getparam("@bill_type", "");
        //        param[3] = dbManager.getparam("@bill_amount", objTransaction.BillAmount);
        //        param[4] = dbManager.getparam("@paid_amount", objTransaction.PaidAmount);
        //        param[5] = dbManager.getparam("@ref_number", objTransaction.RefNumber);
        //        param[6] = dbManager.getparam("@remarks", objTransaction.Remarks);
        //        param[7] = dbManager.getparam("@transactionDate", "");
        //        param[8] = dbManager.getparam("@creator", "");

        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_accountTransactions_Add", param);

        //        chk = dbManager.ExecuteQuery(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        dbManager.Dispose();

        //    }
        //    return chk;
        //}

        //public static DataTable get_account_wise_due_amount(string account_number)
        //{
        //    ISalesPOSDBManager dbManager = new SalesPOSDBManager();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

        //        param[0] = dbManager.getparam("@account_number", account_number);

        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_accountTransactions_account_wise_due_populate", param);
        //        dt = dbManager.GetDataTable(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        dbManager.Dispose();
        //    }
        //    return dt;
        //}

        //public static DataTable get_account_trans_details(string from_date, string to_date)
        //{
        //    ISalesPOSDBManager dbManager = new SalesPOSDBManager();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

        //        param[0] = dbManager.getparam("@fromDate", from_date);
        //        param[1] = dbManager.getparam("@toDate", to_date);

        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.USP_accountTransactions_populate", param);
        //        dt = dbManager.GetDataTable(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        dbManager.Dispose();
        //    }
        //    return dt;
        //}

        #region Account Sub-head setup
        public static DataTable get_account_heads()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 0);

                //param[0] = dbManager.getparam("@AccountNo", account_no);
                //param[1] = dbManager.getparam("@ProductCode", product_code);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_accounts_head_get", param);
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

        public static DataTable get_account_sub_heads()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 0);

                //param[0] = dbManager.getparam("@AccountNo", account_no);
                //param[1] = dbManager.getparam("@ProductCode", product_code);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_accounts_sub_head_get", param);
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

        public static int Insert_account_sub_heads(string head_id, string sub_head)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            int chk;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                param[0] = dbManager.getparam("@AccTypeID", head_id);
                param[1] = dbManager.getparam("@AccountSubHead", sub_head);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_SubAccountTransactionTypeInfo_insert", param);
                chk = (int)dbManager.ExecuteScalar(cmd);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }
        #endregion

        public static DataTable get_commission_adjustment_due_details(string account_no)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@AccountNo", account_no);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_account_wise_adjustment_due_get", param);
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

        public static bool Insert_commission_child(CommissionCalc objTransaction)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);
                param[0] = dbManager.getparam("@CommissionCalcID", objTransaction.CommissionCalcID);
                param[1] = dbManager.getparam("@AccountNo", objTransaction.AccountNo);
                param[2] = dbManager.getparam("@ProductCode", objTransaction.ProductCode);
                param[3] = dbManager.getparam("@ClosingQty", objTransaction.ClossingQty);
                param[4] = dbManager.getparam("@CommissionPercent", objTransaction.CommissionPercent);
                param[5] = dbManager.getparam("@commission_date", objTransaction.CalcDate);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_child_insert", param);
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



        public static DataTable get_commission_calc_IDs(string fromDate,string toDate,string AccountHolderNo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);

                param[0] = dbManager.getparam("@fromDate", fromDate);
                param[1] = dbManager.getparam("@toDate", toDate);
                param[2] = dbManager.getparam("@accountHolder", AccountHolderNo);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_calc_id_get", param);
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
        public static DataTable get_commission_calc_details(string commissionID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@CommissionCalcID", commissionID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_commission_calc_details_get", param);
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

        public static bool insert_closing_stock_commission_wise(string ComissionID, string ClosingStockID)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isSaved = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

                param[0] = dbManager.getparam("@ComissionID", ComissionID);
                param[1] = dbManager.getparam("@ClosingStockID", ClosingStockID);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[insert_closing_stock_commission_wise]", param);
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
    }
}
