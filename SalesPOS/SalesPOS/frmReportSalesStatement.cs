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
    public partial class frmReportSalesStatement : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmReportSalesStatement()
        {
            InitializeComponent();
        }

        private void frmReportSalesStatement_Load(object sender, EventArgs e)
        {

            DataTable dt = bllProductInfo.getAll();

            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;

            load_customer();

            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;

            chk_all_customer.Checked = true;
            chk_all_product.Checked = true;
        }
        private void load_customer()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID] 2");
            cmb_customer.Properties.DisplayMember = "AccHolderName";
            cmb_customer.Properties.ValueMember = "AccountNo";
            cmb_customer.Properties.DataSource = dt;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            PrintPreview(IsPrint);
        }

        private void PrintPreview(bool IsPrint)
        {
            string customer_id = "";
            string product_id = "";
            string isPivot = "0";
            string param_customer = "Customer : All";
            string strDateFrom = bllUtility.FormatDate(dtpFrom);
            string strDateTo = bllUtility.FormatDate(dtpTo);
            string sql = "";
            string ReportType = "";
            if (rptDetails.Checked == true)
            { ReportType = "Details"; }
            else if (rptSummary.Checked == true)
            { ReportType = "Summary"; }
            if (chk_pivot.Checked == true)
                isPivot = "1";

            //if (rptDetails.Checked == true)
            //{
            if (rptDetails.Checked == true && chk_all_product.Checked == false)
            {
                if (cmb_product.EditValue == null || cmb_product.EditValue.ToString() == "")
                {
                    MessageBox.Show("Please select product code.");
                    return;
                }
                product_id = cmb_product.EditValue.ToString();
            }
            if (chk_all_customer.Checked == false)
            {
                if (cmb_customer.EditValue == null || cmb_customer.EditValue.ToString() == "")
                {
                    MessageBox.Show("Please select Customer.");
                    return;
                }
                customer_id = cmb_customer.EditValue.ToString();
                param_customer = "Customer : " + cmb_customer.Text;
            }
            //}

            sql = "[dbo].[USP_RptProductSalesStatement]  '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "','" + ReportType + "','" + customer_id + "','" + product_id + "','" + isPivot+"'";

            if (chk_pivot.Checked == true)
            {
                DataTable dt= bllUtility.GetDataBySP(sql);
                grd_details_report.Visible = false;
                grd_summary_report.Visible = false;
                if (rptSummary.Checked)
                {
                    //summary
                    grd_summary_report.DataSource = dt;
                    grd_summary_report.Dock = DockStyle.Fill;
                    grd_summary_report.Visible = true;
                }
                else
                {
                    //details
                    grd_details_report.DataSource = dt;
                    grd_details_report.Dock = DockStyle.Fill;
                    grd_details_report.Visible = true;
                }

                grp_report.Visible = true;
            }
            else
            {
                Hashtable ht = new Hashtable();

                ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
                ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
                ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
                ht.Add("paramRptTitle", "Sales Statement");
                ht.Add("paramDateFrom", strDateFrom);
                ht.Add("paramDateTo", strDateTo);


                Cursor = Cursors.WaitCursor;
                if (rptDetails.Checked == true)
                {
                    ht.Add("manufacturer", param_customer);
                    rptSalesStatement irptSalesStatement = new rptSalesStatement();
                    iReportUtility.PrintPreview(irptSalesStatement, sql, ht, IsPrint);
                }
                else
                {
                    rptSalesStatementSummary irptSalesStatementSummary = new rptSalesStatementSummary();
                    iReportUtility.PrintPreview(irptSalesStatementSummary, sql, ht, IsPrint);
                }
                Cursor = Cursors.Default;
            }



            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rptDetails_CheckedChanged(object sender, EventArgs e)
        {

            if (rptDetails.Checked == true)
            {
                cmb_customer.Enabled = false;
                cmb_product.Enabled = false;
                chk_all_customer.Enabled = true;
                chk_all_product.Enabled = true;
                chk_all_customer.Checked = true;
                chk_all_product.Checked = true;
            }
            else if (rptSummary.Checked == true)
            {
                //cmb_customer.Enabled = true;
                cmb_product.Enabled = false;
                chk_all_customer.Enabled = true;
                chk_all_product.Enabled = false;
            }

        }

        private void chk_product_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all_product.Checked == false)
                cmb_product.Enabled = true;
            else
                cmb_product.Enabled = false;
        }

        private void rptSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (rptDetails.Checked == true)
            {
                cmb_customer.Enabled = false;
                cmb_product.Enabled = false;
                chk_all_customer.Enabled = true;
                chk_all_product.Enabled = true;
                chk_all_customer.Checked = true;
                chk_all_product.Checked = true;
            }
            else if (rptSummary.Checked == true)
            {
                //cmb_customer.Enabled = true;
                cmb_product.Enabled = false;
                chk_all_customer.Enabled = true;
                chk_all_product.Enabled = false;
            }
        }

        private void chk_all_customer_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all_customer.Checked == false)
                cmb_customer.Enabled = true;
            else
                cmb_customer.Enabled = false;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_close_report_Click(object sender, EventArgs e)
        {
            grp_report.Visible = false;
        }

        
        private void btnPreviewPivotGrid_Click(object sender, EventArgs e)
        {           
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");

            if (rptSummary.Checked)
            {
                //Summary
                this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(30, 30, 60, 36);
                this.printableComponentLink1.MinMargins = new System.Drawing.Printing.Margins(10, 10, 20, 10);
                string reportHeader = "Sales Summary \r\n\r\n Date Range : " + strDateFrom + " to " + strDateTo;
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
            else
            {
                //Details
                this.printableComponentLink2.Margins = new System.Drawing.Printing.Margins(30, 30, 60, 36);
                this.printableComponentLink2.MinMargins = new System.Drawing.Printing.Margins(10, 10, 20, 10);
                string reportHeader = "Sales Details \r\n\r\n Date Range : " + strDateFrom + " to " + strDateTo;
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
        }
    }
}
