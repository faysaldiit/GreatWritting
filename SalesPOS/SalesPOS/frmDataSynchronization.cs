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

namespace SalesPOS
{
    public partial class frmDataSynchronization : DevExpress.XtraEditors.XtraForm
    {
        public frmDataSynchronization()
        {
            InitializeComponent();
        }

        private void btn_prepare_data_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                bllUtility.GetDataBySP("[export_csv] " + cmb_no_of_days_export.EditValue.ToString() + "");
                Cursor = Cursors.Default;
                lbl1.Text = "Successfully Done";
                btn_prepare_data.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btn_file_upload_Click(object sender, EventArgs e)
        {
            string ftp_url = bllUtility.DefaultSettings.Ftp_url;
            string ftp_user = bllUtility.DefaultSettings.Ftp_user;
            string ftp_pass = bllUtility.DefaultSettings.Ftp_pass;
            string default_path = bllUtility.DefaultSettings.Csv_path_local;
            string file1 = default_path + "account_holder_info.csv";
            string file2 = default_path + "account_holder_type.csv";
            string file3 = default_path + "account_transaction_details_info.csv";
            string file4 = default_path + "daily_sales_section_wise.csv";
            string file5 = default_path + "dealer_rsm_configure.csv";
            string file6 = default_path + "dealer_wise_avg_product_rate.csv";
            string file7 = default_path + "section_info.csv";
            string file8 = default_path + "product_info.csv";
            string file9 = default_path + "requisition_list_in_process.csv";

            try
            {
                Cursor = Cursors.WaitCursor;
                if (File.Exists(file1))
                    UploadFile(ftp_url, file1, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file2))
                    UploadFile(ftp_url, file2, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file3))
                    UploadFile(ftp_url, file3, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file4))
                    UploadFile(ftp_url, file4, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file5))
                    UploadFile(ftp_url, file5, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file6))
                    UploadFile(ftp_url, file6, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file7))
                    UploadFile(ftp_url, file7, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file8))
                    UploadFile(ftp_url, file8, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                Cursor = Cursors.WaitCursor;
                if (File.Exists(file9))
                    UploadFile(ftp_url, file9, ftp_user, ftp_pass, "");
                Cursor = Cursors.Default;

                lbl2.Text = "Successfully Done";
                btn_file_upload.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        public static string UploadFile(string FtpUrl, string fileName, string userName, string password, string UploadDirectory)
        {
            string PureFileName = new FileInfo(fileName).Name;
            String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, PureFileName);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
            req.Proxy = null;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(userName, password);
            req.UseBinary = true;
            req.UsePassive = true;
            byte[] data = File.ReadAllBytes(fileName);
            req.ContentLength = data.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            FtpWebResponse res = (FtpWebResponse)req.GetResponse();
            return res.StatusDescription;
        }

        private void frmDataSynchronization_Load(object sender, EventArgs e)
        {
            bllSecurityInfo.SoftDefaultSetting();
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
        }

        private void btn_publish_data_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string url = "http://great.kidmatebd.com/excel_data_import.php";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

                    Cursor = Cursors.Default;
                lbl3.Text = "Successfully Done";
                btn_publish_data.Enabled = false;
                XtraMessageBox.Show("Data published successfully.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btn_data_backup_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = XtraMessageBox.Show("RUN DATABASE BACKUP PROCESS...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (bllUtility.CreateDB_Backup() == true)
                {
                    XtraMessageBox.Show("Database Backup Successfully.");
                }
            }
        }

        public class RequisitionDetails
        {
            public string RequisitionID { get; set; }
            public string DealerID { get; set; }
            public string RequisitionDate { get; set; }
            public string PaymentMode { get; set; }
            public string PaymentAmount { get; set; }
            public string ProductID { get; set; }
            public string Quantity { get; set; }
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
                //requision import
                DataTable dt_req = bllUtility.generate_datetable("RequisitionID,DealerID,RequisitionDate,PaymentMode,PaymentAmount,ProductID,Quantity");
                var url = bllUtility.DefaultSettings.Api_link + "get_requisition_list/" + cmb_no_of_days_import.EditValue.ToString();
                var w = new WebClient();
                var json_data = string.Empty;
                this.Cursor = Cursors.WaitCursor;
                json_data = w.DownloadString(url);
                this.Cursor = Cursors.Default;
                //json_data = json_data.Replace("{}", "\"0\"");
                var machine = JsonConvert.DeserializeObject<List<RequisitionDetails>>(json_data);

                foreach (var data in machine)
                    dt_req.Rows.Add(data.RequisitionID, data.DealerID, Convert.ToDateTime(data.RequisitionDate.Substring(0, 10)).ToString("dd/MM/yyyy"), data.PaymentMode, data.PaymentAmount, data.ProductID, data.Quantity);

                grd_data.DataSource = dt_req;

                if (dt_req.Rows.Count < 1)
                {
                    //XtraMessageBox.Show("No data found for import");
                }
                else
                {
                    for (int i = 0; i < dt_req.Rows.Count; i++)
                    {
                        bllRequisition.InsertRequisition(dt_req.Rows[i]["RequisitionID"].ToString(), dt_req.Rows[i]["DealerID"].ToString(), dt_req.Rows[i]["RequisitionDate"].ToString(), dt_req.Rows[i]["PaymentMode"].ToString(), dt_req.Rows[i]["PaymentAmount"].ToString(), dt_req.Rows[i]["ProductID"].ToString(), dt_req.Rows[i]["Quantity"].ToString());
                    }
                }



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
                    dt_closing_stock.Rows.Add(data.ClosingStockID,data.DealerID, data.Year, data.Month, data.ProductID, data.Quantity);

                for (int i = 0; i < dt_closing_stock.Rows.Count; i++)
                {
                    bllRequisition.InsertClosing(dt_closing_stock.Rows[i]["ClosingStockID"].ToString(), dt_closing_stock.Rows[i]["DealerID"].ToString(), dt_closing_stock.Rows[i]["Year"].ToString(), dt_closing_stock.Rows[i]["Month"].ToString(), dt_closing_stock.Rows[i]["ProductID"].ToString(), dt_closing_stock.Rows[i]["Quantity"].ToString());
                }

                lbl4.Text = "Successfully Done";
                btn_import.Enabled = false;
                XtraMessageBox.Show("Successfully data is imported.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btn_log_clear_Click(object sender, EventArgs e)
        {
            if (bllUtility.LogClear() == true)
            {
                XtraMessageBox.Show("Log Data Clear is Completed.");
            }
        }
    }
}