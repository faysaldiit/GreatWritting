using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
namespace SalesPOS
{
   public class ja_grid : System.Windows.Forms.DataGridView
    {
        DataTable MyDataTable = new DataTable();

        private int _currentRowIndex;
        public int CurrentRowIndex
        {
            get { return _currentRowIndex; }
            set { _currentRowIndex = value; }
        }
      
        public ja_grid()
        : base()
        {
            //set the edit mode to "on enter" so that when a cell gains focus 
            //it automatically enters editing mode
            this.EditMode = DataGridViewEditMode.EditOnKeystroke;            
            this.CellEnter += new DataGridViewCellEventHandler(DataGridViewEx_CellEnter);             
        }
        public bool CheckDuplicateValue(int iColumn, int iCurrentRowIndex, string iSearchValue)
        {
            try
            {
                int intRowCount = 0;
                foreach (DataRow validRow in MyDataTable.Rows)
                {
                    if (intRowCount != iCurrentRowIndex)
                    {
                        if (validRow[iColumn].ToString().Trim().ToUpper() == iSearchValue.ToString().Trim().ToUpper())
                        {
                            return true;
                        }
                    }
                    intRowCount++;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return false;
        }

        public void SetFixedColumn(int NumberofColumns)
        {
            for (int i = 0; i <= NumberofColumns; i++)
            {
                FixedColumn(this.Columns[NumberofColumns - 1]);
            }
        }

        private static void FixedColumn(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Wheat;
            band.DefaultCellStyle = style;
        }

        private void DataGridViewEx_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Columns[this.CurrentCell.ColumnIndex].ReadOnly == false)
            {
                this.BeginEdit(true);
            }            
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return true;
            }
            else
            {
                var key = new KeyEventArgs(keyData);
                //ShortcutKey(this, key);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

     

    }

