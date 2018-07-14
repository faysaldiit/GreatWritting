using System;
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
    public partial class frmListOfSalesInvoice : DevExpress.XtraEditors.XtraForm
    {
        private string _SelctedInvoice = "";
        public frmListOfSalesInvoice()
        {
            InitializeComponent();
        }

        private void LoadTerminal()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllTerminalInfo.LoadTerminalList();
                DataRow dr = dt.NewRow();
                dr["TerminalID"] = "0";
                dr["TerminalName"] = "-----------All Terminal --------";
                dt.Rows.InsertAt(dr, 0);
                cmbTerminal.DisplayMember = "TerminalName";
                cmbTerminal.ValueMember = "TerminalID";
                cmbTerminal.DataSource = dt;
                cmbTerminal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void frmListOfSalesInvoice_Load(object sender, EventArgs e)
        {
            LoadTerminal();
            bllUtility.ResetGridColor(dgvSalesInvoiceList);
            load_customer();

            dgvSalesInvoiceList.AutoGenerateColumns = false;
        }

        private void load_customer()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID] 2");
            cmb_customer.Properties.DisplayMember = "AccHolderName";
            cmb_customer.Properties.ValueMember = "AccountNo";
            cmb_customer.Properties.DataSource = dt;

        }
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try 
            {
                string customer_id="";
                if (chk_all.Checked)
                {
                    customer_id = "";
                }
                else
                {
                    if (cmb_customer.EditValue == null || cmb_customer.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show("Customer selection required!");
                        return;
                    }
                    customer_id = cmb_customer.EditValue.ToString();
                }
                DataTable dt = new DataTable();
                dt = bllInvoiceList.LoadSalesInvoice(dtp_from.Value.ToString("dd/MM/yyyy"),dtp_to.Value.ToString("dd/MM/yyyy"), cmbTerminal.SelectedValue.ToString(), customer_id);
                dgvSalesInvoiceList.DataSource = dt;
                this.dgvSalesInvoiceList.DefaultCellStyle.ForeColor = Color.Black;                
                if (this.dgvSalesInvoiceList.Rows.Count > 0)
                    this.dgvSalesInvoiceList.Rows[0].Selected = false;
                lblRecordCount.Text = dt.Rows.Count.ToString();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_SelctedInvoice == "")
            {
                XtraMessageBox.Show("You have not select any invoice.","Information");
            }
            else
            {
                string SalesReturn = bllReportUtility.ReportData("Select IsNull(SalesReturn,0) from SalesParentInfo where InvoiceNo='" + _SelctedInvoice + "'").Rows[0][0].ToString();
                dsReport ds = new dsReport();
                DataSet dsSP = bllReports.GetSalesInvoice(_SelctedInvoice);
                try
                {
                    foreach (DataRow dr in dsSP.Tables[0].Rows)
                    {
                        ds.Tables["SalesParentInfo"].ImportRow(dr);
                    }
                    foreach (DataRow dr in dsSP.Tables[1].Rows)
                    {
                        ds.Tables["SalesChildInfo"].ImportRow(dr);
                    }
                    foreach (DataRow dr in bllCompanyInfo.getById(1).Rows)
                    {
                        ds.Tables["CompanyInfo"].ImportRow(dr);
                    }
                    rptSalesInvoice_Large rptTest = new Report.rptSalesInvoice_Large();
                    
                    rptTest.SetDataSource(ds);
                    rptTest.SetParameterValue("SalesReturn", bllUtility.Val(SalesReturn));
                    rptTest.PrintToPrinter(1, false, 0, 0);
                    
                    //frmRptv obj = new frmRptv();
                    //obj.SetReportDataSource = rptTest;
                    //obj.ShowDialog();
                }
                catch
                { }
            }
        }

        private void dgvSalesInvoiceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            {

            }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];                
                try
                {                    
                    this._SelctedInvoice= dr.Cells[0].Value.ToString();                    
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_SelctedInvoice == "")
            {
                XtraMessageBox.Show("You have not select any invoice.", "Information");
            }
            else
            {
                string SalesReturn = bllReportUtility.ReportData("Select IsNull(SalesReturn,0) from SalesParentInfo where InvoiceNo='" + _SelctedInvoice + "'").Rows[0][0].ToString();
                dsReport ds = new dsReport();
                DataSet dsSP = bllReports.GetSalesInvoice(_SelctedInvoice);
                try
                {
                    foreach (DataRow dr in dsSP.Tables[0].Rows)
                    {
                        ds.Tables["SalesParentInfo"].ImportRow(dr);
                    }
                    foreach (DataRow dr in dsSP.Tables[1].Rows)
                    {
                        ds.Tables["SalesChildInfo"].ImportRow(dr);
                    }
                    foreach (DataRow dr in bllCompanyInfo.getById(1).Rows)
                    {
                        ds.Tables["CompanyInfo"].ImportRow(dr);
                    }
                    rptSalesInvoice_Large rptTest = new Report.rptSalesInvoice_Large();
                    
                    
                    rptTest.SetDataSource(ds);
                    rptTest.SetParameterValue("SalesReturn", bllUtility.Val(SalesReturn));
                    //rptTest.PrintToPrinter(1, false, 0, 0);

                    frmRptv obj = new frmRptv();
                    obj.SetReportDataSource = rptTest;
                    obj.ShowDialog();
                }
                catch
                { }
            }
        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all.Checked)
                cmb_customer.Enabled = false;
            else
                cmb_customer.Enabled = true;
        }
    }
}
