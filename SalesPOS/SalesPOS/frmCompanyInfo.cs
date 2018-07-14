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
    public partial class frmCompanyInfo : DevExpress.XtraEditors.XtraForm
    {
        
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        private void LoadCompanyDataById(long CompanyID)
        {
            DataTable dt = new DataTable();
            dt = bllCompanyInfo.getById(CompanyID);
            this.txtAddress.Text = dt.Rows[0]["Address"].ToString();
            this.txtContactNumber.Text = dt.Rows[0]["ContactNumber"].ToString();
            this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
            this.txtFax.Text = dt.Rows[0]["FAX"].ToString();
            this.txtWebURL.Text = dt.Rows[0]["WebURL"].ToString();
            this.txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            this.txtShortCode.Text = dt.Rows[0]["ShortCode"].ToString();
            this.dtpExpiryDate.Value = Convert.ToDateTime(dt.Rows[0]["ExpireDate"].ToString());
            this.dtpActivationDate.Value = Convert.ToDateTime(dt.Rows[0]["ActivationDate"].ToString());
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
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

        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            LoadAcitivityCombo();
            LoadCompanyDataById(1);

        }
        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtCompanyName.Text))
            {
                this.err_companyInfo.SetError(txtCompanyName, "Company name is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                this.err_companyInfo.SetError(txtAddress, "Address is mandatory");
                chk = false;
            }
            if (this.dtpActivationDate.Value.Date > this.dtpExpiryDate.Value.Date)
            {
                this.err_companyInfo.SetError(dtpActivationDate, "Expiry date must be greater or equals to activation date.");
                this.err_companyInfo.SetError(dtpExpiryDate, "Expiry date must be greater or equals to activation date.");
                chk = false;
            }
            return chk;
        }
        private void ClearFields()
        {
            try
            {
                this.txtAddress.Text = string.Empty;
                this.txtCompanyName.Text = string.Empty;
                this.txtContactNumber.Text = string.Empty;
                this.txtEmail.Text = string.Empty;
                this.txtFax.Text = string.Empty;
                this.txtShortCode.Text = string.Empty;
                this.txtWebURL.Text = string.Empty;
                

                this.dtpActivationDate.Value = DateTime.Today;
                this.dtpExpiryDate.Value = DateTime.Today;
                this.cmbActivity.SelectedIndex = 0;

                this.err_companyInfo.Clear();
            }
            catch
            { }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.err_companyInfo.Clear();
            if (isValid())
            {
                long _SelctedCompanyId = 1;
                //this._GridRowSelectedIndex = this.dgvUnitList.SelectedRows[0].Index;
                if (_SelctedCompanyId > 0)
                {
                    //update here
                    bool chk = true;

                    CompanyInfo objCompanyInfo = new CompanyInfo();
                    objCompanyInfo.ActivationDate = this.dtpActivationDate.Value;
                    objCompanyInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objCompanyInfo.Address = this.txtAddress.Text;
                    objCompanyInfo.CompanyID = _SelctedCompanyId;
                    objCompanyInfo.CompanyName = this.txtCompanyName.Text;
                    objCompanyInfo.ContactNumber = this.txtContactNumber.Text;
                    objCompanyInfo.Email = this.txtEmail.Text;
                    objCompanyInfo.ExpireDate = Convert.ToDateTime(this.dtpExpiryDate.Value.ToString("dd-MMM-yyyy"));
                    objCompanyInfo.FAX = this.txtFax.Text.Trim();
                    objCompanyInfo.ShortCode = this.txtShortCode.Text;
                    objCompanyInfo.WebURL = this.txtWebURL.Text;
                    objCompanyInfo.UpdatedBy = 1;
                    objCompanyInfo.UpdatedDate = DateTime.Now;

                    //this.btnAdd.Enabled = true;

                    chk = bllCompanyInfo.Update(objCompanyInfo);
                    if (chk)
                    {
                        
                        //show success message here

                        //ClearFields();

                        XtraMessageBox.Show("Successfully Updated.");
                    }
                }
                else
                {
                    XtraMessageBox.Show("No data found for update.");
                }


            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadAcitivityCombo();
            LoadCompanyDataById(1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
