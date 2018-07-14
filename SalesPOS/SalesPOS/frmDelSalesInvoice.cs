using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesPOS.BLL;
using SalesPOS.BOL;
using DevExpress.XtraEditors;
using SalesPOS.DataAccessLayer;

namespace SalesPOS
{
    public partial class frmDelSalesInvoice : DevExpress.XtraEditors.XtraForm
    {
        public frmDelSalesInvoice()
        {
            InitializeComponent();
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {            
            if (this.txtInvoiceNo.TextLength == 14)
            {
                string strinvoiceNo = this.txtInvoiceNo.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllProductSales.GetSalesInvoiceParentInfo(strinvoiceNo);
                if (dt.Rows.Count > 0)
                {
                    txtSalesDate.Text = dt.Rows[0]["SalesDate"].ToString();
                    this.btnDelete.Enabled = true;
                    this.btnDelete.Focus();
                    LoadGrid();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Invoice No.", "Warning");
                    this.txtSalesDate.Text = "";
                    this.txtInvoiceNo.Focus();
                    this.txtInvoiceNo.SelectAll();
                }
            }
        }

        private void frmDelSalesInvoice_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtInvoiceNo;
            this.txtInvoiceNo.Focus();
            LoadPurpose();
            //this.dgvSalesGrid.DefaultCellStyle.ForeColor = Color.Black;
            //bllUtility.ResetGridColor(dgvSalesGrid);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbPurpose.SelectedValue.ToString() == "0")
            {
                XtraMessageBox.Show("You have to select a reason for delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPurpose.Focus();
            }            
            else
            {
                DialogResult result;
                result = XtraMessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    
                    DataAccess obj = new DataAccess();
                    obj.Transaction_Begin();
                    DataTable dt = obj.IUD("USP_DeleteSalesInvoice '" + txtInvoiceNo.Text + "'," + Convert.ToInt64(cmbPurpose.SelectedValue) + "," + bllUtility.LoggedInSystemInformation.LoggedUserId + "," + Convert.ToInt64(bllUtility.LoggedInSystemInformation.TerminalID));
                    if (obj.IsErrorRise())
                    {
                        XtraMessageBox.Show(obj.ErrorMassege(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    obj.Transaction_Commit();
                    XtraMessageBox.Show("Successfully Deleted the Invoice.", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.grd_sales.DataSource = null;
                    this.btnDelete.Enabled = false;
                    this.txtInvoiceNo.Text = string.Empty;
                    this.txtSalesDate.Text = string.Empty;
                    this.txtInvoiceNo.Focus();
                }
            }
        }

        //private void DeleteData()
        //{
        //    bool chk = bllProductSales.DeleteSalesInvoice(txtInvoiceNo.Text, Convert.ToInt64(cmbPurpose.SelectedValue));
        //    if (chk == true)
        //    {
        //        XtraMessageBox.Show("Successfully Deleted the Invoice.", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.grd_sales.DataSource = null;
        //        this.btnDelete.Enabled = false;
        //        this.txtInvoiceNo.Text = string.Empty;
        //        this.txtSalesDate.Text = string.Empty;
        //        this.txtInvoiceNo.Focus();
        //    }
        //    else
        //    {
        //        XtraMessageBox.Show("Unable to Delete", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllProductSales.GetSalesInvoiceDetails(txtInvoiceNo.Text);
            //this.dgvSalesGrid.AutoGenerateColumns = false;
            this.grd_sales.DataSource = dt;            
        }

        private void LoadPurpose()
        {
            DataTable dt = new DataTable();
            dt = bllPurposeInfo.LoadPurpose();
            this.cmbPurpose.DisplayMember = "Purpose";
            this.cmbPurpose.ValueMember = "ID";
            this.cmbPurpose.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
