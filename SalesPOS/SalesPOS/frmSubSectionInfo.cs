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
    public partial class frmSubSectionInfo : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedSubSectionInfoId = 0;
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;

        public frmSubSectionInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubSectionInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSubSectionName;
            bllUtility.LoadAcitivityCombo(this.cmbActivity);
            bllUtility.LoadAcitivityCombo(this.cmbSearchActivity);
            bllSubSectionInfo.LoadSectionInfoCombo(this.cmbSectionName);
            LoadSectionSearch();
            LoadGrid();
            
            this.dgvSubSectionList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvSubSectionList);
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllSubSectionInfo.getAll();
            this.dgvSubSectionList.AutoGenerateColumns = false;
            this.dgvSubSectionList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();
            if (this.dgvSubSectionList.Rows.Count > 0)
                this.dgvSubSectionList.Rows[0].Selected = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            try
            {
                this.txtSearchSubSectionName.Text = string.Empty;
                this.cmbSearchActivity.SelectedIndex = 0;
                this.cmbSearchSectionName.SelectedIndex = 0;

                this.txtSubSectionName.Text = string.Empty;
                this.cmbSectionName.SelectedIndex = 0;
                this.cmbActivity.SelectedIndex = 0;
                this.err_SubSectionInfo.Clear();
                //if (this.dgvSubSectionList.Rows.Count > 0)
                //    this.dgvSubSectionList.Rows[0].Selected = false;
                LoadGrid();
                LoadSectionSearch();
                this.txtSubSectionName.Focus();
                _isNew = true;                
            }
            catch
            { }
        }
        private void LoadSectionSearch()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSectionInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["SectionID"] = "0";
                dr["SectionName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbSearchSectionName.DisplayMember = "SectionName";
                cmbSearchSectionName.ValueMember = "SectionID";
                cmbSearchSectionName.DataSource = dt;
            }
            catch
            { }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this._isNew = true;
            bool chk = true;
            long SubSectionInfoId = 0;

            if (this.dgvSubSectionList.SelectedRows.Count > 0)
            {
                SubSectionInfoId = Convert.ToInt64(this.dgvSubSectionList.SelectedRows[0].Cells[0].Value);
                if (XtraMessageBox.Show("Do you really want to delete the data ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chk = bllSubSectionInfo.Delete(SubSectionInfoId);
                    if (chk)
                    {
                        LoadGrid();
                        ClearFields();
                        if (this.dgvSubSectionList.Rows.Count > 0)
                            this.dgvSubSectionList.Rows[0].Selected = false;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Select a row first.");
            }
        }

        private void dgvSubSectionList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    long SubSectionInfoId = 0;
                    SubSectionInfoId = Convert.ToInt64(dr.Cells[0].Value);

                    //Load the selected row data fro edit mode

                    this._SelctedSubSectionInfoId = SubSectionInfoId;
                    LoadSubSectionInfoByID(_SelctedSubSectionInfoId);
                }
                catch { }
            }
        }

        private void LoadSubSectionInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllSubSectionInfo.getById(selectedID);
            this.txtSubSectionName.Text = dt.Rows[0]["SubSectionName"].ToString();
            this.cmbSectionName.SelectedValue = Convert.ToInt64(dt.Rows[0]["SectionID"].ToString());
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());

        }
        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtSubSectionName.Text))
            {
                this.err_SubSectionInfo.SetError(txtSubSectionName, "Sub Section name is mandatory");
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
                    if (_SelctedSubSectionInfoId > 0)
                    {
                        //update here
                        bool chk = true;

                        SubSectionInfo objSubSectionInfo = new SubSectionInfo();
                        objSubSectionInfo.SubSectionID = this._SelctedSubSectionInfoId;
                        objSubSectionInfo.SubSectionName = this.txtSubSectionName.Text.Trim();
                        objSubSectionInfo.SectionID = Convert.ToInt64(this.cmbSectionName.SelectedValue);
                        objSubSectionInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                        objSubSectionInfo.UpdatedBy = 1;
                        objSubSectionInfo.UpdatedDate = DateTime.Now;

                        chk = bllSubSectionInfo.Update(objSubSectionInfo);
                        if (chk)
                        {
                            LoadGrid();
                            //show success message here
                            XtraMessageBox.Show("Successfully updated the record");
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
                    bool chk = true;
                    //insert validation method

                    //insert here
                    SubSectionInfo objSubSectionInfo = new SubSectionInfo();
                    objSubSectionInfo.SubSectionName = this.txtSubSectionName.Text.Trim();
                    objSubSectionInfo.SectionID = Convert.ToInt64(this.cmbSectionName.SelectedValue);
                    objSubSectionInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                    objSubSectionInfo.CreatedBy = 1;
                    objSubSectionInfo.CreatedDate = DateTime.Now;

                    chk = bllSubSectionInfo.Insert(objSubSectionInfo);
                    if (chk)
                    {
                        LoadGrid();
                        //show success message here

                        ClearFields();
                        this._isNew = true;
                    }

                }
                if (this.dgvSubSectionList.Rows.Count > 0)
                    this.dgvSubSectionList.Rows[0].Selected = false;
            }
        }

        private void LoadGridSearch()
        {
            string sql = "";
            sql = "USP_Search_SubSection '" + cmbSearchSectionName.SelectedValue + "','" + this.txtSearchSubSectionName.Text.Trim()+ "','"+cmbSearchActivity.SelectedValue+"'";
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData(sql);
            this.dgvSubSectionList.AutoGenerateColumns = false;
            this.dgvSubSectionList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();

            if (this.dgvSubSectionList.Rows.Count > 0)
                this.dgvSubSectionList.Rows[0].Selected = false;
        }
        private void btnSearchUser_Click(object sender, EventArgs e)
        {            
            LoadGridSearch();
            //ClearFields();
        }
        
    }
}
