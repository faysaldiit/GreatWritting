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
    public partial class frmRptIncomeStatement : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmRptIncomeStatement()
        {
            InitializeComponent();
        }

        private void frmRptIncomeStatement_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (chk_so_salaries_details.Checked == false)
            {
                IsPrint = false;
                PrintPreview(IsPrint);
            }
            else
            {
                string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
                string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");
                string sql = "[rpt_income_statement_details] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
                DataTable dt = bllUtility.GetDataBySP(sql);
                grd_report.DataSource = dt;
            }
        }

        private void PrintPreview(bool IsPrint)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");

            string sql = "";

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            //ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            //ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            //ht.Add("paramRptTitle", "Expenditure List");
            ht.Add("paramDateFrom", strDateFrom);
            ht.Add("paramDateTo", strDateTo);

            sql = "[rpt_income_statement] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
            rpt_income_statement irpt_income_statement = new rpt_income_statement();
            Cursor = Cursors.WaitCursor;
            iReportUtility.PrintPreview(irpt_income_statement, sql, ht, IsPrint);
            Cursor = Cursors.Default;

        }

    }
}