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
    public partial class frmPurchaseInfo : DevExpress.XtraEditors.XtraForm
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        PurchasePaymentInfo objPurchasePaymentInfo = new PurchasePaymentInfo();
        bllReportUtility iReportUtility = new bllReportUtility();       

        public frmPurchaseInfo()
        {
            InitializeComponent();
            this.ActiveControl = txtProductID;
        }       

        private void frmPurchaseInfo_Load(object sender, EventArgs e)
        {
            
            bllUtility.ResetGridColor(dgvPurchaseGrid);
            bllUtility.ResetGridColor(dgvProductUnitQuantity);
           

            InitializeProductName();//Initial product name to txtProductID for Auto suggetion            
            ClearProductPurchaseInfo();
            ApplyDefaultSetting();
            ClearUnitInfo();            
            this.dgvProductUnitQuantity.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvPurchaseGrid.DefaultCellStyle.ForeColor = Color.Black;
            dtpExpireDate.Visible = false;  
            txtProductID.Focus();
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

        private void InitializeProductName()
        {
            DataTable dt = new DataTable();
            dt = bllProductInfo.getAll_Active();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesCollection.Add(dt.Rows[i][1].ToString());
            }

            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteCustomSource = namesCollection;
        }

        private void loadUnitGrid()
        {
            if (txtProductID.Text != "")
            {
                DataTable dt = new DataTable();
                dt = bllProductUnitPrice.getProductAllUnitPrice(txtProductID.Text);
                if (dt.Rows.Count > 0)
                {
                    this.dgvProductUnitQuantity.AutoGenerateColumns = false;
                    this.dgvProductUnitQuantity.DataSource = dt;

                    // dgvProductUnitQuantity.CurrentCell = dgvProductUnitQuantity.Rows[1].Cells[1];
                    lblProductID.Text = txtProductID.Text.ToUpper();
                    lblProductName.Text = txtProductName.Text;
                    lblTotalQty.Text = "0";
                    lblUnitPrice.Text = "0.00";
                    dgvProductUnitQuantity.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Test_EditingControlShowing);
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    this.dgvProductUnitQuantity.Rows[0].Cells[2].Selected = true;
                    //btnAddToGrid.Focus();
                }
            }
        }

        private void Test_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Test_Control_KeyPress);
        }

        private void Test_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumnName = dgvProductUnitQuantity.Columns[dgvProductUnitQuantity.CurrentCell.ColumnIndex].Name;
            if (ColumnName == "EnteredQuantity")
            {
                if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)//|| e.KeyChar == 46)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (ColumnName == "UPrice")
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
                        dgvPurchaseGrid.Rows[rowIdex].Cells["TotalPrice"].Value = _Convert(dgvPurchaseGrid.Rows[rowIdex].Cells["Quantity"].Value.ToString()) * _Convert(dgvPurchaseGrid.Rows[rowIdex].Cells["Price"].Value.ToString());
                    }
                }
            }
        }

        private double _Convert(string value)
        {
            double Cvalue = 0.00;

            if (value != "")
            {
                Cvalue = Convert.ToDouble(value);
            }
            return Cvalue;

        }

        private void dgvPurchaseGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch { }
        }

        private void btnResetGrid_Click(object sender, EventArgs e)
        {
            ClearUnitInfo();
            txtProductName.Focus();
        }

        private void ClearUnitInfo()
        {
            this.dgvProductUnitQuantity.DataSource = null;
            this.lblTotalQty.Text = "0";
            this.lblUnitPrice.Text = "0.00";
            this.lblProductName.Text = string.Empty;
            this.lblProductID.Text = string.Empty;
            this.lblMinimumUnit.Text = string.Empty;
            this.lblMinimumUnitID.Text = string.Empty; 
            

            if (bllUtility.DefaultSettings.ExpireDateAllow == "True")
            {
                chkExpireDate.Checked = true;
                dtpExpireDate.Visible = true;                
            }
            else
            {
                chkExpireDate.Checked = false;
                dtpExpireDate.Visible = false;                
            }
            dtpExpireDate.Visible = false;  
        }

        private void ClearProductPurchaseInfo()
        {
            this.dgvPurchaseGrid.Rows.Clear();
            this.txtPurchaseNo.Text = string.Empty;
            this.txtProductID.Text = string.Empty;
            this.txtProductName.Text = string.Empty;
            this.txtMemoNo.Text = string.Empty;
            this.txtSupplierCode.Text = string.Empty;
            this.txtSupplierName.Text = string.Empty;
            this.txtPaid.Text = "0.00";
            this.txtDues.Text = "0.00";
            this.lblTotalItem.Text = "0";
            this.lblTotalItemAmount.Text = "0.00";
            this.chkSupplier.Checked = false;
            this.txtProductName.Focus();
            this.btnSave.Enabled = true;
            this.btnPrint.Enabled = false;
            this.btnResetGrid.Enabled = true;
            this.btnAddToGrid.Enabled = true;
            this.txtProductID.Enabled = true;
            this.txtProductName.Enabled = true;
            this.dgvPurchaseGrid.Enabled = true;
            this.dgvProductUnitQuantity.Enabled = true;
            chkSupplier.Enabled = true;
            chkSupplier.Checked = true;
            txtDescription.Text = "";
        }

        private void dgvProductUnitQuantity_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvProductUnitQuantity.Columns[e.ColumnIndex].Name == "EnteredQuantity")
                {
                    int rowIdex = Convert.ToInt16(e.RowIndex);

                    if (dgvProductUnitQuantity.Rows[rowIdex].Cells["EnteredQuantity"].Value != null)
                    {
                        string aa = ConvertTake(dgvProductUnitQuantity.Rows[rowIdex].Cells["EnteredQuantity"].Value.ToString());
                        dgvProductUnitQuantity.Rows[rowIdex].Cells["PTotalQuantity"].Value = _Convert(aa) * _Convert(dgvProductUnitQuantity.Rows[rowIdex].Cells["UnitQuantity"].Value.ToString());
                        dgvProductUnitQuantity.Rows[rowIdex].Cells["EnteredQuantity"].Value = aa;
                        lblTotalQty.Text = Convert.ToString(dgvColumnSum(dgvProductUnitQuantity, "PTotalQuantity"));
                    }
                }
                else if (dgvProductUnitQuantity.Columns[e.ColumnIndex].Name == "UPrice")
                {
                    int rowIdex = Convert.ToInt16(e.RowIndex);
                    if (dgvProductUnitQuantity.Rows[rowIdex].Cells["UPrice"].Value != null)
                    {
                        string aa = ConvertTake(dgvProductUnitQuantity.Rows[rowIdex].Cells["UPrice"].Value.ToString());
                        dgvProductUnitQuantity.Rows[rowIdex].Cells["UPrice"].Value = aa;
                        lblUnitPrice.Text = Convert.ToString(dgvColumnSum(dgvProductUnitQuantity, "UPrice"));
                    }
                }
            }
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

        private void dgvProductUnitQuantity_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

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

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                for (int i = 0; i < namesCollection.Count; i++)
                {
                    if (txtProductName.Text == namesCollection[i])
                    {
                        txtProductID.Text = bllProductInfo.getProductID(txtProductName.Text);
                        load_product_info();
                        loadUnitGrid();
                    }
                }
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            frmProductSearch obj = new frmProductSearch();
            obj.ShowDialog();
            //XtraMessageBox.Show("test");
            txtProductName.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductName; //test code rasel
            txtProductID.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductID;
            if (txtProductID.Text.Length > 4)
                load_product_info();
            //clearing global search object.
            bllUtility.ReturnSearchedProduct.returnSearchedProductInfo = null;
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 80 || e.KeyChar == 112)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            //if (txtProductID.Text.Length == 10)
            //{
            //    //ClearUnitInfo();

            //    DataTable dt = new DataTable();
            //    dt = bllProductUnitPrice.GetMinimumUnitByID(txtProductID.Text);

            //    //checking is there any minimum unit set for this product
            //    if (dt.Rows.Count > 0)
            //    {
            //        txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
            //        lblMinimumUnit.Text = dt.Rows[0]["UnitName"].ToString();
            //        lblMinimumUnitID.Text = dt.Rows[0]["UnitId"].ToString();
            //        loadUnitGrid();
            //        //txtProductID.LostFocus();    
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("No Minimum Unit Setup for this Product. Please Configure the Product first.");
            //        txtProductName.Text = "";
            //        txtProductID.Focus();
            //    }
            //}
        }

        private void load_product_info()
        {
            //ClearUnitInfo();

            DataTable dt = new DataTable();
            dt = bllProductUnitPrice.GetMinimumUnitByID(txtProductID.Text);

            //checking is there any minimum unit set for this product
            if (dt.Rows.Count > 0)
            {
                txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                lblMinimumUnit.Text = dt.Rows[0]["UnitName"].ToString();
                lblMinimumUnitID.Text = dt.Rows[0]["UnitId"].ToString();
                loadUnitGrid();
                //txtProductID.LostFocus();    
            }
            else
            {
                XtraMessageBox.Show("No Minimum Unit Setup for this Product. Please Configure the Product first.");
                txtProductName.Text = "";
                txtProductID.Focus();
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearProductPurchaseInfo();
            ClearUnitInfo();
            ApplyDefaultSetting();
            txtProductID.Focus();
        }

        private void chkExpireDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpireDate.Checked == true)            
                dtpExpireDate.Visible = true; 
            else
                dtpExpireDate.Visible = false;
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
            if (lblProductID.Text == "")
            {
                XtraMessageBox.Show("Please Select a Product first");
            }
            else if (lblTotalQty.Text == "0")
            {
                XtraMessageBox.Show("Please Enter the Product Quantity");
            }
            else if (lblUnitPrice.Text == "0.00")
            {
                XtraMessageBox.Show("Please Enter the Product Price");
            }
            else
            {
                
                AddDataToPurchaseGrid();
                Calculate();
                txtProductID.Focus();
            }
        }
        private void AddDataToPurchaseGrid()
        {
            dgvPurchaseGrid.Rows.Add();
            string strExpDate = string.Empty;
            if (chkExpireDate.Checked == true)
            {
                strExpDate = dtpExpireDate.Text;
            }
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[0].Value = lblProductID.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[1].Value = lblProductName.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[2].Value = lblTotalQty.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[3].Value = lblMinimumUnit.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[4].Value = lblUnitPrice.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[5].Value = Math.Round(Convert.ToDouble(lblTotalQty.Text)*Convert.ToDouble(lblUnitPrice.Text),4);
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells["ExpireDate"].Value = strExpDate;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[7].Value = chkExpireDate.Checked;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[8].Value = lblMinimumUnitID.Text;

            ClearUnitInfo();
        }
        private void Calculate()
        {
            lblTotalItem.Text = dgvPurchaseGrid.Rows.Count.ToString();
            //lblTotalItemAmount.Text = Convert.ToString(dgvColumnSum(dgvPurchaseGrid, "TotalPrice"));
            lblTotalItemAmount.Text = String.Format("{0:0.##}", Convert.ToDouble(dgvColumnSum(dgvPurchaseGrid, "TotalPrice")));
            //Format("{0:0.##}", Convert.ToDouble(output));

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
                txtProductName.Focus();
            }
        }
        private bool Valid()
        {
            bool isValid = true;
            if (chkSupplier.Checked == true &&  String.IsNullOrEmpty(txtSupplierCode.Text))
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
            //initialize the purchase information
            ProductPurchaseInfo objProductPurchaseInfo = new ProductPurchaseInfo();
            objProductPurchaseInfo.PurchaseDate = dtpPurchaseDate.Value.ToString("dd/MM/yyyy");
            objProductPurchaseInfo.MemoNo = txtMemoNo.Text.Trim();
            objProductPurchaseInfo.TotalAmount = Convert.ToDouble(lblTotalItemAmount.Text.Trim());
            objProductPurchaseInfo.TotalPaid = Convert.ToDouble(txtPaid.Text.Trim());
            objProductPurchaseInfo.SupplierAccountNo = txtSupplierCode.Text.Trim();
            objProductPurchaseInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
            objProductPurchaseInfo.TransactionType = "Purchase";
            int area_id = 1;
            //if (bllUtility.DefaultSettings.Store2Display == "True")
            //{
            //    area_id = 2;
            //}
            
            //execute the master purchase information & get the purchase no
            DataTable dt = bllProductPurchase.InsertPurchaseMaster(objProductPurchaseInfo);
            string purchaseID = dt.Rows[0][0].ToString();

            for (int i = 0; i < dgvPurchaseGrid.Rows.Count; i++)
            {
                //execute purchase master details info...........
                bool chk = bllProductPurchase.InsertPurchaseMasterDetails(purchaseID.Trim(), dgvPurchaseGrid.Rows[i].Cells["ProductID"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["UnitID"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["Quantity"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["TotalPrice"].Value.ToString().Trim(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), dgvPurchaseGrid.Rows[i].Cells["IsExpDate"].Value.ToString(), dgvPurchaseGrid.Rows[i].Cells["ExpireDate"].Value.ToString().Trim(), area_id, dgvPurchaseGrid.Rows[i].Cells["UnitPrice"].Value.ToString().Trim());
            }


            //disable save button
            this.btnSave.Enabled = false;
            this.btnResetGrid.Enabled = false;
            this.btnAddToGrid.Enabled = false;
            this.txtProductID.Enabled = false;
            this.txtProductName.Enabled = false;
            this.dgvPurchaseGrid.Enabled = false;
            this.dgvProductUnitQuantity.Enabled = false;
            //set the purchase ID on the screen text box
            this.txtPurchaseNo.Text = purchaseID;

            //enable print button
            this.btnPrint.Enabled = true;


            /********************************************************
            * Save Purchase Payment
            * *******************************************************/
            //InitializePurchasePaymentInfo();
            //bllProductPurchase.InsertPurchasePayment(objPurchasePaymentInfo);

            /*Account transaction for sales*/
            bllProductSales.InsertAccountTransactionBySystem("Purchase", lblTotalItemAmount.Text, txtPurchaseNo.Text, txtDescription.Text.Replace("'", "").Replace(",", ""), bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);

            if (Convert.ToDouble(txtPaid.Text) > 0)
                bllProductSales.InsertAccountTransactionBySystem("Cash Paid", txtPaid.Text, txtPurchaseNo.Text, txtDescription.Text.Replace("'", "").Replace(",", ""), bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);


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
                dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNo,"1");
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
            string sql = "";
            System.Collections.Hashtable ht = new System.Collections.Hashtable();

            ht.Add("paramCompany", bllUtility.LoggedInSystemInformation.CompanyName);
            ht.Add("paramComAddress", bllUtility.LoggedInSystemInformation.CompanyAddress);
            ht.Add("paramComContact", bllUtility.LoggedInSystemInformation.CompanyContactNo);
            ht.Add("paramRptTitle", "Purchase Invoice");
            
            sql = "USP_RptPurchaseInvoice '" + txtPurchaseNo.Text.Trim() + "'";
            rptPurchaseInvoice irptPurchaseInvoice = new rptPurchaseInvoice();
            iReportUtility.PrintPreview(irptPurchaseInvoice, sql, ht, false);
            btnPrint.Enabled = false;
            btnResetForm.Focus();
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

        private void lblProductID_Click(object sender, EventArgs e)
        {

        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                load_product_info();
            }
        }

        private void txtProductID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductUnitQuantity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
