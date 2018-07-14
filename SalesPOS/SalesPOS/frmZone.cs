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
    public partial class frmZone : DevExpress.XtraEditors.XtraForm
    {
        private long _SelctedUnitInfoId = 0;
        private bool _isNew = true;

        public frmZone()
        {
            InitializeComponent();
        }

        private void frmZone_Load(object sender, EventArgs e)
        {
            lbl_ZoneID.Text = "0";
            LoadGrid();
            ActiveControl = txtZoneName;
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllZoneInfo.getAll();
            this.gc_zone.DataSource = dt;

        }

        private void ClearFields()
        {
            lbl_ZoneID.Text = "0";
            this.txtZoneName.Text = string.Empty;
            btnSave.Enabled = true;
            LoadGrid();
        }

        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtZoneName.Text))
            {
                this.err_unitInfo.SetError(txtZoneName, "Zone name is mandatory");
                txtZoneName.Focus();
                chk = false;
            }
            return chk;
        }
        private void LoadZoneByID(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllZoneInfo.getById(selectedID);
            this.txtZoneName.Text = dt.Rows[0]["ZoneName"].ToString();
            this.lbl_ZoneID.Text = dt.Rows[0]["ZoneID"].ToString();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string id="";
                id = bllZoneInfo.Insert(lbl_ZoneID.Text,txtZoneName.Text);
                if (id.ToString().Length > 4)
                {
                    XtraMessageBox.Show(id);
                    return;
                }
                lbl_ZoneID.Text = id;
                XtraMessageBox.Show("Data Saved Successfully.");
                btnSave.Enabled = false;
                LoadGrid();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();        
            this.txtZoneName.Focus();
        }

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
                    LoadZoneByID(_SelctedUnitInfoId);
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

        private void gv_zone_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow dr = gv_zone.GetFocusedDataRow();
            if (dr == null) return;
            LoadZoneByID(Convert.ToInt16(dr[0].ToString()));
        }
    }
}
