using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesPOS.BOL;
using SalesPOS.BLL;
using SalesPOS.Report;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmReportMaterialTransaction : DevExpress.XtraEditors.XtraForm
    {
        bllReportUtility iReportUtility = new bllReportUtility();
        public frmReportMaterialTransaction()
        {
            InitializeComponent();
        }

        private void frmReportMaterialTransaction_Load(object sender, EventArgs e)
        {
            grd_purchase.Visible = true;
            grd_production.Visible = false;
            grd_gift.Visible = false;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string strDateFrom = this.dtpFrom.Value.ToString("dd/MM/yyyy");
            string strDateTo = this.dtpTo.Value.ToString("dd/MM/yyyy");
            
            if (optReportType.SelectedIndex == 0)//purchase
            {                
                Cursor = Cursors.WaitCursor;
                string sql = "[rpt_meterial_purchase_statement] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
                DataTable dt = bllUtility.GetDataBySP(sql);
                grd_purchase.DataSource = dt;
                Cursor = Cursors.Default;
            }
            else if (optReportType.SelectedIndex == 1)  //production        
            {
                Cursor = Cursors.WaitCursor;
                string sql = "[rpt_meterial_production_statement] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
                DataTable dt = bllUtility.GetDataBySP(sql);
                grd_production.DataSource = dt;
                Cursor = Cursors.Default;
            }
            else
            {
                //gift
                Cursor = Cursors.WaitCursor;
                string sql = "[rpt_gift_statement] '" + strDateFrom.Trim() + "','" + strDateTo.Trim() + "'";
                DataTable dt = bllUtility.GetDataBySP(sql);
                grd_gift.DataSource = dt;
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optReportType.SelectedIndex == 0)//purchase
            {
                grd_purchase.Visible = true;
                grd_production.Visible = false;
                grd_gift.Visible = false;
            }
            else if (optReportType.SelectedIndex == 1)
            {
                grd_purchase.Visible = false;
                grd_production.Visible = true;
                grd_gift.Visible = false;
            }
            else 
            {
                grd_purchase.Visible = false;
                grd_production.Visible = false;
                grd_gift.Visible = true;
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (optReportType.SelectedIndex == 0)//purchase
            {
               Export2Xls(grd_purchase);
            }
            else if (optReportType.SelectedIndex == 1)//production
            {
                Export2Xls(grd_production);
            }
            else//gift
            {
                Export2Xls(grd_gift);
            } 
        }

        public static void Export2Xls(DevExpress.XtraPivotGrid.PivotGridControl grd_ctl)
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