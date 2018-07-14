using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesPOS.BLL;
using SalesPOS.BOL;
using SalesPOS.Report;

namespace SalesPOS
{
    public partial class frmReturnNew : DevExpress.XtraEditors.XtraForm
    {
        SalesReturnParent objSalesReturnParent = new SalesReturnParent();        
        ProductSalesDetailsInfo objProductSalesDetailsInfo = new ProductSalesDetailsInfo();
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();


        public frmReturnNew()
        {
            InitializeComponent();
        }


        private void frmSalesInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cmb_customer;
            bllUtility.ResetGridColor(dgvProduct);
            ClearAll();
            load_product_list();
            load_customer();
        }

        private void frmSalesInfo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void load_product_list()
        {
            DataTable dt = bllProductInfo.getAll();
            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;
        }
        private Double GetCellValue(Object Input)
        {
            Double output = 0;
            try
            {
                output = Convert.ToDouble(Input);
            }
            catch
            {
                output = 0;
            }
            return output;
        }
        private bool ValidateReturn()
        {
            bool isValid = true;
            Double RT = 0;
            for (int i = 0; i < this.dgvProduct.Rows.Count; i++)
            {
                RT = RT + (GetCellValue(dgvProduct.Rows[i].Cells["ProductQuantity"].Value));
            }
            if (RT <= 0)
            {
                isValid = false;
            }
            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmb_customer.EditValue == null)
            {
                XtraMessageBox.Show("Customer selection required!");
                cmb_customer.Focus();
                return;
            }

