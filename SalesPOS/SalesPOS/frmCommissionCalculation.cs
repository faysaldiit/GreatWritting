using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using SalesPOS.BOL;
using SalesPOS.BLL;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using SalesPOS.Report;

namespace SalesPOS
{
    public partial class frmCommissionCalculation : DevExpress.XtraEditors.XtraForm
    {
        bool is_new = false;
        public frmCommissionCalculation()
        {
            InitializeComponent();
        }

        private void frmCommissionCalculation_Load(object sender, EventArgs e)
        {
            bllSecurityInfo.SoftDefaultSetting();
            DataTable dt_account_holder = bllCommissionCalc.get_account_holder("Distributor");
            cmb_account_holder.Properties.DisplayMember = "AccHolderName";
            cmb_account_holder.Properties.ValueMember = "AccountNo";
            cmb_account_holder.Properties.DataSource = dt_account_holder;
        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            //frmCustomerSearch obj = new frmCustomerSearch(0);
            //obj.ShowDialog();
            //this.txtAccountHolder.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccHolderName; //test code rasel
            //this.txtAccountNo.Text = bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo.AccountNo;

            //bllUtility.ReturnSearchedAccountHolderInfo.returnSearchedAccountHolderInfo = null;
            if (cmb_account_holder.EditValue == null)
            {
                XtraMessageBox.Show("Account holder selection required!");
                cmb_account_holder.Focus();
                return;
            }
            txtAccountHolder.Text = cmb_account_holder.Properties.View.GetFocusedDataRow()["AccHolderName"].ToString();
            grid_populate();
        }

        private void grid_populate()
        {
            grd_ctl_details.DataSource = null;
            if (cmb_account_holder.EditValue ==null)
            {
                XtraMessageBox.Show("Please select account no");
                cmb_account_holder.Focus();
                return;
            }
            DataTable dt_details = bllCommissionCalc.get_commission_adjustment_due_details(cmb_account_holder.EditValue.ToString());
            grd_ctl_details.DataSource = dt_details;
        }

        private void txtProductCodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            grd_ctl_details.DataSource = null;
            if (e.KeyCode == Keys.Enter)
            {
                get_sale_qty();
                get_adjustment_due();
                calc_n_set_adjust_qty();
            }

        }

        private void get_sale_qty()
        {
            //if (txtAccountHolder.Text.Length < 3)
            //{
            //    MessageBox.Show("Please select account no");
            //    txtAccountNo.Focus();
            //    return;
            //}
            //if (txtProductName.Text.Length < 3)
            //{
            //    MessageBox.Show("Please enter a valid product code");
            //    txtProductCodeSearch.Focus();
            //    return;
            //}
            //if (txt_closing_stock.Text == "")
            //{
            //    txt_closing_stock.Text = "0";
            //    txt_closing_stock.Refresh();
            //}
            //DataTable dt_pending_sale_qty = bllCommissionCalc.get_pending_sale_qty(txtAccountNo.Text, txtProductCodeSearch.Text);
            //if (dt_pending_sale_qty != null && dt_pending_sale_qty.Rows.Count > 0)
            //{
            //    txt_sale_qty.Text = (Convert.ToDecimal(dt_pending_sale_qty.Rows[0]["total_sale_pending_qty"]) - Convert.ToDecimal(txt_closing_stock.Text)).ToString();
            //}
        }

        private void get_adjustment_due()
        {
            //if (txtAccountHolder.Text.Length < 3)
            //{
            //    MessageBox.Show("Please select account no");
            //    txtAccountNo.Focus();
            //    return;
            //}
            //if (txtProductName.Text.Length < 3)
            //{
            //    MessageBox.Show("Please enter a valid product code");
            //    txtProductCodeSearch.Focus();
            //    return;
            //}
            //if (txt_closing_stock.Text == "")
            //    txt_closing_stock.Text = "0";
            //DataTable dt_adjustment_details = bllCommissionCalc.get_commission_adjustment_due_details(txtAccountNo.Text, txtProductCodeSearch.Text);
            //if (dt_adjustment_details != null && dt_adjustment_details.Rows.Count > 0)
            //{
            //    grd_ctl_details.DataSource = dt_adjustment_details;
            //}
        }

