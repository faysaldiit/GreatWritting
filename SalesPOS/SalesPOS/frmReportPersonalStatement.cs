using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesPOS.BOL;
using SalesPOS.BLL;
using SalesPOS.Report;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmReportPersonalStatement : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();
        public frmReportPersonalStatement()
        {
            InitializeComponent();
        }

        private void frmReportPersonalStatement_Load(object sender, EventArgs e)
        {
            lblClosingBalance.Text = "0";
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            PrintPreview(IsPrint);
        }
        private void PrintPreview(bool IsPrint)
        {
            string strDateFrom = bllUtility.FormatDate(dtpFrom);
            string strDateTo = bllUtility.FormatDate(dtpTo);
            string sql = "";

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Personal Statement");
            ht.Add("paramDateFrom", strDateFrom);
            ht.Add("paramDateTo", strDateTo);

            sql = "[dbo].[USP_RptAccountStatement_New] '" + txtAccountNo.Text.Trim() + "','" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
            rptAccountHolderStatement irptPersonalStatement = new rptAccountHolderStatement();
            iReportUtility.PrintPreview(irptPersonalStatement, sql, ht, IsPrint);


        }

        private void btnAccountNoSearch_Click(object sender, EventArgs e)
        {
            //frmCustomerSearch obj = new frmCustomerSearch(0);
            //obj.ShowDialog();
            //this.txtAccountName.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            //this.txtAccountNo.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            ////clearing global search object.
            //bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

            frmCustomerSearchNew obj = new frmCustomerSearchNew();
            obj.ShowDialog();

            this.txtAccountName.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtAccountNo.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

            if (txtAccountNo.Text == "")
                return;
            else
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = bllUtility.GetDataBySP("[rpt_account_last_closing_statement] '','" + txtAccountNo.Text + "'");
                if (dt.Rows.Count > 0)
                    lblClosingBalance.Text = dt.Rows[0]["Banance"].ToString();
                else lblClosingBalance.Text = "0";
                Cursor = Cursors.Default;
            }
        }

        private void txtAccountNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtAccountNo.TextLength == 14)
            {
                string strAccountNo = txtAccountNo.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNo, "");
                if (dt.Rows.Count > 0)
                {
                    txtAccountName.Text = dt.Rows[0]["AccHolderName"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Account Holder.", "Warning");
                    txtAccountName.Text = "";
                    txtAccountNo.Focus();
                    txtAccountNo.SelectAll();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
