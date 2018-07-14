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
    public partial class frmTerminalInfo : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedTerminalInfoId = 0;
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllTerminalInfo.getAll();
            this.dgvTerminalList.AutoGenerateColumns = false;
            this.dgvTerminalList.DataSource = dt;
            
        }
        private void LoadAcitivityCombo()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivity.DisplayMember = "Activity";
            this.cmbActivity.ValueMember = "ActivityID";            
            cmbActivity.DataSource = dt;
        }
        private void ClearFields()
        {
            try
            {
                _isNew = true;
                this.txtAttribute.Text = "HDD";
                this.txtAttributeValue.Text = string.Empty;
                this.txtTerminalName.Text = string.Empty;
                this.txtUserSearch.Text = string.Empty;
                this.dtpActivationDate.Value = DateTime.Today;
                this.dtpExpiryDate.Value = DateTime.Today;
                this.cmbActivity.SelectedIndex = 0;
                if (this.dgvTerminalList.Rows.Count > 0)
                    this.dgvTerminalList.Rows[0].Selected = false;

                this.err_terminalInfo.Clear();
            }
            catch
            { }
        }

        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtTerminalName.Text))
            {
                this.err_terminalInfo.SetError(txtTerminalName, "Terminal name is mandatory");
                chk = false;
            }
            if (this.dtpActivationDate.Value.Date > this.dtpExpiryDate.Value.Date)
            {
                this.err_terminalInfo.SetError(dtpActivationDate, "Expiry date must be greater or equals to activation date.");
                this.err_terminalInfo.SetError(dtpExpiryDate, "Expiry date must be greater or equals to activation date.");
                chk = false; 
            }
            return chk;
        }

        private void LoadTerminalInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllTerminalInfo.getById(selectedID);
            this.txtTerminalName.Text = dt.Rows[0]["TerminalName"].ToString();
            this.txtAttribute.Text = dt.Rows[0]["Attribute"].ToString();
            this.txtAttributeValue.Text = dt.Rows[0]["ValueOfAttribute"].ToString();
            this.dtpExpiryDate.Value = Convert.ToDateTime(dt.Rows[0]["ExpireDate"].ToString());
            this.dtpActivationDate.Value = Convert.ToDateTime(dt.Rows[0]["ActivationDate"].ToString());
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());

        }

        public frmTerminalInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.err_terminalInfo.Clear();
            if (isValid())
            {
                if (!this._isNew) 
                {
                    if (_SelctedTerminalInfoId > 0)
                    {
                        //update here
                        bool chk = true;

                        TerminalInfo objTerminalInfo = new TerminalInfo();
                        objTerminalInfo.TerminalID = this._SelctedTerminalInfoId;
                        objTerminalInfo.TerminalName = this.txtTerminalName.Text.Trim();
                        objTerminalInfo.ActivationDate = this.dtpActivationDate.Value;
                        objTerminalInfo.Attribute = this.txtAttribute.Text;
                        objTerminalInfo.ExpireDate = this.dtpExpiryDate.Value;
                        objTerminalInfo.ValueOfAttribute = this.txtAttributeValue.Text;
                        objTerminalInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                        objTerminalInfo.UpdatedBy = 1;
                        objTerminalInfo.UpdatedDate = DateTime.Now;

                        //this.btnAdd.Enabled = true;

                        chk = bllTerminalInfo.Update(objTerminalInfo);
                        if (chk)
                        {
                            LoadGrid();
                            //show success message here

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
                    TerminalInfo objTerminalInfo = new TerminalInfo();
                    objTerminalInfo.TerminalID = this._SelctedTerminalInfoId;
                    objTerminalInfo.TerminalName = this.txtTerminalName.Text.Trim();
                    objTerminalInfo.ActivationDate = this.dtpActivationDate.Value;
                    objTerminalInfo.Attribute = this.txtAttribute.Text;
                    objTerminalInfo.ExpireDate = this.dtpExpiryDate.Value;
                    objTerminalInfo.ValueOfAttribute = this.txtAttributeValue.Text;
                    objTerminalInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);                    
                    objTerminalInfo.CreatedBy = 1;
                    objTerminalInfo.CreatedDate = DateTime.Now;

                    chk = bllTerminalInfo.Insert(objTerminalInfo);
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

        private void frmTerminalInfo_Load(object sender, EventArgs e)
        {
            LoadAcitivityCombo();
            LoadGrid();
            if (this.dgvTerminalList.Rows.Count > 0)
                this.dgvTerminalList.Rows[0].Selected = false;
            this.dgvTerminalList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvTerminalList);
        }

        private void dgvUnitList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Convert.ToInt32 (e.RowIndex)==-1)
            {

            }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];            
                this._isNew = false;
                try
                {
                    //bool chk = true;
                    long TerminalId = 0;
                    TerminalId = Convert.ToInt64(dr.Cells[0].Value);

                    //Load the selected row data fro edit mode

                    this._SelctedTerminalInfoId = TerminalId;
                    LoadTerminalInfoByID(_SelctedTerminalInfoId);
                }
                catch { }           
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
