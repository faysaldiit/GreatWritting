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
    public partial class frmCustomerSearch : DevExpress.XtraEditors.XtraForm
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection codesCollection = new AutoCompleteStringCollection();        
        AutoCompleteStringCollection contactNoCollection = new AutoCompleteStringCollection();
        DataTable dt = new DataTable();
        Int64 TypeCustOrSupID = 0;
        public frmCustomerSearch()
        {
            InitializeComponent();
        }
        public frmCustomerSearch(Int64 TypeCustSup)
        {
            InitializeComponent();
            this.TypeCustOrSupID = TypeCustSup;
        }

        private void setAutoCompletelist()
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesCollection.Add(dt.Rows[i][2].ToString());
                codesCollection.Add(dt.Rows[i][1].ToString());
                contactNoCollection.Add(dt.Rows[i]["ContactNo"].ToString());
            }

            txtCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerName.AutoCompleteCustomSource = namesCollection;

            txtCustomerCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCustomerCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerCode.AutoCompleteCustomSource = codesCollection;


        }
        private void FilterSearchGrid()
        {
            try
            {
                DataTable dtFiltered = dt.Copy();// Clone();
                DataView dv = new DataView();
                dv = dtFiltered.DefaultView;
                string AccountHolderType = "";
                if (TypeCustOrSupID == 2)
                {
                    //customer
                    if (opt_type.SelectedIndex == 0)
                        AccountHolderType = "Customer";
                    else if (opt_type.SelectedIndex == 1)
                        AccountHolderType = "Distributor";
                    else if (opt_type.SelectedIndex == 2)
                        AccountHolderType = "Retailer";
                    else if (opt_type.SelectedIndex == 3)
                        AccountHolderType = "Wholesaler";
                }
                string s = " AccHolderInfoId is not null";
                s = s + " AND ActivityID = '" + this.cmbActivity.SelectedValue.ToString() + "'";
                if (!string.IsNullOrEmpty(this.txtCustomerCode.Text))
                {
                    s = s + " AND AccountNo Like '%" + this.txtCustomerCode.Text + "%'";
                }
                if (!string.IsNullOrEmpty(this.txtCustomerName.Text))
                {
                    s = s + " AND AccHolderName Like '%" + this.txtCustomerName.Text + "%'";
                }
                if (!string.IsNullOrEmpty(this.txtContactNo.Text))
                {
                    s = s + " AND ContactNo Like '%" + this.txtContactNo.Text + "%'";
                }
                if (!string.IsNullOrEmpty(this.txtAddress.Text))
                {
                    s = s + " AND Address Like '%" + this.txtAddress.Text + "%'";
                }
                if (!string.IsNullOrEmpty(AccountHolderType))
                {
                    s = s + " AND AccountHolderType Like '%" + AccountHolderType + "%'";
                }
                dv.RowFilter = s;


                this.dgvCustomerInfoList.DataSource = null;
                this.dgvCustomerInfoList.DataSource = dv;
            }
            catch { }
        }

        private void LoadAcitivityCombo()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivity.DisplayMember = "Activity";
            this.cmbActivity.ValueMember = "ActivityID";
            cmbActivity.DataSource = dt;
        }
       
        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            LoadAcitivityCombo();
            //if (this.TypeCustOrSup == (Int64)bllUtility.GlobalEnum.AccountHolderType.Supplier)
            //{
            //    this.grpCustSupList.Text = "Supplier List";
            //}
            //else if (this.TypeCustOrSup == (Int64)bllUtility.GlobalEnum.AccountHolderType.Customer)
            //{
            //    this.grpCustSupList.Text = "Customer List";
            //}

            //dt = bllAccountHolderInfo.getAllCustomerOrSupplier(this.TypeCustOrSup); // bllAccountHolderInfo.getAllCustomer();
            
            dt = bllUtility.GetDataBySP("dbo.[Get_AccountInfo_By_AccountTypeID]" + TypeCustOrSupID);
            
            setAutoCompletelist();
            this.dgvCustomerInfoList.AutoGenerateColumns = false;
            this.dgvCustomerInfoList.MultiSelect = false;
            this.dgvCustomerInfoList.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.dgvCustomerInfoList.Rows[0].Selected = false;
            }
            bllUtility.ResetGridColor(dgvCustomerInfoList);

            if (TypeCustOrSupID == 2)
                opt_type.Visible = true;
            else
                opt_type.Visible = false;
            FilterSearchGrid();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void dgvCustomerInfoList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            AccountHolderInfo objProductInfo = new AccountHolderInfo();
            objProductInfo.AccHolderInfoId = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            objProductInfo.AccountNo = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            objProductInfo.AccHolderName = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();

            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = objProductInfo;

            this.Close();
        }

        private void frmCustomerSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo == null)
            {

                AccountHolderInfo objAccountHolderInfo = new AccountHolderInfo();
                objAccountHolderInfo.AccHolderInfoId = 0;
                objAccountHolderInfo.AccountNo = "";
                objAccountHolderInfo.AccHolderName = "";

                bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = objAccountHolderInfo;
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {

        }

        
        private void cmbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

        private void opt_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSearchGrid();
        }

       

        


    }
}
