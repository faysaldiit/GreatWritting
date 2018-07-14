using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesPOS.Report;
using SalesPOS.BLL;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmReportSalesInvoice : DevExpress.XtraEditors.XtraForm
    {
        public frmReportSalesInvoice()
        {
            InitializeComponent();
        }

        private void btnPreviewReport_Click(object sender, EventArgs e)
        {
            dsReport ds = new dsReport();
            DataSet dsSP = bllReports.GetSalesInvoice(this.txtInvoiceNumber.Text.Trim());
            try
            {
                foreach (DataRow dr in dsSP.Tables[0].Rows)
                {
                    ds.Tables["SalesParentInfo"].ImportRow(dr);
                }
                foreach (DataRow dr in dsSP.Tables[1].Rows)
                {
                    ds.Tables["SalesChildInfo"].ImportRow(dr);
                }
                foreach (DataRow dr in bllCompanyInfo.getById(1).Rows)
                {
                    ds.Tables["CompanyInfo"].ImportRow(dr);
                }

                rptSalesInvoice_Large rptTest = new Report.rptSalesInvoice_Large();
                rptTest.SetDataSource(ds);
                //rptTest.PrintToPrinter(1, false, 0, 0);
                frmRptv obj = new frmRptv();
                obj.SetReportDataSource = rptTest;
                obj.ShowDialog();
                

            }
            catch
            { }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            //frmSalesInfo obj = new frmSalesInfo();
            
            //obj.ShowDialog();
            //obj.txtInvoiceNo.Text = this.txtInvoiceNumber.Text;
           
        }


    }
}
