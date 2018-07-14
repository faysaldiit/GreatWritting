using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesPOS.BLL;
using SalesPOS.BOL;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmSalesReturnInfo : DevExpress.XtraEditors.XtraForm
    {
        SalesReturnParent objSalesReturnParent = new SalesReturnParent();
        SalesReturnDetails objSalesReturnDetails = new SalesReturnDetails();

        public frmSalesReturnInfo()
        {
            InitializeComponent();
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtInvoiceNo.TextLength == 14)
            {
                string strinvoiceNo = this.txtInvoiceNo.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllProductSales.GetSalesInvoiceParentInfo(strinvoiceNo);
                if (dt.Rows.Count > 0)
                {
                    txtSalesDate.Text = dt.Rows[0]["SalesDate"].ToString();
                    LoadGrid();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Invoice No.", "Warning");
                    this.txtSalesDate.Text = "";
                    this.txtInvoiceNo.Focus();
                    this.txtInvoiceNo.SelectAll();
                }
            }
        }
        private void LoadGrid()
        {
            dgvSalesGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Test_EditingControlShowing);
            DataTable dt = new DataTable();
            dt = bllProductSales.GetSalesInvoiceDetails(txtInvoiceNo.Text);
            this.dgvSalesGrid.AutoGenerateColumns = false;
            this.dgvSalesGrid.DataSource = dt;
            //this.dgvSalesGrid.Columns[this.dgvSalesGrid.ColumnCount].Visible = false;
        }

        private void Test_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Test_Control_KeyPress);
        }

        private void Test_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumnName = dgvSalesGrid.Columns[dgvSalesGrid.CurrentCell.ColumnIndex].Name;

            if (ColumnName == "ReturnQty")
            {
                if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void frmSalesReturnInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtInvoiceNo;
            ClearAll();
            this.dgvSalesGrid.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvSalesGrid);
        }

        private void dgvSalesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvSalesGrid.Columns[e.ColumnIndex].Name == "ReturnQty")
                {

                    if (GetCellValue(dgvSalesGrid.Rows[e.RowIndex].Cells["ReturnQty"].Value) > GetCellValue(dgvSalesGrid.Rows[e.RowIndex].Cells["SoldQty"].Value))
                    {
                        XtraMessageBox.Show("Return Quantity Must Be Less Than Sale Quantity.");
                        dgvSalesGrid.Rows[e.RowIndex].Cells["ReturnQty"].Value = "0";                    
                    }
                    dgvSalesGrid.Rows[e.RowIndex].Cells["TotalSalesPriceWithVat"].Value = GetCellValue(dgvSalesGrid.Rows[e.RowIndex].Cells["ReturnQty"].Value) * GetCellValue(dgvSalesGrid.Rows[e.RowIndex].Cells["USP"].Value);
                    generate_return_taka();
                        
                }                
            }
        }

        private void generate_return_taka() {
            Double RT = 0;
            for (int i = 0; i < this.dgvSalesGrid.Rows.Count; i++) {

                RT = RT + (GetCellValue(dgvSalesGrid.Rows[i].Cells["ReturnQty"].Value) * GetCellValue(dgvSalesGrid.Rows[i].Cells["USP"].Value));
            }
            this.txtTotal.Text = String.Format("{0:0}", RT);
        }

        private Double GetCellValue(Object Input)
        {
            Double  output = 0;           
            try
            {
                output = Convert.ToDouble(Input);
            }
            catch {
                output = 0;
            }
            return  output;
        }
        private string ConvertTake(string Input)
        {
            if (Input == "")
            {
                Input = "0";
            }
            string output = "";
            output = Input;
            if (Input.IndexOf('.') > -1)
            {
                String[] arry = Input.Split('.');
                output = arry[0];
                if (arry[1] != "")
                    output = output + "." + arry[1];
            }
            return String.Format("{0:0.##}", Convert.ToDouble(output));
        }

        private void dgvSalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSalesGrid.Rows.Count > 0)
            {                    
                if (ValidateReturn())
                {
                    //Execute Sales Process
                    if (SaveDate())
                    {
                        XtraMessageBox.Show("Successfully Save Sales Return transaction.");
                        this.btnSave.Enabled = false;
                        this.btnPrint.Enabled = true;
                    }
                    else { XtraMessageBox.Show("Could not Save Sales Return Transaction"); }
                }
                else { XtraMessageBox.Show("Return Quantity is not found."); }
            }
            else { XtraMessageBox.Show("You have not select any product ror Sales Return."); }                
        }

        private bool ValidateReturn()
        {
            bool isValid = true;
            Double RT = 0;
            for (int i = 0; i < this.dgvSalesGrid.Rows.Count; i++)
            {
                RT = RT + (GetCellValue(dgvSalesGrid.Rows[i].Cells["ReturnQty"].Value));
            }
            if (RT<=0)
            {
                isValid = false;
            }
            return isValid;
        }

        private bool SaveDate()
        {
            /********************************************************
            * Author    : Shah Md. Faysal
            * Date      : 04/07/2011
            * *******************************************************/
            bool isValid = true;
            try
            {
                //Start saving process....
                /********************************************************
                * Save Sales Return Parent & Get Invoice no
                * *******************************************************/
                Initialize_SalesReturn_ParentInfo();
                DataTable dt = bllSalesReturnInfo.InsertSalesReturnParent(objSalesReturnParent,"");
                txtSalesReturnNo.Text = dt.Rows[0]["SalesReturnNo"].ToString();

                /********************************************************
                * Save Sales Return Payment
                * *******************************************************/
                objSalesReturnParent.SalesReturnNo = txtSalesReturnNo.Text;
                bllSalesReturnInfo.InsertSalesReturnPayment(objSalesReturnParent);

                /********************************************************
                * Save Sales Details Info
                * This Process will also update the stock information
                * *******************************************************/
                for (int i = 0; i < dgvSalesGrid.Rows.Count; i++)
                {
                    Initialize_SalesReturn_ChildInfo(i);
                    bllSalesReturnInfo.InsertSalesReturnDetails(objSalesReturnDetails);
                }

                //isValid = true;
            }
            catch (Exception ex)
            {
                isValid = false;
                XtraMessageBox.Show(ex.ToString());
            }
            return isValid;
        }

        private void Initialize_SalesReturn_ParentInfo()
        {
            objSalesReturnParent.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();            
            objSalesReturnParent.InvoiceNo = txtInvoiceNo.Text;
            objSalesReturnParent.SalesReturnNo = txtSalesReturnNo.Text;
            objSalesReturnParent.TotalAmount = txtTotal.Text;
            objSalesReturnParent.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
            objSalesReturnParent.CustomerID = string.Empty;
        }

        private void Initialize_SalesReturn_ChildInfo(int j)
        {
            objSalesReturnDetails.InvoiceNo = txtInvoiceNo.Text;
            objSalesReturnDetails.SalesReturnNo = txtSalesReturnNo.Text;
            objSalesReturnDetails.ProductID = dgvSalesGrid.Rows[j].Cells["ProductID"].Value.ToString().Trim();
            objSalesReturnDetails.ReturnQuantity = dgvSalesGrid.Rows[j].Cells["ReturnQty"].Value.ToString().Trim(); ;
            objSalesReturnDetails.UnitID = dgvSalesGrid.Rows[j].Cells["UnitID"].Value.ToString().Trim(); ;
            objSalesReturnDetails.UnitSalesPrice = dgvSalesGrid.Rows[j].Cells["UnitSalesPrice"].Value.ToString().Trim(); ;            
            objSalesReturnDetails.VatPerchantage = dgvSalesGrid.Rows[j].Cells["VatPerchantage"].Value.ToString().Trim(); ;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            lblAmountInWord.Text= bllUtility.changeCurrencyToWords(txtTotal.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            //this.dgvSalesGrid.Rows.Clear();
            this.txtInvoiceNo.Text = "";
            this.txtSalesReturnNo.Text = "";
            this.txtSalesDate.Text = "";
            this.lblAmountInWord.Text= " Only";
            this.txtTotal.Text = "0.00";            
            this.btnPrint.Enabled = false;
            this.btnSave.Enabled = true;
            this.txtInvoiceNo.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnClose.Enabled = false;
        }
    }
}
//int rowIdex = Convert.ToInt16(e.RowIndex);

//if (dgvSalesGrid.Rows[rowIdex].Cells["ReturnQty"].Value != null)
//{
//    string rtnQty = ConvertTake(dgvSalesGrid.Rows[rowIdex].Cells["ReturnQty"].Value.ToString());
//    string soldQty = dgvSalesGrid.Rows[rowIdex].Cells["ProductQuantity"].Value.ToString();
//    string totalSale = dgvSalesGrid.Rows[rowIdex].Cells["TotalSalesPriceWithVat"].Value.ToString();
//    dgvSalesGrid.Rows[rowIdex].Cells["ReturnQty"].Value = rtnQty;
//    txtTotal.Text = ConvertTake(Convert.ToString((Convert.ToDouble(totalSale) / Convert.ToDouble(soldQty)) * Convert.ToDouble(rtnQty)));
//}