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
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmBranchInfo : DevExpress.XtraEditors.XtraForm
    {

        private long _SelctedBrancgInfoId = 0;
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllBranchInfo.getAll();
            this.dgvBranchList.AutoGenerateColumns = false;
            this.dgvBranchList.DataSource = dt;

            //this.dgvUnitList.Rows[this._GridRowSelectedIndex].Selected = true;


        }
        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtBranchCode.Text))
            {
                this.err_branchInfo.SetError(txtBranchCode, "Branch code is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtBranchName.Text))
            {
                this.err_branchInfo.SetError(txtBranchName, "Branch name is mandatory");
                chk = false;
            }
            if (this.dtpActivationDate.Value.Date > this.dtpExpiryDate.Value.Date)
            {
                this.err_branchInfo.SetError(dtpActivationDate, "Expiry date must be greater or equals to activation date.");
                this.err_branchInfo.SetError(dtpExpiryDate, "Expiry date must be greater or equals to activation date.");
                chk = false;
            }
            return chk;
        }
        private void ClearFields()
        {
            try
            {
                this.txtAddress.Text = string.Empty;
                this.txtBranchName.Text = string.Empty;
                this.txtContactNumber.Text = string.Empty;
                this.txtEmail.Text = string.Empty;
                this.txtFax.Text = string.Empty;
                this.txtVATRegNum.Text = string.Empty;
                this.txtBranchCode.Text = string.Empty;
                this.txtWebURL.Text = string.Empty;
                this.dtpActivationDate.Value = DateTime.Today;
                this.dtpExpiryDate.Value = DateTime.Today;
                this.cmbActivity.SelectedIndex = 0;

                this.err_branchInfo.Clear();
                if (this.dgvBranchList.Rows.Count > 0)
                    this.dgvBranchList.Rows[0].Selected = false;

            }
            catch
            { }
        }
        private void LoadBranchInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllBranchInfo.getById(selectedID);
            this.txtAddress.Text = dt.Rows[0]["Address"].ToString();
            this.txtBranchCode.Text = dt.Rows[0]["BranchCode"].ToString();
            this.txtBranchName.Text = dt.Rows[0]["BranchName"].ToString();
            this.txtContactNumber.Text = dt.Rows[0]["ContactNumber"].ToString();
            this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
            this.txtFax.Text = dt.Rows[0]["FAX"].ToString();
            this.txtVATRegNum.Text = dt.Rows[0]["VatRegistrationNo"].ToString();
            this.txtWebURL.Text = dt.Rows[0]["WebURL"].ToString();
            this.cmbActivity.SelectedValue = dt.Rows[0]["ActivityID"].ToString();
            this.dtpActivationDate.Value = Convert.ToDateTime(dt.Rows[0]["ActivationDate"].ToString());
            this.dtpExpiryDate.Value = Convert.ToDateTime(dt.Rows[0]["ExpireDate"].ToString());

        }
        public frmBranchInfo()
        {
            InitializeComponent();
        }
        
        private void frmBranchInfo_Load(object sender, EventArgs e)
        {
            bllUtility.LoadAcitivityCombo(this.cmbActivity);
            LoadGrid();
            if (this.dgvBranchList.Rows.Count > 0)
                this.dgvBranchList.Rows[0].Selected = false;
            this.dgvBranchList.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.err_branchInfo.Clear();
            if (isValid())
            {
                if (!this._isNew) //(this.btnAdd.Enabled)
                {
                    //this._GridRowSelectedIndex = this.dgvUnitList.SelectedRows[0].Index;
                    if (_SelctedBrancgInfoId > 0)
                    {
                        //update here
                        bool chk = true;

                        BranchInfo objBranchInfo = new BranchInfo();
                        objBranchInfo.BranchID = this._SelctedBrancgInfoId;
                        objBranchInfo.ActivationDate = this.dtpActivationDate.Value;
                        objBranchInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                        objBranchInfo.Address = this.txtAddress.Text;
                        objBranchInfo.BranchCode = this.txtBranchCode.Text;
                        objBranchInfo.BranchName = this.txtBranchName.Text;
                        objBranchInfo.CompanyID = 1; //hard coded
                        objBranchInfo.ContactNumber = this.txtContactNumber.Text;
                        objBranchInfo.Email = this.txtEmail.Text;
                        objBranchInfo.ExpireDate = this.dtpExpiryDate.Value;
                        objBranchInfo.FAX = this.txtFax.Text;
                        objBranchInfo.VatRegistrationNo = this.txtVATRegNum.Text;
                        objBranchInfo.WebURL = this.txtWebURL.Text;
                        objBranchInfo.UpdatedBy = 1;
                        objBranchInfo.UpdatedDate = DateTime.Now;

                        chk = bllBranchInfo.Update(objBranchInfo);
                        if (chk)
                        {
                            LoadGrid();
                            //show success message here
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
                    //this._GridRowSelectedIndex = this.dgvUnitList.Rows.Count;
                    bool chk = true;
                    //insert validation method

                    //insert here
                    BranchInfo objBranchInfo = new BranchInfo();
                    objBranchInfo.BranchID = this._SelctedBrancgInfoId;
                    objBranchInfo.ActivationDate = this.dtpActivationDate.Value;
                    objBranchInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objBranchInfo.Address = this.txtAddress.Text;
                    objBranchInfo.BranchCode = this.txtBranchCode.Text;
                    objBranchInfo.BranchName = this.txtBranchName.Text;
                    objBranchInfo.CompanyID = 1; //hard coded
                    objBranchInfo.ContactNumber = this.txtContactNumber.Text;
                    objBranchInfo.ExpireDate = this.dtpExpiryDate.Value;
                    objBranchInfo.Email = this.txtEmail.Text;
                    objBranchInfo.FAX = this.txtFax.Text;
                    objBranchInfo.VatRegistrationNo = this.txtVATRegNum.Text;
                    objBranchInfo.WebURL = this.txtWebURL.Text;
                    objBranchInfo.CreatedBy = 1;
                    objBranchInfo.CreatedDate = DateTime.Now;



                    chk = bllBranchInfo.Insert(objBranchInfo);
                    if (chk)
                    {
                        LoadGrid();
                        //show success message here

                        ClearFields();
                        this._isNew = true;
                    }

                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvBranchList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this._isNew = false;
            DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
            try
            {
                //bool chk = true;
                long TerminalId = 0;
                TerminalId = Convert.ToInt64(dr.Cells[0].Value);  //this._SelctedUserInfoId;



                //Load the selected row data fro edit mode

                this._SelctedBrancgInfoId = TerminalId;
                LoadBranchInfoByID(_SelctedBrancgInfoId);
            }
            catch { }

            //DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
            //if (e.ColumnIndex == 6) //edit block, load dat for edit.
            //{
            //    this._isNew = false;
            //    try
            //    {
            //        bool chk = true;
            //        long TerminalId = 0;
            //        TerminalId = Convert.ToInt64(dr.Cells[0].Value);  //this._SelctedUserInfoId;



            //        //Load the selected row data fro edit mode

            //        this._SelctedBrancgInfoId = TerminalId;
            //        LoadBranchInfoByID(_SelctedBrancgInfoId);
            //    }
            //    catch { }

            //}
            //if (e.ColumnIndex == 7) //delete block
            //{
            //    ClearFields();
            //    this._isNew = true;
            //    bool chk = true;
            //    long TerminalId = 0;
            //    TerminalId = Convert.ToInt64(dr.Cells[0].Value);  //this._SelctedUserInfoId;
            //    chk = bllTerminalInfo.Delete(TerminalId);
            //    if (chk)
            //    {
            //        LoadGrid();
            //        //show success message here
            //        XtraMessageBox.Show("Successfully deleted the data.");

            //    }
            //}
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
