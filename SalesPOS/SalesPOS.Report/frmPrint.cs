using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SalesPOS.Report
{
   
    public partial class frmPrint : Form
    {
        ReportClass _ireport;
        public frmPrint(ReportClass ireport)
        {
            _ireport = ireport;
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            ReportViewer.ReportSource = _ireport;

        }
    }
}