        private void calc_n_set_adjust_qty()
        {
            if (txt_sale_qty.Text == "")
                txt_sale_qty.Text = "0";
            decimal sale_qty = Convert.ToDecimal(txt_sale_qty.Text);
            DataTable dt_source = grd_ctl_details.DataSource as DataTable;
            if (dt_source == null || dt_source.Rows.Count < 1)
            {
                grd_ctl_details.DataSource = dt_source;
                return;
            }

            foreach (DataRow row in dt_source.Rows)
            {
                if (sale_qty > 0)
                {
                    if (Convert.ToDecimal(row["AdjustmentDueQty"]) < sale_qty)
                    {
                        row["AdjustmentQty"] = row["AdjustmentDueQty"];
                        sale_qty = sale_qty - Convert.ToDecimal(row["AdjustmentDueQty"]);
                    }
                    else
                    {
                        row["AdjustmentQty"] = sale_qty;
                        sale_qty = 0;
                    }
                }
            }
            grd_ctl_details.DataSource = dt_source;
        }

        private void calc_n_set_commission_amount()
        {
            //DataTable dt_source = grd_ctl_details.DataSource as DataTable;
            //foreach (DataRow row in dt_source.Rows)
            //{
            //    row["sale_amount"] = Math.Round(Convert.ToDecimal(row["AdjustmentQty"]) * Convert.ToDecimal(row["avg_rate"]), 2, MidpointRounding.AwayFromZero);
            //    if (row["commission_percent"].ToString() == "0")
            //        row["commission_amount"] = 0;
            //    else
            //        row["commission_amount"] = Math.Round((Convert.ToDecimal(row["sale_amount"]) * Convert.ToDecimal(row["commission_percent"])) / 100, 2, MidpointRounding.AwayFromZero);
            //}
            //grd_ctl_details.DataSource = dt_source;
        }

