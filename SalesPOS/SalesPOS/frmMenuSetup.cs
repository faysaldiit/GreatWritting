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
    public partial class frmMenuSetup : DevExpress.XtraEditors.XtraForm
    {
        private bool _isNew = true;
        public frmMenuSetup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._isNew)
            {
                ScreenInfo objScreenInfo = new ScreenInfo();
                bool chk = true;
                //objScreenInfo.ScreenCode =Convert.ToInt64(this.txtCode.Text.Trim());
                objScreenInfo.ScreenName = this.txtDisplay.Text.Trim();
                objScreenInfo.FormName = txtFormName.Text.Trim();
                string a = cmbMenu.SelectedValue.ToString().Trim();
                objScreenInfo.MenuCode =Convert.ToInt64(cmbMenu.SelectedValue.ToString().Trim());

                chk = bllScreenInfo.InsertScreen(objScreenInfo);
                if (chk)
                {
                    
                    XtraMessageBox.Show("Successfully Updated the record.");
                    //ClearFields();
                    this._isNew = true;
                }
            }

        }

        private void frmMenuSetup_Load(object sender, EventArgs e)
        {
            loadCombo();
        }

        public void loadCombo()
        {

            this.cmbMenu.DisplayMember = "menudescription";
            this.cmbMenu.ValueMember = "MenuID";
            //this.dgvUserList.AutoGenerateColumns = false;
            //this.dgvUserList.DataSource = dt;
            cmbMenu.DataSource = (DataTable)bllScreenInfo.getMenuList();
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
