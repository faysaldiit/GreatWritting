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
    public partial class frmBalanceSheet : DevExpress.XtraEditors.XtraForm
    {
        public frmBalanceSheet()
        {
            InitializeComponent();
        }

        private void frmBalanceSheet_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");
            string sql = "[rpt_balance_sheet] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
            DataTable dt = bllUtility.GetDataBySP(sql);
            grd_report.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            Export2Xls(grd_report);
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