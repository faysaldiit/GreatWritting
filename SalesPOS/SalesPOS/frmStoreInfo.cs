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
    public partial class frmStoreInfo : DevExpress.XtraEditors.XtraForm
    {
        public frmStoreInfo()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllStoreInfo.getAll();
            this.dgvStoreList.AutoGenerateColumns = false;
            this.dgvStoreList.DataSource = dt;

        }

        private void frmStoreInfo_Load(object sender, EventArgs e)
        {
            LoadGrid();
            this.dgvStoreList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvStoreList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
