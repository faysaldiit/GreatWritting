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
    public partial class frmReportCashBook : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmReportCashBook()
        {
            InitializeComponent();
        }

        private void frmReportCashBook_Load(object sender, EventArgs e)
        {
            this.dtpFrom.Value = DateTime.Now;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            PrintPreview(IsPrint);

        }

        private void PrintPreview(bool IsPrint)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");           

            string sql = "";

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Cash Book");
            ht.Add("paramDateFrom", strDateFrom);


            sql = "[dbo].[daily_cash_book] '" + strDateFrom.Trim() + "'";
            rptCashBook irptCashBook = new rptCashBook();
            iReportUtility.PrintPreview(irptCashBook, sql, ht, IsPrint);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
