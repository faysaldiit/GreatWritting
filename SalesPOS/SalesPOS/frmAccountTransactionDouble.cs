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
using System.Web;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmAccountTransactionDouble : DevExpress.XtraEditors.XtraForm
    {
        public frmAccountTransactionDouble()
        {
            InitializeComponent();
        }

        private void frmAccountTransactionDouble_Load(object sender, EventArgs e)
        {
            clear_all();
        }

        private void txtSearchAccNo_Click(object sender, EventArgs e)
        {
            frmCustomerSearchNew obj = new frmCustomerSearchNew();
            obj.ShowDialog();

            this.txtAccountHolder_CashRecv.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtAccountNo_CashRecv.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;
        }

        private void txtSearchAccNo_CashPaid_Click(object sender, EventArgs e)
        {
            frmCustomerSearchNew obj = new frmCustomerSearchNew();
            obj.ShowDialog();

            this.txtAccountHolder_CashPaid.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtAccountNo_CashPaid.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;
        }

        private void clear_all()
        {
            dtpTransactionDate.Value = DateTime.Now;
            txtAmount.Text = "";
            txtDescription.Text = "";
            txtRef.Text = "";
            txtAccountNo_CashRecv.Text = "";
            txtAccountHolder_CashRecv.Text = "";
            txtAccountNo_CashPaid.Text = "";
            txtAccountHolder_CashPaid.Text = "";
          
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            clear_all();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAccountHolder_CashRecv_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtAccountHolder_CashPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string transaction_date = Convert.ToDateTime(dtpTransactionDate.Value.ToString()).ToString("dd/MM/yyyy");
            if (bllUtility.Val(txtAmount.Text) < 1)
            {
                XtraMessageBox.Show("Enter Amount");
                txtAmount.Focus();
                return;
            }
            if (txtAccountNo_CashPaid.Text == "")
            {
                XtraMessageBox.Show("Enter Account No");
                txtAccountNo_CashPaid.Focus();
                return;
            }
            if (txtAccountNo_CashRecv.Text == "")
            {
                XtraMessageBox.Show("Enter Acco unt No");
                txtAccountNo_CashRecv.Focus();
                return;
            }

            bllProductSales.InsertAccountTransactionBySystem("Cash Recv", txtAmount.Text, txtRef.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), txtAccountNo_CashRecv.Text, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), transaction_date, 1);
            bllProductSales.InsertAccountTransactionBySystem("Cash Paid", txtAmount.Text, txtRef.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), txtAccountNo_CashPaid.Text, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), transaction_date, 1);

            XtraMessageBox.Show("Data Saved Successfully.");
            btnSave.Enabled = false;
        }

        private void txtAccountNo_CashRecv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}