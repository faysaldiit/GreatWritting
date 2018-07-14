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
    public partial class frmPurchaseReturn : DevExpress.XtraEditors.XtraForm
    {
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }

        private void frmPurchaseReturn_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID]" + 1);
            cmb_supplier.Properties.DataSource = dt;
            dtpPRDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            cmb_product.Properties.DataSource = bllProductInfo.getAll_Active();
        }

        private void cmb_product_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
            }
        }
        private void AddtoGrid()
        {
            if (cmb_product.EditValue == null || cmb_product.EditValue == "")
            {
                XtraMessageBox.Show("Product selection required!");
                cmb_product.Focus();
                cmb_product.SelectAll();
                return;
            }
            DataTable dt = new DataTable();
            DataTable dt_main = new DataTable();
            dt_main = grd_purchase_return.DataSource as DataTable;
            dt = bllReportUtility.ReportData("[USP_populate_product_info_for_pr] '" + cmb_product.EditValue.ToString() + "'");
            if (dt.Rows.Count < 1)
            {
                XtraMessageBox.Show("Product inportmation not found. Please check the stock.");
                cmb_product.Focus();
                cmb_product.SelectAll();
            }
            else
            {
                if (grd_view_purchase_return.RowCount > 0)
                {
                    dt_main.Merge(dt);
                }
                else
                {
                    dt_main = dt;
                }
                grd_purchase_return.DataSource = dt_main;
                cmb_product.Focus();
                cmb_product.SelectAll();
            }
        }

        private void toolStrip_btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip_btn_save_Click(object sender, EventArgs e)
        {
            cmb_product.Focus();
            DevExpress.XtraGrid.Views.Grid.GridView view = grd_view_purchase_return as DevExpress.XtraGrid.Views.Grid.GridView;

            if (cmb_supplier.EditValue == null || cmb_supplier.EditValue == "")
            {
                XtraMessageBox.Show("Supplier selection required!");
                cmb_supplier.Focus();
                cmb_supplier.SelectAll();
                return;
            }
            if (grd_view_purchase_return.RowCount < 1)
            {
                XtraMessageBox.Show("No data found for purchase return!");
                grd_view_purchase_return.Focus();
                return;
            }

            //Return Parent
            DataTable dt = new DataTable();
            try
            {
                dt = bllPurchaseReturn.InsertPurchaseReturnParent(dtpPRDate.Value.ToString("dd/MM/yyyy"), cmb_supplier.EditValue.ToString(), bllUtility.Val(grd_view_purchase_return.Columns["TotalPrice"].SummaryText.ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtPRNumber.Text = dt.Rows[0]["PRNumber"].ToString();
                    Int32 PRID = Convert.ToInt32(dt.Rows[0]["PRID"].ToString());
                    //Return Child
                    for (int i = 0; i < grd_view_purchase_return.RowCount; i++)
                    {

                        bllPurchaseReturn.InsertPurchaseReturnChild(PRID
                                        , view.GetRowCellValue(i, "ProductID").ToString()
                                        , Convert.ToInt32(view.GetRowCellValue(i, "UnitId").ToString())
                                        , Convert.ToDecimal(view.GetRowCellValue(i, "PRQty").ToString())
                                        , Convert.ToDecimal(view.GetRowCellValue(i, "UnitPrice").ToString())
                                        , Convert.ToDecimal(view.GetRowCellValue(i, "TotalPrice").ToString()));

                    }
                }
                XtraMessageBox.Show("Successfully saved the record.", "Sales System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStrip_btn_save.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void toolStrip_btn_print_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_btn_new_Click(object sender, EventArgs e)
        {
            cmb_product.EditValue = null;
            cmb_supplier.EditValue = null;
            grd_purchase_return.DataSource = null;
            txtPRNumber.Text = "";
            dtpPRDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            toolStrip_btn_save.Enabled = true;
        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            if (cmb_product.EditValue == null || cmb_product.EditValue == "")
            {
                XtraMessageBox.Show("Product selection required!");
                cmb_product.Focus();
                cmb_product.SelectAll();
                return;
            }
            else
            {
                AddtoGrid();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtPRAmount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void mnu_delete_line_Click(object sender, EventArgs e)
        {
            DataTable dt = grd_purchase_return.DataSource as DataTable;
            DevExpress.XtraGrid.Views.Grid.GridView view = grd_view_purchase_return as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view.RowCount >= 1)
            {
                DataRow dr = view.GetDataRow(view.FocusedRowHandle);
                if (dr[0].ToString() != "")
                {
                    dt.Rows.Remove(dr);
                }
            }
        }

        private void cmb_product_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grd_purchase_return_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            DevExpress.XtraGrid.GridControl grid = sender as DevExpress.XtraGrid.GridControl;
            grd_view_purchase_return_KeyPress(grid.FocusedView, e);
        }

        private void grd_view_purchase_return_KeyPress(object sender, KeyPressEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view.FocusedColumn.VisibleIndex == 3 || view.FocusedColumn.VisibleIndex == 5 || view.FocusedColumn.VisibleIndex == 6)
            {
                string allow_keys = ".0123456789" + '\b';
                if (allow_keys.IndexOf(e.KeyChar) < 0)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void grd_view_purchase_return_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DevExpress.XtraGrid.Views.Base.ColumnView view = sender as DevExpress.XtraGrid.Views.Base.ColumnView;
            if (view.FocusedColumn.VisibleIndex == 3)
            {
                double stock_qty = bllUtility.Val(view.GetRowCellDisplayText(view.FocusedRowHandle, "Stock"));
                double pr_qty = bllUtility.Val(e.Value.ToString());
                if (pr_qty > stock_qty)
                {
                    e.Valid = false;
                    e.ErrorText = "You can not return more then stock qty !";
                    view.SetColumnError(view.Columns["PRQty"], e.ErrorText);
                    return;
                }
            }
        }

        private void grd_view_purchase_return_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = grd_view_purchase_return.GetDataRow(e.RowHandle);
            double qty = 0;
            double unit_price = 0;
            double total_price = 0;
            if (row["PRQty"] != DBNull.Value)
                qty = Convert.ToDouble(row["PRQty"]);
            if (row["UnitPrice"] != DBNull.Value)
                unit_price = Convert.ToDouble(row["UnitPrice"]);
            total_price = qty * unit_price;
            row["TotalPrice"] = total_price.ToString();
        }

        //private void grd_view_purchase_return_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    calculate_amount();
        //}
        //private void calculate_amount()
        //{
        //    Decimal total = 0;
        //    for (int i = 0; i < grd_view_purchase_return.RowCount; i++)
        //    {
        //        total = total+( Convert.ToDecimal(grd_view_purchase_return.GetRowCellValue(i, "PRQty").ToString())*
        //                        Convert.ToDecimal(grd_view_purchase_return.GetRowCellValue(i, "UnitPrice").ToString()));
        //    }
        //    txtPRAmount.Text = total.ToString();
        //}
    }
}
