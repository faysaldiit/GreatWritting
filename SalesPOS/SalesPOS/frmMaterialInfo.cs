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
    public partial class frmMaterialInfo : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedUnitInfoId = 0;
        private bool _isNew = true;

        public frmMaterialInfo()
        {
            InitializeComponent();
        }

        private void frmZone_Load(object sender, EventArgs e)
        {
            txtMaterialID.Text = "";
            LoadAcitivityCombo();
            LoadGrid();
            LoadUnit();
            ActiveControl = txtMaterialName;
            txtMaterialName.Focus();
        }

        private void LoadAcitivityCombo()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivity.DisplayMember = "Activity";
            this.cmbActivity.ValueMember = "ActivityID";
            cmbActivity.DataSource = dt;
        }
        private void LoadUnit()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllUnitInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["UnitId"] = "0";
                dr["UnitName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbUnit.DisplayMember = "UnitName";
                cmbUnit.ValueMember = "UnitId";
                cmbUnit.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllMaterial.getAll();
            this.gc_zone.DataSource = dt;

        }

        private void ClearFields()
        {
            txtMaterialID.Text = "";
            this.txtMaterialName.Text = string.Empty;
            btnSave.Enabled = true;
            LoadGrid();
            txtMaterialName.Focus();
        }


        private void LoadMaterialByID(string selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllMaterial.getById(selectedID);
            this.txtMaterialName.Text = dt.Rows[0]["MaterialName"].ToString();
            this.txtMaterialID.Text = dt.Rows[0]["MaterialID"].ToString();
            //cmbActivity.SelectedItem = dt.Rows[0]["ActivityID"].ToString();
            cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
            cmbUnit.SelectedValue = Convert.ToInt64(dt.Rows[0]["UnitID"].ToString());
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtMaterialName.Text == "")
            {
                XtraMessageBox.Show("Material name required!");
                txtMaterialName.Focus();
                return;
            }

            if (bllUtility.Val(this.cmbUnit.SelectedValue) == 0)
            {
                XtraMessageBox.Show("Unit selection required!");
                cmbUnit.Focus();
                return;
            }

            if (bllUtility.Val(this.cmbActivity.SelectedValue) == 0)
            {
                XtraMessageBox.Show("Activity selection required!");
                cmbActivity.Focus();
                return;
            }

            string id = txtMaterialID.Text.Trim();
            string UnitID = this.cmbUnit.SelectedValue.ToString();
            string ActivityID = this.cmbActivity.SelectedValue.ToString();
            id = bllMaterial.Insert(txtMaterialID.Text, txtMaterialName.Text, UnitID, ActivityID);            
            txtMaterialID.Text = id;
            XtraMessageBox.Show("Data Saved Successfully.");
            //btnSave.Enabled = false;
            LoadGrid();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            this.txtMaterialName.Focus();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {

        }

        private void gv_zone_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow dr = gv_zone.GetFocusedDataRow();
            if (dr == null) return;
            LoadMaterialByID(dr[0].ToString());
        }
    }
}
