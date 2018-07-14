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
    public partial class frmAccountHolderInfo : DevExpress.XtraEditors.XtraForm
    {

        private long _SelctedAccHolderInfoId = 0;
        private bool _isNew = true;
        private DataTable dtAccountHolderType = new DataTable();


        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllAccountHolderInfo.getAll();
            this.dgvAccountHolderList.AutoGenerateColumns = false;
            this.dgvAccountHolderList.DataSource = dt;
            gridSearch1.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();
            if (this.dgvAccountHolderList.Rows.Count > 0)
                this.dgvAccountHolderList.Rows[0].Selected = false;
        }
        private void LoadSearchGrid()
        {
            string sql = "";
            sql = "USP_Search_AccountHolder '" + txtAccountNoSearch.Text.Trim() + "','" + txtAccountNameSearch.Text.Trim() + "','" + this.cmbAccountTypeSearch.SelectedValue + "','" + this.cmbActivitySearch.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData(sql);
            this.dgvAccountHolderList.AutoGenerateColumns = false;
            this.dgvAccountHolderList.DataSource = dt;
            gridSearch1.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();

            if (this.dgvAccountHolderList.Rows.Count > 0)
                this.dgvAccountHolderList.Rows[0].Selected = false;
        }
        public void LoadAccountHolderTypeCombo()
        {
            //DataTable dt = new DataTable();
            dtAccountHolderType = null;
            dtAccountHolderType = bllAccountHolderType.getAll();
            //this.cmbType.DisplayMember = "AccountHolderType";
            //this.cmbType.ValueMember = "AccountHolderTypeID";
            //cmbType.DataSource = dtAccountHolderType;

            cmb_type.Properties.DataSource = dtAccountHolderType;
            this.cmb_type.Properties.DisplayMember = "AccountHolderType";
            this.cmb_type.Properties.ValueMember = "AccountHolderTypeID";

        }

        private void ClearFields()
        {
            try
            {
                _isNew = true;
                this.txtAccountNameSearch.Text = string.Empty;
                this.txtContactNum.Text = string.Empty;
                this.txtAccountHolderName.Text = string.Empty;
                this.txtAccountNumber.Text = string.Empty;
                this.txtAccountNoSearch.Text = string.Empty;
                this.cmbActivity.SelectedIndex = 0;
                this.cmbActivitySearch.SelectedIndex = 0;
                this.txtAddress.Text = string.Empty;
                this.cmb_type.EditValue  = null;
                this.cmbAccountTypeSearch.SelectedIndex = 0;
                cmb_rsm.EditValue = null;
                cmb_zone.EditValue = null;
                this.err_accountholderinfo.Clear();
                if (this.dgvAccountHolderList.Rows.Count > 0)
                    this.dgvAccountHolderList.Rows[0].Selected = false;
            }
            catch
            { }
        }

        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtAccountHolderName.Text))
            {
                this.err_accountholderinfo.SetError(txtAccountHolderName, "Name is mandatory");
                chk = false;
            }

            return chk;
        }

        private void LoadAccountHolderInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllAccountHolderInfo.getById(selectedID);
            this.txtAccountHolderName.Text = dt.Rows[0]["AccHolderName"].ToString();

            this.txtAddress.Text = dt.Rows[0]["Address"].ToString();
            this.txtContactNum.Text = dt.Rows[0]["ContactNo"].ToString();
            this.cmb_type.EditValue= dt.Rows[0]["AccountHolderTypeID"].ToString();
            this.cmb_zone.EditValue = dt.Rows[0]["ZoneID"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
            this.txtAccountNumber.Text = dt.Rows[0]["AccountNo"].ToString();

            if (dt.Rows[0]["RSMID"].ToString() == "")
                cmb_rsm.EditValue = null;
            else
                cmb_rsm.EditValue = dt.Rows[0]["RSMID"].ToString();

        }

        public frmAccountHolderInfo()
        {
            InitializeComponent();
        }

        private void frmAccountHolderInfo_Load(object sender, EventArgs e)
        {
            bllUtility.ResetGridColor(dgvAccountHolderList);
            this.ActiveControl = txtAccountNoSearch;
            bllUtility.LoadAcitivityCombo(this.cmbActivity);
            LoadAccountHolderTypeCombo();
            LoadGrid();
            LoadAccountType();
            bllUtility.LoadAcitivityCombo(this.cmbActivitySearch);

            this.dgvAccountHolderList.DefaultCellStyle.ForeColor = Color.Black;


            load_zone_list();
            load_rsm_list();

            txtAccountNoSearch.Focus();
        }

        private void load_zone_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[PopulateZoneList]");
            cmb_zone.Properties.DisplayMember = "ZoneName";
            cmb_zone.Properties.ValueMember = "ZoneID";
            cmb_zone.Properties.DataSource = dt;
        }

        private void load_rsm_list()
        {
            DataTable dt = bllUtility.GetDataBySP("search_account_holder_by_type_n_zone '','10'");
            cmb_rsm.Properties.DisplayMember = "AccHolderName";
            cmb_rsm.Properties.ValueMember = "AccountNo";
            cmb_rsm.Properties.DataSource = dt;
        }

        private void LoadAccountType()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllAccountHolderType.getAll();
                DataRow dr = dt.NewRow();
                dr["AccountHolderTypeID"] = "0";
                dr["AccountHolderType"] = "All";
                dt.Rows.InsertAt(dr, 0);
                cmbAccountTypeSearch.DisplayMember = "AccountHolderType";
                cmbAccountTypeSearch.ValueMember = "AccountHolderTypeID";
                cmbAccountTypeSearch.DataSource = dt;
            }
            catch
            { }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.err_accountholderinfo.Clear();
            if (this.cmb_type.EditValue == null)
            {
                XtraMessageBox.Show("Account holder type selection required!");
                cmb_type.Focus();
                return;
            }
            if (this.cmb_zone.EditValue == null)
            {
                XtraMessageBox.Show("Zone selection required!");
                cmb_zone.Focus();
                return;
            }
            if (isValid())
            {
                string rsmid = "";
                if (cmb_rsm.EditValue == null || cmb_rsm.EditValue.ToString() == "") rsmid = "";
                else rsmid = cmb_rsm.EditValue.ToString();

                if (!this._isNew)
                {
                    if (_SelctedAccHolderInfoId > 0)
                    {
                        //update here
                        bool chk = true;

                        AccountHolderInfo objAccountHolderInfo = new AccountHolderInfo();
                        objAccountHolderInfo.AccHolderInfoId = this._SelctedAccHolderInfoId;
                        objAccountHolderInfo.AccHolderName = this.txtAccountHolderName.Text.Trim();
                        objAccountHolderInfo.ContactNo = this.txtContactNum.Text.Trim();
                        objAccountHolderInfo.Address = this.txtAddress.Text;
                        objAccountHolderInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                        objAccountHolderInfo.ZoneID = Convert.ToInt64(this.cmb_zone.EditValue.ToString());
                        objAccountHolderInfo.UpdatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
                        objAccountHolderInfo.UpdatedDate = DateTime.Now;
                        objAccountHolderInfo.RSMID = rsmid;
                        chk = bllAccountHolderInfo.Update(objAccountHolderInfo);
                        if (chk)
                        {
                            LoadGrid();
                            //show success message here                            
                            //XtraMessageBox.Show("Successfully Updated the record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XtraMessageBox.Show("Successfully Updated the record");
                            ClearFields();
                            this._isNew = true;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No data found for update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //this._GridRowSelectedIndex = this.dgvUnitList.Rows.Count;
                    bool chk = true;
                    //insert validation method

                    //insert here
                    AccountHolderInfo objAccountHolderInfo = new AccountHolderInfo();
                    //objAccountHolderInfo.AccHolderInfoId = this._SelctedAccHolderInfoId;
                    objAccountHolderInfo.AccHolderName = this.txtAccountHolderName.Text.Trim();
                    objAccountHolderInfo.AccountHolderTypeID = Convert.ToInt64(this.cmb_type.EditValue.ToString());
                    objAccountHolderInfo.AccountNo = this.txtAccountNumber.Text;
                    objAccountHolderInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objAccountHolderInfo.ZoneID = Convert.ToInt64(this.cmb_zone.EditValue.ToString());
                    objAccountHolderInfo.Address = this.txtAddress.Text;
                    objAccountHolderInfo.ContactNo = this.txtContactNum.Text;
                    objAccountHolderInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
                    objAccountHolderInfo.CreatedDate = DateTime.Now;
                    objAccountHolderInfo.RSMID = rsmid;


                    chk = bllAccountHolderInfo.Insert(objAccountHolderInfo);
                    if (chk)
                    {
                        LoadGrid();
                        ClearFields();
                        this._isNew = true;
                    }
                }
                this._SelctedAccHolderInfoId = 0;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetAccountNumber();                    

        }
        private void SetAccountNumber()
        {
            //string s = "AccountHolderTypeID = " + this.cmbType.SelectedValue.ToString();

            //DataRow drAccountHolderType = dtAccountHolderType.NewRow();

            //drAccountHolderType = dtAccountHolderType.Select(s).FirstOrDefault();
            //maxAcctTypeValue = Convert.ToInt64(drAccountHolderType[8]) + 1;
            //string AccountNum = drAccountHolderType[2] + (Convert.ToInt64(drAccountHolderType[8]) + 1).ToString().PadLeft(7, '0');

            //this.txtAccountNumber.Text = AccountNum;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this._isNew = true;
            this._SelctedAccHolderInfoId = 0;
            ClearFields();
            this.txtAccountHolderName.Focus();
            //SetAccountNumber();  

        }

        private void dgvAccountHolderList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ////if (Convert.ToInt32(e.RowIndex) == -1)
            ////{

            ////}
            ////else
            ////{
            ////    DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];

            ////    this._isNew = false;
            ////    try
            ////    {
            ////        //bool chk = true;
            ////        long AccHolderInfoId = 0;
            ////        AccHolderInfoId = Convert.ToInt64(dr.Cells[0].Value);

            ////        //Load the selected row data fro edit mode

            ////        this._SelctedAccHolderInfoId = AccHolderInfoId;
            ////        LoadAccountHolderInfoByID(_SelctedAccHolderInfoId);
            ////    }
            ////    catch { }
            ////}
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadSearchGrid();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvAccountHolderList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    long AccHolderInfoId = 0;
                    AccHolderInfoId = Convert.ToInt64(dr.Cells[0].Value);

                    //Load the selected row data fro edit mode

                    this._SelctedAccHolderInfoId = AccHolderInfoId;
                    LoadAccountHolderInfoByID(_SelctedAccHolderInfoId);
                }
                catch { }
            }
        }

        private void txtAccountNoSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender,e);
        }

        private void txtAccountNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmbAccountTypeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmbActivitySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

    }
}
