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
using System.IO;
using System.Globalization;


namespace SalesPOS
{
    public partial class frmReportProductList : DevExpress.XtraEditors.XtraForm
    {
        bool IsPrint = false;
      //  private export2Excel export2XLS;
        DataTable gridData;
        bllReportUtility iReportUtility = new bllReportUtility();
        public frmReportProductList()
        {
            InitializeComponent();
        }

        private void frmReportProductList_Load(object sender, EventArgs e)
        {
            LoadSection();
        }

        private void LoadSection()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSectionInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["SectionID"] = "0";
                dr["SectionName"] = "Select All Category";
                dt.Rows.InsertAt(dr, 0);
                cmbSection.DisplayMember = "SectionName";
                cmbSection.ValueMember = "SectionID";
                cmbSection.DataSource = dt;
            }
            catch
            { }
        }

        private void LoadSubSection(long SectionId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSubSectionInfo.getBySectionId(SectionId);
                DataRow dr = dt.NewRow();
                dr["SubSectionID"] = "0";
                dr["SubSectionName"] = "Select All Sub Category";
                dt.Rows.InsertAt(dr, 0);
                cmbSubSection.DisplayMember = "SubSectionName";
                cmbSubSection.ValueMember = "SubSectionID";
                cmbSubSection.DataSource = dt;
            }
            catch
            { }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            long SectionID = Convert.ToInt64(this.cmbSection.SelectedValue);
            LoadSubSection(SectionID);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {            
            string strSectionID = this.cmbSection.SelectedValue.ToString();
            string strSubSectionID = this.cmbSubSection.SelectedValue.ToString();

            string sql = "";
            sql = "[dbo].[USP_product_list]  '" + strSectionID.Trim() + "','" + strSubSectionID.Trim() + "'";
            DataTable dt = new DataTable();

            dt = bllReportUtility.ReportData(sql);
            grd_product_list.DataSource = dt;

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            //grd_product_list.ShowRibbonPrintPreview(); 
            gridData = grd_product_list.DataSource as DataTable;
            if (gridData.Rows.Count < 1)
                return;
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".xls"))
                    {
                        StartExport(saveFileDialog1.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location to save file to");
                }
            }
         
        }

        private void grd_product_list_Click(object sender, EventArgs e)
        {

        }
        //private void export2XLS_prg(object sender, ProgressEventArgs e)
        //{

        //}

        private void StartExport(String filepath)
        {
            //btn2Excel.Enabled = false;
            //btnUseTemplate.Enabled = false;
            //create a new background worker, to do the exporting
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync(filepath);

            //create a new export2XLS object, providing DataView as a input parameter
            //export2XLS = new export2Excel();
            //export2XLS.prg += new export2Excel.ProgressHandler(export2XLS_prg);
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            //get the Gridviews DataView
            DataView dv = gridData.DefaultView;
            //Pass the path and the sheet to use
            //export2XLS.ExportToExcel(dv, (String)e.Argument, "newSheet1");
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //btn2Excel.Enabled = true;
            //btnUseTemplate.Enabled = true;
            //MessageBox.Show("Finished");
            XtraMessageBox.Show("Successfully exported.");
        }
    }
}
