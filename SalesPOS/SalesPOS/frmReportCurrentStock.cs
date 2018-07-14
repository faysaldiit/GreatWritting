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
    public partial class frmReportCurrentStock : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmReportCurrentStock()
        {
            InitializeComponent();
        }

        private void frmReportCurrentStock_Load(object sender, EventArgs e)
        {
            cmb_product.Enabled = false;
            DataTable dt = bllProductInfo.getAll();

            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;

            LoadSection();

            DataTable dt1 = new DataTable();
            dt1 = bllManufacturerInfo.getAll();
            DataRow dr1 = dt1.NewRow();
            dr1["ManufacturerID"] = "0";
            dr1["ManufacturarName"] = "All";
            dt1.Rows.InsertAt(dr1, 0);
            cmb_manufacturer.Properties.DataSource = dt1;
            
            grp_product_current_stock.Visible = false;
        }

        

        private void LoadSection()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSectionInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["SectionID"] = "0";
                dr["SectionName"] = "Select All Category";
                dt.Rows.InsertAt(dr, 0);
                cmbSection.DisplayMember = "SectionName";
                cmbSection.ValueMember = "SectionID";
                cmbSection.DataSource = dt;
            }
            catch
            { }
        }

        private void LoadSubSection(long SectionId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSubSectionInfo.getBySectionId(SectionId);
                DataRow dr = dt.NewRow();
                dr["SubSectionID"] = "0";
                dr["SubSectionName"] = "Select All Sub Category";
                dt.Rows.InsertAt(dr, 0);
                cmbSubSection.DisplayMember = "SubSectionName";
                cmbSubSection.ValueMember = "SubSectionID";
                cmbSubSection.DataSource = dt;
            }
            catch
            { }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            long SectionID = Convert.ToInt64(this.cmbSection.SelectedValue);
            LoadSubSection(SectionID);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            PrintPreview(IsPrint);

        }

        private void PrintPreview(bool IsPrint)
        {
            string param_Manufacturer = "";
            string strSection = this.cmbSection.Text.ToString();
            string strSubSection = this.cmbSubSection.Text.ToString();

            string strSectionID = this.cmbSection.SelectedValue.ToString();
            string strSubSectionID = this.cmbSubSection.SelectedValue.ToString();
            string strManufacturerID="";
            string strProductCode = "0";
            if (chk_product.Checked)
            {
                if (cmb_product.EditValue == null)
                {
                    XtraMessageBox.Show("Please select product code");
                    cmb_product.Focus();
                    return;
                }
                strProductCode = cmb_product.EditValue.ToString();

            }
            if (cmb_manufacturer.EditValue == null || cmb_manufacturer.EditValue.ToString() == "")
            {
                strManufacturerID = "0";
                param_Manufacturer = "Manufacturer : All";
            }
            else
            {
                strManufacturerID = this.cmb_manufacturer.EditValue.ToString();
                param_Manufacturer = "Manufacturer : " + cmb_manufacturer.Text;
            }

            Hashtable ht = new Hashtable();

            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Current Stock Report");
            ht.Add("manufacturer", param_Manufacturer);
            //ht.Add("paramSubSection", strSubSection);


            string sql = "[dbo].[USP_RptCurrentStock]  '" + strSectionID.Trim() + "','" + strSubSectionID.Trim() + "','" + strManufacturerID + "','0','" + strProductCode+"'";
            rptCurrentStockSummary irptCurrentStockSummary = new rptCurrentStockSummary();
            iReportUtility.PrintPreview(irptCurrentStockSummary, sql, ht, IsPrint);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_product_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_product.Checked == true)
                cmb_product.Enabled = true;
            else
                cmb_product.Enabled = false;
        }

        private void lnk_material_stock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grp_material_stock.Visible = true;
            Cursor = Cursors.WaitCursor;
            DataTable dt = bllUtility.GetDataBySP("[load_material_current_stock] ");
            grd_material_stock.DataSource = dt;
            Cursor = Cursors.Default;
        }

        private void btn_close_material_stock_Click(object sender, EventArgs e)
        {
            grp_material_stock.Visible = false;
        }

       
        private void link_product_stock_storewise_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grp_product_current_stock.Visible = true;
            Cursor = Cursors.WaitCursor;
            DataTable dt = bllUtility.GetDataBySP("[rpt_stock_qty_storewise] ");
            grdStoreWiseProductStock.DataSource = dt;
            Cursor = Cursors.Default;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            grp_product_current_stock.Visible = false;
        }
        


    }
}
