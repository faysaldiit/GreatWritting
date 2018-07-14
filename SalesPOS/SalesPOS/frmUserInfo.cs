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
    public partial class frmUserInfo : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedUserInfoId = 0;
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;
        private bool _isAdmin = false;
        public frmUserInfo()
        {
            InitializeComponent();
        }



        #region private methods
        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                this.err_userInfo.SetError(txtName, "User name is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                this.err_userInfo.SetError(txtUserName, "User ID is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.err_userInfo.SetError(txtPassword, "Password is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtPasswordRetype.Text))
            {
                this.err_userInfo.SetError(txtPasswordRetype, "Re-Type Password is mandatory");
                chk = false;
            }
            if (this.txtPasswordRetype.Text != this.txtPassword.Text)
            {
                this.err_userInfo.SetError(txtPasswordRetype, "New Password & Re-Type Password are ");
                chk = false;
            }
            return chk;
        }
        private void LoadGrid()
        {
            if (bllUtility.LoggedInSystemInformation.IsAdmin == true)
            {
                DataTable dt = new DataTable();
                dt = bllUserInfo.getAll();
                this.dgvUserList.AutoGenerateColumns = false;
                this.dgvUserList.DataSource = dt;
            }
            //this.dgvUserList.Rows[0].Selected = true;
            
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
        private void LoaduserInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllUserInfo.getById(selectedID);
            this.txtUserName.Text = dt.Rows[0]["SoftUser"].ToString();
            this.txtPasswordHints.Text = dt.Rows[0]["PasswordsHints"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
            txtName.Text = dt.Rows[0]["UserName"].ToString();
            chkisadmin.Checked=Convert.ToBoolean(dt.Rows[0]["IsAdmin"].ToString());

        }
        private void ClearFields()
        {
            _isNew = true;
            this.txtPassword.Text = string.Empty;
            this.txtPasswordRetype.Text = string.Empty;
            this.txtPasswordHints.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            txtName.Text = string.Empty;
            chkisadmin.Checked = false;
            _isAdmin = false;
            this.cmbActivity.SelectedIndex = 0;
            this.err_userInfo.Clear();
            if (this.dgvUserList.Rows.Count > 0)
                this.dgvUserList.Rows[0].Selected = false;
            this.txtName.Focus();
        }
        #endregion
        #region events
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtName;
            //this.dgvUserList.AlternatingRowsDefaultCellStyle.BackColor = Color.
            LoadAcitivityCombo();
            LoadGrid();
            this.dgvUserList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvUserList);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkisadmin.Checked)
            {
                _isAdmin = true;
            }
            else
            {
                _isAdmin = false;
            }
            if (isValid())
            {
                if (!this._isNew)
                {                    
                    if (_SelctedUserInfoId > 0)
                    {
                        //update here
                        bool chk = true;                        
                        UserInfo objUserInfo = new UserInfo();
                        objUserInfo.UserInfoId = this._SelctedUserInfoId;
                        objUserInfo.SoftUser = this.txtUserName.Text.Trim();
                        objUserInfo.UserName = txtName.Text.Trim();
                        objUserInfo.SoftPassword = bllUtility.EncryptPassword(this.txtPassword.Text.Trim());
                        objUserInfo.PasswordsHints = this.txtPasswordHints.Text.Trim();
                        objUserInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                        objUserInfo.IsAdmin = _isAdmin;
                        objUserInfo.UpdatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
                        objUserInfo.UpdatedDate = DateTime.Now;
                        
                        chk = bllUserInfo.Update(objUserInfo);
                        if (chk)
                        {
                            LoadGrid();
                            XtraMessageBox.Show("Successfully Updated the record.");
                            ClearFields();
                            this._isNew = true;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No data found for update.");
                    }
                }
                else
                {
                    //if(this.txt)
                    bool chk = true;
                    //insert here
                    UserInfo objUserInfo = new UserInfo();
                    objUserInfo.SoftUser = this.txtUserName.Text.Trim();
                    objUserInfo.UserName = txtName.Text.Trim();
                    objUserInfo.SoftPassword = bllUtility.EncryptPassword(this.txtPassword.Text.Trim());
                    objUserInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objUserInfo.PasswordsHints = this.txtPasswordHints.Text.Trim();
                    objUserInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
                    objUserInfo.CreatedDate = DateTime.Now;
                    objUserInfo.IsAdmin = _isAdmin;

                    chk = bllUserInfo.Insert(objUserInfo);
                    if (chk)
                    {
                        LoadGrid();
                        XtraMessageBox.Show("Successfully Create User.");
                        ClearFields();
                        this._isNew = true;
                    }
                    
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();            
        }
        #endregion

        private void dgvUserList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //Load the selected row data fro edit mode
                DataGridView dgv = (DataGridView)sender;
                long selectedID = Convert.ToInt64(dgv.SelectedCells[0].Value);
                this._SelctedUserInfoId = selectedID;
                LoaduserInfoByID(selectedID);
            }
            catch { }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this._isNew = true;
            bool chk = true;
            long UserInfoId = 0;
            
            if (this.dgvUserList.SelectedRows.Count > 0)
            {
                UserInfoId = Convert.ToInt64(this.dgvUserList.SelectedRows[0].Cells[0].Value);//(dr.Cells[0].Value);  //
                if (XtraMessageBox.Show("Do you really want to delete the data ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chk = bllUserInfo.Delete(UserInfoId);
                    if (chk)
                    {
                        LoadGrid();
                        ClearFields();
                        if (this.dgvUserList.Rows.Count > 0)
                            this.dgvUserList.Rows[0].Selected = false;                        
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                XtraMessageBox.Show("Select a row first.");
            }
        }

        private void dgvUserList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    DataGridView dgv = (DataGridView)sender;
                    long selectedID = Convert.ToInt64(dgv.SelectedCells[0].Value);
                    this._SelctedUserInfoId = selectedID;
                    LoaduserInfoByID(selectedID);
                }
                catch { }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this._isNew = true;
            ClearFields();
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkisadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkisadmin.Checked)
            {
                _isAdmin = true;
            }
            else
            {
                _isAdmin = false;
            }
        }

        
    }
}
