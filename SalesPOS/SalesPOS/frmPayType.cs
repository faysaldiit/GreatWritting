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
    public partial class frmPayType : DevExpress.XtraEditors.XtraForm
    {
        public frmPayType()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = bllPayTypeInfo.getAll();
            this.dgvPayTypeList.AutoGenerateColumns = false;
            this.dgvPayTypeList.DataSource = dt;

        }

        private void frmPayType_Load(object sender, EventArgs e)
        {
            LoadGrid();
            this.dgvPayTypeList.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvPayTypeList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
