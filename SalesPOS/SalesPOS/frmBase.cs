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

namespace SalesPOS
{
    public partial class frmBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable MenuList = new DataTable();
        long UserID;
        public frmBase(DataTable DTab, long _UserID)
        {
            MenuList = DTab;
            UserID = _UserID;
            InitializeComponent();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
            UserLookAndFeel.Default.SkinName = "Blue";

            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Default;
            this.ribbon.Minimized = true;
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

                obj.MdiParent = this;
                obj.Dock = DockStyle.Fill;
                obj.Show();
            }
        }

        private void CheckMdiChildren(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == form.GetType())
                {
                    frm.Focus();
                    return;
                }
            }

            form.MdiParent = this;
            form.Show();

        }
        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            // ribbon.Minimized = true;
            LoadSubMenuList(MenuList);
            //NavBarGroup nvg = new NavBarGroup();
            //nvg.Name = "Order11";
            //nvg.Caption = "Test22";

            //NavBarItem nvt= new NavBarItem();
            //nvt.Name = "Test";
            //nvt.Caption = "Test";
            //nvg.ItemLinks.Add(nvt); 

            //nbMain.Groups.Add(nvg);
            //this.Ribbon.Minimized = true;
            status_bar_info.Caption = "Logged User : " + bllUtility.LoggedInSystemInformation.UserName;
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
        }

        public void LoadSubMenuList(DataTable DTabList)
        {
            #region Add Menu
            foreach (DataRow dr in DTabList.Rows)
            {

                NavBarGroup nvg = new NavBarGroup();
                nvg.Caption = dr[2].ToString().Trim();
                nvg.Name = dr[1].ToString().Trim();
                nvg.SmallImage = Image.FromFile(".\\icon\\master_menu\\" + dr[4].ToString().Trim() + "");

                long MenuCode = Convert.ToInt64(dr[0].ToString().Trim());
                DataTable DTab_SubMenu = (DataTable)bllScreenInfo.getUserSubMenuList(MenuCode, UserID);
                #region Add SubItem
                foreach (DataRow drSub in DTab_SubMenu.Rows)
                {
                    NavBarItem nvt = new NavBarItem();
                    nvt.Caption = drSub[1].ToString().Trim();
                    nvt.Name = drSub[2].ToString().Trim();
                    nvt.SmallImage = Image.FromFile(".\\icon\\" + drSub[3].ToString().Trim() + "");
                    nvt.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.MenuandSubmenu_Click);
                    nvg.ItemLinks.Add(nvt);
                }
                #endregion

                nbMain.Groups.Add(nvg);
            }
            #endregion

        }

        private void MenuandSubmenu_Click(object sender, EventArgs e)
        {
            #region Click Event for Menu & SubMenu

            NavBarItem _NavBarItem = (NavBarItem)sender;
            string NameText = _NavBarItem.Name.ToString().Trim();
            if (NameText == "mnuCompanyInfo")
            {
                form_load("frmCompanyInfo");
            }
            else if (NameText == "mnuTerminalInfo")
            {
                form_load("frmTerminalInfo");
            }
            else if (NameText == "mnuBalanceSheet")
            {
                form_load("frmBalanceSheet");
            }
            else if (NameText == "mnuUserInfo")
            {
                //frmUserInfo obj = new frmUserInfo();
                //obj.ShowDialog();
                form_load("frmUserInfo");
            }

            else if (NameText == "mnuExit")
            {
                //this.Close();
                Application.Exit();
            }

            else if (NameText == "mnuUnitInfo")
            {
                //frmUnitInfo obj = new frmUnitInfo();
                //obj.ShowDialog();
                form_load("frmUnitInfo");
            }

            else if (NameText == "mnuSectionInfo")
            {
                //frmSectionInfo obj = new frmSectionInfo();
                //obj.ShowDialog();
                form_load("frmSectionInfo");
            }

            else if (NameText == "mnuBranchInfo")
            {
                //frmBranchInfo obj = new frmBranchInfo();
                //obj.ShowDialog();
                form_load("frmBranchInfo");

            }

            else if (NameText == "mnuAccountTypeInfo")
            {
                //frmAccountHolderType obj = new frmAccountHolderType();
                //obj.ShowDialog();
                form_load("frmAccountHolderType");
            }

            else if (NameText == "mnuAccountHolderInfo")
            {
                //frmAccountHolderInfo obj = new frmAccountHolderInfo();
                //obj.ShowDialog();
                form_load("frmAccountHolderInfo");
            }

            else if (NameText == "mnuSubSection")
            {
                //frmSubSectionInfo obj = new frmSubSectionInfo();
                //obj.ShowDialog();
                form_load("frmSubSectionInfo");
            }

            else if (NameText == "mnuDBBackup")
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
            else if (NameText == "mnuDelPurchase")
            {
                //frmDeletePurchase obj = new frmDeletePurchase();
                //obj.ShowDialog();
                form_load("frmDeletePurchase");
            }
            else if (NameText == "mnuVatInfo")
            {
                //frmVatInfo obj = new frmVatInfo();
                //obj.ShowDialog();
                form_load("frmVatInfo");
            }

            else if (NameText == "mnuManufacturerInfo")
            {
                //frmManufacturerInfo obj = new frmManufacturerInfo();
                //obj.ShowDialog();
                form_load("frmManufacturerInfo");
            }

            else if (NameText == "mnuStoreInfo")
            {
                //frmStoreInfo obj = new frmStoreInfo();
                //obj.ShowDialog();
                form_load("frmStoreInfo");
            }

            else if (NameText == "mnuPayType")
            {
                //frmPayType obj = new frmPayType();
                //obj.ShowDialog();
                form_load("frmPayType");
            }

            else if (NameText == "mnuSalesInfo")
            {
                //frmSalesInfo obj = new frmSalesInfo();
                //obj.ShowDialog();
                form_load("frmSalesInfo");
            }

            else if (NameText == "mnuPurchase")
            {
                //frmPurchaseInfo obj = new frmPurchaseInfo();
                //obj.ShowDialog();
                form_load("frmPurchaseInfo");
            }

            else if (NameText == "mnuSalesReturn")
            {
                //frmSalesReturnInfo obj = new frmSalesReturnInfo();
                //obj.ShowDialog();
                form_load("frmReturnNew");
            }

            else if (NameText == "mnuPurchaseReturn")
            {
                //frmPurchaseReturn obj = new frmPurchaseReturn();
                //obj.ShowDialog();
                form_load("frmPurchaseReturn");
            }

            else if (NameText == "mnuStocktransfer")
            {
                //frmStockTransferInfo obj = new frmStockTransferInfo();
                //obj.ShowDialog();
                form_load("frmStockTransferInfo");
            }

            else if (NameText == "mnuDefaultSetup")
            {
                //frmDefautSetup obj = new frmDefautSetup();
                //obj.ShowDialog();
                form_load("frmDefautSetup");
            }

            else if (NameText == "mnuProductInfo")
            {
                //frmProductInfo obj = new frmProductInfo();
                //obj.ShowDialog();
                form_load("frmProductInfo");
            }

            else if (NameText == "mnuUserMenuConfigure")
            {
                //frmUserMenu _OfrmUserMenu = new frmUserMenu();
                //_OfrmUserMenu.ShowDialog();
                form_load("frmUserMenu");
            }

            else if (NameText == "mnuMasterMenuList")
            {
                //frmMenuSetup _OfrmMenuSetup = new frmMenuSetup();
                //_OfrmMenuSetup.ShowDialog();
                form_load("frmMenuSetup");
            }
            else if (NameText == "mnuPasswordChange")
            {
                form_load("frmChangePassWord");
            }
            else if (NameText == "mnuPasswordChange")
            {
                form_load("frmChangePassWord");
            }
            else if (NameText == "mnuTransactionType")
            {
                form_load("frmAccountTransaction");
            }
            else if (NameText == "mnuTransactionType_new")
            {
                form_load("frmAccountTransactions");
            }
            else if (NameText == "mnuDelSalesInvoice")
            {
                form_load("frmDelSalesInvoice");
            }
            else if (NameText == "mnuSalesRefund")
            {
                form_load("frmSalesRefundInfo");
            }
            else if (NameText == "mnuSalesRefundInvoice")
            {
                form_load("frmListOfSalesRefundInvoice");
            }
            else if (NameText == "mnuSalesReturnInvoice")
            {
                form_load("frmListOfSalesReturnInvoice");
            }
            else if (NameText == "mnuSalesInvoice")
            {
                form_load("frmListOfSalesInvoice");
            }
            else if (NameText == "mnuPurchaseInvoice")
            {
                form_load("frmListOfPurchaseInvoice");
            }
            //else if (NameText == "mnuExit")
            //{
            //    Application.Exit();
            //}
            ///////////////////////  report menu start ////////////////////////////////////
            else if (NameText == "mnuProductSalesStatement")
            {
                form_load("frmReportSalesStatement");
            }
            else if (NameText == "mnuProductSalesProfit")
            {
                form_load("frmReportProductSalesProfit");
            }
            else if (NameText == "mnuProductPurchaseStatement")
            {
                form_load("frmReportPurchaseStatement");
            }
            else if (NameText == "mnuRptProductList")
            {
                form_load("frmReportProductList");
            }
            else if (NameText == "mnuMonthlyAccountStatement")
            {
                form_load("frmReportMonthlyAccStatement");
            }
            else if (NameText == "mnuPersonalStatement")
            {
                form_load("frmReportPersonalStatement");
            }
            else if (NameText == "mnuRptReorderProduct")
            {
                form_load("frmReportReOrderProduct");
            }
            else if (NameText == "mnuExpenditure")
            {
                form_load("frmReportExpenditure");
            }
            else if (NameText == "mnuDebitorCreditor")
            {
                form_load("frmReportDebtoCredtorList");
            }
            else if (NameText == "mnuProductOpenCloseStock")
            {
                form_load("frmReportOpeningClosingStock");
            }
            else if (NameText == "mnuCashBook")
            {
                form_load("frmReportCashBook");
            }
            else if (NameText == "mnuRptCurrentProductStock")
            {
                form_load("frmReportCurrentStock");
            }
            else if (NameText == "mnuCashReceive")
            {
                form_load("frmReportCashReceive");
            }
            else if (NameText == "mnuSalesReturnStatement")
            {
                form_load("frmReportSalesReturn");
            }
            else if (NameText == "mnuProductOut")
            {
                form_load("frmProductOut");
            }
            else if (NameText == "mnuCommission")
            {
                form_load("frmCommissionCalculation");
            }
            else if (NameText == "mnuZoneSetup")
            {
                form_load("frmZone");
            }
            else if (NameText == "mnuIncomeStatement")
            {
                form_load("frmRptIncomeStatement");
            }
            else if (NameText == "mnuDataSynchronization")
            {
                form_load("frmDataSynchronization");
            }
            else if (NameText == "mnuMaterialSetup")
            {
                form_load("frmMaterialInfo");
            }
            else if (NameText == "mnuMaterialPurchaseInfo")
            {
                form_load("frmMaterialPurchaseInfo");
            }
            else if (NameText == "mnuProduction")
            {
                form_load("frmProduction");
            }
            else if (NameText == "mnuReportMaterialTransaction")
            {
                form_load("frmReportMaterialTransaction");
            }
            //////////////////////////// End of report menu ////////////////////////////////
            #endregion
        }
        private void barButtonItem_Exit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void bar_btn_log_out_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            this.Hide();
            frmLogin fLogin = new frmLogin();
            fLogin.ShowDialog();
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    UploadFile("ftp://nannabiriyanimirpur10.com/", "D:\\OA0000003281992.pdf", "nannabiriyani", "SglSR$bL2b2k", "");
        //}

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

        private void btn_prepare_data_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                bllUtility.GetDataBySP("[export_csv] 10");
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
            string ftp_url = "ftp://nannabiriyanimirpur10.com/";
            string ftp_user = "nannabiriyani";
            string ftp_pass = "SglSR$bL2b2k";
            string default_path = "E:\\csv\\";
            string file1 = default_path + "account_holder_info.csv";
            string file2 = default_path + "account_holder_type.csv";
            string file3 = default_path + "account_transaction_details_info.csv";
            string file4 = default_path + "daily_sales_section_wise.csv";
            string file5 = default_path + "dealer_rsm_configure.csv";
            string file6 = default_path + "dealer_wise_avg_product_rate.csv";
            string file7 = default_path + "section_info.csv";

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

                lbl2.Text = "Successfully Done";
                btn_file_upload.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = XtraMessageBox.Show("Do you want to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void nbMain_Click(object sender, EventArgs e)
        {

        }


    }
}