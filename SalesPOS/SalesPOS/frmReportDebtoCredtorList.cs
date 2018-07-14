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
    public partial class frmReportDebtoCredtorList : DevExpress.XtraEditors.XtraForm
    {
        public frmReportDebtoCredtorList()
        {
            InitializeComponent();
        }

        private void frmReportDebtoCredtorList_Load(object sender, EventArgs e)
        {
            LoadAccountHolderTypeCombo();
        }

        public void LoadAccountHolderTypeCombo()
        {
            DataTable dtAccountHolderType = bllAccountHolderType.getAll();
            cmb_account_type.Properties.DataSource = dtAccountHolderType;
            this.cmb_account_type.Properties.DisplayMember = "AccountHolderType";
            this.cmb_account_type.Properties.ValueMember = "AccountHolderTypeID";
        }

        private void chk_all_account_type_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all_account_type.Checked)
                cmb_account_type.Enabled = false;
            else
                cmb_account_type.Enabled = true;
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string AccountNo = "";
            if (chk_all_account_type.Checked)
                AccountNo = "";
            else
            {
                if (cmb_account_type.EditValue == null)
                {
                    XtraMessageBox.Show("Account No Selection Required!");
                    return;
                }
                AccountNo = cmb_account_type.EditValue.ToString();
            }

            Cursor = Cursors.WaitCursor;
            DataTable dt = bllUtility.GetDataBySP("[rpt_account_last_closing_statement] '" + AccountNo + "'");
            grd_closing_balance.DataSource = dt;
            Cursor = Cursors.Default;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            Export2Xls(grd_closing_balance);
        }

        public static void Export2Xls(DevExpress.XtraGrid.GridControl grd_ctl)
        {
            SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog.FileName.Equals(String.Empty))
                {
                    try
                    {
                        string file_name = saveFileDialog.FileName;
                        grd_ctl.ExportToXls(file_name);
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
        }

    }
}
