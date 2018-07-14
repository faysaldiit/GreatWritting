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
using System.Web;
using DevExpress.XtraEditors;
using SalesPOS.Report;

namespace SalesPOS
{
    public partial class frmMaterialPurchaseInfo : DevExpress.XtraEditors.XtraForm
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        PurchasePaymentInfo objPurchasePaymentInfo = new PurchasePaymentInfo();
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmMaterialPurchaseInfo()
        {
            InitializeComponent();
            this.ActiveControl = cmbMaterial;
        }

        private void frmPurchaseInfo_Load(object sender, EventArgs e)
        {
            bllUtility.ResetGridColor(dgvPurchaseGrid);
            ClearProductPurchaseInfo();
            ApplyDefaultSetting();
            load_material_info();
            this.dgvPurchaseGrid.DefaultCellStyle.ForeColor = Color.Black;
            ActiveControl = cmbMaterial;
            cmbMaterial.Focus();
        }

        private void load_material_info()
        {
            DataTable dt = bllMaterial.getAll();
            cmbMaterial.Properties.DisplayMember = "MaterialName";
            cmbMaterial.Properties.ValueMember = "MaterialID";
            cmbMaterial.Properties.DataSource = dt;
        }

        private void ApplyDefaultSetting()
        {
            // Load Default Setup
            bllSecurityInfo.SoftDefaultSetting();

            // Set Default Mini Account Allow or Not
            if (bllUtility.DefaultSettings.MiniAccAllow == "True")
            {
                this.grpSupplier.Visible = true;
                this.chkSupplier.Visible = true;
            }
            else
            {
                this.grpSupplier.Visible = false;
                this.chkSupplier.Visible = false;
            }

        }

