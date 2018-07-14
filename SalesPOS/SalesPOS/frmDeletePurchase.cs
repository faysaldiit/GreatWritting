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
using DevExpress.XtraEditors;


namespace SalesPOS
{
    public partial class frmDeletePurchase : DevExpress.XtraEditors.XtraForm
    {
        public frmDeletePurchase()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;
                if (dgvGrid.Rows.Count > 0)
                {
                    dt = bllReportUtility.ReportData("[dbo].[CheckDeletePurchaseInfo] '" + txtInvoiceNo.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == dt.Rows[0][1].ToString() && dt.Rows[0][0].ToString() != "0" && dt.Rows[0][1].ToString() != "0")
                        {
                            DialogResult result;
                            result = XtraMessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                bllReportUtility.Exec_Store_Procedure("[DeletePurchaseInfo] '" + txtInvoiceNo.Text.Trim() + "'");
                                XtraMessageBox.Show("You have successfully deleted the purchase record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvGrid.DataSource = null;
                                txtInvoiceNo.Text = "";
                                txtPurchaseDate.Text = "";
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("You can not delete this purchase information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("You have not select any purchase no for delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void frmDeletePurchase_Load(object sender, EventArgs e)
        {
            dgvGrid.AutoGenerateColumns = false;
            bllUtility.ResetGridColor(dgvGrid);
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtInvoiceNo.TextLength == 14)
            {
                //string strinvoiceNo = this.txtInvoiceNo.Text.ToUpper();
                DataTable dt1;
                
                dt1 = bllReportUtility.ReportData("SELECT PurchaseDate FROM  PurchaseMasterInfo WHERE (PurchaseID = '" + txtInvoiceNo.Text.Trim() + "')");
                if (dt1.Rows.Count > 0)
                {
                    txtPurchaseDate.Text = dt1.Rows[0][0].ToString();
                    dgvGrid.DataSource = bllProductPurchase.LoadPurchase_For_Delete(txtInvoiceNo.Text.Trim());

                }
                else
                {
                    XtraMessageBox.Show("Invalid Invoice No.", "Warning");
                    this.txtPurchaseDate.Text = "";
                    dgvGrid.DataSource = null;
                    this.txtInvoiceNo.Focus();
                    this.txtInvoiceNo.SelectAll();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
