using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SalesPOS.BLL;
using SalesPOS.BOL;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesPOS.DataAccessLayer;

namespace SalesPOS
{
    public partial class frmStockTransferInfo : DevExpress.XtraEditors.XtraForm
    {
        //Global Declarations
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        public frmStockTransferInfo()
        {
            InitializeComponent();           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();            
        }
        private void ClearAll()
        {
            this.txtProductID.Text = string.Empty;
            this.txtProductName.Text = string.Empty;
            cmb_from_store.EditValue = "1";
            cmb_to_store.EditValue = null;
            this.txtTransferQty.Text = "0";
            lblStockFromStore.Text = "";
            lblStockToStore.Text = "";
            btnTransfer.Enabled = true;
        }

        private void frmStockTransferInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtProductName;
            ClearAll();
            InitializeProductName();
            //this.dgvProductStock.DefaultCellStyle.ForeColor = Color.Black;

            load_area_list();
        }

        private void load_area_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.populate_area_list");
            cmb_from_store.Properties.DisplayMember = "AreaName";
            cmb_from_store.Properties.ValueMember = "AreaID";
            cmb_from_store.Properties.DataSource = dt;
            cmb_from_store.EditValue = "1";
            cmb_to_store.Properties.DisplayMember = "AreaName";
            cmb_to_store.Properties.ValueMember = "AreaID";
            cmb_to_store.Properties.DataSource = dt;
        }

        private int get_product_stock(string ProductID, string AreaID)
        {
            int StockQty = 0;
            DataTable dt = bllUtility.GetDataBySP("dbo.get_product_stock_store_wise '" + ProductID + "'," + AreaID);
            if (dt.Rows.Count > 0)
            {
                StockQty =Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
            }
            return StockQty;
        }


        private void InitializeProductName()
        {
            DataTable dt = new DataTable();
            dt = bllProductInfo.getAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesCollection.Add(dt.Rows[i][1].ToString());
            }

            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteCustomSource = namesCollection;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            frmProductSearch obj = new frmProductSearch();
            obj.ShowDialog();
            this.txtProductName.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductName; //test code rasel
            this.txtProductID.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductID;
            if (txtProductID.Text.Length > 4)
            {
                lblStockFromStore.Text = "0";
                if (txtProductID.Text == "") return;
                if (cmb_from_store.EditValue == "") return;
                lblStockFromStore.Text = get_product_stock(txtProductID.Text, cmb_from_store.EditValue.ToString()).ToString();
            }
            bllUtility.ReturnSearchedProduct.returnSearchedProductInfo = null;
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 80 || e.KeyChar == 112)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            //if (txtProductID.TextLength == 6)
            //{
            //    DataTable dt = new DataTable();
            //    dt = bllProductTransferInfo.GetProductMainStock(txtProductID.Text.Trim());

            //    //checking is there any minimum unit set for this product
            //    if (dt.Rows.Count > 0)
            //    {
            //        ClearAll();
            //        lblProductID.Text = dt.Rows[0]["ProductID"].ToString();                                       
            //        lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
            //        LoadGrid(dt);
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("No Stock found for this product. PLease Purchase first.");
            //        ClearAll();
            //    }
            //}
        }
        //private void LoadGrid(DataTable dt)
        //{
        //    dgvProductStock.AutoGenerateColumns = false;
        //    dgvProductStock.DataSource = dt;
        //    this.txtTransferQty.Focus();
        //    this.txtTransferQty.SelectAll();                    
        //}

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            if (cmb_from_store.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("You have not selected From store.");
                return;
            }

            if (cmb_to_store.EditValue.ToString()=="")
            {
                XtraMessageBox.Show("You have not selected To store.");
                return;
            }

            if (cmb_from_store.EditValue.ToString() == cmb_to_store.EditValue.ToString())
            {
                XtraMessageBox.Show("You have selected same store.");
                return;
            }
            
            if (txtTransferQty.Text == "0" || txtTransferQty.Text == "")
            {
                XtraMessageBox.Show("Please enter the Quantity for transfer.");
                txtTransferQty.Focus();
                return;
            }

            DataAccess obj = new DataAccess();
            obj.Transaction_Begin();
            DataTable dt = obj.IUD("[USP_ProductTransferToDisplay] '" + txtProductID.Text + "','" + cmb_from_store.EditValue.ToString() + "','" + cmb_to_store.EditValue.ToString() + "'," + Convert.ToInt64(txtTransferQty.Text) + "," + bllUtility.LoggedInSystemInformation.LoggedUserId);
            if (obj.IsErrorRise())
            {
                XtraMessageBox.Show(obj.ErrorMassege(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            obj.Transaction_Commit();
            XtraMessageBox.Show("Successfully Transferred.", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnTransfer.Enabled = false;




            //if (dgvProductStock.Rows.Count > 0)
            //{
            //    if (txtTransferQty.Text == "0" || txtTransferQty.Text == "")
            //    {
            //        XtraMessageBox.Show("Please enter the Quantity for transfer.");
            //        txtTransferQty.Focus();
            //    }
            //    else
            //    { 
            //        //Start transfer process...
            //        bool chk = false;
            //        chk = bllProductTransferInfo.InsertTransferProduct(lblProductID.Text.Trim(), txtTransferQty.Text.Trim());
            //        if (chk)
            //        {
            //            //Transfer process successfull completed.
            //            XtraMessageBox.Show("Successfully transferred the product to display.");
            //            txtTransferQty.Text = "0";                        
            //            txtTransferQty.Focus();

            //            //Reload grid
            //            DataTable dt = new DataTable();
            //            dt = bllProductTransferInfo.GetProductMainStock(lblProductID.Text.Trim());
            //            LoadGrid(dt);
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("Operation failed.");
            //        }
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("There are no record on the table.");
            //    this.txtProductName.Focus();
            //}
        }

        private void txtTransferQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTransferQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt16(e.KeyCode) == 13)
            {
                btnTransfer.Focus();
            }
        }

        private void cmb_from_store_EditValueChanged(object sender, EventArgs e)
        {
            lblStockFromStore.Text = "0";
            if (txtProductID.Text == "") return;
            if (cmb_from_store.EditValue == "") return;
            lblStockFromStore.Text=get_product_stock(txtProductID.Text,cmb_from_store.EditValue.ToString()).ToString();
        }

        private void cmb_from_store_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblStockFromStore.Text = "0";
                if (txtProductID.Text == "") return;
                if (cmb_from_store.EditValue == "") return;
                lblStockFromStore.Text = get_product_stock(txtProductID.Text, cmb_from_store.EditValue.ToString()).ToString();
            }
        }

        private void cmb_to_store_EditValueChanged(object sender, EventArgs e)
        {
            lblStockToStore.Text = "0";
            if (txtProductID.Text == "") return;
            if (cmb_to_store.EditValue == "") return;
            lblStockToStore.Text = get_product_stock(txtProductID.Text, cmb_to_store.EditValue.ToString()).ToString();
        }

        private void cmb_to_store_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblStockToStore.Text = "0";
                if (txtProductID.Text == "") return;
                if (cmb_to_store.EditValue == "") return;
                lblStockToStore.Text = get_product_stock(txtProductID.Text, cmb_to_store.EditValue.ToString()).ToString();
            }
        }
    }
}