        private void dgvPurchaseGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvPurchaseGrid.Columns[e.ColumnIndex].Name == "Quantity" || dgvPurchaseGrid.Columns[e.ColumnIndex].Name == "Price")
                {
                    int rowIdex = Convert.ToInt16(e.RowIndex);

                    if (dgvPurchaseGrid.Rows[rowIdex].Cells["Quantity"].Value != null && dgvPurchaseGrid.Rows[rowIdex].Cells["Price"].Value != null)
                    {
                        dgvPurchaseGrid.Rows[rowIdex].Cells["TotalPrice"].Value = bllUtility.Val(dgvPurchaseGrid.Rows[rowIdex].Cells["Quantity"].Value.ToString()) * bllUtility.Val(dgvPurchaseGrid.Rows[rowIdex].Cells["Price"].Value.ToString());
                    }
                }
            }
        }


        private void dgvPurchaseGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch { }
        }

        private void ClearProductPurchaseInfo()
        {
            this.dgvPurchaseGrid.Rows.Clear();
            this.txtPurchaseNo.Text = string.Empty;
            this.cmbMaterial.EditValue = null;
            this.txtMemoNo.Text = string.Empty;
            this.txtSupplierCode.Text = string.Empty;
            this.txtSupplierName.Text = string.Empty;
            this.txtPaid.Text = "0.00";
            this.txtDues.Text = "0.00";
            this.lblTotalItem.Text = "0";
            this.lblTotalItemAmount.Text = "0.00";
            this.chkSupplier.Checked = false;
            this.cmbMaterial.Focus();
            this.btnSave.Enabled = true;
            this.btnPrint.Enabled = false;
            this.btnAddToGrid.Enabled = true;
            this.cmbMaterial.Enabled = true;
            this.dgvPurchaseGrid.Enabled = true;
            chkSupplier.Enabled = true;
            chkSupplier.Checked = true;
            txtDescription.Text = "";
        }

        private string ConvertTake(string Input)
        {
            string output = "";
            output = Input;
            if (Input.IndexOf('.') > -1)
            {
                String[] arry = Input.Split('.');
                output = arry[0];
                if (arry[1] != "")
                    output = output + "." + arry[1];
            }
            return String.Format("{0:0.####}", Convert.ToDouble(output));
        }

        private static double dgvColumnSum(DataGridView dgv, string cellName)
        {
            double sumValue = 0;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[cellName].Value != null)
                {
                    string aa = dgv.Rows[i].Cells[cellName].Value.ToString();
                    sumValue += Convert.ToDouble(aa);
                }
            }
            return sumValue;
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearProductPurchaseInfo();
            ApplyDefaultSetting();
            cmbMaterial.Focus();
        }


        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked == true)
            {
                grpSupplier.Enabled = true;
            }
            else
            {
                grpSupplier.Enabled = false;
            }
        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.EditValue == null || cmbMaterial.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Please Select a Material first");
                cmbMaterial.Focus();
                return;
            }
            if (bllUtility.Val(txtMaterialQty.Text) == 0)
            {
                XtraMessageBox.Show("Please Enter the Product Quantity");
                txtMaterialQty.Focus();
                return;
            }
            if (bllUtility.Val(txtUnitPrice.Text) == 0)
            {
                XtraMessageBox.Show("Please Enter the Product Price");
                txtUnitPrice.Focus();
                return;
            }

            AddDataToPurchaseGrid();
            Calculate();
            txtMaterialQty.Text = "";
            txtUnitPrice.Text = "";
            cmbMaterial.Focus();

        }
        private void AddDataToPurchaseGrid()
        {
            dgvPurchaseGrid.Rows.Add();
            
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[0].Value = cmbMaterial.EditValue.ToString();
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[1].Value = cmbMaterial.Text.ToString();
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[2].Value = txtMaterialQty.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[3].Value = txtUnitPrice.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[4].Value = Math.Round(Convert.ToDouble(txtMaterialQty.Text) * Convert.ToDouble(txtUnitPrice.Text), 4);
            
        }
        private void Calculate()
        {
            lblTotalItem.Text = dgvPurchaseGrid.Rows.Count.ToString();
            lblTotalItemAmount.Text = String.Format("{0:0.##}", Convert.ToDouble(dgvColumnSum(dgvPurchaseGrid, "TotalPrice")));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseGrid.Rows.Count > 0)
            {
                if (Valid())
                {
                    SaveDate();
                    btnPrint.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("No information found for insert. Select the product first.");
                cmbMaterial.Focus();
            }
        }
        private bool Valid()
        {
            bool isValid = true;
            if (chkSupplier.Checked == true && String.IsNullOrEmpty(txtSupplierCode.Text))
            {
                isValid = false;
                XtraMessageBox.Show("Please Select Supplier.");
                this.txtSupplierCode.Focus();
                this.txtSupplierCode.SelectAll();
            }
            else if (this.txtPaid.Text == "")
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Paid Amount");
                this.txtPaid.Focus();
                this.txtPaid.SelectAll();
            }
            else if (Convert.ToDouble(this.lblTotalItemAmount.Text.Trim()) > Convert.ToDouble(this.txtPaid.Text.Trim()))
            {
                DialogResult result;
                result = XtraMessageBox.Show("Do you want to SAVE without payment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    isValid = true;
                else
                    isValid = false;
            }


            return isValid;
        }
        private void SaveDate()
        {
            string AccountNo = "";
            if (txtSupplierCode.Text == "")
                AccountNo = "SUP00000000000";
            else
                AccountNo = txtSupplierCode.Text;
            
            string PurchaseDate = dtpPurchaseDate.Value.ToString("dd/MM/yyyy");
            string MemoNo = txtMemoNo.Text.Trim();
            double TotalAmount = Convert.ToDouble(lblTotalItemAmount.Text.Trim());
            double TotalPaid = Convert.ToDouble(txtPaid.Text.Trim());
            string SupplierAccountNo = txtSupplierCode.Text.Trim();
            long CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
            string TransactionType = "Purchase";
            

            //execute the master purchase information & get the purchase no
            DataTable dt = bllMaterialPurchase.InsertPurchaseMaster(PurchaseDate, MemoNo, TotalAmount, TotalPaid, SupplierAccountNo, CreatedBy,TransactionType);
            string purchaseID = dt.Rows[0][0].ToString();

            for (int i = 0; i < dgvPurchaseGrid.Rows.Count; i++)
            {
                //execute purchase master details info...........
                bool chk = bllMaterialPurchase.InsertPurchaseMasterDetails(purchaseID.Trim(), dgvPurchaseGrid.Rows[i].Cells["MaterialID"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["Quantity"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["UnitPrice"].Value.ToString().Trim(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
            }


            //disable save button
            this.txtPurchaseNo.Text = purchaseID;

            this.btnSave.Enabled = false;
            this.btnAddToGrid.Enabled = false;
            this.cmbMaterial.Enabled = false;
            this.dgvPurchaseGrid.Enabled = false;
            this.btnPrint.Enabled = true;


            /********************************************************
            * Save Purchase Payment
            * *******************************************************/
            //InitializePurchasePaymentInfo();
            //bllMaterialPurchase.InsertPurchasePayment(objPurchasePaymentInfo);

            /*Account transaction for sales*/
            bllProductSales.InsertAccountTransactionBySystem("Purchase", lblTotalItemAmount.Text, txtPurchaseNo.Text, "Material Purchase "+ txtDescription.Text.Replace("'","").Replace(",",""), bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);

            if (Convert.ToDouble(txtPaid.Text) > 0)
                bllProductSales.InsertAccountTransactionBySystem("Cash Paid", txtPaid.Text, txtPurchaseNo.Text, "Material Purchase " + txtDescription.Text.Replace("'", "").Replace(",", ""), bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);


            //display successful message
            XtraMessageBox.Show("Successfully Inserted the purchase information");

        }
        private void InitializePurchasePaymentInfo()
        {
            objPurchasePaymentInfo.PurchaseID = txtPurchaseNo.Text;
            objPurchasePaymentInfo.PaidAmount = txtPaid.Text;
            if (txtSupplierCode.Text == "")
            {
                objPurchasePaymentInfo.SupplierID = "";
            }
            else
            {
                objPurchasePaymentInfo.SupplierID = txtSupplierCode.Text.Trim();
            }
            objPurchasePaymentInfo.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
            objPurchasePaymentInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPaid_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                btnSave.Focus();
            }
        }

        private void frmPurchaseInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.txtPaid.Focus();
                this.txtPaid.SelectAll();
            }
            else if (e.KeyCode == Keys.F2)
            {
                this.chkSupplier.Checked = true;
                this.txtSupplierCode.Focus();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnResetForm_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }


        private void CalculateAmount()
        {
            if (txtPaid.Text == "")
            {
                this.txtPaid.Text = "0";
            }
            this.txtDues.Text = Convert.ToString(Convert.ToDecimal(this.lblTotalItemAmount.Text) - Convert.ToDecimal(this.txtPaid.Text));

        }

        private void lblTotalItemAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtSupplierCode_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSupplierCode.Text.Length == 14)
            {
                string strAccountNo = txtSupplierCode.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNo, "1");
                if (dt.Rows.Count > 0)
                {
                    txtSupplierName.Text = dt.Rows[0]["AccHolderName"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Account Holder.", "Warning");
                    txtSupplierName.Text = "";
                    txtSupplierCode.Focus();
                    txtSupplierCode.SelectAll();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //string sql = "";
            //System.Collections.Hashtable ht = new System.Collections.Hashtable();

            //ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            //ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            //ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            //ht.Add("paramRptTitle", "Purchase Invoice");

            //sql = "USP_RptPurchaseInvoice '" + txtPurchaseNo.Text.Trim() + "'";
            //rptPurchaseInvoice irptPurchaseInvoice = new rptPurchaseInvoice();
            //iReportUtility.PrintPreview(irptPurchaseInvoice, sql, ht, false);
            //btnPrint.Enabled = false;
            //btnResetForm.Focus();
        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            frmCustomerSearch obj = new frmCustomerSearch(1); // 1=Supplier
            obj.ShowDialog();
            this.txtSupplierName.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtSupplierCode.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;
        }

        private void dgvPurchaseGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.dgvPurchaseGrid.Rows.RemoveAt(dgvPurchaseGrid.CurrentCell.RowIndex);
                //this.lblTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvPurchaseGrid, "TotalPriceWithVat")));
                Calculate();
            }
        }

        private void mnu_delete_Click(object sender, EventArgs e)
        {
            this.dgvPurchaseGrid.Rows.RemoveAt(dgvPurchaseGrid.CurrentCell.RowIndex);
            //this.lblTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvPurchaseGrid, "TotalPriceWithVat")));
            Calculate();
        }


        private void txtMaterialQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        private void cmbMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMaterialQty.Focus();
        }

        private void txtMaterialQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUnitPrice.Focus();
        }

        private void txtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddToGrid_Click(sender,e);
        }

    }
}
