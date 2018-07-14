using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesPOS.BLL;
using SalesPOS.BOL;
using SalesPOS.Report;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SalesPOS
{
    public partial class frmSalesInfo : DevExpress.XtraEditors.XtraForm
    {

        ProductSalesInfo objProductSalesInfo = new ProductSalesInfo();
        SalesPaymentInfo objSalesPaymentInfo = new SalesPaymentInfo();
        ProductSalesDetailsInfo objProductSalesDetailsInfo = new ProductSalesDetailsInfo();
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();


        public frmSalesInfo()
        {
            InitializeComponent();
        }


        private void frmSalesInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtProductID;
            bllUtility.ResetGridColor(dgvSalesGrid);
            bllUtility.ResetGridColor(dgvFree);
            bllUtility.ResetGridColor(dgvGift);
            ClearAll();
            ApplyDefaultSetting();
            //this.dgvSalesGrid.DefaultCellStyle.ForeColor = Color.Black;
            InitializeProductName();
            load_product_info();
            LoadUnit();
            load_rtl_manager();
            load_zone_list();
            load_bank_list();
            load_area_list();
        }

        private void load_area_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.populate_area_list");
            cmb_store.Properties.DisplayMember = "AreaName";
            cmb_store.Properties.ValueMember = "AreaID";
            cmb_store.Properties.DataSource = dt;
            cmb_store.EditValue = "1";
        }

        private void frmSalesInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //this.Close();
            }
            else
                if (e.KeyCode == Keys.S && e.Control)
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
                else
                    if (e.KeyCode == Keys.F5)
                    {
                        //call reset function
                        this.btnResetForm_Click(sender, e);
                    }
                    else
                        if (e.KeyCode == Keys.F1)
                        {
                            this.txtPaidAmount.Focus();
                            this.txtPaidAmount.SelectAll();
                        }
        }


        private void LoadUnit()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllUnitInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["UnitId"] = "0";
                dr["UnitName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmb_unit_gift.DisplayMember = "UnitName";
                cmb_unit_gift.ValueMember = "UnitId";
                cmb_unit_gift.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void load_product_info()
        {
            DataTable dt = bllProductInfo.getAll();
            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;
        }

        private void load_rtl_manager()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID] 10");
            cmb_rsm.Properties.DisplayMember = "AccHolderName";
            cmb_rsm.Properties.ValueMember = "AccountNo";
            cmb_rsm.Properties.DataSource = dt;
        }

        private void load_requisition_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.populate_requition_list");
            cmb_req_no.Properties.DisplayMember = "RequisitionID";
            cmb_req_no.Properties.ValueMember = "RequisitionID";
            cmb_req_no.Properties.DataSource = dt;
        }

        private void load_zone_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[PopulateZoneList]");
            cmb_zone.Properties.DisplayMember = "ZoneName";
            cmb_zone.Properties.ValueMember = "ZoneID";
            cmb_zone.Properties.DataSource = dt;
        }

        private void load_bank_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.PopulateBankList");
            cmb_bank.Properties.DisplayMember = "Bank";
            cmb_bank.Properties.ValueMember = "AccountNo";
            cmb_bank.Properties.DataSource = dt;
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
            double discount = Math.Round(dgvColumnSum(dgvSalesGrid, "DiscountAmount"));
            double total = Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat"));

            this.txtDiscountAmount.Text = Convert.ToString(discount);
            this.txtTotalItemAmount.Text = Convert.ToString(total + discount);

            //this.txtPayableAmount.Text = Math.Round(Convert.ToDecimal(this.txtTotalItemAmount.Text) - Convert.ToDecimal(this.txtDiscountAmount.Text) - Convert.ToDecimal(this.txt_sales_return.Text), 0).ToString();
            this.txtPayableAmount.Text = Math.Round(Convert.ToDecimal(this.txtTotalItemAmount.Text) - Convert.ToDecimal(this.txtDiscountAmount.Text), 0).ToString();
            this.txtChangeAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(this.txtPaidAmount.Text) - Convert.ToDecimal(this.txtPayableAmount.Text), 0));
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
                        if (cmb_rsm.EditValue == null)
                        {
                            XtraMessageBox.Show("RSM selection required!");
                            cmb_rsm.Focus();
                            return;
                        }
                        if (cmb_zone.EditValue == null)
                        {
                            XtraMessageBox.Show("Zone selection required!");
                            cmb_zone.Focus();
                            return;
                        }
                        if (chkCustomer.Checked == true)
                        {
                            if (txtCustomerCode.Text == "")
                            {
                                XtraMessageBox.Show("Customer selection required!!");
                                btnSearchCustomer.Focus();
                                return;
                            }
                        }
                        if (opt_bank_option.Checked)
                        {
                            if (cmb_bank.EditValue == null)
                            {
                                XtraMessageBox.Show("Bank selection required!");
                                cmb_bank.Focus();
                                return;
                            }
                            if (Convert.ToDouble(txtPaidAmount.Text) < 1)
                            {
                                XtraMessageBox.Show("Receive amount required!");
                                txtPaidAmount.Focus();
                                return;
                            }
                        }
                        if (opt_commission_adjust.Checked)
                        {
                            if (Convert.ToDouble(txt_commission_adjust.Text) > 0)
                            {
                                if (lbl_commission_adjustable_amount.Text == "") lbl_commission_adjustable_amount.Text = "0.00";
                                if (Convert.ToDouble(txt_commission_adjust.Text) > Convert.ToDouble(lbl_commission_adjustable_amount.Text))
                                {
                                    //if (XtraMessageBox.Show("You are crossing the limit of commission amount.\nDo you want to continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    XtraMessageBox.Show("You are crossing the limit of commission amount.\nDo you want to continue?");
                                    return;
                                }
                            }
                        }

                        if (chk_requisition.Checked)
                        {
                            if (lbl_req_number.Text == "")
                            {
                                XtraMessageBox.Show("You have not select any Requisition No.");
                                return;
                            }
                        }

                        if (ValidatePayment())
                        {
                            //Execute Sales Process
                            if (SaveDate())
                            {
                                XtraMessageBox.Show("Successfully Save Sales Transaction");
                                this.btnSave.Enabled = false;
                                this.btnPrint.Enabled = true;
                                chk_requisition.Enabled = false;
                                link_requisition_import.Enabled = false;
                                this.btnPrint.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show("Could not Save Sales Transaction");
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("You Have Not Select Any Product For Sales.");
                    }
                }
                else
                {
                    XtraMessageBox.Show("You Have Not Setup The VAT Registration No.");
                }
            }
            else
            {
                XtraMessageBox.Show("You Have Not Setup Branch Information");
            }
        }

        private bool SaveDate()
        {
            /********************************************************
            * Author    : Shah Md. Faysal
            * Date      : 04/12/2010
            * *******************************************************/
            string ProductName = "";
            string UnidID = "";
            string Qty = "";
            string AccountNo = "";

            if (txtCustomerCode.Text == "")
                AccountNo = "CUS00000000000";
            else
                AccountNo = txtCustomerCode.Text;

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

                if (chk_requisition.Checked)
                {
                    bllProductSales.InsertSalesRequisitionList(txtInvoiceNo.Text,lbl_req_number.Text.Trim());
                }
                /********************************************************
                * Save Sales Payment
                * *******************************************************/
                InitializeSalesPaymentInfo();
                if (Convert.ToDouble(objSalesPaymentInfo.PaidAmount) > 0)
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
                for (int i = 0; i < dgvFree.Rows.Count; i++)
                {
                    InitializeFreeSalesDetailsInfo(i);
                    bllProductSales.InsertSalesDetails(objProductSalesDetailsInfo);
                }
                for (int i = 0; i < dgvGift.Rows.Count; i++)
                {
                    ProductName = dgvGift.Rows[i].Cells["ProductName_Gift"].Value.ToString().Trim();
                    Qty = dgvGift.Rows[i].Cells["ProductQuantity_Gift"].Value.ToString().Trim();
                    UnidID = dgvGift.Rows[i].Cells["UnitID_Gift"].Value.ToString().Trim();
                    bllProductSales.InsertGiftItem(txtInvoiceNo.Text, ProductName, UnidID, Qty);
                }

                /*Account transaction for sales*/
                bllProductSales.InsertAccountTransactionBySystem("Sales", txtPayableAmount.Text, txtInvoiceNo.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);

                if (Convert.ToDouble(objSalesPaymentInfo.PaidAmount) > 0)
                    bllProductSales.InsertAccountTransactionBySystem("Cash Receive", txtPaidAmount.Text, txtInvoiceNo.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);

                if (opt_bank_option.Checked)
                {
                    if (Convert.ToDouble(objSalesPaymentInfo.PaidAmount) > 0)
                        bllProductSales.InsertAccountTransactionBySystem("Bank Deposit", txtPaidAmount.Text, txtInvoiceNo.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), cmb_bank.EditValue.ToString(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);
                }
                if (opt_commission_adjust.Checked)
                {
                    if (Convert.ToDouble(objProductSalesInfo.CommissionAdjustAmount) > 0)
                        bllProductSales.InsertAccountTransactionBySystem("Commission Adjust", objProductSalesInfo.CommissionAdjustAmount, txtInvoiceNo.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);
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

        //private void SaveReturn()
        //{
        //    SalesReturnParent objSalesReturnParent = new SalesReturnParent();
        //    SalesReturnDetails objSalesReturnDetails = new SalesReturnDetails();

        //    #region Sales Return Parent
        //    objSalesReturnParent.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
        //    objSalesReturnParent.InvoiceNo = txtInvoiceNo.Text;
        //    //objSalesReturnParent.TotalAmount = txt_sales_return.Text;
        //    objSalesReturnParent.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
        //    objSalesReturnParent.CustomerID = string.Empty;
        //    DataTable dt_sa_parent = bllSalesReturnInfo.InsertSalesReturnParent(objSalesReturnParent);
        //    //lblSRNumber.Text = dt_sa_parent.Rows[0]["SalesReturnNo"].ToString();
        //    #endregion

        //    #region Sales Return Child
        //    for (int j = 0; j < dgvFree.Rows.Count; j++)
        //    {
        //        objSalesReturnDetails.InvoiceNo = txtInvoiceNo.Text;
        //        objSalesReturnDetails.SalesReturnNo = lblSRNumber.Text;
        //        objSalesReturnDetails.ProductID = dgvFree.Rows[j].Cells["ProductID1"].Value.ToString().Trim();
        //        objSalesReturnDetails.ReturnQuantity = dgvFree.Rows[j].Cells["Quantity"].Value.ToString().Trim();
        //        objSalesReturnDetails.UnitID = dgvFree.Rows[j].Cells["MinimumUnitID"].Value.ToString().Trim();
        //        objSalesReturnDetails.UnitSalesPrice = dgvFree.Rows[j].Cells["UnitPrice"].Value.ToString().Trim();
        //        objSalesReturnDetails.VatPerchantage = "0";
        //        bllSalesReturnInfo.InsertSalesReturnDetails(objSalesReturnDetails);
        //    }
        //    #endregion

        //    #region Sales & Sales Return
        //    bllReportUtility.Exec_Store_Procedure("usp_insert_sales_and_sales_return '"+txtInvoiceNo.Text.Trim()+"','"+lblSRNumber.Text+"'");
        //    #endregion

        //    #region Purchase Parent
        //    ProductPurchaseInfo objProductPurchaseInfo = new ProductPurchaseInfo();
        //    objProductPurchaseInfo.PurchaseDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    objProductPurchaseInfo.MemoNo = lblSRNumber.Text;
        //    objProductPurchaseInfo.TotalAmount = Convert.ToDouble(txt_sales_return.Text.Trim());
        //    objProductPurchaseInfo.TotalPaid = Convert.ToDouble("0");
        //    objProductPurchaseInfo.SupplierAccountNo = "CUS00000000000";
        //    objProductPurchaseInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
        //    objProductPurchaseInfo.TransactionType = "Sales Return";
        //    objProductPurchaseInfo.PurchaseID = lblSRNumber.Text;
        //    int area_id = 1;
        //    if (bllUtility.DefaultSettings.Store2Display == "True")
        //    {
        //        area_id = 2;
        //    }

        //    //execute the master purchase information & get the purchase no
        //    DataTable dt_purchase = bllProductPurchase.InsertPurchaseMaster_For_SalesReturn(objProductPurchaseInfo);
        //    string purchaseID = dt_purchase.Rows[0][0].ToString();
        //    #endregion

        //    #region Purchase Child
        //    for (int i = 0; i < dgvFree.Rows.Count; i++)
        //    {
        //        //execute purchase master details info...........
        //        bool chk = bllProductPurchase.InsertPurchaseMasterDetails(lblSRNumber.Text, dgvFree.Rows[i].Cells["ProductID1"].Value.ToString().Trim(), dgvFree.Rows[i].Cells["MinimumUnitID"].Value.ToString().Trim(), dgvFree.Rows[i].Cells["Quantity"].Value.ToString().Trim(), dgvFree.Rows[i].Cells["TotalPrice"].Value.ToString().Trim(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), "1", "", area_id);
        //    }
        //    #endregion

        //}

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
            objProductSalesInfo.SalesReturn = "0";
            if (cmb_rsm.EditValue == null)
                objProductSalesInfo.RtlManager = "";
            else
                objProductSalesInfo.RtlManager = cmb_rsm.EditValue.ToString();
            objProductSalesInfo.ZoneID = cmb_zone.EditValue.ToString();
            if (txt_commission_adjust.Text == "") txt_commission_adjust.Text = "0.00";
            objProductSalesInfo.CommissionAdjustAmount = txt_commission_adjust.Text;
            objProductSalesInfo.AreaID = cmb_store.EditValue.ToString();
        }
        private void DisplayStock()
        {
            pic_reorder.Visible = false;
            lblReorder.Text = "";
            string current_stock = "";
            DataTable dt = bllUtility.GetDataBySP("dbo.get_product_stock_store_wise '" + txtProductID.Text.Trim() + "'," + cmb_store.EditValue.ToString());

//            DataTable dt = bllReportUtility.ReportData(@"SELECT     cast(ProductMainStock.Quantity AS VARCHAR(10)) + ' ' + UnitInfo.UnitName AS Stock,ProductMainStock.Quantity
//FROM         ProductMainStock INNER JOIN
//                      UnitInfo ON ProductMainStock.MinimumUnitID = UnitInfo.UnitId
//WHERE     (ProductMainStock.ProductID = '" + txtProductID.Text.Trim() + "') AND (ProductMainStock.AreaID = 2)");


            if (dt.Rows.Count > 0)
            {
                current_stock = dt.Rows[0][1].ToString();
                lblStock.Text = dt.Rows[0][1].ToString();
                cmb_store.Enabled = false;
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
            objProductSalesDetailsInfo.ActualQty = dgvSalesGrid.Rows[j].Cells["ProductQuantity"].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualUnitID = dgvSalesGrid.Rows[j].Cells["UnitID"].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualUnitSalesPrice = dgvSalesGrid.Rows[j].Cells["UnitSalesPrice"].Value.ToString().Trim();
            objProductSalesDetailsInfo.TotalPriceWithoutVat = dgvSalesGrid.Rows[j].Cells["TotalPriceWithoutVat"].Value.ToString().Trim();
            objProductSalesDetailsInfo.VatID = dgvSalesGrid.Rows[j].Cells["VatID"].Value.ToString().Trim();
            objProductSalesDetailsInfo.VatPerchantage = dgvSalesGrid.Rows[j].Cells["VatPerchantage"].Value.ToString().Trim();
            objProductSalesDetailsInfo.VatAmount = dgvSalesGrid.Rows[j].Cells["VatAmount"].Value.ToString().Trim();
            objProductSalesDetailsInfo.TotalPriceWithVat = dgvSalesGrid.Rows[j].Cells["TotalPriceWithVat"].Value.ToString().Trim();
            objProductSalesDetailsInfo.DiscountAmount = dgvSalesGrid.Rows[j].Cells["DiscountAmount"].Value.ToString().Trim();
            objProductSalesDetailsInfo.DiscountPercent = dgvSalesGrid.Rows[j].Cells["DiscountPercent"].Value.ToString().Trim();
            objProductSalesDetailsInfo.ConvertedUnitID = dgvSalesGrid.Rows[j].Cells["ConvertedUnitID"].Value.ToString().Trim();
            objProductSalesDetailsInfo.CovertedQuantity = dgvSalesGrid.Rows[j].Cells["CovertedQuantity"].Value.ToString().Trim();
            if (chk_sample.Checked == true)
                objProductSalesDetailsInfo.ItemType = "2";
            else
                objProductSalesDetailsInfo.ItemType = "0";
        }

        private void InitializeFreeSalesDetailsInfo(int j)
        {
            objProductSalesDetailsInfo.InvoiceNo = txtInvoiceNo.Text;
            objProductSalesDetailsInfo.ProductID = dgvFree.Rows[j].Cells[0].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualQty = dgvFree.Rows[j].Cells[2].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualUnitID = dgvFree.Rows[j].Cells[4].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualUnitSalesPrice = "0";
            objProductSalesDetailsInfo.TotalPriceWithoutVat = "0";
            objProductSalesDetailsInfo.VatID = "0";
            objProductSalesDetailsInfo.VatPerchantage = "0";
            objProductSalesDetailsInfo.VatAmount = "0";
            objProductSalesDetailsInfo.TotalPriceWithVat = "0";
            objProductSalesDetailsInfo.DiscountAmount = "0";
            objProductSalesDetailsInfo.DiscountPercent = "0";
            objProductSalesDetailsInfo.ConvertedUnitID = dgvFree.Rows[j].Cells[4].Value.ToString().Trim();
            objProductSalesDetailsInfo.CovertedQuantity = dgvFree.Rows[j].Cells[2].Value.ToString().Trim();
            objProductSalesDetailsInfo.ItemType = "1";

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
                    if (XtraMessageBox.Show("YOU ARE DOING A CREDIT SALE. DO YOU WANT TO CONTINUE? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        isValid = true;
                    else
                        isValid = false;
                }

            }
            return isValid;
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearAll();
            ApplyDefaultSetting();
            txtProductID.Focus();
        }

        private void ClearAll()
        {
            lblClosingBalance.Text = "";
            txtDescription.Text = "";
            lbl_dealerid.Text = "";
            chk_requisition.Enabled = true;
            chk_requisition.Checked=false;
            cmb_req_no.EditValue = null;
            lbl_req_title.Text = "";
            lbl_req_number.Text = "";
            txt_req_date.Text = "";
            txt_dealerid.Text = "";
            txt_dealer_name.Text = "";
            txt_payment_amount.Text = "";
            txt_payment_mode.Text = "";
            grd_requisition_details.DataSource = null;

            txt_commission_adjust.Text = "";
            opt_bank_option.Checked = false;
            opt_commission_adjust.Checked = false;
            lbl_commission_adjustable_amount.Text = "";
            cmb_zone.EditValue = null;
            chk_sample.Enabled = true;
            chk_sample.Checked = false;
            //lblSRNumber.Text = "";
            lblReorder.Text = "";
            ClearProductInfo();
            dgvSalesGrid.Rows.Clear();
            dgvFree.Rows.Clear();
            dgvGift.Rows.Clear();
            this.lblTotalItem.Text = "0";
            this.txtTotalItemAmount.Text = "0.00";
            this.lblPaymentType.Text = "Cash";
            //this.chkCustomer.Checked = false;
            //this.chkDiscount.Checked = false;
            this.txtDiscountAmount.Text = "0.00";
            this.txtPayableAmount.Text = "0.00";
            this.txtPaidAmount.Text = "0.00";
            txtChangeAmount.Text = "0.00";
            this.btnPrint.Enabled = false;
            this.btnSave.Enabled = true;
            this.txtProductName.Focus();
            this.txtCustomerCode.Text = string.Empty;
            this.txtCustomerName.Text = string.Empty;
            this.txtInvoiceNo.Text = string.Empty;
            lblStock.Text = "";
            pic_reorder.Visible = false;
            chk_free.Checked = false;
            //txt_sales_return.Text = "0.00";
            cmb_product.EditValue = null;
            lbl_return_unit_id.Text = "";
            lbl_return_unit.Text = "";
            //txt_return_unit_price.Text = "";
            txt_free_qty.Text = "";
            lblTotalFreeItem.Text = "0";
            lblTotalGiftItem.Text = "0";
            txt_gift_qty.Text = "";
            txt_gift_name.Text = "";
            chk_gift.Checked = false;
            cmb_rsm.EditValue = null;
            chkCustomer.Checked = true;
            //chk_deposit_to_bank.Checked = false;
            //opt_item_type.Enabled = true;
            cmb_store.Enabled = true;
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
            //if (bllUtility.DefaultSettings.DiscountAllow == "True")
            //{
            //    this.txtDiscountAmount.Visible = true;
            //    this.chkDiscount.Visible = true;
            //    this.chkDiscount.Checked = false;
            //}
            //else
            //{
            //    this.txtDiscountAmount.Visible = false;
            //    this.chkDiscount.Visible = false;
            //    this.chkDiscount.Checked = false;
            //}
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
            //try
            //{
            //    if (this.txtProductID.Text.Length == 10)
            //    {
            //        DataTable dt1 = bllProductInfo.getById(txtProductID.Text);
            //        if (dt1.Rows.Count > 0)
            //        {
            //            //get Product name
            //            this.txtProductName.Text = dt1.Rows[0]["ProductName"].ToString();
            //            //load unit combo
            //            LoadProductUnit(cmbUnit, this.txtProductID.Text);
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("No product found.");
            //            return;
            //        }
            //        //check the minimum unit of product
            //        DataTable dt = new DataTable();
            //        dt = bllProductUnitPrice.GetMinimumUnitByID(this.txtProductID.Text);
            //        if (dt.Rows.Count > 0)
            //        {
            //            //get minimum unit id                    
            //            this.cmbUnit.SelectedValue = Convert.ToInt64(dt.Rows[0]["UnitID"]);
            //            DisplayStock();
            //            this.txtQuantity.Text = string.Empty;
            //            this.txtUnitSalePrice.Text = string.Empty;
            //            this.txtQuantity.Focus();
            //            this.txtQuantity.SelectAll();
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("Minimum unit of this product has not setup.");
            //            return;
            //            //this.txtProductName.Text = string.Empty;
            //            //this.txtQuantity.Text = string.Empty;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.ToString());
            //}
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
                        //double discount = Math.Round(dgvColumnSum(dgvSalesGrid, "DiscountAmount"));
                        //double total = Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat"));

                        //this.txtDiscountAmount.Text = Convert.ToString(discount);
                        //this.txtTotalItemAmount.Text = Convert.ToString(total-discount);

                        CalculateAmount();
                        CalculateFree();
                        ClearProductInfo();
                        this.txtProductID.Focus();
                        lblTotalGiftItem.Text = (dgvGift.Rows.Count).ToString();
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
                chk_sample.Enabled = false;
            }
        }

        private bool IsStockAvailable()
        {
            bool isAvailable = false;
            string convertedQty;
            Double gridProductQty = 0;
            //We have to converted the entered qty in minimum unit qty
            //like if we select 1 Pata Napa it will return us 10 Pcs
            //Because we store the product in minimum unit quantity
            convertedQty = bllProductSales.GetQtyInMinimumUnit(this.txtProductID.Text, this.cmbUnit.SelectedValue.ToString(), this.txtQuantity.Text);

            //if the enterd product already enterd in the sales grid 
            //we have to also count it. So Now we will get the product
            //quantity from the grid if exist.
            gridProductQty = GetProductQtyFromGrid(this.txtProductID.Text);

            //check stock availibility
            Double TotalQty = gridProductQty + Convert.ToDouble(convertedQty);
            if (bllProductSales.IsAvailableStock(this.txtProductID.Text, TotalQty.ToString(),cmb_store.EditValue.ToString()) == true)
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
                }
            }
            return isExist;
        }

        private bool IsExistInFreeGrid(string ProductID, string UnitID,string RootProductID)
        {
            bool isExist = false;
            for (int i = 0; i < dgvFree.Rows.Count; i++)
            {
                if (RootProductID == "")
                {
                    if (dgvFree.Rows[i].Cells["UnitID_Free"].Value.ToString() == UnitID && dgvFree.Rows[i].Cells["ProductID_Free"].Value.ToString() == ProductID)
                    {
                        isExist = true;
                    }
                }
                else
                {
                    if (dgvFree.Rows[i].Cells["UnitID_Free"].Value.ToString() == UnitID && dgvFree.Rows[i].Cells["ProductID_Free"].Value.ToString() == ProductID && dgvFree.Rows[i].Cells["RootProductID"].Value.ToString() == RootProductID)
                    {
                        isExist = true;
                    }
                }
            }
            return isExist;
        }

        private bool IsExistInGiftGrid(string ProductName, string UnitID, string RootProductIDGift)
        {
            bool isExist = false;
            for (int i = 0; i < dgvGift.Rows.Count; i++)
            {
                if (RootProductIDGift == "")
                {
                    if (dgvGift.Rows[i].Cells["UnitID_Gift"].Value.ToString() == UnitID && dgvGift.Rows[i].Cells["ProductName_Gift"].Value.ToString().ToUpper().Trim() == ProductName.ToUpper().Trim())
                    {
                        isExist = true;
                    }
                }
                else
                {
                    if (dgvGift.Rows[i].Cells["UnitID_Gift"].Value.ToString() == UnitID && dgvGift.Rows[i].Cells["ProductName_Gift"].Value.ToString().ToUpper().Trim() == ProductName.ToUpper().Trim() && dgvGift.Rows[i].Cells["RootProductIDGift"].Value.ToString() == RootProductIDGift)
                    {
                        isExist = true;
                    }
                }
            }
            return isExist;
        }

        private Double GetProductQtyFromGrid(string ProductID)
        {
            Double grdSum = 0;
            for (int i = 0; i < dgvSalesGrid.Rows.Count; i++)
            {
                if (this.dgvSalesGrid.Rows[i].Cells["ProductID"].Value.ToString() == ProductID)
                {
                    grdSum += Convert.ToDouble(this.dgvSalesGrid.Rows[i].Cells["CovertedQuantity"].Value);
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
            else
                if (this.txtProductName.Text == string.Empty)
                {
                    isValid = false;
                    this.txtProductName.Focus();
                    XtraMessageBox.Show("Please Enter Product Name");
                }
                else
                    if (this.cmbUnit.Text == string.Empty)
                    {
                        isValid = false;
                        this.cmbUnit.Focus();
                        XtraMessageBox.Show("Please Select Unit");
                    }
                    else
                        if (this.txtQuantity.Text == string.Empty || Convert.ToDouble(txtQuantity.Text) <= 0)
                        {
                            isValid = false;
                            XtraMessageBox.Show("Please Enter Valid Product Quantity");
                            this.txtQuantity.Focus();
                            this.txtQuantity.SelectAll();
                        }
                        else
                            if (this.txtUnitSalePrice.Text == string.Empty)
                            {
                                isValid = false;
                                XtraMessageBox.Show("Please Enter Product Unit Price");
                                this.txtUnitSalePrice.Focus();
                                this.txtUnitSalePrice.SelectAll();
                            }
                            else
                                if (Convert.ToDouble(txtUnitSalePrice.Text) < 0.001)
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
            dt = bllProductSales.PopulateSalesGrid(this.txtProductID.Text.Trim(), this.cmbUnit.SelectedValue.ToString(), this.txtQuantity.Text.Trim(), this.txtUnitSalePrice.Text.Trim(),cmb_store.EditValue.ToString());
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
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["DiscountPercent"].Value = dt.Rows[0]["DiscountPercent"].ToString();
                this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["TotalWODiscount"].Value = _Convert(dt.Rows[0]["ProductQuantity"].ToString()) * Math.Round(_Convert(dt.Rows[0]["UnitSalesPrice"].ToString()), 2);

                //get free qty
                string root_product_id = "";
                double qty = 0;
                root_product_id = dt.Rows[0]["ProductID"].ToString().ToString();
                qty = _Convert(dt.Rows[0]["CovertedQuantity"].ToString());
                DataTable dt_free = bllUtility.GetDataBySP("USP_get_free '" + root_product_id + "'," + qty + "");
                if (dt_free.Rows.Count > 0)
                {
                    chk_free.Checked = true;

                    if (IsExistInFreeGrid(dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["UnitId"].ToString(), root_product_id) == true)
                    {
                        UpdateDataToFreeGrid(root_product_id, dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["ProductName"].ToString(), dt_free.Rows[0]["FreeQty"].ToString(), dt_free.Rows[0]["UnitID"].ToString(), dt_free.Rows[0]["UnitName"].ToString());
                    }
                    else
                    {
                        AddDataToFreeGrid(root_product_id, dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["ProductName"].ToString(), dt_free.Rows[0]["FreeQty"].ToString(), dt_free.Rows[0]["UnitID"].ToString(), dt_free.Rows[0]["UnitName"].ToString());
                    }
                }

                //get gift qty
                DataTable dt_gift = bllUtility.GetDataBySP("USP_get_gift '" + root_product_id + "'," + qty + "");
                if (dt_gift.Rows.Count > 0)
                {
                    chk_gift.Checked = true;

                    if (IsExistInGiftGrid(dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["UnitId"].ToString(), root_product_id) == true)
                    {
                        UpdateDataToGiftGrid(root_product_id, dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["gift_qty"].ToString(), dt_gift.Rows[0]["UnitID"].ToString(), dt_gift.Rows[0]["UnitName"].ToString());
                    }
                    else
                    {
                        AddDataToGiftGrid(root_product_id, dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["gift_qty"].ToString(), dt_gift.Rows[0]["UnitID"].ToString(), dt_gift.Rows[0]["UnitName"].ToString());
                    }
                }
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
            if (txtProductID.Text.Length > 4)
                load_product_to_grid();
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

        //private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkDiscount.Checked == true)
        //    {
        //        this.txtDiscountAmount.Enabled = true;
        //        this.txtDiscountAmount.Text = "0.00";
        //        this.txtDiscountAmount.Focus();
        //        this.txtDiscountAmount.SelectAll();
        //    }
        //    else
        //    {
        //        this.txtDiscountAmount.Enabled = false;
        //        this.txtDiscountAmount.Text = "0.00";
        //    }
        //}

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
                rptTest.SetParameterValue("SalesReturn", bllUtility.Val("0"));
                //rptTest.PrintToPrinter(1, false, 0, 0);
                frmRptv obj = new frmRptv();
                obj.SetReportDataSource = rptTest;
                obj.ShowDialog();
            }
            catch
            {
            }

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
                lbl_commission_adjustable_amount.Text = "";
                if (txtCustomerCode.Text.Substring(0, 3) == "DTB")
                {
                    DataTable dt = bllUtility.GetDataBySP("USP_commission_unadjusted_amount_get '" + txtCustomerCode.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        lbl_commission_adjustable_amount.Text = dt.Rows[0]["AdjustableAmount"].ToString();
                    }
                }
                //string strAccountNo = txtCustomerCode.Text.ToUpper();
                //DataTable dt = new DataTable();
                //dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNo, "2");
                //if (dt.Rows.Count > 0)
                //{
                //    txtCustomerName.Text = dt.Rows[0]["AccHolderName"].ToString();
                //}
                //else
                //{
                //    XtraMessageBox.Show("Invalid Account Holder.", "Warning");
                //    txtCustomerName.Text = "";
                //    txtCustomerCode.Focus();
                //    txtCustomerCode.SelectAll();
                //}
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
            //frmCustomerSearch obj = new frmCustomerSearch(2);// 2 = Customer
            //obj.ShowDialog();
            //this.txtCustomerName.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            //this.txtCustomerCode.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            ////clearing global search object.
            //bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

            frmCustomerSearchNew obj = new frmCustomerSearchNew();
            obj.ShowDialog();

            this.txtCustomerName.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtCustomerCode.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;
            cmb_zone.EditValue = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.ZoneID.ToString();
            if (bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.RSMID != "")
                cmb_rsm.EditValue = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.RSMID;
            else
                cmb_rsm.EditValue = null;
            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;


            Cursor = Cursors.WaitCursor;
            DataTable dt = bllUtility.GetDataBySP("[rpt_account_last_closing_statement] '','" + this.txtCustomerCode.Text + "'");
            if (dt.Rows.Count > 0)
                lblClosingBalance.Text = dt.Rows[0]["Banance"].ToString();
            else lblClosingBalance.Text = "0";
            Cursor = Cursors.Default;

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
                //this.txtTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat")));
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
            double _TotalPrice;
            double _Vat;
            double _DiscountAmount;
            int rowIdex = Convert.ToInt16(e.RowIndex);
            string root_product_id = "";
            double qty = 0;
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                //if (dgvSalesGrid.Columns[e.ColumnIndex].Name == "ProductQuantity")
                //{
                if (_Convert(dgvSalesGrid.Rows[rowIdex].Cells["StockQty"].Value.ToString().Trim()) < (_Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString().Trim()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitQuantity"].Value.ToString().Trim())))
                {
                    dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value = "0";
                    dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithVat"].Value = "0";
                    dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithoutVat"].Value = "0";
                    dgvSalesGrid.Rows[rowIdex].Cells["DiscountAmount"].Value = "0";
                    dgvSalesGrid.Rows[rowIdex].Cells["TotalWODiscount"].Value = "0";

                    XtraMessageBox.Show("Stock not available. Please purchase this product.");
                    //return;
                }
                else
                {
                    _TotalPrice = _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitSalesPrice"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString());
                    _Vat = (_Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitSalesPrice"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString())) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["VatPerchantage"].Value.ToString()) / 100;
                    _DiscountAmount = _Convert(dgvSalesGrid.Rows[rowIdex].Cells["DiscountPercent"].Value.ToString()) * _TotalPrice / 100;
                    dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithVat"].Value = _TotalPrice + _Vat - _DiscountAmount;
                    dgvSalesGrid.Rows[rowIdex].Cells["TotalPriceWithoutVat"].Value = _TotalPrice - _Vat - _DiscountAmount;
                    dgvSalesGrid.Rows[rowIdex].Cells["CovertedQuantity"].Value = _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitQuantity"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString());
                    dgvSalesGrid.Rows[rowIdex].Cells["DiscountAmount"].Value = _DiscountAmount.ToString();
                    dgvSalesGrid.Rows[rowIdex].Cells["TotalWODiscount"].Value = _TotalPrice;

                    //get free qty
                    root_product_id = dgvSalesGrid.Rows[rowIdex].Cells["ProductID"].Value.ToString();
                    qty = _Convert(dgvSalesGrid.Rows[rowIdex].Cells["UnitQuantity"].Value.ToString()) * _Convert(dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString());
                    DataTable dt_free = bllUtility.GetDataBySP("USP_get_free '" + root_product_id + "'," + qty + "");
                    if (dt_free.Rows.Count > 0)
                    {
                        chk_free.Checked = true;
                        if (IsExistInFreeGrid(dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["UnitId"].ToString(), root_product_id) == true)
                        {
                            UpdateDataToFreeGrid(root_product_id, dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["ProductName"].ToString(), dt_free.Rows[0]["FreeQty"].ToString(), dt_free.Rows[0]["UnitID"].ToString(), dt_free.Rows[0]["UnitName"].ToString());
                        }
                        else
                        {
                            AddDataToFreeGrid(root_product_id, dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["ProductName"].ToString(), dt_free.Rows[0]["FreeQty"].ToString(), dt_free.Rows[0]["UnitID"].ToString(), dt_free.Rows[0]["UnitName"].ToString());
                        }
                    }

                    //get gift qty
                    DataTable dt_gift = bllUtility.GetDataBySP("USP_get_gift '" + root_product_id + "'," + qty + "");
                    if (dt_gift.Rows.Count > 0)
                    {
                        chk_gift.Checked = true;

                        if (IsExistInGiftGrid(dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["UnitId"].ToString(), root_product_id) == true)
                        {
                            UpdateDataToGiftGrid(root_product_id, dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["gift_qty"].ToString(), dt_gift.Rows[0]["UnitID"].ToString(), dt_gift.Rows[0]["UnitName"].ToString());
                        }
                        else
                        {
                            AddDataToGiftGrid(root_product_id, dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["gift_qty"].ToString(), dt_gift.Rows[0]["UnitID"].ToString(), dt_gift.Rows[0]["UnitName"].ToString());
                        }
                    }
                }
                //}

                
            }
            //this.txtTotalItemAmount.Text = Convert.ToString(Math.Round(dgvColumnSum(dgvSalesGrid, "TotalPriceWithVat")));
            CalculateAmount();
            CalculateFree();
            lblTotalGiftItem.Text = (dgvGift.Rows.Count).ToString();
            
        }

        private void dgvSalesGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumnName = dgvSalesGrid.Columns[dgvSalesGrid.CurrentCell.ColumnIndex].Name;
            if (ColumnName == "ProductQuantity" || ColumnName == "DiscountPercent")
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
                        load_product_to_grid();
                    }
                }
            }
        }

        //        private void cmb_product_EditValueChanged(object sender, EventArgs e)
        //        {
        //            if (cmb_product.EditValue == null) return;
        //            if (cmb_product.EditValue != null && cmb_product.EditValue != "")
        //            {
        //                //LoadProductUnit(cmbUnit, cmb_product.EditValue.ToString()); 
        //                DataTable dt = new DataTable();
        //                dt = bllReportUtility.ReportData(@"SELECT dbo.UnitInfo.UnitName, dbo.UnitInfo.UnitId
        //                                                   FROM dbo.ProductSalesPrice INNER JOIN dbo.UnitInfo ON dbo.ProductSalesPrice.UnitID = dbo.UnitInfo.UnitId
        //                                                   WHERE (dbo.ProductSalesPrice.IsMinimumUnit = 1) AND (dbo.ProductSalesPrice.ProductID = '" + cmb_product.EditValue.ToString() + "')");
        //                if (dt.Rows.Count > 0)
        //                {
        //                    lbl_return_unit.Text = dt.Rows[0][0].ToString();
        //                    lbl_return_unit_id.Text = dt.Rows[0][1].ToString();

        //                }
        //                else 
        //                {
        //                    XtraMessageBox.Show("Minimum unit not setup for this product.");
        //                    cmb_product.Focus();
        //                    return;

        //                }
        //            }
        //        }

        //private void txt_free_qty_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)//|| e.KeyChar == 46)
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

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

        //private void cmb_product_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txt_free_qty.Focus();
        //    }
        //}

        //private void txt_free_qty_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txt_return_unit_price.Focus();
        //    }
        //}

        //private void btn_add_to_return_Click(object sender, EventArgs e)
        //{
        //    if (cmb_product.EditValue == null || cmb_product.EditValue == "")
        //    {
        //        XtraMessageBox.Show("Product name required!.");
        //        cmb_product.Focus();
        //        return;
        //    }
        //    if (bllUtility.Val(txt_free_qty.Text.Trim())<=0)              
        //    {
        //        XtraMessageBox.Show("Product return qty required!.");
        //        txt_free_qty.Focus();
        //        return;
        //    }
        //    if (bllUtility.Val(txt_return_unit_price.Text.Trim()) <= 0)
        //    {
        //        XtraMessageBox.Show("Product return qty unit price required!.");
        //        txt_return_unit_price.Focus();
        //        return;
        //    }
        //    AddDataToReturnGrid();
        //    CalculateReturnAmount();
        //}

        private void AddDataToFreeGrid()
        {
            //Add data to grid
            dgvFree.Rows.Add();
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[0].Value = cmb_product.EditValue.ToString();
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[1].Value = cmb_product.Text;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[2].Value = txt_free_qty.Text;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[3].Value = lbl_return_unit.Text;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[4].Value = lbl_return_unit_id.Text;

            //clear free items
            cmb_product.EditValue = null;
            txt_free_qty.Text = "";
            lbl_return_unit.Text = "";
            lbl_return_unit_id.Text = string.Empty;
            cmb_product.Focus();
        }

        private void AddDataToFreeGrid(string root_product_id,string product_code,string product_name,string free_qty,string unit_id,string unit_name)
        {
            //Add data to grid
            dgvFree.Rows.Add();
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[0].Value = product_code;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[1].Value = product_name;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[2].Value = free_qty;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[3].Value = unit_name;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells[4].Value = unit_id;
            dgvFree.Rows[dgvFree.Rows.Count - 1].Cells["RootProductID"].Value = root_product_id;
        }

        private void UpdateDataToFreeGrid(string root_product_id, string product_code, string product_name, string free_qty, string unit_id, string unit_name)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvFree.Rows)
            {
                if (row.Cells["RootProductID"].Value.ToString().Equals(root_product_id))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dgvFree.Rows[rowIndex].Cells[2].Value = free_qty;            
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

        private void cmb_product_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_product.EditValue == null)
                return;
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

        private void cmb_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_free_qty.Focus();
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
            if (bllUtility.Val(txt_free_qty.Text.Trim()) <= 0)
            {
                XtraMessageBox.Show("Product return qty required!.");
                txt_free_qty.Focus();
                return;
            }
            if (IsExistInFreeGrid(this.cmb_product.EditValue.ToString(), lbl_return_unit_id.Text.ToString(),"") == false)
            {
                AddDataToFreeGrid();
                CalculateFree();
            }
            else
            {
                XtraMessageBox.Show("You have already Input this Product in the list.");
                return;
            }
            //opt_item_type.Enabled = false;
        }

        private void CalculateFree()
        {
            lblTotalFreeItem.Text = (dgvFree.Rows.Count).ToString();
        }

        private void chk_free_CheckedChanged(object sender, EventArgs e)
        {
            grp_free.Enabled = chk_free.Checked;
            cmb_product.Focus();
        }

        private void txt_free_qty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_free_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_to_return.Focus();
            }
        }

        private void dgvFree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvFree.CurrentCell == null)
                    return;
                this.dgvFree.Rows.RemoveAt(dgvFree.CurrentCell.RowIndex);
                CalculateFree();
            }
        }

        private void btn_add_to_gift_Click(object sender, EventArgs e)
        {
            if (txt_gift_name.Text == "")
            {
                XtraMessageBox.Show("Product name required!.");
                txt_gift_name.Focus();
                return;
            }
            if (bllUtility.Val(txt_gift_qty.Text.Trim()) <= 0)
            {
                XtraMessageBox.Show("Gift qty required!.");
                txt_gift_qty.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cmb_unit_gift.SelectedValue.ToString()) || cmb_unit_gift.SelectedValue.ToString() == "0")
            {
                XtraMessageBox.Show("Unit required!.");
                cmb_unit_gift.Focus();
                return;
            }

            AddDataToGiftGrid();

            //clear free items
            txt_gift_name.Text = "";
            txt_gift_qty.Text = "";
            txt_gift_name.Focus();

            //count the no of item
            lblTotalGiftItem.Text = (dgvGift.Rows.Count).ToString();
        }

        private void AddDataToGiftGrid()
        {
            //Add data to grid
            dgvGift.Rows.Add();
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[0].Value = txt_gift_name.Text;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[1].Value = txt_gift_qty.Text;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[2].Value = cmb_unit_gift.Text;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[3].Value = cmb_unit_gift.SelectedValue;
        }

        private void AddDataToGiftGrid(string RootProductIDGift, string gift_name, string gift_qty, string gift_unit_id, string gift_unit_name)
        {
            //Add data to grid
            dgvGift.Rows.Add();
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[0].Value = gift_name;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[1].Value = gift_qty;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[2].Value = gift_unit_name;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells[3].Value = gift_unit_id;
            dgvGift.Rows[dgvGift.Rows.Count - 1].Cells["RootProductIDGift"].Value = RootProductIDGift;
        }

        private void UpdateDataToGiftGrid(string RootProductIDGift, string gift_name, string gift_qty, string gift_unit_name, string gift_unit_id)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvGift.Rows)
            {
                if (row.Cells["RootProductIDGift"].Value.ToString().Equals(RootProductIDGift))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dgvGift.Rows[rowIndex].Cells["ProductQuantity_Gift"].Value = gift_qty;    
        }

        private void chk_gift_CheckedChanged(object sender, EventArgs e)
        {
            grp_gift.Enabled = chk_gift.Checked;
            txt_gift_name.Focus();
        }

        private void txt_gift_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_gift_qty.Focus();
            }
        }

        private void txt_gift_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmb_unit_gift.Focus();
            }
        }

        private void cmb_unit_gift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_to_gift.Focus();
            }
        }

        private void dgvGift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvGift.CurrentCell == null)
                    return;
                this.dgvGift.Rows.RemoveAt(dgvGift.CurrentCell.RowIndex);
                //count the no of item
                lblTotalGiftItem.Text = (dgvGift.Rows.Count).ToString();
            }
        }

        private void chk_sample_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sample.Checked == true)
            {
                grp_free.Enabled = false;
                grp_gift.Enabled = false;
                chk_free.Enabled = false;
                chk_gift.Enabled = false;
            }
            else
            {
                grp_free.Enabled = true;
                grp_gift.Enabled = true;
                chk_free.Enabled = true;
                chk_gift.Enabled = true;
            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    load_product_to_grid();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void load_product_to_grid()
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
                this.cmbUnit.SelectedValue = Convert.ToDouble(dt.Rows[0]["UnitID"]);
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

        private void chk_deposit_to_bank_CheckedChanged(object sender, EventArgs e)
        {
            //cmb_bank.Enabled = chk_deposit_to_bank.Checked;            
            //chk_commission_adjust.Checked = false;           
        }

        private void txtPaidAmount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void chk_commission_adjust_CheckedChanged(object sender, EventArgs e)
        {
            //txt_commission_adjust.Enabled = chk_commission_adjust.Checked;            
            //txt_commission_adjust.Text = "";
            //txt_commission_adjust.Focus();
            //chk_deposit_to_bank.Checked = false;
        }

        private void cmb_bank_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void opt_commission_adjust_CheckedChanged(object sender, EventArgs e)
        {
            txt_commission_adjust.Enabled = opt_commission_adjust.Checked;
            txt_commission_adjust.Focus();
            txt_commission_adjust.SelectAll();
        }

        private void opt_bank_option_CheckedChanged(object sender, EventArgs e)
        {
            cmb_bank.Enabled = opt_bank_option.Checked;
        }

        private void btn_clear_commission_Click(object sender, EventArgs e)
        {
            opt_bank_option.Checked = false;
            opt_commission_adjust.Checked = false;
            txt_commission_adjust.Text = "0";
        }

        private void chk_requisition_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_requisition.Checked == true)
                link_requisition_import.Enabled = true;
            else
                link_requisition_import.Enabled = false;
        }

        private void link_requisition_import_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            load_requisition_list();
            grp_requisition.Visible = true;
            Cursor = Cursors.Default;
        }

        private void btn_search_req_Click(object sender, EventArgs e)
        {
            string RequisitionID = "";

            if (cmb_req_no.EditValue == null)
            {
                XtraMessageBox.Show("Requisition No Selection Required!");
                cmb_req_no.Focus();
                return;
            }

            RequisitionID = cmb_req_no.EditValue.ToString();

            DataTable dt = bllUtility.GetDataBySP("dbo.load_requition_details '" + RequisitionID + "'");
            grd_requisition_details.DataSource = dt;

        }

        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_close_req_Click(object sender, EventArgs e)
        {
            grp_requisition.Visible = false;
        }

        private void gv_details_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataTable dt = grd_requisition_details.DataSource as DataTable;
            if ((e.Column.VisibleIndex == 5))
            {
                double stock_qty = bllUtility.Val(dt.Rows[e.RowHandle]["StockQty"]);
                double req_qty = bllUtility.Val(e.CellValue);
                if (req_qty > stock_qty)
                    e.Appearance.BackColor = Color.OrangeRed;
                else
                    e.Appearance.BackColor = Color.Lavender;
            }
        }

        private void cmb_req_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_req_Click(sender, e);
        }

        private void cmb_req_no_EditValueChanged(object sender, EventArgs e)
        {

            if (cmb_req_no.EditValue == null)
                return;
            string req_no = cmb_req_no.EditValue.ToString();
            DataTable dt = (cmb_req_no.Properties.DataSource as DataTable).Copy();
            DataRow[] dr = dt.Select("RequisitionID='" + req_no.Replace("(", "").Replace(")", "") + "'");
            txt_req_date.Text = dr[0]["RequisitionDate"].ToString();
            txt_dealerid.Text = dr[0]["DealerID"].ToString();
            txt_dealer_name.Text = dr[0]["AccHolderName"].ToString();
            txt_payment_amount.Text = dr[0]["PaymentAmount"].ToString();
            txt_payment_mode.Text = dr[0]["PaymentMode"].ToString();
            lbl_dealerid.Text = dr[0]["AccHolderInfoId"].ToString();
            btn_search_req_Click(sender, e);
        }

        private void btn_load_for_sale_req_Click(object sender, EventArgs e)
        {
            grd_requisition_details.Focus();
            DataTable dt_grd = grd_requisition_details.DataSource as DataTable;
            bool isStockExceed = false;
            if (dt_grd.Rows == null || dt_grd.Rows.Count < 1)
            {
                XtraMessageBox.Show("You have not sel;ect any requisition.");
                return;
            }

            for (int i = 0; i < dt_grd.Rows.Count; i++)
            {
                if (bllUtility.Val(dt_grd.Rows[i]["Quantity"].ToString()) > bllUtility.Val(dt_grd.Rows[i]["StockQty"].ToString()))
                {
                    isStockExceed = true;
                    break;
                }
            }
            if (isStockExceed)
            {
                XtraMessageBox.Show("You have not sufficient stock for this requisition.");
                return;
            }
            for (int i = 0; i < dt_grd.Rows.Count; i++)
            {
                if (IsExistInGrid(dt_grd.Rows[i]["ProductID"].ToString(), dt_grd.Rows[i]["UnitID"].ToString()) == true)
                {
                    XtraMessageBox.Show(dt_grd.Rows[i]["ProductID"].ToString()+ " product already added in the sales list.");
                    return;
                }
            }
            grp_requisition.Visible = false;

            //load data to sales grid
            lbl_req_title.Text = "Requisition No : ";
            lbl_req_number.Text = cmb_req_no.EditValue.ToString();
            this.dgvSalesGrid.AutoGenerateColumns = false;
            for (int i = 0; i < dt_grd.Rows.Count; i++)
            {
                if (bllUtility.Val(dt_grd.Rows[i]["Quantity"].ToString()) > 0)
                {
                    DataTable dt = new DataTable();
                    dt = bllProductSales.PopulateSalesGrid(dt_grd.Rows[i]["ProductID"].ToString().Trim(), dt_grd.Rows[i]["UnitID"].ToString(), dt_grd.Rows[i]["Quantity"].ToString(), dt_grd.Rows[i]["SalesPrice"].ToString(),cmb_store.EditValue.ToString());
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
                    this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["DiscountPercent"].Value = dt.Rows[0]["DiscountPercent"].ToString();
                    this.dgvSalesGrid.Rows[dgvSalesGrid.Rows.Count - 1].Cells["TotalWODiscount"].Value = _Convert(dt.Rows[0]["ProductQuantity"].ToString()) * Math.Round(_Convert(dt.Rows[0]["UnitSalesPrice"].ToString()), 2);

                    //get free qty
                    string root_product_id = "";
                    double qty = 0;
                    root_product_id = dt.Rows[0]["ProductID"].ToString().ToString();
                    qty = _Convert(dt.Rows[0]["CovertedQuantity"].ToString());
                    DataTable dt_free = bllUtility.GetDataBySP("USP_get_free '" + root_product_id + "'," + qty + "");
                    if (dt_free.Rows.Count > 0)
                    {
                        chk_free.Checked = true;

                        if (IsExistInFreeGrid(dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["UnitId"].ToString(), root_product_id) == true)
                        {
                            UpdateDataToFreeGrid(root_product_id, dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["ProductName"].ToString(), dt_free.Rows[0]["FreeQty"].ToString(), dt_free.Rows[0]["UnitID"].ToString(), dt_free.Rows[0]["UnitName"].ToString());
                        }
                        else
                        {
                            AddDataToFreeGrid(root_product_id, dt_free.Rows[0]["ProductID"].ToString(), dt_free.Rows[0]["ProductName"].ToString(), dt_free.Rows[0]["FreeQty"].ToString(), dt_free.Rows[0]["UnitID"].ToString(), dt_free.Rows[0]["UnitName"].ToString());
                        }
                    }

                    //get gift qty
                    DataTable dt_gift = bllUtility.GetDataBySP("USP_get_gift '" + root_product_id + "'," + qty + "");
                    if (dt_gift.Rows.Count > 0)
                    {
                        chk_gift.Checked = true;

                        if (IsExistInGiftGrid(dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["UnitId"].ToString(), root_product_id) == true)
                        {
                            UpdateDataToGiftGrid(root_product_id, dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["gift_qty"].ToString(), dt_gift.Rows[0]["UnitID"].ToString(), dt_gift.Rows[0]["UnitName"].ToString());
                        }
                        else
                        {
                            AddDataToGiftGrid(root_product_id, dt_gift.Rows[0]["gift_name"].ToString(), dt_gift.Rows[0]["gift_qty"].ToString(), dt_gift.Rows[0]["UnitID"].ToString(), dt_gift.Rows[0]["UnitName"].ToString());
                        }
                    }

                }
            }
            
            //set dealer id, name and zone
            DataTable dt_dealer = new DataTable();
            dt_dealer = bllAccountHolderInfo.getById(Convert.ToInt16(lbl_dealerid.Text));
            txtCustomerCode.Text = dt_dealer.Rows[0]["AccountNo"].ToString();
            txtCustomerName.Text = dt_dealer.Rows[0]["AccHolderName"].ToString();
            this.cmb_zone.EditValue = dt_dealer.Rows[0]["ZoneID"].ToString();
            cmb_rsm.EditValue = dt_dealer.Rows[0]["RSMID"].ToString();
            //calculation
            CalculateAmount();
            CalculateFree();
            lblTotalGiftItem.Text = (dgvGift.Rows.Count).ToString();

            lbl_dealerid.Text = "";
            cmb_req_no.EditValue = null;
            txt_req_date.Text = "";
            txt_dealerid.Text = "";
            txt_dealer_name.Text = "";
            txt_payment_amount.Text = "";
            txt_payment_mode.Text = "";
            grd_requisition_details.DataSource = null;


        }

        public class RequisitionDetails
        {
            public string RequisitionID { get; set; }
            public string DealerID { get; set; }
            public string RequisitionDate { get; set; }
            public string PaymentMode { get; set; }
            public string PaymentAmount { get; set; }
            public string ProductID { get; set; }
            public string Quantity { get; set; }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_req = bllUtility.generate_datetable("RequisitionID,DealerID,RequisitionDate,PaymentMode,PaymentAmount,ProductID,Quantity");
                var url = bllUtility.DefaultSettings.Api_link + "get_requisition_list/" + "2";
                var w = new WebClient();
                var json_data = string.Empty;
                this.Cursor = Cursors.WaitCursor;
                json_data = w.DownloadString(url);
                this.Cursor = Cursors.Default;
                //json_data = json_data.Replace("{}", "\"0\"");
                var machine = JsonConvert.DeserializeObject<List<RequisitionDetails>>(json_data);

                foreach (var data in machine)
                    dt_req.Rows.Add(data.RequisitionID, data.DealerID, Convert.ToDateTime(data.RequisitionDate.Substring(0, 10)).ToString("dd/MM/yyyy"), data.PaymentMode, data.PaymentAmount, data.ProductID, data.Quantity);

                //grd_data.DataSource = dt_req;

                if (dt_req.Rows.Count < 1)
                {
                    XtraMessageBox.Show("No data found for import");
                }
                else
                {
                    for (int i = 0; i < dt_req.Rows.Count; i++)
                    {
                        bllRequisition.InsertRequisition(dt_req.Rows[i]["RequisitionID"].ToString(), dt_req.Rows[i]["DealerID"].ToString(), dt_req.Rows[i]["RequisitionDate"].ToString(), dt_req.Rows[i]["PaymentMode"].ToString(), dt_req.Rows[i]["PaymentAmount"].ToString(), dt_req.Rows[i]["ProductID"].ToString(), dt_req.Rows[i]["Quantity"].ToString());
                    }
                   // lbl4.Text = "Successfully Done";
                    //btn_import.Enabled = false;
                    XtraMessageBox.Show("Successfully requisition data is imported.");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btn_delete_requisition_Click(object sender, EventArgs e)
        {
            if (cmb_req_no.EditValue == null)
            {
                XtraMessageBox.Show("No data found for Delete.");
                return;
            }

            if (XtraMessageBox.Show("Do you want to delete the requisition? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //delete
            if (bllRequisition.Delete(cmb_req_no.EditValue.ToString()) == true)
            {
                XtraMessageBox.Show("Data Deleted successfully.");
            }
            grd_requisition_details.DataSource = null;
            load_requisition_list();
            cmb_req_no.EditValue = null;
            txt_req_date.Text = "";
            txt_dealer_name.Text = "";
            txt_dealerid.Text = "";
            lbl_dealerid.Text = "";
            txt_payment_mode.Text = "";
            txt_payment_amount.Text = "";
        }

        private void txtProductID_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
