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
using DevExpress.XtraGrid.Controls;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;

namespace SalesPOS
{
    public partial class frmCustomerSearchNew : DevExpress.XtraEditors.XtraForm
    {
        public frmCustomerSearchNew()
        {
            InitializeComponent();
        }

        private void frmCustomerSearchNew_Load(object sender, EventArgs e)
        {
            load_zone_list();
            LoadAccountHolderTypeCombo();
            cmb_zone.EditValue = null;
            cmb_account_type.EditValue = null;
            chk_all_account_type.Checked = true;
            chk_all_zone.Checked = true;
            btn_search_Click(sender,e);
            //grd_search.Focus();
            gv_search.ShowFindPanel();            
            ActiveControl = grd_search;
            grd_search.Focus();
            //gv_search.fin
        }

        private void load_zone_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.[PopulateZoneList]");
            cmb_zone.Properties.DisplayMember = "ZoneName";
            cmb_zone.Properties.ValueMember = "ZoneID";
            cmb_zone.Properties.DataSource = dt;
        }

        public void LoadAccountHolderTypeCombo()
        {           
            DataTable dtAccountHolderType = bllAccountHolderType.getAll();
            cmb_account_type.Properties.DataSource = dtAccountHolderType;
            this.cmb_account_type.Properties.DisplayMember = "AccountHolderType";
            this.cmb_account_type.Properties.ValueMember = "AccountHolderTypeID";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string zone_id = "";
            string account_type_id="";
            if (chk_all_zone.Checked == false)
            {
                if (cmb_zone.EditValue == null)
                {
                    XtraMessageBox.Show("zone selection required!");
                    cmb_zone.Focus();
                    return;
                }
                zone_id = cmb_zone.EditValue.ToString();
            }
            if (chk_all_account_type.Checked == false)
            {
                if (cmb_account_type.EditValue == null)
                {
                    XtraMessageBox.Show("Account Holder Type selection required!");
                    cmb_account_type.Focus();
                    return;
                }
                account_type_id = cmb_account_type.EditValue.ToString();
            }
            load_account_list(zone_id, account_type_id);
        }

        private void load_account_list(string zone_id, string account_type_id)
        {
            Cursor = Cursors.WaitCursor;
            DataTable dt = bllUtility.GetDataBySP("search_account_holder_by_type_n_zone '" + zone_id + "','" + account_type_id+"'");
            grd_search.DataSource = dt;
            Cursor = Cursors.Default;
        }

        private void gv_search_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr= gv_search.GetFocusedDataRow();
            if (dr == null)
            {
                XtraMessageBox.Show("No data has selected.");
                return;
            }
            //string account_no = dr["AccountNo"].ToString();
            //string account_name = dr["AccHolderName"].ToString();

            AccountHolderInfo objProductInfo = new AccountHolderInfo();
            objProductInfo.AccHolderInfoId = Convert.ToInt64(dr["AccHolderInfoId"].ToString());
            objProductInfo.AccountNo = dr["AccountNo"].ToString();
            objProductInfo.AccHolderName = dr["AccHolderName"].ToString();
            objProductInfo.RSMID = dr["RSMID"].ToString();
            if (dr["ZoneID"].ToString()!="")
                objProductInfo.ZoneID = Convert.ToInt64(dr["ZoneID"].ToString());

            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = objProductInfo;

            this.Close();
        }

        private void chk_all_zone_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all_zone.Checked)
                cmb_zone.Enabled = false;
            else
                cmb_zone.Enabled = true;
        }

        private void chk_all_account_type_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all_account_type.Checked)
                cmb_account_type.Enabled = false;
            else
                cmb_account_type.Enabled = true;
        }

        private void frmCustomerSearchNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo == null)
            {

                AccountHolderInfo objAccountHolderInfo = new AccountHolderInfo();
                objAccountHolderInfo.ZoneID = 0;
                objAccountHolderInfo.AccHolderInfoId = 0;
                objAccountHolderInfo.AccountNo = "";
                objAccountHolderInfo.AccHolderName = "";

                bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = objAccountHolderInfo;
            }
        }

        

    }
}