            if (dgvProduct.Rows.Count > 0)
            {
                if (ValidateReturn())
                {
                    //Execute Sales Process
                    if (SaveDate())
                    {
                        XtraMessageBox.Show("Successfully Saved Transaction");
                        this.btnSave.Enabled = false;
                        //this.btnPrint.Enabled = true;
                        //this.btnPrint.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("Could not Save Transaction");
                    }
                }
                else { XtraMessageBox.Show("Return Quantity is not found."); }
            }
            else
            {
                XtraMessageBox.Show("You Have Not Select Any Product.");
            }
        }

        private bool SaveDate()
        {

            bool isValid = false;
            try
            {
                double return_amount = 0.00;
                string transaction_id = "";
                string AccountNo = "";
                AccountNo = cmb_customer.EditValue.ToString();
                Initialize_SalesReturn_ParentInfo();



                DataTable dt = bllSalesReturnInfo.InsertSalesReturnParent(objSalesReturnParent, AccountNo);
                transaction_id = dt.Rows[0]["SalesReturnNo"].ToString();

                for (int i = 0; i < dgvProduct.Rows.Count; i++)
                {
                    bllSalesReturnInfo.InsertSalesReturnLotWise(transaction_id, dgvProduct.Rows[i].Cells["ProductID"].Value.ToString().Trim(), dgvProduct.Rows[i].Cells["UnitID"].Value.ToString().Trim(), dgvProduct.Rows[i].Cells["ProductQuantity"].Value.ToString().Trim(), AccountNo);
                }

                DataTable dt_return_amount = bllReportUtility.ReportData("get_return_amount '" + transaction_id + "'");
                if (dt_return_amount.Rows.Count > 0)
                {
                    return_amount=Convert.ToDouble(dt_return_amount.Rows[0][0].ToString());
                }

                if (return_amount > 0)
                    bllProductSales.InsertAccountTransactionBySystem("Return", return_amount.ToString(), transaction_id,txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"),0);




                txtInvoiceNo.Text = transaction_id;
                isValid = true;

            }
            catch (Exception ex)
            {
                isValid = false;
                XtraMessageBox.Show(ex.ToString());
            }
            return isValid;
        }

        private void load_customer()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID] 2");
            cmb_customer.Properties.DisplayMember = "AccHolderName";
            cmb_customer.Properties.ValueMember = "AccountNo";
            cmb_customer.Properties.DataSource = dt;
        }

        private void Initialize_SalesReturn_ParentInfo()
        {
            objSalesReturnParent.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
            objSalesReturnParent.InvoiceNo = txtInvoiceNo.Text;
            objSalesReturnParent.SalesReturnNo = "";
            objSalesReturnParent.TotalAmount = "0";
            objSalesReturnParent.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
            objSalesReturnParent.CustomerID = string.Empty;
        }


        private void DisplayReturnableQty()
        {
            if (cmb_customer.EditValue == null)
            {
                XtraMessageBox.Show("Customer selection required!");
                cmb_customer.Focus();
                return;
            }
            string account_no = cmb_customer.EditValue.ToString();
            string current_stock = "";
            DataTable dt = bllReportUtility.ReportData("get_returnable_qty '" + account_no + "','" + cmb_product.EditValue.ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                current_stock = dt.Rows[0][0].ToString();
                lblStock.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                lblStock.Text = "0";
                current_stock = "0";
            }
        }

        //private void InitializeFreeSalesDetailsInfo(int j)
        //{
        //    objProductSalesDetailsInfo.InvoiceNo = txtInvoiceNo.Text;
        //    objProductSalesDetailsInfo.ProductID = dgvProduct.Rows[j].Cells[0].Value.ToString().Trim();
        //    objProductSalesDetailsInfo.ActualQty = dgvProduct.Rows[j].Cells[2].Value.ToString().Trim();
        //    objProductSalesDetailsInfo.ActualUnitID = dgvProduct.Rows[j].Cells[4].Value.ToString().Trim();
        //    objProductSalesDetailsInfo.ActualUnitSalesPrice = "0";
        //    objProductSalesDetailsInfo.TotalPriceWithoutVat = "0";
        //    objProductSalesDetailsInfo.VatID = "0";
        //    objProductSalesDetailsInfo.VatPerchantage = "0";
        //    objProductSalesDetailsInfo.VatAmount = "0";
        //    objProductSalesDetailsInfo.TotalPriceWithVat = "0";
        //    objProductSalesDetailsInfo.DiscountAmount = "0";
        //    objProductSalesDetailsInfo.DiscountPercent = "0";
        //    objProductSalesDetailsInfo.ConvertedUnitID = dgvProduct.Rows[j].Cells[4].Value.ToString().Trim();
        //    objProductSalesDetailsInfo.CovertedQuantity = dgvProduct.Rows[j].Cells[2].Value.ToString().Trim();
        //    objProductSalesDetailsInfo.ItemType = "1";

        //}



        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            //lblReorder.Text = "";
            ClearProductInfo();
            dgvProduct.Rows.Clear();
            this.btnSave.Enabled = true;
            this.txtInvoiceNo.Text = string.Empty;
            lblStock.Text = "";
            //pic_reorder.Visible = false;
            cmb_product.EditValue = null;
            lbl_unit_id.Text = "";
            lbl_unit.Text = "";
            txt_qty.Text = "";
            cmb_customer.EditValue = null;
            //cmb_transaction_type.Focus();
            cmb_customer.Enabled = true;
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



        private bool IsExistGrid(string ProductID, string UnitID)
        {
            bool isExist = false;
            for (int i = 0; i < dgvProduct.Rows.Count; i++)
            {
                if (dgvProduct.Rows[i].Cells["UnitID"].Value.ToString() == UnitID && dgvProduct.Rows[i].Cells["ProductID"].Value.ToString() == ProductID)
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        private void ClearProductInfo()
        {
            lblStock.Text = "";
            //lblReorder.Text = "";
            //pic_reorder.Visible = false;
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




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPaidAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                this.btnSave.Focus();
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

        private double _Convert(string value)
        {
            double Cvalue = 0.000;
            if (value != "")
            {
                Cvalue = Convert.ToDouble(value);
            }
            return Cvalue;

        }



        private void AddDataToGrid()
        {
            //Add data to grid
            dgvProduct.Rows.Add();
            dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[0].Value = cmb_product.EditValue.ToString();
            dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[1].Value = cmb_product.Text;
            dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[2].Value = txt_qty.Text;
            dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[3].Value = lbl_unit.Text;
            dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[4].Value = lbl_unit_id.Text;
            dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells["StockQty"].Value = lblStock.Text.ToString();
            //clear free items
            cmb_product.EditValue = null;
            txt_qty.Text = "";
            lbl_unit.Text = "";
            lbl_unit_id.Text = string.Empty;
            cmb_product.Focus();
        }



        private void txtCustomerCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmb_product_EditValueChanged(object sender, EventArgs e)
        {
            load_product_info();
        }

        private void load_product_info()
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
                    lbl_unit.Text = dt.Rows[0][0].ToString();
                    lbl_unit_id.Text = dt.Rows[0][1].ToString();

                }
                else
                {
                    XtraMessageBox.Show("Minimum unit not setup for this product.");
                    cmb_product.Focus();
                    return;
                }
            }
            DisplayReturnableQty();
        
        }


        private void cmb_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                load_product_info();
                txt_qty.Focus();
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
            if (bllUtility.Val(txt_qty.Text.Trim()) <= 0)
            {
                XtraMessageBox.Show("Product qty required!.");
                txt_qty.Focus();
                return;
            }

            if (Convert.ToDouble(txt_qty.Text) > Convert.ToDouble(lblStock.Text))
            {
                XtraMessageBox.Show("Not sufficient returnable qty!");
                txt_qty.Focus();
                return;
            }


            if (IsExistGrid(this.cmb_product.EditValue.ToString(), lbl_unit_id.Text.ToString()) == false)
            {
                AddDataToGrid();
                cmb_customer.Enabled = false;
            }
            else
            {
                XtraMessageBox.Show("You have already Input this Product in the list.");
                return;
            }


            lblStock.Text = "";
            //opt_item_type.Enabled = false;
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
                btn_add_to_grid.Focus();
            }
        }

        private void dgvFree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvProduct.CurrentCell == null)
                    return;
                this.dgvProduct.Rows.RemoveAt(dgvProduct.CurrentCell.RowIndex);
            }
        }

        private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdex = Convert.ToInt16(e.RowIndex);
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                //if (dgvSalesGrid.Columns[e.ColumnIndex].Name == "ProductQuantity")
                //{
                if (_Convert(dgvProduct.Rows[rowIdex].Cells["StockQty"].Value.ToString().Trim()) < (_Convert(dgvProduct.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString().Trim())))
                {
                    dgvProduct.Rows[rowIdex].Cells["ProductQuantity"].Value = "0";
                    XtraMessageBox.Show("Stock not available. Please purchase this product.");
                    //return;
                }
            }
        }

        private void cmb_customer_EditValueChanged(object sender, EventArgs e)
        {
            load_product_info();
        }
    }
}
