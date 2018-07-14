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
    public partial class frmSectionInfo : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedSectionInfoId = 0;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private bool _isNew = true;
        
        public frmSectionInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSectionInfo_Load(object sender, EventArgs e)
        {   
            this.ActiveControl = this.txtSectionName;
            bllUtility.LoadAcitivityCombo(this.cmbActivity);
            LoadGrid();
            LoadAcitivityComboSearch();
            this.dgvSectionList.DefaultCellStyle.ForeColor = Color.Black;
            ClearFields();
            bllUtility.ResetGridColor(dgvSectionList);
        }

        private void LoadGridSearch()
        {
            string sql = "";
            sql = "USP_Search_Section '" + txtSearchSectionName.Text.Trim() + "','" + this.cmbSearchActivity.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData(sql);
            this.dgvSectionList.AutoGenerateColumns = false;
            this.dgvSectionList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();

            if (this.dgvSectionList.Rows.Count > 0)
                this.dgvSectionList.Rows[0].Selected = false;
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllSectionInfo.getAll();
            this.dgvSectionList.AutoGenerateColumns = false;
            this.dgvSectionList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();

            if (this.dgvSectionList.Rows.Count > 0)
                this.dgvSectionList.Rows[0].Selected = false;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesCollection.Add(dt.Rows[i]["SectionName"].ToString());
            }

            txtSectionName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSectionName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSectionName.AutoCompleteCustomSource = namesCollection;
        }
        private void LoadAcitivityComboSearch()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbSearchActivity.DisplayMember = "Activity";
            this.cmbSearchActivity.ValueMember = "ActivityID";
            cmbSearchActivity.DataSource = dt;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadGrid();
            ClearFields();
            //this._isNew = true;
            this.txtSectionName.Focus();
        }

        private void ClearFields()
        {
            try
            {
                _isNew = true;
                this.txtSectionName.Text = string.Empty;
                this.cmbActivity.SelectedIndex = 0;
                this.txtSearchSectionName.Text = string.Empty;
                this.cmbSearchActivity.SelectedIndex = 0;
                this.err_SectionInfo.Clear();
                this.txt_discount_percent.Text = string.Empty;
                if (this.dgvSectionList.Rows.Count > 0)
                    this.dgvSectionList.Rows[0].Selected = false;
                this.txtSectionName.Focus();
            }
            catch
            { }
        }

        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtSectionName.Text))
            {
                this.err_SectionInfo.SetError(txtSectionName, "Section name is mandatory");
                chk = false;
            }
            return chk;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (!this._isNew) 
                {
                    if (_SelctedSectionInfoId > 0)
                    {
                        //update here
                        bool chk = true;

                        SectionInfo objSectionInfo = new SectionInfo();
                        objSectionInfo.SectionID = this._SelctedSectionInfoId;
                        objSectionInfo.SectionName = this.txtSectionName.Text.Trim();

                        objSectionInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                        objSectionInfo.UpdatedBy = 1;
                        objSectionInfo.UpdatedDate = DateTime.Now;

                        if (txt_discount_percent.Text == "")
                            txt_discount_percent.Text = "0";
                        objSectionInfo.DiscountPercent = Convert.ToDecimal(txt_discount_percent.Text);

                        DataTable dt1 = bllSectionInfo.IsDuplicateCategoryName(this._SelctedSectionInfoId, this.txtSectionName.Text.ToString(), "Update");
                        if (dt1.Rows.Count > 0)
                        {
                            XtraMessageBox.Show("Duplicate Product Category Found. Please change the Product Category.");
                            this.txtSectionName.Focus();
                            this.txtSectionName.SelectAll();                           
                        }
                        else
                        {
                            chk = bllSectionInfo.Update(objSectionInfo);
                            if (chk)
                            {
                                LoadGrid();
                                //show success message here
                                XtraMessageBox.Show("Successfully updated the record");
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
                    bool chk = true;                   

                    //insert here
                    SectionInfo objSectionInfo = new SectionInfo();
                    objSectionInfo.SectionName = this.txtSectionName.Text.Trim();

                    objSectionInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                    objSectionInfo.CreatedBy = 1;
                    objSectionInfo.CreatedDate = DateTime.Now;

                    if (txt_discount_percent.Text == "")
                        txt_discount_percent.Text = "0";
                    objSectionInfo.DiscountPercent =Convert.ToDecimal( txt_discount_percent.Text);

                    DataTable dt1 = bllSectionInfo.IsDuplicateCategoryName(0, this.txtSectionName.Text.ToString(), "Update");
                    if (dt1.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Product Category Found. Please change the Product Category.");
                        this.txtSectionName.Focus();
                        txtSectionName.SelectAll();                        
                    }
                    else
                    {
                        chk = bllSectionInfo.Insert(objSectionInfo);
                        if (chk)
                        {
                            LoadGrid();                            
                            ClearFields();
                            this._isNew = true;
                        }
                    }
                }
                //if (this.dgvSectionList.Rows.Count > 0)
                //    this.dgvSectionList.Rows[0].Selected = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this._isNew = true;
            bool chk = true;
            long SectionInfoId = 0;
            
            if (this.dgvSectionList.SelectedRows.Count > 0)
            {
                SectionInfoId = Convert.ToInt64(this.dgvSectionList.SelectedRows[0].Cells[0].Value);
                if (XtraMessageBox.Show("Do you really want to delete the data ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chk = bllSectionInfo.Delete(SectionInfoId);
                    if (chk)
                    {
                        LoadGrid();
                        ClearFields();
                        if (this.dgvSectionList.Rows.Count > 0)
                            this.dgvSectionList.Rows[0].Selected = false;                
                    }
                }                
            }
            else
            {
                XtraMessageBox.Show("Select a row first.");
            }
        }

        private void dgvSectionList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    long SectionInfoId = 0;
                    SectionInfoId = Convert.ToInt64(dr.Cells[0].Value);

                    //Load the selected row data fro edit mode

                    this._SelctedSectionInfoId = SectionInfoId;
                    LoadSectionInfoByID(_SelctedSectionInfoId);
                }
                catch { }
            }
        }

        private void LoadSectionInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllSectionInfo.getById(selectedID);
            this.txtSectionName.Text = dt.Rows[0]["SectionName"].ToString();
            this.txt_discount_percent.Text = dt.Rows[0]["DiscountPercent"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());

        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadGridSearch();           
            ClearFields();
        }

        private void txt_discount_percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allow_keys = "0123456789." + '\b';
            if (allow_keys.IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }
        
    }
}
