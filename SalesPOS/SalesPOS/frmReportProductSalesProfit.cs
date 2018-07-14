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
    public partial class frmReportProductSalesProfit : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmReportProductSalesProfit()
        {
            InitializeComponent();
        }

        private void frmReportProductSalesProfit_Load(object sender, EventArgs e)
        {
            LoadSection();
            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;
        }

        private void LoadSection()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSectionInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["SectionID"] = "0";
                dr["SectionName"] = "----Select All----";
                dt.Rows.InsertAt(dr, 0);
                cmbSection.DisplayMember = "SectionName";
                cmbSection.ValueMember = "SectionID";
                cmbSection.DataSource = dt;
            }
            catch
            { }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (chk_pivot.Checked == true)
            {
                string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
                string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");
                string strSectionID = this.cmbSection.SelectedValue.ToString();
                string sql = "[dbo].[USP_RptProductSalesProfit] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "','" + strSectionID.Trim() + "'";
                DataTable dt = bllUtility.GetDataBySP(sql);
                grd_report.DataSource = dt;
                grp_report.Visible = true;
            }
            else
            {
                grp_report.Visible = false;
                IsPrint = false;
                PrintPreview(IsPrint);
            }
            

        }

        private void PrintPreview(bool IsPrint)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy"); 
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");
            string strSectionID = this.cmbSection.SelectedValue.ToString();


            string sql = "";

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Profit Sales Analysis Report");
            ht.Add("paramDateFrom", strDateFrom);
            ht.Add("paramDateTo", strDateTo);

            sql = "[dbo].[USP_RptProductSalesProfit] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "','" + strSectionID.Trim() + "'";
            rptProfitLossSalesAnalysis irptProfitLossSalesAnalysis = new rptProfitLossSalesAnalysis();
            iReportUtility.PrintPreview(irptProfitLossSalesAnalysis, sql, ht, IsPrint);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_report_Click(object sender, EventArgs e)
        {
            grp_report.Visible = false;
        }

        private void btnPreviewPivotGrid_Click(object sender, EventArgs e)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");

           
                //Summary
                this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(30, 30, 60, 36);
                this.printableComponentLink1.MinMargins = new System.Drawing.Printing.Margins(10, 10, 20, 10);
                string reportHeader = "Sales Profit Analysis \r\n\r\n Date Range : " + strDateFrom + " to " + strDateTo;
                this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                    "",
                    reportHeader,
                    "\r\n\r\n "}, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Far),
                new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                    "Printed On: [Date Printed][Time Printed]",
                    "",
                    ""}, new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));

                printableComponentLink1.CreateDocument();
                printableComponentLink1.ShowPreview();
            
        }
    }
}
