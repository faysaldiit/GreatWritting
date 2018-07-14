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
    public partial class frmManufacturerInfo : DevExpress.XtraEditors.XtraForm
    {
        private string _SelctedManufacturerID="";
        //private Int32 _GridRowSelectedIndex = 0;
        private bool _isNew = true;

        public frmManufacturerInfo()
        {
            InitializeComponent();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "USP_Search_Manufacturer '" + txtSearchManufacturarName.Text.Trim() + "','" + this.cmbSearchActivity.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData(sql);
            this.dgvManufacturerList.AutoGenerateColumns = false;
            this.dgvManufacturerList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();

            if (this.dgvManufacturerList.Rows.Count > 0)
                this.dgvManufacturerList.Rows[0].Selected = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManufacturerInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtManufacturarName;
            bllUtility.LoadAcitivityCombo(this.cmbActivity);
            LoadGrid();
            if (this.dgvManufacturerList.Rows.Count > 0)
                this.dgvManufacturerList.Rows[0].Selected = false;
            this.dgvManufacturerList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.LoadAcitivityCombo(this.cmbSearchActivity);
            bllUtility.ResetGridColor(dgvManufacturerList);
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllManufacturerInfo.getAll();
            this.dgvManufacturerList.AutoGenerateColumns = false;
            this.dgvManufacturerList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            //this._isNew = true;
        }

        private void ClearFields()
        {
            try
            {
                _isNew = true;
                this.txtManufacturerID.Text = string.Empty;
                this.txtManufacturarName.Text = string.Empty;
                this.cmbActivity.SelectedIndex = 0;
                this.err_ManufacturerInfo.Clear();
                if (this.dgvManufacturerList.Rows.Count > 0)
                    this.dgvManufacturerList.Rows[0].Selected = false;
                this.txtManufacturarName.Focus();
            }
            catch
            { }
        }

        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtManufacturarName.Text))
            {
                this.err_ManufacturerInfo.SetError(txtManufacturarName, "Manufacturer name is mandatory");
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
                    if (_SelctedManufacturerID != "" )
                    {
                        //update here
                        bool chk = true;

                        ManufacturerInfo objManufacturerInfo = new ManufacturerInfo();
                        objManufacturerInfo.ManufacturerID = this._SelctedManufacturerID;
                        objManufacturerInfo.ManufacturarName = this.txtManufacturarName.Text.Trim();

                        objManufacturerInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                        objManufacturerInfo.UpdatedBy = 1;
                        objManufacturerInfo.UpdatedDate = DateTime.Now;
                        DataTable dt1 = bllManufacturerInfo.IsDuplicate_Manufacturer_Name(this._SelctedManufacturerID, this.txtManufacturarName.Text.ToString(), "Update");
                        if (dt1.Rows.Count > 0)
                        {
                            XtraMessageBox.Show("Duplicate Manufacturer Name Found. Please change the Manufacturer Name");
                            this.txtManufacturarName.Focus();
                            txtManufacturarName.SelectAll();
                            //this._isNew = true;
                        }
                        else
                        {
                            chk = bllManufacturerInfo.Update(objManufacturerInfo);
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
                    //insert validation method

                    //insert here
                    ManufacturerInfo objManufacturerInfo = new ManufacturerInfo();
                    objManufacturerInfo.ManufacturarName = this.txtManufacturarName.Text.Trim();

                    objManufacturerInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);

                    objManufacturerInfo.CreatedBy = 1;
                    objManufacturerInfo.CreatedDate = DateTime.Now;

                    DataTable dt1 = bllManufacturerInfo.IsDuplicate_Manufacturer_Name("", this.txtManufacturarName.Text.ToString(), "Insert");
                    if (dt1.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Manufacturer Name Found. Please change the Manufacturer Name");
                        this.txtManufacturarName.Focus();
                        txtManufacturarName.SelectAll();
                        //this._isNew = true;
                    }
                    else
                    {
                        chk = bllManufacturerInfo.Insert(objManufacturerInfo);
                        if (chk)
                        {
                            LoadGrid();
                            //show success message here

                            ClearFields();
                            this._isNew = true;
                        }                        
                    }                    
                }
                //if (this.dgvManufacturerList.Rows.Count > 0)
                //    this.dgvManufacturerList.Rows[0].Selected = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this._isNew = true;
            bool chk = true;
            string ManufacturerID = "";

            if (this.dgvManufacturerList.SelectedRows.Count > 0)
            {
                ManufacturerID = Convert.ToString(this.dgvManufacturerList.SelectedRows[0].Cells[0].Value);
                if (XtraMessageBox.Show("Do you really want to delete the data ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chk = bllManufacturerInfo.Delete(ManufacturerID);
                    if (chk)
                    {
                        LoadGrid();
                        ClearFields();
                        if (this.dgvManufacturerList.Rows.Count > 0)
                            this.dgvManufacturerList.Rows[0].Selected = false;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Select a row first.");
            }
        }

        private void dgvManufacturerList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    string ManufacturerID = "";
                    ManufacturerID = Convert.ToString(dr.Cells[0].Value);

                    //Load the selected row data fro edit mode

                    this._SelctedManufacturerID = ManufacturerID;
                    LoadManufacturerByID(_SelctedManufacturerID);
                }
                catch { }
            }
        }

        private void LoadManufacturerByID(string selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllManufacturerInfo.getById(selectedID);
            this.txtManufacturerID.Text = selectedID;
            this.txtManufacturarName.Text = dt.Rows[0]["ManufacturarName"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());

        }
        

    }
}

