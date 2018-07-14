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
    public partial class frmAccountHolderType : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedAccountHolderTypeId = 0;
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;
        
        private void ClearFields()
        {
            try
            {
                _isNew = true;
                this.txtAccountHolderTypeName.Text = string.Empty;
                this.txtPrefix.Text = string.Empty;
                this.txtPrefix.ReadOnly = false;
                this.cmbActivity.SelectedIndex = 0;
                this.err_accountholdertype.Clear();
                if (this.dgvAccountTypeList.Rows.Count > 0)
                    this.dgvAccountTypeList.Rows[0].Selected = false;

                this.txtAccountHolderTypeName.Focus();
            }
            catch
            { }
        }
        
        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtAccountHolderTypeName.Text))
            {
                this.err_accountholdertype.SetError(txtAccountHolderTypeName, "Name is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtPrefix.Text))
            {
                this.err_accountholdertype.SetError(txtPrefix, "Prefix is mandatory");
                chk = false;
            }
            return chk;
        }
        private void LoadAccountHolderTypeInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllAccountHolderType.getById(selectedID);
            this.txtAccountHolderTypeName.Text = dt.Rows[0]["AccountHolderType"].ToString();
            this.txtPrefix.Text = dt.Rows[0]["AccountHolderTypePrefix"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());

        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllAccountHolderType.getAll();
            this.dgvAccountTypeList.AutoGenerateColumns = false;
            this.dgvAccountTypeList.DataSource = dt;

            //this.dgvUnitList.Rows[this._GridRowSelectedIndex].Selected = true;


        }
        private void LoadAcitivityCombo()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivity.DisplayMember = "Activity";
            this.cmbActivity.ValueMember = "ActivityID";
            //this.dgvUserList.AutoGenerateColumns = false;
            //this.dgvUserList.DataSource = dt;
            cmbActivity.DataSource = dt;
        }
        public frmAccountHolderType()
        {
            InitializeComponent();
        }

        private void frmAccountHolderType_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtAccountHolderTypeName;
            LoadAcitivityCombo();
            LoadGrid();
            if (this.dgvAccountTypeList.Rows.Count > 0)
                this.dgvAccountTypeList.Rows[0].Selected = false;
            this.dgvAccountTypeList.DefaultCellStyle.ForeColor = Color.Black;
            this.txtAccountHolderTypeName.Focus();
            bllUtility.ResetGridColor(dgvAccountTypeList);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (!this._isNew) //(this.btnAdd.Enabled)
                {
                    //this._GridRowSelectedIndex = this.dgvUnitList.SelectedRows[0].Index;
                    if (_SelctedAccountHolderTypeId > 0)
                    {
                        //update here
                        bool chk = true;

                        AccountHolderType objAccountHolderType = new AccountHolderType();
                        objAccountHolderType.AccountHolderTypeID= this._SelctedAccountHolderTypeId;
                        objAccountHolderType.AccountHolderTypeName = this.txtAccountHolderTypeName.Text.Trim();
                        objAccountHolderType.AccountHolderTypePrefix = this.txtPrefix.Text.ToUpper();
                        objAccountHolderType.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                        objAccountHolderType.UpdatedBy = 1;
                        objAccountHolderType.UpdatedDate = DateTime.Now;
                                                                        
                        DataTable dt1 = bllAccountHolderType.IsDuplicate_AccountHolder_Type(this._SelctedAccountHolderTypeId, this.txtAccountHolderTypeName.Text.ToString(), "Update");
                        if (dt1.Rows.Count > 0)
                        {
                            XtraMessageBox.Show("Duplicate Account Holder Type Found. Please change the Account Holder Type.");
                            this.txtAccountHolderTypeName.Focus();
                            this.txtAccountHolderTypeName.SelectAll();                            
                            //this._isNew = true;
                        }
                        else
                        {
                            chk = bllAccountHolderType.Update(objAccountHolderType);
                            if (chk)
                            {
                                LoadGrid();
                                //show success message here
                                XtraMessageBox.Show("Successfully Updated the record.");
                                ClearFields();
                                this._isNew = true;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No data found for update.");
                    }
                }
                else
                {
                    //this._GridRowSelectedIndex = this.dgvUnitList.Rows.Count;
                    bool chk = true;
                    //insert validation method

                    //insert here
                    AccountHolderType objAccountHolderType = new AccountHolderType();
                    objAccountHolderType.AccountHolderTypeName = this.txtAccountHolderTypeName.Text.Trim();
                    objAccountHolderType.AccountHolderTypePrefix = this.txtPrefix.Text.ToUpper();
                    objAccountHolderType.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objAccountHolderType.CreatedBy = 1;
                    objAccountHolderType.CreatedDate = DateTime.Now;

                    DataTable dt1 = bllAccountHolderType.IsDuplicate_AccountHolder_Type(0, this.txtAccountHolderTypeName.Text.ToString(), "Update");
                    if (dt1.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Account Holder Type Found. Please change the Account Holder Type.");
                        this.txtAccountHolderTypeName.Focus();
                        txtAccountHolderTypeName.SelectAll();
                        //this._isNew = true;
                    }
                    else
                    {
                        chk = bllAccountHolderType.Insert(objAccountHolderType);
                        if (chk)
                        {
                            LoadGrid();
                            ClearFields();
                            this._isNew = true;
                        }
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            this.txtAccountHolderTypeName.Focus();
            this._isNew = true;
        }

        private void dgvActivityTypeList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            {

            }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                this._isNew = false;
                try
                {
                    //bool chk = true;
                    long AccountHoldertypeId = 0;
                    AccountHoldertypeId = Convert.ToInt64(dr.Cells[0].Value);  //this._SelctedUserInfoId;

                    //Load the selected row data fro edit mode
                    this._SelctedAccountHolderTypeId = AccountHoldertypeId;
                    LoadAccountHolderTypeInfoByID(_SelctedAccountHolderTypeId);
                }
                catch 
                { 
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {

        }
       
    }
}