        private void txt_closing_stock_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text.Length > 5)
            {
                get_sale_qty();
                get_adjustment_due();
                calc_n_set_adjust_qty();
            }
        }

        private void txtAccountHolder_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text.Length > 5)
            {
                get_sale_qty();
                get_adjustment_due();
                calc_n_set_adjust_qty();
            }
        }

        private void dgvAdjustmentDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grd_view_details.Columns[e.ColumnIndex].Name == "AdjustmentQty")
            {
                calc_n_set_commission_amount();
            }
        }

        private void txt_commission_percent_TextChanged(object sender, EventArgs e)
        {
            DataTable dt_source = grd_ctl_details.DataSource as DataTable;
            if (dt_source == null || dt_source.Rows.Count < 1) return;
            if (txt_commission_percent.Text == "")
            {
                txt_commission_percent.Text = "0";
                txt_commission_percent.Refresh();
            }
            foreach (DataRow row in dt_source.Rows)
            {
                row["commission_percent"] = txt_commission_percent.Text;
            }
            calc_n_set_commission_amount();
        }

        private void clear_form()
        {
            //cmb_account_holder.EditValue = null;
            is_new = true;
            txt_sale_qty.Text = "0";
            txtProductName.Text = "";
            txtProductCodeSearch.Text = "";
            cmb_account_holder.EditValue  = null;
            txtAccountHolder.Text = "";
            txt_closing_stock.Text = "0";
            is_new = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cmb_account_holder.Focus();
            DataTable dt_source = grd_ctl_details.DataSource as DataTable;
            if (dt_source == null || dt_source.Rows.Count < 1)
            {
                XtraMessageBox.Show("No Data Found to Save.");
                return;
            }

            if (cmb_account_holder.EditValue == null)
            {
                XtraMessageBox.Show("Please select account no");
                cmb_account_holder.Focus();
                return;
            }

            
            string AccountNo = cmb_account_holder.EditValue.ToString();

            CommissionCalc obj_parent = new CommissionCalc();
            obj_parent.AccountNo = AccountNo;
            obj_parent.CommissionCalcDate = Convert.ToDateTime(dtpSalesDt.Value).ToString("dd/MM/yyyy");
            string created_by = bllUtility.LoggedInSystemInformation.LoggedUserId.ToString();
            string id = bllCommissionCalc.Insert_parent(obj_parent, created_by).ToString();

            if (id.Length < 4)
            {
                XtraMessageBox.Show("Data could not save. Please try again.");
                return;
            }

            //obj_parent.CommissionCalcID = id;
            //obj_parent.ProductCode = txtProductCodeSearch.Text;
            //obj_parent.ClossingQty = Convert.ToDecimal(txt_closing_stock.Text);
            //obj_parent.CalcDate = dtpSalesDt.Value.ToString("dd/mm/yyyy");
            //obj_parent.IsLastClossing = 1;
            //bllCommissionCalc.Insert_clossing_qty(obj_parent);

            CommissionCalc obj_child;
            foreach (DataRow row in dt_source.Rows)
            {
                //if (Convert.ToDecimal(row["AdjustmentQty"]) > 0)
                //{
                obj_child = new CommissionCalc();
                obj_child.CommissionCalcID = id;
                obj_child.AccountNo = AccountNo;
                //obj_child.InvoiceNo = row["InvoiceNo"].ToString();
                obj_child.ProductCode = row["ProductID"].ToString();
                obj_child.ClossingQty = Convert.ToDecimal(row["ClosingQty"]);
                //obj_child.AverageRate = Convert.ToDecimal(row["avg_rate"]);
                obj_child.CommissionPercent = Convert.ToDecimal(row["commission_percent"]);
                obj_child.CalcDate = Convert.ToDateTime(dtpSalesDt.Value).ToString("dd/MM/yyyy");
                //obj_child.CommissionAmount = Convert.ToDecimal(row["commission_amount"]);
                bllCommissionCalc.Insert_commission_child(obj_child);
                //}
            }
            decimal commissionAmount = 0;
            DataTable dt_commission_amount = bllReportUtility.ReportData("get_commission_amount '" + id + "'");
            if (dt_commission_amount.Rows.Count > 0)
            {
                commissionAmount = Convert.ToDecimal(dt_commission_amount.Rows[0][0].ToString());
            }

            //if (commissionAmount > 0)
            //    bllProductSales.InsertAccountTransactionBySystem("Commission", commissionAmount.ToString(), id.ToString(), bllUtility.LoggedInSystemInformation.TerminalID.ToString(), AccountNo, bllUtility.LoggedInSystemInformation.LoggedUserId.ToString());


            if (chk_closing_stock.Checked)
            {
                bllCommissionCalc.insert_closing_stock_commission_wise(id, cmb_closing_stock_id.EditValue.ToString());
            }

            btnSave.Enabled = false;
            lbl_commission_amount.Text = commissionAmount.ToString();
            txt_commission_id.Text = id.ToString();
            XtraMessageBox.Show("Saved successfully");
            //clear_form();
        }

        private void btn_product_search_Click(object sender, EventArgs e)
        {
            frmProductSearch obj = new frmProductSearch();
            obj.ShowDialog();
            this.txtProductName.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductName; //test code rasel
            this.txtProductCodeSearch.Text = bllUtility.ReturnSearchedProduct.returnSearchedProductInfo.ProductID;

            //clearing global search object.
            bllUtility.ReturnSearchedProduct.returnSearchedProductInfo = null;
            txt_commission_percent.Text = "8";
            if (txtProductName.Text.Length > 3 && txtAccountHolder.Text.Length > 3)
            {
                get_sale_qty();
                get_adjustment_due();
                calc_n_set_adjust_qty();
            }
        }

        private void txt_closing_stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_sale_qty();
                get_adjustment_due();
                calc_n_set_adjust_qty();
            }
        }

        private void grd_view_details_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "AdjustmentQty" || e.Column.FieldName == "commission_percent")
            {
                calc_n_set_commission_amount();
            }
        }

        private void grd_view_details_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = grd_view_details.GetFocusedDataRow();
            if (Convert.ToDecimal(row["AdjustmentQty"]) > Convert.ToDecimal(row["AdjustmentDueQty"]))
            {
                e.ErrorText = "Adjustment Qty can not be greater than adjustment Due Qty";
                e.Valid = false;
            }
            else if (Convert.ToDecimal(row["AdjustmentQty"]) < 0)
            {
                e.ErrorText = "Adjustment Qty can not be negative";
                e.Valid = false;
            }
            else e.Valid = true;
        }

        private void txt_closing_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allow_keys = "0123456789." + '\b';
            if (allow_keys.IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }

        private void txt_commission_percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allow_keys = "0123456789." + '\b';
            if (allow_keys.IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }

        private void grd_view_details_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "ClosingQty") return;
            DataRow row = grd_view_details.GetFocusedDataRow();
            row["isedited"] = 1;
            row["AdjustmentQty"] = Math.Round(Convert.ToDecimal(row["AdjustmentDueQty"]) - Convert.ToDecimal(row["ClosingQty"]), 2, MidpointRounding.AwayFromZero);
        }

        private void grd_view_details_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (grd_view_details.GetDataRow(e.RowHandle)["isedited"].ToString() == "1")
            {
                e.Appearance.BackColor = Color.AntiqueWhite;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            grd_ctl_details.DataSource = null;
            cmb_account_holder.EditValue = null;
            btnSave.Enabled = true;
            lbl_commission_amount.Text = "";
            txt_commission_id.Text = "";

            chk_closing_stock.Checked = false;

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_load(string form_name)
        {
            string str = "SalesPOS." + form_name;
            Type tpfrm = Type.GetType(str);
            if (tpfrm != null)
            {
                Form obj = (Form)Activator.CreateInstance(tpfrm);
                //obj.Text = caption;

                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.GetType() == obj.GetType())
                    {
                        frm.Focus();
                        return;
                    }
                }
                obj.MdiParent = (Form)this.Parent;
                obj.Dock = DockStyle.Fill;
                obj.Show();
            }
        }

        private void btn_commission_details_view_Click(object sender, EventArgs e)
        {
            string account_number = "";
            if (cmb_account_holder.EditValue == null || cmb_account_holder.EditValue.ToString() == "")
                account_number = "";
            else account_number = cmb_account_holder.EditValue.ToString();

            frmCommissionDetailsView obj = new frmCommissionDetailsView(txt_commission_id.Text, account_number);
            obj.ShowDialog();
            //form_load("frmCommissionDetailsView");
        }

        private void chk_closing_stock_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_closing_stock.Checked == true)
                link_closing_stock_import.Enabled = true;
            else
                link_closing_stock_import.Enabled = false;
        }

        public class ClosingStock
        {
            public string ClosingStockID { get; set; }
            public string DealerID { get; set; }
            public string Year { get; set; }
            public string Month { get; set; }
            public string ProductID { get; set; }
            public string Quantity { get; set; }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                //closing stock import
                DataTable dt_closing_stock = bllUtility.generate_datetable("ClosingStockID,DealerID,Year,Month,ProductID,Quantity");
                var url_closing_stock = bllUtility.DefaultSettings.Api_link + "get_closing_stock/";
                var w_closing_stock = new WebClient();
                var json_data_closing_stock = string.Empty;
                this.Cursor = Cursors.WaitCursor;
                json_data_closing_stock = w_closing_stock.DownloadString(url_closing_stock);
                this.Cursor = Cursors.Default;
                var machine_closing_stock = JsonConvert.DeserializeObject<List<ClosingStock>>(json_data_closing_stock);

                foreach (var data in machine_closing_stock)
                    dt_closing_stock.Rows.Add(data.ClosingStockID, data.DealerID, data.Year, data.Month, data.ProductID, data.Quantity);

                for (int i = 0; i < dt_closing_stock.Rows.Count; i++)
                {
                    bllRequisition.InsertClosing(dt_closing_stock.Rows[i]["ClosingStockID"].ToString(), dt_closing_stock.Rows[i]["DealerID"].ToString(), dt_closing_stock.Rows[i]["Year"].ToString(), dt_closing_stock.Rows[i]["Month"].ToString(), dt_closing_stock.Rows[i]["ProductID"].ToString(), dt_closing_stock.Rows[i]["Quantity"].ToString());
                }
                XtraMessageBox.Show("Successfully data is imported.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void link_closing_stock_import_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            load_closing_stock_list();
            grp_closing_stock.Visible = true;
            grd_closing_stock_details.DataSource = null;
            cmb_closing_stock_id.EditValue = null;
            txt_year.Text = "";
            txt_month.Text = "";
            lbl_dealerid.Text = "";

            Cursor = Cursors.Default;
        }
        private void load_closing_stock_list()
        {
            DataTable dt = bllUtility.GetDataBySP("dbo.populate_closing_stock_list");
            cmb_closing_stock_id.Properties.DisplayMember = "DealerName";
            cmb_closing_stock_id.Properties.ValueMember = "ClosingStockID";
            cmb_closing_stock_id.Properties.DataSource = dt;
        }

        private void btn_search_closing_stock_Click(object sender, EventArgs e)
        {
            string ClosingStockID = "";

            if (cmb_closing_stock_id.EditValue == null)
            {
                XtraMessageBox.Show("Requisition No Selection Required!");
                cmb_closing_stock_id.Focus();
                return;
            }

            ClosingStockID = cmb_closing_stock_id.EditValue.ToString();

            DataTable dt = bllUtility.GetDataBySP("dbo.load_closing_stock_details '" + ClosingStockID + "'");
            grd_closing_stock_details.DataSource = dt;
        }

        private void cmb_closing_stock_id_EditValueChanged(object sender, EventArgs e)
        {

            if (cmb_closing_stock_id.EditValue == null)
                return;
            string ClosingStockID = cmb_closing_stock_id.EditValue.ToString();
            DataTable dt = (cmb_closing_stock_id.Properties.DataSource as DataTable).Copy();
            DataRow[] dr = dt.Select("ClosingStockID='" + ClosingStockID.Replace("(", "").Replace(")", "") + "'");
            lbl_dealerid.Text = dr[0]["DealerID"].ToString();
            txt_year.Text = dr[0]["Year"].ToString();
            txt_month.Text = dr[0]["Month"].ToString();

            btn_search_closing_stock_Click(sender, e);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (cmb_closing_stock_id.EditValue == null)
            {
                XtraMessageBox.Show("No data found for Delete.");
                return;
            }

            if (XtraMessageBox.Show("Do you want to delete the Closing Stock? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //delete
            if (bllRequisition.DeleteClosingStock(cmb_closing_stock_id.EditValue.ToString()) == true)
            {
                XtraMessageBox.Show("Data Deleted successfully.");
            }
            grd_closing_stock_details.DataSource = null;
            load_closing_stock_list();
            cmb_closing_stock_id.EditValue = null;
            txt_year.Text = "";
            txt_month.Text = "";
            lbl_dealerid.Text = "";
        }

        private void btn_close_req_Click(object sender, EventArgs e)
        {
            grp_closing_stock.Visible = false;
        }

        private void btn_load_closing_stock_Click(object sender, EventArgs e)
        {
            cmb_closing_stock_id.Focus();
            if (cmb_closing_stock_id.EditValue == null)
            {
                XtraMessageBox.Show("Closinh stock is selection required!");
                return;
            }
            DataTable dt = grd_closing_stock_details.DataSource as DataTable;
            if (dt == null || dt.Rows.Count < 1)
            {
                XtraMessageBox.Show("No data found for load");
                return;
            }
            bool isvalidData = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (bllUtility.Val((dt.Rows[i]["AdjustmentDueQty"].ToString())) < bllUtility.Val((dt.Rows[i]["ClosingQty"].ToString())))
                {
                    isvalidData = false;
                    //break;
                }
                dt.Rows[i]["AdjustmentQty"] = Math.Round(Convert.ToDecimal(dt.Rows[i]["AdjustmentDueQty"]) - Convert.ToDecimal(dt.Rows[i]["ClosingQty"]), 2, MidpointRounding.AwayFromZero);
            }

            if (isvalidData == false)
            {
                XtraMessageBox.Show("Some product's closing stock is not matched with system qty.");
                return;
            }

            cmb_account_holder.EditValue = lbl_dealerid.Text.Trim();
            grd_ctl_details.DataSource = dt;
            grp_closing_stock.Visible = false;
        }

        private void cmb_account_holder_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gv_details_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (bllUtility.Val(gv_details.GetDataRow(e.RowHandle)["AdjustmentDueQty"].ToString()) < bllUtility.Val(gv_details.GetDataRow(e.RowHandle)["ClosingQty"].ToString()))
            {
                e.Appearance.BackColor = Color.Red;
                //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txt_commission_id.Text.ToString() == "")
            {
                XtraMessageBox.Show("Please select a valid commission ID");
                txt_commission_id.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            dsCommission ds = new dsCommission();
            DataSet dsSP = bllReports.CommissionStatement(cmb_account_holder.EditValue.ToString(), txt_commission_id.EditValue.ToString());
            try
            {
                foreach (DataRow dr in dsSP.Tables[0].Rows)
                {
                    ds.Tables["CommissionDetails"].ImportRow(dr);
                }
                foreach (DataRow dr in dsSP.Tables[1].Rows)
                {
                    ds.Tables["CommissionSummary"].ImportRow(dr);
                }
                foreach (DataRow dr in bllCompanyInfo.getById(1).Rows)
                {
                    ds.Tables["CompanyInfo"].ImportRow(dr);
                }

                rptCommissionStatement rptTest = new Report.rptCommissionStatement();
                rptTest.SetDataSource(ds);
                //rptTest.SetParameterValue("SalesReturn", bllUtility.Val("0"));
                frmPrint ifrmPrint = new frmPrint(rptTest);
                ifrmPrint.Visible = true;
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }
    }
}