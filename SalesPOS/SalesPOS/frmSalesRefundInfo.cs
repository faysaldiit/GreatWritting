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

namespace SalesPOS
{
    public partial class frmSalesRefundInfo : DevExpress.XtraEditors.XtraForm
    {
        public frmSalesRefundInfo()
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

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllProductSales.GetSalesInvoiceDetails(txtInvoiceNo.Text);
            this.dgvSalesGrid.AutoGenerateColumns = false;
            this.dgvSalesGrid.DataSource = dt;
        }

        private void frmSalesRefundInfo_Load(object sender, EventArgs e)
        {
            this.dgvSalesGrid.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvSalesGrid);
        }
    }
}
