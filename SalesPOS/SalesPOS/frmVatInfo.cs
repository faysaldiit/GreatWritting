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
    public partial class frmVatInfo : DevExpress.XtraEditors.XtraForm
    {
        public frmVatInfo()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllVatInfo.getAll();
            this.dgvVatList.AutoGenerateColumns = false;
            this.dgvVatList.DataSource = dt;

        }

        private void frmVatInfo_Load(object sender, EventArgs e)
        {
            LoadGrid();
            this.dgvVatList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvVatList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
