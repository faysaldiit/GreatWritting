using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesPOS.BLL;
using SalesPOS.Report;
using System.IO;
using System.Net;

namespace SalesPOS
{
    public partial class frmCommissionDetailsView : DevExpress.XtraEditors.XtraForm
    {
        private static string commissionID = "";
        private static string AccountHolderNo = "";
        private static DataTable DtCommissionID;
        public frmCommissionDetailsView()
        {
            InitializeComponent();
        }

        public frmCommissionDetailsView(string commission_ID,string account_no)
        {
            bllSecurityInfo.SoftDefaultSetting();
            InitializeComponent();

            if (account_no.Length > 5 && commission_ID.Length > 5)
            {
                commissionID = commission_ID;
                AccountHolderNo = account_no;

                date_from_date.Value = DateTime.Today.AddMonths(-1);
                date_to_date.Value = DateTime.Today;

                cmb_account_holder.EditValue = account_no;
                btn_load_commission_id_Click(null, null);
                cmb_commission_id.EditValue = commission_ID;

                //txt_commission_id.Text = commission_ID;
                bindGrid(commission_ID);
                //btn_load_Click(null, null);
            }
        } 

        private void frmCommissionDetailsView_Load(object sender, EventArgs e)
        {
            DataTable dt_account_holder = bllCommissionCalc.get_account_holder("Distributor");
            cmb_account_holder.Properties.DisplayMember = "AccHolderName";
            cmb_account_holder.Properties.ValueMember = "AccountNo";
            cmb_account_holder.Properties.DataSource = dt_account_holder;

            date_from_date.Value = DateTime.Today.AddMonths(-1);
            date_to_date.Value = DateTime.Today;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            grd_ctl_commission_details.DataSource = null;
            if (cmb_commission_id.EditValue == null || cmb_commission_id.EditValue.ToString()=="")
            {
                XtraMessageBox.Show("Please select a valid commission ID");
                cmb_commission_id.Focus();
                return;
            }
            bindGrid(cmb_commission_id.EditValue.ToString());   
        }

        private void bindGrid(string commissionID)
        {
            grd_ctl_commission_details.DataSource = null;
            if (commissionID.Length > 5)
            {
                DataTable dt_details = bllCommissionCalc.get_commission_calc_details(commissionID);
                if (dt_details == null || dt_details.Rows.Count < 1)
                {
                    XtraMessageBox.Show("Please select a valid commission ID");
                    cmb_commission_id.Focus();
                    return;
                }

                grd_ctl_commission_details.DataSource = dt_details;
                grd_view_commission_details.BestFitColumns();
            }
        }

        private void btn_load_commission_id_Click(object sender, EventArgs e)
        {
            //dtpTransactionDate.Value.ToString();
            if (cmb_account_holder.EditValue == null)
            {
                XtraMessageBox.Show("Account holder selection required!");
                cmb_account_holder.Focus();
                return;
            }
            cmb_commission_id_populate();
        }

        private void cmb_commission_id_populate()
        {
            cmb_commission_id.Properties.DataSource = null;
            DataTable dt_details = bllCommissionCalc.get_commission_calc_IDs(date_from_date.Value.ToString(), date_to_date.Value.ToString(), cmb_account_holder.EditValue.ToString());
            cmb_commission_id.Properties.ValueMember = "CommissionCalcID";
            cmb_commission_id.Properties.DisplayMember = "CommissionCalcID";
            cmb_commission_id.Properties.DataSource = dt_details;
        }

        private void btn_export_to_excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog.FileName.Equals(String.Empty))
                {
                    try
                    {
                        string file_name = saveFileDialog.FileName;
                        grd_ctl_commission_details.ExportToXls(file_name);
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmb_commission_id.EditValue == null || cmb_commission_id.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Please select a valid commission ID");
                cmb_commission_id.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            dsCommission ds = new dsCommission();
            DataSet dsSP = bllReports.CommissionStatement(cmb_account_holder.EditValue.ToString(),cmb_commission_id.EditValue.ToString());
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

        private void cmb_account_holder_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_account_holder.EditValue == null)
                return;
            btn_load_commission_id_Click(sender,e);
        }

        

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (cmb_commission_id.EditValue == null || cmb_commission_id.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Please select a valid commission ID");
                cmb_commission_id.Focus();
                return;
            }
            if (cmb_account_holder.EditValue == null || cmb_account_holder.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Please select a dealer");
                cmb_account_holder.Focus();
                return;
            }

            //01. genarate csv first-----------------------------------------------

            try
            {
                
                Cursor = Cursors.WaitCursor;
                bllUtility.GetDataBySP("[rpt_commission_wise_stock_statement_csv] '" + cmb_account_holder.EditValue.ToString() + "','" + cmb_commission_id.EditValue.ToString()+"'");
                Cursor = Cursors.Default;

                

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return;
            }


            //02. upload ftp server ------------------------------------------------
            string ftp_url = bllUtility.DefaultSettings.Ftp_url;
            string ftp_user = bllUtility.DefaultSettings.Ftp_user;
            string ftp_pass = bllUtility.DefaultSettings.Ftp_pass;
            string default_path = bllUtility.DefaultSettings.Csv_path_local;
            string file1 = default_path + "closing_stock_statement.csv";
            try
            {
                Cursor = Cursors.WaitCursor;
                if (File.Exists(file1))
                    bllUtility.UploadFile(ftp_url, file1, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return;
            }

            //03. publish to website-----------------------------------------------
            try
            {
                Cursor = Cursors.WaitCursor;
                string url = "http://great.kidmatebd.com/closing_data_import.php";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return;
            }
            XtraMessageBox.Show("Data published successfully.");
        }
    }
}