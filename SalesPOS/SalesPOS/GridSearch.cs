using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AARONG_ERP.Classes.Utilities
{
    public partial class GridSearch : UserControl
    {
        /// <summary>
        /// Control Name    : Grid Search
        /// Auther          : Shah Md Faysal
        /// Date            : 06/04/2011
        /// Purpose         : This control help you to search 
        ///                   based on grid collumn.
        /// Propertise      : You have to select Grid
        ///                     1. Source_Grid
        ///                     2. DataSource
        /// </summary>
        /// 
        private DataGridView _Source_Grid = new DataGridView();
        private DataTable _DataSource = new DataTable();

        public DataTable DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        public GridSearch()
        {
            InitializeComponent();
        }
        public DataGridView Source_Grid
        {
            get { return _Source_Grid; }
            set { _Source_Grid = value; }
        }

        public void comboBox_Load_With_CollumnName()
        {
            int i;
            i = _Source_Grid.ColumnCount;
            comboBoxTest.Items.Clear();
            DataTable dType = new DataTable();
            dType.Columns.Add("HeaderText");
            dType.Columns.Add("Name");

            for (int j = 0; j < i; j++)
            {
                if (_Source_Grid.Columns[j].Visible == true)
                {
                    DataRow rw = dType.NewRow();
                    rw["HeaderText"] = _Source_Grid.Columns[j].HeaderText.Trim();
                    rw["Name"] = _Source_Grid.Columns[j].Name;
                    dType.Rows.Add(rw);
                }
            }
            comboBoxTest.DataSource = dType;
            comboBoxTest.DisplayMember = "HeaderText";
            comboBoxTest.ValueMember = "Name";
            if (i > 0)
            {

                comboBoxTest.SelectedIndex = 0;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtFiltered = _DataSource.Copy();
                DataView dv = new DataView();
                dv = dtFiltered.DefaultView;

                if (txtSearch.Text == "")
                {
                    _Source_Grid.DataSource = _DataSource;
                }
                else
                {
                    string abc = comboBoxTest.SelectedValue.ToString().Trim();
                    dv.RowFilter = "" + comboBoxTest.SelectedValue.ToString().Trim() + " Like '" + txtSearch.Text + "%'";
                    _Source_Grid.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void GridSearch_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox_Load_With_CollumnName();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dtFiltered = _DataSource.Copy();
                DataView dv = new DataView();
                dv = dtFiltered.DefaultView;

                if (txtSearch.Text == "")
                {
                    _Source_Grid.DataSource = _DataSource;
                }
                else
                {
                    string abc = comboBoxTest.SelectedValue.ToString().Trim();
                    dv.RowFilter = "" + comboBoxTest.SelectedValue.ToString().Trim() + " Like '" + txtSearch.Text + "%'";
                    _Source_Grid.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}
