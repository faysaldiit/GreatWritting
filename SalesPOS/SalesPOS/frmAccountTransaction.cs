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
    public partial class frmAccountTransaction : DevExpress.XtraEditors.XtraForm
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        DataTable dtAccTrans = new DataTable();
        AccountTransaction objAccountTransaction = new AccountTransaction();
        private long _ATID = 0;
        private string CashFlowType = "";
        public frmAccountTransaction()
        {
            InitializeComponent();
        }

        private void frmAccountTransaction_Load(object sender, EventArgs e)
        {
            chk_all.Checked = true;
            this.ActiveControl = cmbAccTransType;
            lbl_total_balance.Text = "0.00";
            ClearAll();
            LoadGrid();
            LoadMasterTransactionType();
            LoadTransactionType(cmb_master_head.SelectedValue.ToString());
            this.dgvAccountTransaction.DefaultCellStyle.ForeColor = Color.Black;
            bllUtility.ResetGridColor(dgvAccountTransaction);
            InitializeReason();
            load_cash_n_bank_balance();
            load_bank_list();
            
        }

        private void load_bank_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.PopulateBankList");
            cmb_bank.Properties.DisplayMember = "Bank";
            cmb_bank.Properties.ValueMember = "AccountNo";
            cmb_bank.Properties.DataSource = dt;
        }

        private void load_cash_n_bank_balance()
        {
            DataTable dt=bllUtility.GetDataBySP("get_cash_n_bank_closing_amount");
            grd_bank_balance.DataSource = dt;

            double total_balance =Convert.ToDouble(dt.Compute("Sum(Balance)", "").ToString());
            lbl_total_balance.Text = Math.Round(total_balance,0).ToString();
        }

        private void InitializeReason()
        {
            DataTable dt = new DataTable();
            dt = bllAccountTransaction.getReason();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesCollection.Add(dt.Rows[i][0].ToString());
            }

            txtDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDescription.AutoCompleteCustomSource = namesCollection;
        }

        private void LoadTransactionType(string MasterHead)
        {
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData("USP_AccountTransInfoForMiniAcc '" + MasterHead + "'");
            this.cmbAccTransType.DisplayMember = "TransactionType";
            this.cmbAccTransType.ValueMember = "AccTypeID";
            this.cmbAccTransType.DataSource = dt;
        }
        private void LoadMasterTransactionType()
        {
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData("[USP_AccountMasterTransInfoForMiniAcc]");
            this.cmb_master_head.DisplayMember = "AccountHead";
            this.cmb_master_head.ValueMember = "AccountHead";
            this.cmb_master_head.DataSource = dt;
        }

        private void LoadData(long selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllAccountTransaction.getById(selectedID);
            this.txtAtid.Text = dt.Rows[0]["ATID"].ToString();
            this.txtAccountNo.Text = dt.Rows[0]["AccountNo"].ToString();
            this.txtAccountHolder.Text = dt.Rows[0]["AccHolderName"].ToString();
            

            DataTable dt1 = bllAccountTransaction.GetTransactionType(Convert.ToInt64(dt.Rows[0]["ATTID"].ToString()));
            if (dt1.Rows[0]["DrCr"].ToString() == "Debit")
            {
                this.txtAmount.Text = dt.Rows[0]["Debit"].ToString();
            }
            else
            {
                this.txtAmount.Text = dt.Rows[0]["Credit"].ToString();
            }

            this.txtDescription.Text = dt.Rows[0]["Description"].ToString();
            this.txtRef.Text = dt.Rows[0]["RefNo"].ToString();
            this.dtpTransactionDate.Value = Convert.ToDateTime(dt.Rows[0]["TransactionDate"]);
            cmb_master_head.SelectedValue = dt.Rows[0]["AccountHead"].ToString();
            this.cmbAccTransType.SelectedValue = Convert.ToInt64(dt.Rows[0]["ATTID"].ToString());
        }

        private void ClearAll()
        {
            txtAccountNoSearch.Text = "";
            txtSearchAccNo.Text = "";
            cmbAccTransTypeSearch.DataSource = null;
            cmbRecordType.Text = "Both";
            chkTransactionType.Checked = false;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            dgvAccountTransaction.DataSource = null;
        }

        private void ClearFields()
        {
            lbl_total_balance.Text = "";
            chk_deposit_to_bank.Checked = false;
            chk_deposit_to_bank.Enabled = true;
            //txtAccountHolder.Text = "";
            //txtAccountNo.Text = "";
            txtAmount.Text = "";
            txtAtid.Text = "";
            txtDescription.Text = "";
            txtRef.Text = "";
            //lblDrCr.Text = "Amount :";
            //dtpTransactionDate.Value = DateTime.Now;            
            //this.lblDrCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //txtAccountNo.Focus();
            CashFlowType = "";
            txtRefSearch.Text = "";
        }
        private void LoadGrid()
        {
            if (chk_all.Checked == false)
            {
                if (txtAccountNoSearch.Text == "")
                {
                    XtraMessageBox.Show("Account No selection required!");
                    return;
                }
            }
            InitializeSearchValue();
            dtAccTrans = bllAccountTransaction.GetAccTransDetails(objAccountTransaction, txtAmountTo.Text);
            this.dgvAccountTransaction.AutoGenerateColumns = false;
            this.dgvAccountTransaction.DataSource = dtAccTrans;
            lblRecordCount.Text = dtAccTrans.Rows.Count.ToString();
        }

        private void chkTransactionType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransactionType.Checked == true)
            {
                DataTable dt = new DataTable();
                dt = bllAccountTransactionType.GetAccountTransInfoForMiniAcc();
                this.cmbAccTransTypeSearch.DisplayMember = "TransactionType";
                this.cmbAccTransTypeSearch.ValueMember = "AccTypeID";
                this.cmbAccTransTypeSearch.DataSource = dt;
            }
            else
            {
                this.cmbAccTransTypeSearch.DataSource = null;
            }

        }

        private void dgvAccountTransaction_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (Convert.ToInt32(e.RowIndex) == -1)
            //{ }
            //else
            //{
            //    if (XtraMessageBox.Show("Do you want to modify the record? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        return;

            //    DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
            //    try
            //    {
            //        long ATID = 0;
            //        long ATTID = 0;
            //        ATID = Convert.ToInt64(dr.Cells[0].Value);
            //        ATTID = Convert.ToInt64(dr.Cells["ATTID"].Value);
            //        this._ATID = ATID;
            //        if (Convert.ToBoolean(dr.Cells["IsEditable"].Value) == true)
            //        {
            //            LoadData(_ATID);
            //            txtAccountNo.Focus();
            //            txtAccountNo.SelectAll();
            //        }
            //        else
            //        {
            //            ClearFields();
            //            txtAmount.BackColor = Color.White;
            //            txtAmount.ForeColor = Color.Black;
            //            //XtraMessageBox.Show("You can not modify this record.","Warning Message.");
            //        }
            //        chk_deposit_to_bank.Enabled = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.ToString());
            //    }
            //}
        }

        private void SetTextLabeColor(DataTable dt)
        {
            this.lblDrCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lblDrCr.Text = dt.Rows[0]["DrCr"].ToString();
            if (dt.Rows[0]["CashFlow"].ToString() == "Inlay")
            {
                txtAmount.BackColor = Color.Green;
                txtAmount.ForeColor = Color.White;
            }
            else if (dt.Rows[0]["CashFlow"].ToString() == "Outlay")
            {
                txtAmount.BackColor = Color.Red;
                txtAmount.ForeColor = Color.White;
            }
            else if (dt.Rows[0]["CashFlow"].ToString() == "Impartial")
            {
                txtAmount.BackColor = Color.White;
                txtAmount.ForeColor = Color.Black;
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearFields();
            load_cash_n_bank_balance();
            cmbAccTransType.Focus();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadGrid();
            load_cash_n_bank_balance();
        }

        private void InitializeSearchValue()
        {
            if (chk_all.Checked)
                objAccountTransaction.SearchAccountNo = "";
            else
                objAccountTransaction.SearchAccountNo = txtAccountNoSearch.Text;

            if (chkTransactionType.Checked == true)
            {
                objAccountTransaction.SearchATTID = cmbAccTransTypeSearch.SelectedValue.ToString();
            }
            else
            {
                objAccountTransaction.SearchATTID = string.Empty;
            }
            objAccountTransaction.SearchDateFrom = dtpFrom.Value.ToString("dd/MM/yyyy");
            objAccountTransaction.SearchDateTo = dtpTo.Value.ToString("dd/MM/yyyy");
            objAccountTransaction.SearchIsEditable = cmbRecordType.Text;
            objAccountTransaction.SearchRef = txtRefSearch.Text;
            objAccountTransaction.SearchAmount = txtAmountFrom.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmbAccTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            long ATTID = 0;
            ATTID = Convert.ToInt64(cmbAccTransType.SelectedValue);
            DataTable dt = bllAccountTransaction.GetTransactionType(ATTID);
            if (dt.Rows[0]["CashFlow"].ToString().ToUpper() == "Impartial".ToUpper())
            {
                chk_deposit_to_bank.Visible = false;
                cmb_bank.Visible = false;
            }
            else
            {                
                chk_deposit_to_bank.Visible = true;
                cmb_bank.Visible = true;
                chk_deposit_to_bank.Checked = false;

            }
            SetTextLabeColor(dt);
            txtAmount.Focus();
            CashFlowType = dt.Rows[0]["CashFlow"].ToString();
            if (CashFlowType.ToUpper() == "Inlay".ToUpper())
                chk_deposit_to_bank.Text = "To Bank";
            else if (CashFlowType.ToUpper() == "Outlay".ToUpper())
                chk_deposit_to_bank.Text = "From Bank";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    InitializeDataForSave();
                    SaveData();
                    LoadGrid();
                    load_cash_n_bank_balance();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void InitializeDataForSave()
        {
            this.lblDrCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            objAccountTransaction.AccountHolderID = txtAccountNo.Text;
            objAccountTransaction.ATID = txtAtid.Text;
            objAccountTransaction.ATTID = cmbAccTransType.SelectedValue.ToString();
            objAccountTransaction.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
            //if (lblDrCr.Text == "Debit")
            //{
            objAccountTransaction.Debit = txtAmount.Text;
            //    objAccountTransaction.Credit = "0.00";
            //}
            //else 
            //{
            //    objAccountTransaction.Credit = txtAmount.Text;
            //    objAccountTransaction.Debit = "0.00";
            //}            

            objAccountTransaction.Description = txtDescription.Text;
            objAccountTransaction.RefNo = txtRef.Text;
            objAccountTransaction.TransactionDate = dtpTransactionDate.Value.ToString();
            objAccountTransaction.TerminalID = bllUtility.LoggedInSystemInformation.TerminalID.ToString();
        }

        private void SaveData()
        {
            if (txtAtid.Text == "")
            {
                DataTable dt_cashflow = bllAccountTransaction.GetTransactionType(Convert.ToInt64(cmbAccTransType.SelectedValue));
                CashFlowType = dt_cashflow.Rows[0]["CashFlow"].ToString();
                //Insert Data
                DataTable dt = new DataTable();
                dt = bllAccountTransaction.InsertData(objAccountTransaction);
                if (dt.Rows.Count > 0)
                {
                    if (chk_deposit_to_bank.Checked)
                    {
                        if (CashFlowType.ToUpper() == "INLAY")
                        {
                            if (Convert.ToDouble(txtAmount.Text) > 0)
                                bllProductSales.InsertAccountTransactionBySystem("Bank Deposit", txtAmount.Text, txtRef.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), cmb_bank.EditValue.ToString(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), objAccountTransaction.TransactionDate,1);
                        }
                        else if (CashFlowType.ToUpper() == "OUTLAY")
                        {
                            if (Convert.ToDouble(txtAmount.Text) > 0)
                                bllProductSales.InsertAccountTransactionBySystem("Bank Cash Withdrawn", txtAmount.Text, txtRef.Text, txtDescription.Text, bllUtility.LoggedInSystemInformation.TerminalID.ToString(), cmb_bank.EditValue.ToString(), bllUtility.LoggedInSystemInformation.LoggedUserId.ToString(), objAccountTransaction.TransactionDate,1);
                        }
                    }
                    XtraMessageBox.Show("Data Saved Successfully..", "Successfull Message");
                    txtAtid.Text = dt.Rows[0]["ATID"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("Error found", "Error Message");
                }
            }
            else
            {
                //Update Data
                bool chk = bllAccountTransaction.UpdateData(objAccountTransaction);
                if (chk == true)
                {
                    XtraMessageBox.Show("Data Edited Successfully..", "Successfull Message");
                }
                else
                {
                    XtraMessageBox.Show("Error found", "Error Message");
                }
            }
        }

        private bool IsValidData()
        {
            bool isValid = true;
            if (this.txtAccountNo.Text == "")
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Account No", "Warning");
                this.txtAccountNo.Focus();
            }
            else if (this.txtAmount.Text == "")
            {
                isValid = false;
                XtraMessageBox.Show("Please Enter Amount", "Warning");
                this.txtAmount.Focus();
            }
            else if (this.txtDescription.Text == "")
            {
                this.txtDescription.Text = "N/A";
            }
            return isValid;
        }

        private void txtAccountNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtAccountNo.TextLength == 14)
            {
                string strAccountNo = txtAccountNo.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNo, "");
                if (dt.Rows.Count > 0)
                {
                    txtAccountHolder.Text = dt.Rows[0]["AccHolderName"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Account Holder.", "Warning");
                    txtAccountHolder.Text = "";
                    txtAccountNo.Focus();
                    txtAccountNo.SelectAll();
                }
            }
        }

        private void txtAccountNoSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.txtAccountNoSearch.TextLength == 14)
            {
                string strAccountNoSearch = txtAccountNoSearch.Text.ToUpper();
                //txtAccountNoSearch.Text = txtAccountNoSearch.Text.ToUpper();
                DataTable dt = new DataTable();
                dt = bllAccountHolderInfo.GetAccountHolderInfo(strAccountNoSearch, "");
                if (dt.Rows.Count > 0)
                {
                    txtAccountHolderSearch.Text = dt.Rows[0]["AccHolderName"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Account Holder.", "Warning");
                    txtAccountHolderSearch.Text = "";
                    txtAccountNoSearch.Focus();
                    txtAccountNoSearch.SelectAll();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchAccNo_Click(object sender, EventArgs e)
        {
            //frmCustomerSearch obj = new frmCustomerSearch(0);
            //obj.ShowDialog();
            //this.txtAccountHolder.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            //this.txtAccountNo.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            ////clearing global search object.
            //bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

            frmCustomerSearchNew obj = new frmCustomerSearchNew();
            obj.ShowDialog();

            this.txtAccountHolder.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtAccountNo.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;
            
            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

        }

        private void dgvAccountTransaction_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cmb_master_head_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_master_head.SelectedValue.ToString() == null || cmb_master_head.SelectedValue.ToString() == "")
                return;
            LoadTransactionType(cmb_master_head.SelectedValue.ToString());

            cmbAccTransType.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void chk_deposit_to_bank_CheckedChanged(object sender, EventArgs e)
        {
            cmb_bank.Enabled = chk_deposit_to_bank.Checked;
        }

        private void dgvAccountTransaction_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvAccountTransaction.Rows[e.RowIndex].Cells["IsEditable"].Value.ToString() == "False")
            {
                dgvAccountTransaction.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void dgvAccountTransaction_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            { }
            else
            {
                if (XtraMessageBox.Show("Do you want to modify the record? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                if (bllUtility.LoggedInSystemInformation.UserName.ToUpper() == "Admin".ToUpper() || bllUtility.LoggedInSystemInformation.UserName.ToUpper() == "Administrator".ToUpper())
                {
                    DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                    try
                    {
                        long ATID = 0;
                        long ATTID = 0;
                        ATID = Convert.ToInt64(dr.Cells[0].Value);
                        ATTID = Convert.ToInt64(dr.Cells["ATTID"].Value);
                        this._ATID = ATID;
                        if (Convert.ToBoolean(dr.Cells["IsEditable"].Value) == true)
                        {
                            LoadData(_ATID);
                            txtAccountNo.Focus();
                            txtAccountNo.SelectAll();
                        }
                        else
                        {
                            ClearFields();
                            load_cash_n_bank_balance();
                            txtAmount.BackColor = Color.White;
                            txtAmount.ForeColor = Color.Black;
                            //XtraMessageBox.Show("You can not modify this record.","Warning Message.");
                        }
                        chk_deposit_to_bank.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    XtraMessageBox.Show("You don't have permission for modify.");
                    return;
                }
            }
        }

        private void btn_search_account_Click(object sender, EventArgs e)
        {
            //frmCustomerSearchNew obj = new frmCustomerSearchNew();
            //obj.ShowDialog();

            //this.txtAccountHolderSearch.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            //this.txtAccountNoSearch.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;
            ////cmb_zone.EditValue = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.ZoneID.ToString();
            ////clearing global search object.
            //bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

            frmCustomerSearchNew obj = new frmCustomerSearchNew();
            obj.ShowDialog();

            this.txtAccountHolderSearch.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            this.txtAccountNoSearch.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //clearing global search object.
            bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;

        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {           
            if (chk_all.Checked)
            {                
                txtAccountNoSearch.Enabled = false;
                txtAccountHolderSearch.Enabled = false;
                btn_search_account.Enabled = false;
            }
            else
            {                
                txtAccountNoSearch.Enabled = true;
                txtAccountHolderSearch.Enabled = true;
                btn_search_account.Enabled = true;
            }
        }

        private void dtpTransactionDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvAccountTransaction_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void txtAmountSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmountTo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lnkAccountTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAccountTransactionDouble obj = new frmAccountTransactionDouble();
            obj.ShowDialog();
        }

    }
}
