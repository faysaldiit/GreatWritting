using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesPOS.BOL;
using SalesPOS.BLL;

namespace SalesPOS
{
    
    public partial class frmUserMenu : DevExpress.XtraEditors.XtraForm
    {
        
        private bool _isNew = true;
        public frmUserMenu()
        {
            InitializeComponent();
        }

        private void frmUserMenu_Load(object sender, EventArgs e)
        {
            loadGrid();
            Load_Combo();
            this.cmbUserList.Text = "";
            this.txtUserName.Text = "";
            this.grdUserMenu.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(grdUserMenu);
        }


        public void loadGrid()
        {
            this.grdUserMenu.AutoGenerateColumns = false;
            grdUserMenu.DataSource = (DataTable)bllScreenInfo.getMenu_ScreenList();
           

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this._isNew && cmbUserList.Text!="")
            {
                ScreenInfo objScreenInfo = new ScreenInfo();

                bllReportUtility.Exec_Store_Procedure("DELETE FROM UserMenuConfigure WHERE UserInfoId="+Convert.ToInt64(cmbUserList.SelectedValue.ToString().Trim())); 
                foreach(DataGridViewRow dgvr in grdUserMenu.Rows )
                {
                    //string chk_val = dgvr.Cells[0].Value.ToString().Trim();
                    if (dgvr.Cells[0].Value.ToString().Trim() =="1")
                    {
                        objScreenInfo.UserInfoId =Convert.ToInt64(cmbUserList.SelectedValue.ToString().Trim());
                        objScreenInfo.ScreenCode = Convert.ToInt64(dgvr.Cells[3].Value.ToString().Trim());
                        objScreenInfo.MenuCode = Convert.ToInt64(dgvr.Cells[1].Value.ToString().Trim());
                        bllScreenInfo.InsertScreen_UserPermission(objScreenInfo);
                    }
                }
                XtraMessageBox.Show("User Permission Successfully Save.");
               
            }

        }

        //private void btnLoad_Click(object sender, EventArgs e)
        //{

        //    //DataTable DTab_User = (DataTable)bllScreenInfo.getUserInformation(txtuserID.Text.Trim());
        //    //if (DTab_User.Rows.Count > 0)
        //    //{
        //    //    txtID.Text = DTab_User.Rows[0][0].ToString().Trim();
        //    //    txtUserName.Text = DTab_User.Rows[0][1].ToString().Trim();
        //    //Check_AccessScreen(DTab_User.Rows[0][0].ToString().Trim());
        //    //}
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Load_Combo()
        {

            try
            {
                DataTable dt = new DataTable();
                dt = bllScreenInfo.getUserList();
                //this.cmbUserList.DisplayMember = "SoftUser";
                //this.cmbUserList.ValueMember = "UserInfoId";
                this.cmbUserList.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        
        }

        public void Check_AccessScreen(string _UserInfoID)
        {
            long UserInfoId = Convert.ToInt64(_UserInfoID.Trim());

            for (int j = 0; j < grdUserMenu.Rows.Count; j++)
            {
               
                    grdUserMenu.Rows[j].Cells[0].Value = 0;
                    grdUserMenu.Rows[j].Selected = false;
             
            }

            DataTable DTab_ScreenList = (DataTable)bllScreenInfo.getUserAccessInformation(UserInfoId);

            if (DTab_ScreenList.Rows.Count > 0)
            {
                for (int i = 0; i < DTab_ScreenList.Rows.Count;i++ )
                {
                    for (int j = 0; j < grdUserMenu.Rows.Count; j++)
                    {
                        if (grdUserMenu.Rows[j].Cells[3].Value.ToString().Trim() == DTab_ScreenList.Rows[i][0].ToString().Trim() & grdUserMenu.Rows[j].Cells[1].Value.ToString().Trim() == DTab_ScreenList.Rows[i][2].ToString().Trim())
                        {
                            grdUserMenu.Rows[j].Cells[0].Value = 1;
                            grdUserMenu.Rows[j].Selected = true;
                        }                        
                    }
                }
            }
        
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbUserList_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable DTab_User = (DataTable)bllScreenInfo.getUserInformation(Convert.ToInt64(cmbUserList.SelectedValue.ToString().Trim()));
            //string a = cmbUserList.SelectedItem.ToString() + "-" + cmbUserList.SelectedText + "-" + cmbUserList.SelectedValue.ToString();
            if (DTab_User.Rows.Count > 0)
            {
                txtUserName.Text = DTab_User.Rows[0][2].ToString().Trim();
                Check_AccessScreen(DTab_User.Rows[0][0].ToString().Trim());

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}
