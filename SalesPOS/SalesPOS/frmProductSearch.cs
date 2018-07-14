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
    public partial class frmProductSearch : DevExpress.XtraEditors.XtraForm
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection codesCollection = new AutoCompleteStringCollection();
        DataTable dt = new DataTable();

        public frmProductSearch()
        {
            InitializeComponent();
        }
        private void setAutoCompletelist()
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesCollection.Add(dt.Rows[i][1].ToString());
                codesCollection.Add(dt.Rows[i][0].ToString());
            }

            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteCustomSource = namesCollection;

            txtProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductCode.AutoCompleteCustomSource = codesCollection;


        }
        private void FilterSearchGrid()
        {
            try
            {
                DataTable dtFiltered = dt.Copy();// Clone();
                DataView dv = new DataView();
                dv = dtFiltered.DefaultView;

                string s = " SerialNo is not null";
                if (!string.IsNullOrEmpty(this.txtProductCode.Text))
                {
                    s = s + " AND ProductID Like '%" + this.txtProductCode.Text + "%'";
                }
                if (!string.IsNullOrEmpty(this.txtProductName.Text))
                {
                    s = s + " AND ProductName Like '%" + this.txtProductName.Text + "%'";
                }
                dv.RowFilter = s;
               

                this.dgvProductInfoList.DataSource = null;
                this.dgvProductInfoList.DataSource = dv;
            }
            catch { }
        }
        private void frmProductSearch_Load(object sender, EventArgs e)
        {
            dt = bllProductInfo.getAll();
            setAutoCompletelist();
            this.dgvProductInfoList.AutoGenerateColumns = false;
            this.dgvProductInfoList.MultiSelect = false;
            this.dgvProductInfoList.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.dgvProductInfoList.Rows[0].Selected = false;
            }
            this.dgvProductInfoList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvProductInfoList);
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void dgvProductInfoList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            {

            }
            else
            {
                DataGridView dgv = (DataGridView)sender;

                ProductInfo objProductInfo = new ProductInfo();
                objProductInfo.SerialNo = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                objProductInfo.ProductID = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                objProductInfo.ProductName = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();

                bllUtility.ReturnSearchedProduct.returnSearchedProductInfo = objProductInfo;

                this.Close();
            }
            
        }

        private void dgvProductInfoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProductSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bllUtility.ReturnSearchedProduct.returnSearchedProductInfo == null)
            {

                ProductInfo objProductInfo = new ProductInfo();
                objProductInfo.SerialNo = "0";
                objProductInfo.ProductID = "";
                objProductInfo.ProductName = "";

                bllUtility.ReturnSearchedProduct.returnSearchedProductInfo = objProductInfo;
            }
        }

        
    }
}
