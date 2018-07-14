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
    public partial class frmReportPurchaseStatement : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmReportPurchaseStatement()
        {
            InitializeComponent();
        }

        private void frmReportPurchaseStatement_Load(object sender, EventArgs e)
        {
            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;


            DataTable dt = new DataTable();
            dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID]" + 1);
            DataRow dr = dt.NewRow();
            dr["AccountNo"] = "0";
            dr["AccHolderName"] = "All";
            dt.Rows.InsertAt(dr, 0);
            cmb_supplier.Properties.DataSource = dt;


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

        private void PrintPreview(bool IsPrint)
        {
            string supplier_id = "";
            string manufacturer_id = "";
            string param_Supplier = "";
            string param_Manufacturer = "";

            if (cmb_supplier.EditValue == null || cmb_supplier.EditValue.ToString() == "")
            {
                supplier_id = "0";
                param_Supplier = "Supplier : All";
            }
            else
            {
                supplier_id = cmb_supplier.EditValue.ToString();
                param_Supplier = "Supplier : " + cmb_supplier.Text;
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

            string strDateFrom = bllUtility.FormatDate(dtpFrom);
            string strDateTo = bllUtility.FormatDate(dtpTo); 

            string sql = "";
            string ReportType = "";
            if (rptDetails.Checked == true)
            { ReportType = "Details"; }
            else
            { ReportType = "Summary"; }

            Hashtable ht = new Hashtable();


            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Purchase Statement Report");
            ht.Add("paramDateFrom", strDateFrom);
            ht.Add("paramDateTo", strDateTo);
           

            sql = "[dbo].[USP_RptPurchaseStatement] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "','" + ReportType + "','" + supplier_id + "','"+manufacturer_id+"'";
                        
            if (rptDetails.Checked == true)
            {
                ht.Add("supplier", param_Supplier);
                ht.Add("manufacturer", param_Manufacturer);
                rptPurchaseStatement irptPurchaseStatement = new rptPurchaseStatement();
                iReportUtility.PrintPreview(irptPurchaseStatement, sql, ht, IsPrint);
            }
            else
            {
                rptPurchaseStatementSummary irptPurchaseStatementSummary = new rptPurchaseStatementSummary();
                iReportUtility.PrintPreview(irptPurchaseStatementSummary, sql, ht, IsPrint);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opt_supplier_manufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (opt_supplier_manufacturer.SelectedIndex == 0)
            {
                cmb_manufacturer.Enabled = false;
                cmb_supplier.Enabled = true;
            }
            else
            {
                cmb_manufacturer.Enabled = true;
                cmb_supplier.Enabled = false;
            }
            cmb_supplier.EditValue = null;
            cmb_manufacturer.EditValue = null;
        }

        private void rptDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rptDetails.Checked == true)
            {
                cmb_manufacturer.Enabled = true;
                opt_supplier_manufacturer.Properties.Items[1].Enabled = true;           
            }
            else
            {
                cmb_manufacturer.Enabled = false;
                opt_supplier_manufacturer.Properties.Items[1].Enabled = false;  
            }
        }
    }
}
