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
using SalesPOS.Report;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmSalesInfo_old : DevExpress.XtraEditors.XtraForm
    {

        ProductSalesInfo objProductSalesInfo = new ProductSalesInfo();
        SalesPaymentInfo objSalesPaymentInfo = new SalesPaymentInfo();
        ProductSalesDetailsInfo objProductSalesDetailsInfo = new ProductSalesDetailsInfo();
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
       

        public frmSalesInfo_old()
        {
            InitializeComponent();
        }

        private void frmSalesInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                //call the save function
                if (this.btnSave.Enabled == true)
                {
                    this.btnSave_Click(sender, e);
                }
                else
                {
                    XtraMessageBox.Show("You can't save now. Please reset the window. Press [F5] Key.");
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                //call reset function
                this.btnResetForm_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F1)
            {
                this.txtPaidAmount.Focus();
                this.txtPaidAmount.SelectAll();
            }
        }

        private void frmSalesInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtProductName;
            bllUtility.ResetGridColor(dgvSalesGrid);
            bllUtility.ResetGridColor(dgvPurchaseGrid);
            ClearAll();
            ApplyDefaultSetting();
            this.dgvSalesGrid.DefaultCellStyle.ForeColor = Color.Black;
            InitializeProductName();
            load_product_info();
        }
        private void load_product_info()
        {
            DataTable dt = bllProductInfo.getAll();
            
            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;
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

        private void CalculateAmount()
        {
            if (txtPaidAmount.Text == "")
            {
                this.txtPaidAmount.Text = "0";
            }
            this.txtPayableAmount.Text = Math.Round(Convert.ToDecimal(this.txtTotalItemAmount.Text) - Convert.ToDecimal(this.txtDiscountAmount.Text) - Convert.ToDecimal(this.txt_sales_return.Text), 0).ToString();
            this.txtChangeAmount.Text = Convert.ToString(Convert.ToDecimal(this.txtPaidAmount.Text) - Convert.ToDecimal(this.txtPayableAmount.Text));
            lblTotalItem.Text = (dgvSalesGrid.Rows.Count).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = bllBranchInfo.GetVatRegNo();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["VatRegistrationNo"].ToString() != "")
                {
                    if (dgvSalesGrid.Rows.Count > 0)
                    {
                        //Validation check
                        if (ValidatePayment())
                        {
                            //Execute Sales Process
                            if (SaveDate())
                            {
                                XtraMessageBox.Show("Successfully Save Sales Transaction");
                                this.btnSave.Enabled = false;
                                this.btnPrint.Enabled = true;
                                this.btnPrint.Focus();
                            }
                            else { XtraMessageBox.Show("Could not Save Sales Transaction"); }
                        }
                    }
                    else { XtraMessageBox.Show("You Have Not Select Any Product For Sales."); }
                }
                else { XtraMessageBox.Show("You Have Not Setup The VAT Registration No."); }
            }
            else { XtraMessageBox.Show("You Have Not Setup Branch Information"); }
        }

        private bool SaveDate()
        {
            /********************************************************
            * Author    : Shah Md. Faysal
            * Date      : 04/12/2010
            * *******************************************************/
            bool isValid = false;
            try
            {
                //Start saving process....
                /********************************************************
                * Save Sales Parent & Get Invoice no
                * *******************************************************/
                InitializeSalesParentInfo();
                DataTable dt = bllProductSales.InsertSalesParent(objProductSalesInfo);
                txtInvoiceNo.Text = dt.Rows[0]["InvoiceID"].ToString();

                /********************************************************
                * Save Sales Payment
                * *******************************************************/
                InitializeSalesPaymentInfo();
                bllProductSales.InsertSalesPayment(objSalesPaymentInfo);

                /********************************************************
                * Save Sales Details Info
                * This Process will also update the stock information
                * *******************************************************/
                for (int i = 0; i < dgvSalesGrid.Rows.Count; i++)
                {
                    InitializeSalesDetailsInfo(i);
                    bllProductSales.InsertSalesDetails(objProductSalesDetailsInfo);
                }

                //Sales Return
                if (dgvPurchaseGrid.Rows.Count > 0)
                {
                    SaveReturn();
                }

                isValid = true;
            }
            catch (Exception ex)
            {
                isValid = false;
                XtraMessageBox.Show(ex.ToString());
            }
            return isValid;
        }
        
        private void SaveReturn()
        {
            SalesReturnParent objSalesReturnParent = new SalesReturnParent();
            SalesReturnDetails objSalesReturnDetails = new SalesReturnDetails();

            #region Sales Return Parent
            objSalesReturnParent.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
            objSalesReturnParent.InvoiceNo = txtInvoiceNo.Text;
            objSalesReturnParent.TotalAmount = txt_sales_return.Text;
            objSalesReturnParent.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
            objSalesReturnParent.CustomerID = string.Empty;
            DataTable dt_sa_parent = bllSalesReturnInfo.InsertSalesReturnParent(objSalesReturnParent,"");
            lblSRNumber.Text = dt_sa_parent.Rows[0]["SalesReturnNo"].ToString();
            #endregion

            #region Sales Return Child
            for (int j = 0; j < dgvPurchaseGrid.Rows.Count; j++)
            {
                objSalesReturnDetails.InvoiceNo = txtInvoiceNo.Text;
                objSalesReturnDetails.SalesReturnNo = lblSRNumber.Text;
                objSalesReturnDetails.ProductID = dgvPurchaseGrid.Rows[j].Cells["ProductID1"].Value.ToString().Trim();
                objSalesReturnDetails.ReturnQuantity = dgvPurchaseGrid.Rows[j].Cells["Quantity"].Value.ToString().Trim();
                objSalesReturnDetails.UnitID = dgvPurchaseGrid.Rows[j].Cells["MinimumUnitID"].Value.ToString().Trim();
                objSalesReturnDetails.UnitSalesPrice = dgvPurchaseGrid.Rows[j].Cells["UnitPrice"].Value.ToString().Trim();
                objSalesReturnDetails.VatPerchantage = "0";
                bllSalesReturnInfo.InsertSalesReturnDetails(objSalesReturnDetails);
            }
            #endregion

            #region Sales & Sales Return
            bllReportUtility.Exec_Store_Procedure("usp_insert_sales_and_sales_return '"+txtInvoiceNo.Text.Trim()+"','"+lblSRNumber.Text+"'");
            #endregion

            #region Purchase Parent
            ProductPurchaseInfo objProductPurchaseInfo = new ProductPurchaseInfo();
            objProductPurchaseInfo.PurchaseDate = DateTime.Now.ToString("dd/MM/yyyy");
            objProductPurchaseInfo.MemoNo = lblSRNumber.Text;
            objProductPurchaseInfo.TotalAmount = Convert.ToDouble(txt_sales_return.Text.Trim());
            objProductPurchaseInfo.TotalPaid = Convert.ToDouble("0");
            objProductPurchaseInfo.SupplierAccountNo = "CUS00000000000";
            objProductPurchaseInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
            objProductPurchaseInfo.TransactionType = "Sales Return";
            objProductPurchaseInfo.PurchaseID = lblSRNumber.Text;
            int area_id = 1;
            if (bllUtility.DefaultSettings.Store2Display == "True")
            {
                area_id = 2;
            }

            //execute the master purchase information & get the purchase no
            DataTable dt_purchase = bllProductPurchase.InsertPurchaseMaster_For_SalesReturn(objProductPurchaseInfo);
            string purchaseID = dt_purchase.Rows[0][0].ToString();
            #endregion

            #region Purchase Child
            for (int i = 0; i < dgvPurchaseGrid.Rows.Count; i++)
            {
                //execute purchase master details info...........
                bool chk = bllProductPurchase.InsertPurchaseMasterDetails(lblSRNumber.Text, dgvPurchaseGrid.Rows[i].Cells["ProductID1"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["MinimumUnitID"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["Quantity"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["TotalPrice"].Value.ToString().Trim(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), "1", "", area_id,"");
            }
            #endregion
            
        }

        private void InitializeSalesParentInfo()
        {
            objProductSalesInfo.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
            objProductSalesInfo.MemoNoteNo = "1";
            objProductSalesInfo.TotalAmount = txtTotalItemAmount.Text;
            objProductSalesInfo.DiscountAmount = txtDiscountAmount.Text;
            objProductSalesInfo.TotalGrossAmount = txtPayableAmount.Text;
            objProductSalesInfo.ReceivedAmount = txtPaidAmount.Text;
            objProductSalesInfo.ChangeAmount = txtChangeAmount.Text;
            objProductSalesInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
            if (optRetailPrice.Checked == true)
            {
                objProductSalesInfo.SalesType = "R";
            }
            else
            {
                objProductSalesInfo.SalesType = "W";
            }
            objProductSalesInfo.CustomerID = txtCustomerCode.Text.Trim();
            objProductSalesInfo.SalesReturn = txt_sales_return.Text.Trim();
        }
        private void DisplayStock()
        {
            pic_reorder.Visible = false;
            lblReorder.Text = "";
            string current_stock = "";
            DataTable dt = bllReportUtility.ReportData(@"SELECT     cast(ProductMainStock.Quantity AS VARCHAR(10)) + ' ' + UnitInfo.UnitName AS Stock,ProductMainStock.Quantity
FROM         ProductMainStock INNER JOIN
                      UnitInfo ON ProductMainStock.MinimumUnitID = UnitInfo.UnitId
WHERE     (ProductMainStock.ProductID = '" + txtProductID.Text.Trim() + "') AND (ProductMainStock.AreaID = 2)");
            if (dt.Rows.Count > 0)
            {
                current_stock = dt.Rows[0][1].ToString();
                lblStock.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                lblStock.Text = "0";
                current_stock = "0";
            }

            string _reorder = "";
            DataTable dt1 = bllReportUtility.ReportData("SELECT ISNULL(ReOrderLevel, 0) AS ReOrderLevel FROM ProductInfo WHERE (ProductID = '" + txtProductID.Text.Trim() + "')");
            if (dt1.Rows.Count > 0)
            {
                _reorder = dt1.Rows[0][0].ToString();
            }
            else
            {
                _reorder = "0";
            }

            if (bllUtility.Val(_reorder) >= bllUtility.Val(current_stock))
            {
                lblReorder.Text = "Re-order this product!";
                pic_reorder.Visible = true;
            }


        }
        private void InitializeSalesPaymentInfo()
        {
            objSalesPaymentInfo.InvoiceNo = txtInvoiceNo.Text;
            objSalesPaymentInfo.PayTypeId = "1";//1=Cash Payment

            double paidAmount;
            if (Convert.ToDouble(txtPayableAmount.Text) > Convert.ToDouble(txtPaidAmount.Text))
            {
                paidAmount = Convert.ToDouble(txtPaidAmount.Text);
            }
            else
            {
                paidAmount = Convert.ToDouble(txtPayableAmount.Text);
            }

            objSalesPaymentInfo.PaidAmount = paidAmount.ToString();
            objSalesPaymentInfo.CardNo = "";
            objSalesPaymentInfo.ExpDate = "";
            if (txtCustomerCode.Text == "")
            {
                objSalesPaymentInfo.CustomerID = "";
            }
            else
            {
                objSalesPaymentInfo.CustomerID = txtCustomerCode.Text.Trim();
            }
            objSalesPaymentInfo.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
            objSalesPaymentInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
        }

        private void InitializeSalesDetailsInfo(int j)
        {
            objProductSalesDetailsInfo.InvoiceNo = txtInvoiceNo.Text;
            objProductSalesDetailsInfo.ProductID = dgvSalesGrid.Rows[j].Cells["ProductID"].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualQty = dgvSalesGrid.Rows[j].Cells["ProductQuantity"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.ActualUnitID = dgvSalesGrid.Rows[j].Cells["UnitID"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.ActualUnitSalesPrice = dgvSalesGrid.Rows[j].Cells["UnitSalesPrice"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.TotalPriceWithoutVat = dgvSalesGrid.Rows[j].Cells["TotalPriceWithoutVat"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.VatID = dgvSalesGrid.Rows[j].Cells["VatID"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.VatPerchantage = dgvSalesGrid.Rows[j].Cells["VatPerchantage"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.VatAmount = dgvSalesGrid.Rows[j].Cells["VatAmount"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.TotalPriceWithVat = dgvSalesGrid.Rows[j].Cells["TotalPriceWithVat"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.DiscountAmount = dgvSalesGrid.Rows[j].Cells["DiscountAmount"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.ConvertedUnitID = dgvSalesGrid.Rows[j].Cells["ConvertedUnitID"].Value.ToString().Trim(); ;
            objProductSalesDetailsInfo.CovertedQuantity = dgvSalesGrid.Rows[j].Cells["CovertedQuantity"].Value.ToString().Trim(); ;
        }

        private bool ValidatePayment()
        {
            bool isValid = true;
            if (this.txtPaidAmount.Text == "")
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Paid Amount");
                this.txtPaidAmount.Focus();
                this.txtPaidAmount.SelectAll();
            }
            if (bllUtility.DefaultSettings.CreditSaleAllow == "False")
            {
                if (Convert.ToDouble(this.txtPayableAmount.Text.Trim()) > Convert.ToDouble(this.txtPaidAmount.Text.Trim()))
                {
                    isValid = false;
                    XtraMessageBox.Show("Please paid more amount..\nCREDIT SALE ARE NOT ALLOW.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPaidAmount.Focus();
                    this.txtPaidAmount.SelectAll();
                }
            }
            else
            {
                if (Convert.ToDouble(this.txtPayableAmount.Text.Trim()) > Convert.ToDouble(this.txtPaidAmount.Text.Trim()))
                {
                    XtraMessageBox.Show("YOU ARE DOING A CREDIT SALE.......", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.txtPaidAmount.Focus();
                    //this.txtPaidAmount.SelectAll();
                }

            }
            return isValid;
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearAll();
            ApplyDefaultSetting();
        }

        private void ClearAll()
        {
            lblSRNumber.Text = "";
            lblReorder.Text = "";
            ClearProductInfo();
            this.dgvSalesGrid.Rows.Clear();
            this.dgvPurchaseGrid.Rows.Clear();
            this.lblTotalItem.Text = "0";
            this.txtTotalItemAmount.Text = "0.00";
            this.lblPaymentType.Text = "Cash";
            this.chkCustomer.Checked = false;
            this.chkDiscount.Checked = false;
            this.txtDiscountAmount.Text = "0.00";
            this.txtPayableAmount.Text = "0.00";
            this.txtPaidAmount.Text = "0.00";
            this.txtChangeAmount.Text = "0.00";
            this.btnPrint.Enabled = false;
            this.btnSave.Enabled = true;
            this.txtProductName.Focus();
            this.txtCustomerCode.Text = string.Empty;
            this.txtCustomerName.Text = string.Empty;
            this.txtInvoiceNo.Text = string.Empty;
            lblStock.Text = "";
            pic_reorder.Visible = false;
            txt_sales_return.Text = "0.00";
            cmb_product.EditValue = null;
            lbl_return_unit_id.Text = "";
            lbl_return_unit.Text = "";
            txt_return_unit_price.Text = "";
            txt_return_qty.Text = "";
        }

        private void ApplyDefaultSetting()
        {
            // Load Default Setup
            bllSecurityInfo.SoftDefaultSetting();

            // Set Default  Sales Type
            if (bllUtility.DefaultSettings.DefaultSaleType == "R")
            {
                this.optRetailPrice.Checked = true;
            }
            else
            {
                this.optWholeSale.Checked = true;
            }
            // Set Default IS Editable Sales Price
            if (bllUtility.DefaultSettings.IsEditableSalePrice == "True")
            {
                this.txtUnitSalePrice.Properties.ReadOnly = false;
            }
            else
            {
                this.txtUnitSalePrice.Properties.ReadOnly = true;
            }
            // Set Default Discount Allow or Not
            if (bllUtility.DefaultSettings.DiscountAllow == "True")
            {
                this.txtDiscountAmount.Visible = true;
                this.chkDiscount.Visible = true;
                this.chkDiscount.Checked = false;
            }
            else
            {
                this.txtDiscountAmount.Visible = false;
                this.chkDiscount.Visible = false;
                this.chkDiscount.Checked = false;
            }
            // Set Default Mini Account Allow or Not
            if (bllUtility.DefaultSettings.MiniAccAllow == "True")
            {
                this.grp_customer.Visible = true;
                this.chkCustomer.Visible = true;
            }
            else
            {
                this.grp_customer.Visible = false;
                this.chkCustomer.Visible = false;
            }
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
            try
            {
                if (this.txtProductID.Text.Length == 10)
                {
                    DataTable dt1 = bllProductInfo.getById(txtProductID.Text);
                    if (dt1.Rows.Count > 0)
                    {
                        //get Product name
                        this.txtProductName.Text = dt1.Rows[0]["ProductName"].ToString();
                        //load unit combo
                        LoadProductUnit(cmbUnit, this.txtProductID.Text);
                    }
                    else
                    {
                        XtraMessageBox.Show("No product found.");
                        return;
                    }
                    //check the minimum unit of product
                    DataTable dt = new DataTable();
                    dt = bllProductUnitPrice.GetMinimumUnitByID(this.txtProductID.Text);
                    if (dt.Rows.Count > 0)
                    {
                        //get minimum unit id                    
                        this.cmbUnit.SelectedValue = Convert.ToInt64(dt.Rows[0]["UnitID"]);
                        DisplayStock();
                        this.txtQuantity.Text = string.Empty;
                        this.txtUnitSalePrice.Text = string.Empty;
                        this.txtQuantity.Focus();
                        this.txtQuantity.SelectAll();
                    }
                    else
                    {
                        XtraMessageBox.Show("Minimum unit of this product has not setup.");
                        return;
                        //this.txtProductName.Text = string.Empty;
                        //this.txtQuantity.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadProductUnit(System.Windows.Forms.ComboBox cb, string ProductID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllProductUnitPrice.getProductAllUnitPrice(ProductID);
                cb.DisplayMember = "UnitName";
                cb.ValueMember = "UnitID";
                cb.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            if (IsValidForGridAdd())
            {
                if (IsStockAvailable() == true)
                {
                    if (IsExistInGrid(this.txtProductID.Text, this.cmbUnit.SelectedValue.ToString()) == false)
                    {
                        //dgvSalesGrid.Rows.Add();
                        AddToSalesGrid();

                        this.txtTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat")));
                        CalculateAmount();
                        ClearProductInfo();
                        this.txtProductName.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("you have already Input this Product in the list.");
                        return;
                        //ClearProductInfo();
                        //this.btnSearchProduct.Focus();
                    }

                }
                else
                {
                    XtraMessageBox.Show("You have not sufficient stock of this product.");
                    this.txtQuantity.Focus();
                    this.txtQuantity.SelectAll();
                }
            }
        }

        private bool IsStockAvailable()
        {
            bool isAvailable = false;
            string convertedQty;
            Int64 gridProductQty = 0;
            //We have to converted the entered qty in minimum unit qty
            //like if we select 1 Pata Napa it will return us 10 Pcs
            //Because we store the product in minimum unit quantity
            convertedQty = bllProductSales.GetQtyInMinimumUnit(this.txtProductID.Text, this.cmbUnit.SelectedValue.ToString(), this.txtQuantity.Text);

            //if the enterd product already enterd in the sales grid 
            //we have to also count it. So Now we will get the product
            //quantity from the grid if exist.
            gridProductQty = GetProductQtyFromGrid(this.txtProductID.Text);

            //check stock availibility
            Int64 TotalQty = gridProductQty + Convert.ToInt64(convertedQty);
            if (bllProductSales.IsAvailableStock(this.txtProductID.Text, TotalQty.ToString(),"1") == true)
            {
                isAvailable = true;
            }

            return isAvailable;
        }

        private bool IsExistInGrid(string ProductID, string UnitID)
        {
            bool isExist = false;
            for (int i = 0; i < dgvSalesGrid.Rows.Count; i++)
            {
                if (dgvSalesGrid.Rows[i].Cells["UnitID"].Value.ToString() == UnitID && dgvSalesGrid.Rows[i].Cells["ProductID"].Value.ToString() == ProductID)
                {
                    isExist = true;
                    /*string NewProductQty = Convert.ToString(Convert.ToInt64(this.dgvSalesGrid.Rows[i].Cells["ProductQuantity"].Value) + Convert.ToInt64(this.txtQuantity.Text));
                    string NewTotalPriceWithoutVat = Convert.ToString(Convert.ToDouble(NewProductQty) * Convert.ToDouble(this.dgvSalesGrid.Rows[i].Cells["UnitSalesPrice"].Value));
                    string NewVat = Convert.ToString((Convert.ToDouble(NewTotalPriceWithoutVat) * Convert.ToDouble(this.dgvSalesGrid.Rows[i].Cells["VatPerchantage"].Value)) / 100);
                    this.dgvSalesGrid.Rows[i].Cells["ProductQuantity"].Value = NewProductQty;
                    this.dgvSalesGrid.Rows[i].Cells["TotalPriceWithoutVat"].Value = NewTotalPriceWithoutVat;
                    this.dgvSalesGrid.Rows[i].Cells["TotalPriceWithVat"].Value = Convert.ToDouble(NewTotalPriceWithoutVat) + Convert.ToDouble(NewVat);
                    this.dgvSalesGrid.Rows[i].Cells["CovertedQuantity"].Value = Convert.ToString(Convert.ToInt64(this.dgvSalesGrid.Rows[i].Cells["UnitQuantity"].Value) * Convert.ToInt64(NewProductQty));*/
                }
            }
            return isExist;
        }
        private Int64 GetProductQtyFromGrid(string ProductID)
        {
            Int64 grdSum = 0;
            for (int i = 0; i < dgvSalesGrid.Rows.Count; i++)
            {
                if (this.dgvSalesGrid.Rows[i].Cells["ProductID"].Value.ToString() == ProductID)
                {
                    grdSum += Convert.ToInt64(this.dgvSalesGrid.Rows[i].Cells["CovertedQuantity"].Value);
                }
            }
            return grdSum;
        }

        private bool IsValidForGridAdd()
        {
            bool isValid = true;
            if (this.txtProductID.Text == string.Empty)
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter ProductID");
                this.txtProductID.Focus();
                this.txtProductID.SelectAll();
            }
            else if (this.txtProductName.Text == string.Empty)
            {
                isValid = false;
                this.txtProductName.Focus();
                XtraMessageBox.Show("Please Enter Product Name");
            }
            else if (this.cmbUnit.Text == string.Empty)
            {
                isValid = false;
                this.cmbUnit.Focus();
                XtraMessageBox.Show("Please Select Unit");
            }
            else if (this.txtQuantity.Text == string.Empty || Convert.ToInt64(txtQuantity.Text) <= 0)
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Valid Product Quantity");
                this.txtQuantity.Focus();
                this.txtQuantity.SelectAll();
            }
            else if (this.txtUnitSalePrice.Text == string.Empty)
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Product Unit Price");
                this.txtUnitSalePrice.Focus();
                this.txtUnitSalePrice.SelectAll();
            }
            else if (Convert.ToDouble(txtUnitSalePrice.Text) < 0.001)
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Valid Unit Price");
                this.txtUnitSalePrice.Focus();
                this.txtUnitSalePrice.SelectAll();
            }
            return isValid;
        }
        private void AddToSalesGrid()
        {
            DataTable dt = new DataTable();
            dt = bllProductSales.PopulateSalesGrid(this.txtProductID.Text.Trim(), this.cmbUnit.SelectedValue.ToString(), this.txtQuantity.Text.Trim(), this.txtUnitSalePrice.Text.Trim(),"1");
            this.dgvSalesGrid.AutoGenerateColumns = false;
            if (dt.Rows[0]["VatID"].ToString() == "")
            {
                XtraMessageBox.Show("This Product has not setup any VAT policy.\n Please select the VAT of this Product from Product setup.");
            }
            else
            {
                dgvSalesGrid.Rows.Add();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["ProductID"].Value = dt.Rows[0]["ProductID"].ToString().ToUpper();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["ProductName"].Value = dt.Rows[0]["ProductName"].ToString().Trim();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["ProductQuantity"].Value = dt.Rows[0]["ProductQuantity"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["UnitID"].Value = dt.Rows[0]["UnitID"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["UnitName"].Value = dt.Rows[0]["UnitName"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["UnitSalesPrice"].Value = Math.Round(_Convert(dt.Rows[0]["UnitSalesPrice"].ToString()), 2);
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["TotalPriceWithoutVat"].Value = dt.Rows[0]["TotalPriceWithoutVat"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["VatID"].Value = dt.Rows[0]["VatID"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["VatPerchantage"].Value = dt.Rows[0]["VatPerchantage"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["VatAmount"].Value = dt.Rows[0]["VatAmount"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["TotalPriceWithVat"].Value = Math.Round(_Convert(dt.Rows[0]["TotalPriceWithVat"].ToString()), 2);
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["DiscountAmount"].Value = dt.Rows[0]["DiscountAmount"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["ConvertedUnitID"].Value = dt.Rows[0]["ConvertedUnitID"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["CovertedQuantity"].Value = dt.Rows[0]["CovertedQuantity"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["ConvertedUnitName"].Value = dt.Rows[0]["ConvertedUnitName"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["UnitQuantity"].Value = dt.Rows[0]["UnitQuantity"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["StockQty"].Value = dt.Rows[0]["OnhandQty"].ToString();

            }
        }

        private void ClearProductInfo()
        {
            this.txtProductID.Text = string.Empty;
            this.txtProductName.Text = string.Empty;
            this.txtQuantity.Text = string.Empty;
            this.txtProductName.Focus();
            this.cmbUnit.DataSource = null;
            this.txtUnitSalePrice.Text = string.Empty;
            lblStock.Text = "";
            lblReorder.Text = "";
            pic_reorder.Visible = false;
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void SetSalesPrice()
        {
            if (txtProductID.Text != "" && txtProductName.Text != "" && cmbUnit.Text != "")
            {
                DataTable dt = new DataTable();
                dt = bllProductSales.GetSalesPrice(this.txtProductID.Text.Trim(), this.cmbUnit.SelectedValue.ToString());
                if (optRetailPrice.Checked == true)
                {
                    txtUnitSalePrice.Text = dt.Rows[0]["Retail"].ToString();
                }
                else
                {
                    txtUnitSalePrice.Text = dt.Rows[0]["WholeSale"].ToString();
                }
            }
        }

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPayableAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            frmProductSearch obj = new frmProductSearch();
            obj.ShowDialog();
            this.txtProductName.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductName; //test code rasel
            this.txtProductID.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductID;

            //clearing global search object.
            bllUtility.ReturnSearchedProduct.returnSearchedProductInfo = null;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                this.grp_customer.Enabled = true;
            }
            else
            {
                this.grp_customer.Enabled = false;
            }
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked == true)
            {
                this.txtDiscountAmount.Enabled = true;
                this.txtDiscountAmount.Text = "0.00";
                this.txtDiscountAmount.Focus();
                this.txtDiscountAmount.SelectAll();
            }
            else
            {
                this.txtDiscountAmount.Enabled = false;
                this.txtDiscountAmount.Text = "0.00";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dsReport ds = new dsReport();
            DataSet dsSP = bllReports.GetSalesInvoice(this.txtInvoiceNo.Text.Trim());
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
                rptTest.SetParameterValue("SalesReturn", bllUtility.Val(txt_sales_return.Text));
                //rptTest.PrintToPrinter(1, false, 0, 0);
                frmRptv obj = new frmRptv();
                obj.SetReportDataSource = rptTest;
                obj.ShowDialog();
            }
            catch
            { }

            this.btnPrint.Enabled = false;
            this.btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtPaidAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                this.btnSave.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                //this.btnAddToGrid_Click(sender, e);
                SetSalesPrice();
                this.txtUnitSalePrice.Focus();
                this.txtUnitSalePrice.SelectAll();
            }
        }

        private void txtUnitSalePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void optRetailPrice_CheckedChanged(object sender, EventArgs e)
        {
            //DialogResult result;
            //result = XtraMessageBox.Show("Are you sure you want to change the price type?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    ClearAll();
            //}            
        }

        private void optWholeSale_CheckedChanged(object sender, EventArgs e)
        {
            //DialogResult result;
            //result = XtraMessageBox.Show("Are you sure you want to change the price type?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    ClearAll();
            //}
        }

        private void txtUnitSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                this.btnAddToGrid_Click(sender, e);
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                this.txtQuantity.Text = "";
                this.txtUnitSalePrice.Text = "";
                this.txtQuantity.Focus();
                this.txtQuantity.SelectAll();
            }
        }

        private void optRetailPrice_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("You are changing the price type?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
        }

        private void optWholeSale_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("You are changing the price type?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCustomerCode.Text.Length == 14)
            {
                string strAccountNo = txtCustomerCode.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNo, "2");
                if (dt.Rows.Count > 0)
                {
                    txtCustomerName.Text = dt.Rows[0]["AccHolderName"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Account Holder.", "Warning");
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                    txtCustomerCode.SelectAll();
                }
            }
        }

        private void cmbUnit_MouseClick(object sender, MouseEventArgs e)
        {
            //this.txtQuantity.Text = "";
            //this.txtUnitSalePrice.Text = "";
            //this.txtQuantity.Focus();
            //this.txtQuantity.SelectAll();
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtQuantity.Text = "";
            this.txtUnitSalePrice.Text = "";
            this.txtQuantity.Focus();
            this.txtQuantity.SelectAll();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerSearch obj = new frmCustomerSearch(2);// 2 = Customer
            obj.ShowDialog();
            this.txtCustomerName.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtCustomerCode.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtPayableAmount_TextChanged(object sender, EventArgs e)
        {
            lblAmountInWord.Text = bllUtility.changeCurrencyToWords(txtPayableAmount.Text);
        }

        private void dgvSalesGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.dgvSalesGrid.Rows.RemoveAt(dgvSalesGrid.CurrentCell.RowIndex);
                this.txtTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat")));
                CalculateAmount();
            }
        }

        private void txtDiscountAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                txtPaidAmount.Focus();
            }
        }
        private double _Convert(string value)
        {
            double Cvalue = 0.000;
            if (value != "")
            {
                Cvalue = Convert.ToDouble(value);
            }
            return Cvalue;

        }
        private void dgvSalesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double _TotalPrice, _Vat;
            int rowIdex = Convert.ToInt16(e.RowIndex);
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvSalesGrid.Columns[e.ColumnIndex].Name == "ProductQuantity")
                {
                    if (_Convert(dgvSalesGrid.Rows[rowIdex].Cells["StockQty"].Value.ToString().Trim()) < (_Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString().Trim()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitQuantity"].Value.ToString().Trim())))
                    {
                        dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value = "0";
                        dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithVat"].Value = "0";
                        dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithoutVat"].Value = "0";
                        XtraMessageBox.Show("Stock not available. Please purchase this product.");
                        //return;
                    }
                    else
                    {
                        _TotalPrice = _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitSalesPrice"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString());
                        _Vat = (_Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitSalesPrice"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString())) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["VatPerchantage"].Value.ToString()) / 100;
                        dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithVat"].Value = _TotalPrice + _Vat;
                        dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithoutVat"].Value = _Vat;
                        dgvSalesGrid.Rows[rowIdex].Cells["CovertedQuantity"].Value = _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitQuantity"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString());
                        
                            
                    }
                }
            }
            this.txtTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat")));
            CalculateAmount();
        }

        private void dgvSalesGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumnName = dgvSalesGrid.Columns[dgvSalesGrid.CurrentCell.ColumnIndex].Name;
            if (ColumnName == "ProductQuantity")
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
        }

        private void dgvSalesGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dgvSalesGrid_KeyPress);
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
                    }
                }
            }
        }

        private void cmb_product_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_product.EditValue == null) return;
            if (cmb_product.EditValue != null && cmb_product.EditValue != "")
            {
                //LoadProductUnit(cmbUnit, cmb_product.EditValue.ToString()); 
                DataTable dt = new DataTable();
                dt = bllReportUtility.ReportData(@"SELECT dbo.UnitInfo.UnitName, dbo.UnitInfo.UnitId
                                                   FROM dbo.ProductSalesPrice INNER JOIN dbo.UnitInfo ON dbo.ProductSalesPrice.UnitID = dbo.UnitInfo.UnitId
                                                   WHERE (dbo.ProductSalesPrice.IsMinimumUnit = 1) AND (dbo.ProductSalesPrice.ProductID = '" + cmb_product.EditValue.ToString() + "')");
                if (dt.Rows.Count > 0)
                {
                    lbl_return_unit.Text = dt.Rows[0][0].ToString();
                    lbl_return_unit_id.Text = dt.Rows[0][1].ToString();

                }
                else 
                {
                    XtraMessageBox.Show("Minimum unit not setup for this product.");
                    cmb_product.Focus();
                    return;
                
                }
            }
        }

        private void txt_return_qty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_return_unit_price_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmb_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_return_qty.Focus();
            }
        }

        private void txt_return_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_return_unit_price.Focus();
            }
        }

        private void btn_add_to_return_Click(object sender, EventArgs e)
        {
            if (cmb_product.EditValue == null || cmb_product.EditValue == "")
            {
                XtraMessageBox.Show("Product name required!.");
                cmb_product.Focus();
                return;
            }
            if (bllUtility.Val(txt_return_qty.Text.Trim())<=0)              
            {
                XtraMessageBox.Show("Product return qty required!.");
                txt_return_qty.Focus();
                return;
            }
            if (bllUtility.Val(txt_return_unit_price.Text.Trim()) <= 0)
            {
                XtraMessageBox.Show("Product return qty unit price required!.");
                txt_return_unit_price.Focus();
                return;
            }
            AddDataToReturnGrid();
            CalculateReturnAmount();
        }

        private void AddDataToReturnGrid()
        {
            dgvPurchaseGrid.Rows.Add();
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[0].Value = cmb_product.EditValue.ToString();
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[1].Value = cmb_product.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[2].Value = txt_return_qty.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[3].Value = lbl_return_unit.Text;
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[4].Value = txt_return_unit_price.Text.Trim();
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[5].Value = Math.Round(bllUtility.Val(txt_return_unit_price.Text.Trim()) * bllUtility.Val(txt_return_qty.Text.Trim()),2);
            dgvPurchaseGrid.Rows[dgvPurchaseGrid.Rows.Count - 1].Cells[6].Value = lbl_return_unit_id.Text;

            ClearReturnInfo();
        }
        private void ClearReturnInfo()
        {
            //cmb_product.EditValue = null;
            this.txt_return_qty.Text = "";
            //this.lbl_return_unit.Text = "";
            txt_return_unit_price.Text = "";
            //this.lbl_return_unit_id.Text = string.Empty;
            cmb_product.Focus();
        }
        private void CalculateReturnAmount()
        {
            txt_sales_return.Text = Math.Round(dgvColumnSum(dgvPurchaseGrid, "TotalPrice"), 2).ToString();//String.Format("{0:0.##}", Convert.ToDouble(dgvColumnSum(dgvPurchaseGrid, "TotalPrice")));            
        }
        private void txt_return_unit_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_to_return_Click(sender,e);
            }
        }

        private void dgvPurchaseGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvPurchaseGrid.Columns[e.ColumnIndex].Name == "UnitPrice")
                {
                    int rowIdex = Convert.ToInt16(e.RowIndex);
                    if (dgvPurchaseGrid.Rows[rowIdex].Cells["UnitPrice"].Value != null)
                    {
                        string qty = dgvPurchaseGrid.Rows[rowIdex].Cells["Quantity"].Value.ToString();
                        string unit_price = dgvPurchaseGrid.Rows[rowIdex].Cells["UnitPrice"].Value.ToString();
                        dgvPurchaseGrid.Rows[rowIdex].Cells["TotalPrice"].Value = Math.Round(bllUtility.Val(qty) * bllUtility.Val(unit_price),2);
                        CalculateReturnAmount();
                    }
                }
            }
        }

        private void dgvPurchaseGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumnName = dgvPurchaseGrid.Columns[dgvPurchaseGrid.CurrentCell.ColumnIndex].Name;
            if (ColumnName == "UnitPrice")
            {
                if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46)                
                    e.Handled = false;                
                else                
                    e.Handled = true;               
            }
        }

        private void dgvPurchaseGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dgvPurchaseGrid_KeyPress);
        }

        private void dgvPurchaseGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.dgvPurchaseGrid.Rows.RemoveAt(dgvPurchaseGrid.CurrentCell.RowIndex);                
                CalculateReturnAmount();
            }
        }

        private void txt_sales_return_EditValueChanged(object sender, EventArgs e)
        {
            //txtPayableAmount.Text = (bllUtility.Val(txtPayableAmount.Text) - bllUtility.Val(txt_sales_return.Text)).ToString();
            //this.txtPayableAmount.Text = Math.Round(Convert.ToDecimal(this.txtTotalItemAmount.Text) - Convert.ToDecimal(this.txtDiscountAmount.Text) - Convert.ToDecimal(this.txt_sales_return.Text), 0).ToString();
            CalculateAmount();
        }

        private void txtCustomerCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}
