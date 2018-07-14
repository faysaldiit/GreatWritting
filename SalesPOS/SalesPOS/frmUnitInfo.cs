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
    public partial class frmUnitInfo : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedUnitInfoId = 0;
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllUnitInfo.getAll();
            this.dgvUnitList.AutoGenerateColumns = false;
            this.dgvUnitList.DataSource = dt;

        }
        private void LoadAcitivityCombo()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivity.DisplayMember = "Activity";
            this.cmbActivity.ValueMember = "ActivityID";
            this.cmbActivity.DataSource = dt;
        }

        private void ClearFields()
        {
            try
            {
                _isNew = true;
                this.txtUnitName.Text = string.Empty;
                this.cmbActivity.SelectedIndex = 0;
                if (this.dgvUnitList.Rows.Count > 0)
                    this.dgvUnitList.Rows[0].Selected = false;
                this.err_unitInfo.Clear();

            }
            catch
            { }
        }
        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtUnitName.Text))
            {
                this.err_unitInfo.SetError(txtUnitName, "Unit name is mandatory");
                chk = false;
            }
            return chk;
        }
        private void LoadUnitInfoByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllUnitInfo.getById(selectedID);
            this.txtUnitName.Text = dt.Rows[0]["UnitName"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
        }

        public frmUnitInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (!this._isNew) //(this.btnAdd.Enabled)
                {
                    if (_SelctedUnitInfoId > 0)
                    {
                        //update here
                        bool chk = true;

                        UnitInfo objUnitInfo = new UnitInfo();
                        objUnitInfo.UnitId = this._SelctedUnitInfoId;
                        objUnitInfo.UnitName = this.txtUnitName.Text.Trim();
                        objUnitInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                        objUnitInfo.UpdatedBy = 1;
                        objUnitInfo.UpdatedDate = DateTime.Now;

                        DataTable dt1 = bllUnitInfo.IsDuplicateUnitName (this._SelctedUnitInfoId, this.txtUnitName.Text.ToString(), "Update");
                        if (dt1.Rows.Count > 0)
                        {
                            XtraMessageBox.Show("Duplicate Unit Found. Please change the Unit.");
                            this.txtUnitName.Focus();
                            this.txtUnitName.SelectAll();
                        }
                        else
                        {
                            chk = bllUnitInfo.Update(objUnitInfo);
                            if (chk)
                            {
                                LoadGrid();                                
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
                    bool chk = true;                   

                    //insert here
                    UnitInfo objUnitInfo = new UnitInfo();
                    objUnitInfo.UnitName = this.txtUnitName.Text.Trim();
                    objUnitInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objUnitInfo.CreatedBy = 1;
                    objUnitInfo.CreatedDate = DateTime.Now;                    

                    DataTable dt1 = bllUnitInfo.IsDuplicateUnitName(0, this.txtUnitName.Text.ToString(), "Update");
                    if (dt1.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Unit Found. Please change the Unit.");
                        this.txtUnitName.Focus();
                        this.txtUnitName.SelectAll();
                    }
                    else
                    {
                        chk = bllUnitInfo.Insert(objUnitInfo);
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
            //this._isNew = true;
            this.txtUnitName.Focus();
        }

        private void frmUnitInfo_Load(object sender, EventArgs e)
        {
            bllUtility.ResetGridColor(dgvUnitList);
            LoadAcitivityCombo();
            LoadGrid();
            if (this.dgvUnitList.Rows.Count > 0)
                this.dgvUnitList.Rows[0].Selected = false;
            
        }

        //private void LoadGridStyle( DataGridView dgv)
        //{
        //    //data grid view style
        //    dgv.DefaultCellStyle.ForeColor = Color.Black;
        //    dgv.ColumnHeadersDefaultCellStyle.Font = new Font(this.dgvUnitList.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        //    dgv.AllowUserToAddRows = false;
        //    dgv.AllowUserToDeleteRows = false;
        //    dgv.AllowUserToResizeRows = false;
        //    dgv.BackgroundColor = Color.White;
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;            
        //}
        private void dgvUnitList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    long UnitInfoId = 0;
                    UnitInfoId = Convert.ToInt64(dr.Cells[0].Value);

                    //Load the selected row data fro edit mode
                    this._SelctedUnitInfoId = UnitInfoId;
                    LoadUnitInfoByID(_SelctedUnitInfoId);
                }
                catch { }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {            
            this._isNew = true;
            bool chk = true;
            long UnitInfoId = 0;
            
            if (this.dgvUnitList.SelectedRows.Count > 0)
            {
                UnitInfoId = Convert.ToInt64(this.dgvUnitList.SelectedRows[0].Cells[0].Value);//(dr.Cells[0].Value);  //
                if (XtraMessageBox.Show("Do you really want to delete the data ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chk = bllUnitInfo.Delete(UnitInfoId);
                    if (chk)
                    {
                        LoadGrid();
                        ClearFields();
                        if (this.dgvUnitList.Rows.Count > 0)
                            this.dgvUnitList.Rows[0].Selected = false;                        
                    }
                }
                else
                {
                    //ClearFields();
                    //if (this.dgvUnitList.Rows.Count > 0)
                    //    this.dgvUnitList.Rows[0].Selected = false;
                }
            }
            else
            {
                XtraMessageBox.Show("Select a row first.");
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
