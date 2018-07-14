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
using SalesPOS.DataAccessLayer;
using DevExpress.XtraGrid.Views.Grid;

namespace SalesPOS
{
    public partial class frmProduction : DevExpress.XtraEditors.XtraForm
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        PurchasePaymentInfo objPurchasePaymentInfo = new PurchasePaymentInfo();
        bllReportUtility iReportUtility = new bllReportUtility();

        public frmProduction()
        {
            InitializeComponent();
            this.ActiveControl = cmbProduct;
        }

        private void frmPurchaseInfo_Load(object sender, EventArgs e)
        {
            lbl_amount.Text = "";
            ApplyDefaultSetting();
            load_product_info();
            ActiveControl = cmbProduct;
            cmbProduct.Focus();
        }

        private void load_product_info()
        {
            DataTable dt = bllProductInfo.getAll();
            cmbProduct.Properties.DisplayMember = "ProductName";
            cmbProduct.Properties.ValueMember = "ProductID";
            cmbProduct.Properties.DataSource = dt;
        }

        private void ApplyDefaultSetting()
        {
            // Load Default Setup
            bllSecurityInfo.SoftDefaultSetting();
        }

        private void dgvPurchaseGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch { }
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

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            cmbProduct.EditValue = null;
            txtProductionNo.Text = "";
            txtProductionQty.Text = "";
            grdProduction.DataSource = null;
            btnSave.Enabled = true;
            lbl_amount.Text = "";
            ApplyDefaultSetting();
            cmbProduct.Focus();
        }
       
        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            if (cmbProduct.EditValue == null || cmbProduct.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Please Select a Material first");
                cmbProduct.Focus();
                return;
            }
            if (bllUtility.Val(txtProductionQty.Text) == 0)
            {
                XtraMessageBox.Show("Please Enter the Product Quantity");
                txtProductionQty.Focus();
                return;
            }

            DataTable dt_grd = grdProduction.DataSource as DataTable;
            DataTable dt= bllReportUtility.ReportData("populate_production '" + cmbProduct.EditValue.ToString() + "'," + txtProductionQty.Text + "");
            if (dt==null || dt.Rows.Count < 1)
            {
                XtraMessageBox.Show("No data found.");
                return;
            }

            if (dt_grd == null || dt_grd.Rows.Count < 1)
                grdProduction.DataSource = dt;
            else
            {
                DataRow[] dr = dt_grd.Select("ProductID='" + cmbProduct.EditValue.ToString() + "'", "");
                if (dr.Length > 0)
                {
                    XtraMessageBox.Show("This product already exists in the grid.");
                    return;
                }
                dt_grd.Merge(dt);
                grdProduction.DataSource = dt_grd;
            }
            cmbProduct.EditValue = null;
            txtProductionQty.Text="";
            cmbProduct.Focus();

            //AddDataToPurchaseGrid();
            //Calculate();
            //txtProductionQty.Text = "";
            ////txtUnitPrice.Text = "";
            //cmbProduct.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt_grd = grdProduction.DataSource as DataTable;
            
            //validation
            if (dt_grd == null || dt_grd.Rows.Count<1)
            {
                XtraMessageBox.Show("No data found for save");
                return;
            }
            //check material stock availability

            string production_date=dtpProductionDate.Value.ToString("dd/MM/yyyy");

            DataView dview = new DataView(dt_grd);
            DataTable dt_distinct = dview.ToTable(true, "ProductID", "ProductionQty", "ProductUnitID");
            

            ////SAVE START//////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //insert to production parent
            DataAccess obj = new DataAccess();
            obj.Transaction_Begin();
            DataTable dt=obj.IUD("insert_production_parent '" + production_date + "'," + bllUtility.LoggedInSystemInformation.LoggedUserId);
            if (obj.IsErrorRise())
            {
                XtraMessageBox.Show(obj.ErrorMassege(),"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string production_id = dt.Rows[0][0].ToString();
            
            //insert to production product
            for (int i = 0; i < dt_distinct.Rows.Count; i++)
            {
                obj.IUD("insert_production_product '" + production_id + "','" + dt_distinct.Rows[i]["ProductID"].ToString() + "'," + bllUtility.Val(dt_distinct.Rows[i]["ProductUnitID"].ToString()) + "," + bllUtility.Val(dt_distinct.Rows[i]["ProductionQty"].ToString()) + "," + bllUtility.LoggedInSystemInformation.LoggedUserId);
                if (obj.IsErrorRise())
                {
                    XtraMessageBox.Show(obj.ErrorMassege(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //insert to production material
            for (int i = 0; i < dt_grd.Rows.Count; i++)
            {
                obj.IUD("insert_production_material '" + production_id + "','" + dt_grd.Rows[i]["ProductID"].ToString() + "','" + dt_grd.Rows[i]["MaterialID"].ToString() + "'," + bllUtility.Val(dt_grd.Rows[i]["MaterialQty"].ToString()) + "," + bllUtility.LoggedInSystemInformation.LoggedUserId);
                if (obj.IsErrorRise())
                {
                    XtraMessageBox.Show(obj.ErrorMassege(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            obj.Transaction_Commit();


            ////SAVE END/////////////////////////////////////////////////////////////////////////////////////////////////////////
            txtProductionNo.Text = production_id;
            btnSave.Enabled = false;
            lbl_amount.Text=obj.GetDatabyQuery(@"SELECT CAST(ISNULL(SUM(Quantity * PurchasePrice), 0) AS DECIMAL(16,2)) AS TotalAmount
                                FROM dbo.ProductionMaterialLotWise_t
                                WHERE (ProductionID = '"+production_id+"')").Tables[0].Rows[0][0].ToString();
            XtraMessageBox.Show("Saved Successfully.");
        }

        private bool Valid()
        {
            bool isValid = true;            


            return isValid;
        }
        private void SaveDate()
        {
            ////string AccountNo = "";
            ////if (txtSupplierCode.Text == "")
            ////    AccountNo = "SUP00000000000";
            ////else
            ////    AccountNo = txtSupplierCode.Text;
            
            ////string PurchaseDate = dtpPurchaseDate.Value.ToString("dd/MM/yyyy");
            ////string MemoNo = txtMemoNo.Text.Trim();
            ////double TotalAmount = Convert.ToDouble(lblTotalItemAmount.Text.Trim());
            ////double TotalPaid = Convert.ToDouble(txtPaid.Text.Trim());
            ////string SupplierAccountNo = txtSupplierCode.Text.Trim();
            ////long CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
            ////string TransactionType = "Purchase";
            

            //////execute the master purchase information & get the purchase no
            ////DataTable dt = bllMaterialPurchase.InsertPurchaseMaster(PurchaseDate, MemoNo, TotalAmount, TotalPaid, SupplierAccountNo, CreatedBy,TransactionType);
            ////string purchaseID = dt.Rows[0][0].ToString();

            ////for (int i = 0; i < dgvPurchaseGrid.Rows.Count; i++)
            ////{
            ////    //execute purchase master details info...........
            ////    bool chk = bllMaterialPurchase.InsertPurchaseMasterDetails(purchaseID.Trim(), dgvPurchaseGrid.Rows[i].Cells["MaterialID"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["Quantity"].Value.ToString().Trim(), dgvPurchaseGrid.Rows[i].Cells["UnitPrice"].Value.ToString().Trim(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());
            ////}


            //////disable save button
            ////this.txtPurchaseNo.Text = purchaseID;

            ////this.btnSave.Enabled = false;
            ////this.btnAddToGrid.Enabled = false;
            ////this.cmbProduct.Enabled = false;
            ////this.dgvPurchaseGrid.Enabled = false;
            ////this.btnPrint.Enabled = true;


            /////********************************************************
            ////* Save Purchase Payment
            ////* *******************************************************/
            //////InitializePurchasePaymentInfo();
            //////bllMaterialPurchase.InsertPurchasePayment(objPurchasePaymentInfo);

            /////*Account transaction for sales*/
            ////bllProductSales.InsertAccountTransactionBySystem("Purchase", lblTotalItemAmount.Text, txtPurchaseNo.Text, "Material Purchase", bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);

            ////if (Convert.ToDouble(txtPaid.Text) > 0)
            ////    bllProductSales.InsertAccountTransactionBySystem("Cash Paid", txtPaid.Text, txtPurchaseNo.Text, "Material Purchase", bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), 0);


            //////display successful message
            ////XtraMessageBox.Show("Successfully Inserted the purchase information");

        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPaid_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                btnSave.Focus();
            }
        }

        private void cmbMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtProductionQty.Focus();
        }

        private void txtProductionQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddToGrid_Click(sender, e);
        }

        private void txtProductionQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gvProduction_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "ProductionQty")// || e.Column.FieldName == "BillQty" || e.Column.FieldName == "RemQty" || e.Column.FieldName == "Rack" || e.Column.FieldName == "Quantity")
            {
                string val1 = e.CellValue1.ToString();
                string val2 = e.CellValue2.ToString();

                string value3 = view.GetRowCellValue(e.RowHandle1, view.Columns["ProductID"]).ToString();
                string value4 = view.GetRowCellValue(e.RowHandle2, view.Columns["ProductID"]).ToString();

                e.Merge = (val1 == val2 && value3 == value4);
                e.Handled = true;
                return;
            }
            else if (e.Column.FieldName == "ProductUnit")// || e.Column.FieldName == "BillQty" || e.Column.FieldName == "RemQty" || e.Column.FieldName == "Rack" || e.Column.FieldName == "Quantity")
            {
                string val1 = e.CellValue1.ToString();
                string val2 = e.CellValue2.ToString();

                string value3 = view.GetRowCellValue(e.RowHandle1, view.Columns["ProductID"]).ToString();
                string value4 = view.GetRowCellValue(e.RowHandle2, view.Columns["ProductID"]).ToString();

                e.Merge = (val1 == val2 && value3 == value4);
                e.Handled = true;
                return;
            }
        }

        private void gvProduction_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataTable dt = grdProduction.DataSource as DataTable;
            if ((e.Column.VisibleIndex == 7))
            {
                double stock_qty = bllUtility.Val(dt.Rows[e.RowHandle]["MaterialStockQty"]);
                double req_qty = bllUtility.Val(e.CellValue);
                if (req_qty > stock_qty)
                    e.Appearance.BackColor = Color.OrangeRed;

            }
        }

        private void mnu_delete_Click(object sender, EventArgs e)
        {
            DataTable dt = grdProduction.DataSource as DataTable;
            GridView view = gvProduction;
            if (view.RowCount >= 1)
            {
                DataRow dr = view.GetDataRow(view.FocusedRowHandle);
                if (dr[0].ToString() != "")
                {
                    string ProductID = dr["ProductID"].ToString();
                    DeleteRows(dt, r => r.Field<string>("ProductID") == ProductID);
                }
            }
            
        }
        public static void DeleteRows(DataTable dt, Func<DataRow, bool> predicate)
        {
            foreach (var row in dt.Rows.Cast<DataRow>().Where(predicate).ToList())
            {
                dt.Rows.Remove(row);
                //row.Delete();
            }
        }
    }
}
