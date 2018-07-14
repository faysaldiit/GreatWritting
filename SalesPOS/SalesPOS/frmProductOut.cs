using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesPOS.BLL;
using SalesPOS.BOL;
using SalesPOS.Report;

namespace SalesPOS
{
    public partial class frmProductOut : DevExpress.XtraEditors.XtraForm
    {

        ProductSalesInfo objProductSalesInfo = new ProductSalesInfo();
        SalesPaymentInfo objSalesPaymentInfo = new SalesPaymentInfo();
        ProductSalesDetailsInfo objProductSalesDetailsInfo = new ProductSalesDetailsInfo();
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();


        public frmProductOut()
        {
            InitializeComponent();
        }


        private void frmSalesInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cmb_transaction_type;
            bllUtility.ResetGridColor(dgvProduct);
            ClearAll();
            load_product_info();
        }

        private void frmSalesInfo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void load_product_info()
        {
            DataTable dt = bllProductInfo.getAll();
            cmb_product.Properties.DisplayMember = "ProductName";
            cmb_product.Properties.ValueMember = "ProductID";
            cmb_product.Properties.DataSource = dt;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmb_transaction_type.EditValue == null)
            {
                XtraMessageBox.Show("Transaction type required!");
                return;
            }
            if (dgvProduct.Rows.Count > 0)
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

                string transaction_id = "";
    
                DataTable dt = bllProductSales.InsertProductOutParentInfo(cmb_transaction_type.EditValue.ToString(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
                transaction_id = dt.Rows[0]["TransactionID"].ToString();
                for (int i = 0; i < dgvProduct.Rows.Count; i++)
                {
                    
                    bllProductSales.InsertProductOutDetails(transaction_id, dgvProduct.Rows[i].Cells["ProductID"].Value.ToString().Trim(), dgvProduct.Rows[i].Cells["UnitID"].Value.ToString().Trim(), dgvProduct.Rows[i].Cells["ProductQuantity"].Value.ToString().Trim());
                }

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
        

       
        private void DisplayStock()
        {
            pic_reorder.Visible = false;
            lblReorder.Text = "";
            string current_stock = "";
            DataTable dt = bllReportUtility.ReportData(@"SELECT     cast(ProductMainStock.Quantity AS VARCHAR(10)) + ' ' + UnitInfo.UnitName AS Stock,ProductMainStock.Quantity
FROM         ProductMainStock INNER JOIN
                      UnitInfo ON ProductMainStock.MinimumUnitID = UnitInfo.UnitId
WHERE     (ProductMainStock.ProductID = '" + cmb_product.EditValue.ToString() + "') AND (ProductMainStock.AreaID = 2)");
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
            DataTable dt1 = bllReportUtility.ReportData("SELECT ISNULL(ReOrderLevel, 0) AS ReOrderLevel FROM ProductInfo WHERE (ProductID = '" + cmb_product.EditValue.ToString() + "')");
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

        private void InitializeFreeSalesDetailsInfo(int j)
        {
            objProductSalesDetailsInfo.InvoiceNo = txtInvoiceNo.Text;
            objProductSalesDetailsInfo.ProductID = dgvProduct.Rows[j].Cells[0].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualQty = dgvProduct.Rows[j].Cells[2].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualUnitID = dgvProduct.Rows[j].Cells[4].Value.ToString().Trim();
            objProductSalesDetailsInfo.ActualUnitSalesPrice = "0";
            objProductSalesDetailsInfo.TotalPriceWithoutVat = "0";
            objProductSalesDetailsInfo.VatID = "0";
            objProductSalesDetailsInfo.VatPerchantage = "0";
            objProductSalesDetailsInfo.VatAmount = "0";
            objProductSalesDetailsInfo.TotalPriceWithVat = "0";
            objProductSalesDetailsInfo.DiscountAmount = "0";
            objProductSalesDetailsInfo.DiscountPercent = "0";
            objProductSalesDetailsInfo.ConvertedUnitID = dgvProduct.Rows[j].Cells[4].Value.ToString().Trim();
            objProductSalesDetailsInfo.CovertedQuantity = dgvProduct.Rows[j].Cells[2].Value.ToString().Trim();
            objProductSalesDetailsInfo.ItemType = "1";

        }



        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            lblReorder.Text = "";
            ClearProductInfo();
            dgvProduct.Rows.Clear();
            this.btnSave.Enabled = true;
            this.txtInvoiceNo.Text = string.Empty;
            lblStock.Text = "";
            pic_reorder.Visible = false;
            cmb_product.EditValue = null;
            lbl_unit_id.Text = "";
            lbl_unit.Text = "";
            txt_qty.Text = "";
            cmb_transaction_type.Focus();
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



        private bool IsExistInFreeGrid(string ProductID, string UnitID)
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
            DisplayStock();
        }

        private void cmb_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                XtraMessageBox.Show("Not sufficient stock!");
                txt_qty.Focus();
                return;
            }


            if (IsExistInFreeGrid(this.cmb_product.EditValue.ToString(), lbl_unit_id.Text.ToString()) == false)
            {
                AddDataToGrid();
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
    }
}
