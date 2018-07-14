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
    public partial class frmReportExpenditure : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmReportExpenditure()
        {
            InitializeComponent();
        }

        private void frmReportExpenditure_Load(object sender, EventArgs e)
        {
            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //IsPrint = false;
            //PrintPreview(IsPrint);
            //printableComponentLink1.ShowPreview();
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy"); 

            this.printableComponentLink2.Margins = new System.Drawing.Printing.Margins(30, 30, 60, 36);
            this.printableComponentLink2.MinMargins = new System.Drawing.Printing.Margins(10, 10, 20, 10);
            string reportHeader = "Expense Report \r\n\r\n Date Range : " + strDateFrom + " to " + strDateTo;
            this.printableComponentLink2.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                    "",
                    reportHeader,
                    "\r\n\r\n "}, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Far),
            new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                    "Printed On: [Date Printed][Time Printed]",
                    "",
                    ""}, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));

            printableComponentLink2.CreateDocument();
            printableComponentLink2.ShowPreview();

        }

        private void PrintPreview(bool IsPrint)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy"); 
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy"); 

            string sql = "";

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Expenditure List");
            ht.Add("paramDateFrom", strDateFrom);
            ht.Add("paramDateTo", strDateTo);

            sql = "[USP_RptExpense] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
            rptExpenditure irptExpenditure = new rptExpenditure();
            iReportUtility.PrintPreview(irptExpenditure, sql, ht, IsPrint);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy"); 

            Cursor = Cursors.WaitCursor;
            DataTable dt = bllUtility.GetDataBySP("USP_RptExpense '" + strDateFrom + "','" + strDateTo + "'");
            grd_report.DataSource = dt;
            Cursor = Cursors.Default;
        }

    }
}
