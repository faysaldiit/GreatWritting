using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesPOS.Report
{
    public partial class frmRptv : Form
    {
        public frmRptv()
        {
            InitializeComponent();
        }
        public Report.rptSalesInvoice_Large SetReportDataSource
        {
            set
            {
                this.rptvCommon.ReportSource = value;
            }
        }
        //public Report.rptCommissionStatement SetReportDataSource
        //{
        //    set
        //    {
        //        this.rptvCommon.ReportSource = value;
        //    }
        //}
    }
}
