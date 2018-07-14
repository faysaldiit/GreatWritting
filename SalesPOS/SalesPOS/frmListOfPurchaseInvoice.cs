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
    public partial class frmListOfPurchaseInvoice : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;        
        bllReportUtility iReportUtility = new bllReportUtility();
        private string _SelctedInvoice = "";
        public frmListOfPurchaseInvoice()
        {
            InitializeComponent();
        }

        private void frmListOfPurchaseInvoice_Load(object sender, EventArgs e)
        {
            bllUtility.ResetGridColor(dgvPurchaseInvoiceList);
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                string strDateFrom = this.dtpPurchaseDt.Value.ToString("dd/MM/yyyy");
                string strDateTo = this.dtp_to.Value.ToString("dd/MM/yyyy"); 
                DataTable dt = new DataTable();
                dt = bllInvoiceList.LoadPurchaseInvoice(strDateFrom, strDateTo);
                dgvPurchaseInvoiceList.DataSource = dt;
                this.dgvPurchaseInvoiceList.DefaultCellStyle.ForeColor = Color.Black;
                if (this.dgvPurchaseInvoiceList.Rows.Count > 0)
                    this.dgvPurchaseInvoiceList.Rows[0].Selected = false;
                lblRecordCount.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            IsPrint = false;
            PrintPreview(IsPrint);

        }

        private void PrintPreview(bool IsPrint)
        {
            if (_SelctedInvoice == "")
            {
                XtraMessageBox.Show("You have not selected any Invoice. Please select an Invoice.", "Information");
            }
            else
            {
                string sql = "";
                Hashtable ht = new Hashtable();

                ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
                ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
                ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
                ht.Add("paramRptTitle", "Purchase Invoice");

                //string invoiceID = "PUR00000000038";
                sql = "USP_RptPurchaseInvoice '" + _SelctedInvoice.Trim() + "'";
                rptPurchaseInvoice irptPurchaseInvoice = new rptPurchaseInvoice();
                iReportUtility.PrintPreview(irptPurchaseInvoice, sql, ht, IsPrint);
            }
        }

        private void dgvPurchaseInvoiceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            {

            }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                try
                {
                    this._SelctedInvoice = dr.Cells[0].Value.ToString();
                }
                catch { }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        
    }
}
