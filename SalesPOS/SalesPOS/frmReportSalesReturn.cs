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
    public partial class frmReportSalesReturn : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();
        public frmReportSalesReturn()
        {
            InitializeComponent();
        }

        private void frpReportSalesReturn_Load(object sender, EventArgs e)
        {
            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;
            cmb_product.Enabled = false;

            DataTable dt = bllProductInfo.getAll();

            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;

            DataTable dt1 = new DataTable();
            dt1 = bllManufacturerInfo.getAll();
            DataRow dr1 = dt1.NewRow();
            dr1["ManufacturerID"] = "0";
            dr1["ManufacturarName"] = "All";
            dt1.Rows.InsertAt(dr1, 0);
            cmb_manufacturer.Properties.DataSource = dt1;

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            PrintPreview(IsPrint);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintPreview(bool IsPrint)
        {
            string manufacturer_id = "";
            string product_id = "";
            string param_Manufacturer = "";
            string strDateFrom = bllUtility.FormatDate(dtpFrom);
            string strDateTo = bllUtility.FormatDate(dtpTo);
            
            string sql = "";
            string ReportType = "";
            if (rptDetails.Checked == true)
            { ReportType = "Details"; }
            else
            { ReportType = "Summary"; }

            if (chk_product.Checked == true)
            {
                if (cmb_product.EditValue == null || cmb_product.EditValue.ToString() == "")
                {
                    MessageBox.Show("Please select product code.");
                    return;
                }
                else
                {
                    product_id = cmb_product.EditValue.ToString();
                }
            }
            else
            {
                product_id = "0";
            }

            if (cmb_manufacturer.EditValue == null || cmb_manufacturer.EditValue.ToString() == "")
            {
                manufacturer_id = "0";
                param_Manufacturer = "Manufacturer : All";
            }
            else
            {
                manufacturer_id = cmb_manufacturer.EditValue.ToString();
                param_Manufacturer = "Manufacturer : " + cmb_manufacturer.Text;
            }

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Sales Return Statement");
            ht.Add("paramDateFrom", strDateFrom);
            ht.Add("paramDateTo", strDateTo);

            sql = "[dbo].[USP_Rpt_Product_SalesReturn_Statement]  '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "','" + ReportType + "','"+manufacturer_id+"','"+product_id+"'";

            if (rptDetails.Checked == true)
            {
                rptSalesReturnDetails irptSalesReturnDetails = new rptSalesReturnDetails();
                iReportUtility.PrintPreview(irptSalesReturnDetails, sql, ht, IsPrint);
            }
            else
            {
                rptSalesReturn_Summary irptSalesReturn_Summary = new rptSalesReturn_Summary();
                iReportUtility.PrintPreview(irptSalesReturn_Summary, sql, ht, IsPrint);
            }

        }

        private void chk_product_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_product.Checked == true)
                cmb_product.Enabled = true;
            else
                cmb_product.Enabled = false;
        }

        private void rptDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rptDetails.Checked == true)
                cmb_manufacturer.Enabled = true;
            else
                cmb_manufacturer.Enabled = false;
        }

    }
}
