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
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        DataTable MenuList = new DataTable();
        long UserID;
        public frmMain(DataTable DTab,long _UserID)
        {
            MenuList = DTab;
            UserID = _UserID;
            InitializeComponent();            
        }

        private void MenuandSubmenu_Click(object sender, EventArgs e)
        {
            #region Click Event for Menu & SubMenu
            ToolStripMenuItem SubmenuName = (ToolStripMenuItem)sender;
            string NameText=SubmenuName.Name.ToString().Trim();
         if (NameText == "mnuCompanyInfo")
         {
                frmCompanyInfo obj = new frmCompanyInfo();
                obj.ShowDialog();
         }        
        

        else if (NameText == "mnuTerminalInfo")
        {
         
            frmTerminalInfo obj = new frmTerminalInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuUserInfo")
        {
            frmUserInfo obj = new frmUserInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuExit")
        {
            this.Close();
        }

        else if (NameText == "mnuUnitInfo")
        {
            frmUnitInfo obj = new frmUnitInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuSectionInfo")
        {
            frmSectionInfo obj = new frmSectionInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuBranchInfo")
        {
            frmBranchInfo obj = new frmBranchInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuAccountTypeInfo")
        {
            frmAccountHolderType obj = new frmAccountHolderType();
            obj.ShowDialog();
        }

        else if (NameText == "mnuAccountHolderInfo")
        {
            frmAccountHolderInfo obj = new frmAccountHolderInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuSubSection")
        {
            frmSubSectionInfo obj = new frmSubSectionInfo();
            obj.ShowDialog();
        }

         else if (NameText == "mnuDBBackup")
         {
             //frmProductInfo obj = new frmProductInfo();
             //obj.ShowDialog();
             if (bllUtility.CreateDB_Backup() == true)
             {
                 XtraMessageBox.Show("Database Backup Successfully.");             
             }

         }
         else if (NameText == "mnuDelPurchase")
         {
             frmDeletePurchase obj = new frmDeletePurchase();
             obj.ShowDialog();         
         }
        else if (NameText == "mnuVatInfo")
        {
            frmVatInfo obj = new frmVatInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuManufacturerInfo")
        {
            frmManufacturerInfo obj = new frmManufacturerInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuStoreInfo")
        {
            frmStoreInfo obj = new frmStoreInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuPayType")
        {
            frmPayType obj = new frmPayType();
            obj.ShowDialog();
        }

        else if (NameText == "mnuSalesInfo")
        {
            frmSalesInfo obj = new frmSalesInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuPurchase")
        {
            frmPurchaseInfo obj = new frmPurchaseInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuSalesReturn")
        {
            frmSalesReturnInfo obj = new frmSalesReturnInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuPurchaseReturn")
        {
            frmPurchaseReturn obj = new frmPurchaseReturn();
            obj.ShowDialog();
        }

        else if (NameText == "mnuStocktransfer")
        {
            frmStockTransferInfo obj = new frmStockTransferInfo();
            obj.ShowDialog();
        }       

        else if (NameText == "mnuDefaultSetup")
        {
            frmDefautSetup obj = new frmDefautSetup();
            obj.ShowDialog();
        }

        else if (NameText == "mnuProductInfo")
        {
            frmProductInfo obj = new frmProductInfo();
            obj.ShowDialog();
        }

        else if (NameText == "mnuUserMenuConfigure")
        {
            frmUserMenu _OfrmUserMenu = new frmUserMenu();
            _OfrmUserMenu.ShowDialog();
        }

        else if (NameText == "mnuMasterMenuList")
        {
            frmMenuSetup _OfrmMenuSetup = new frmMenuSetup();
            _OfrmMenuSetup.ShowDialog();
        }
        else if(NameText =="mnuPasswordChange")
       {
             frmChangePassWord obj=new frmChangePassWord();
             obj.ShowDialog();
         }
         else if (NameText == "mnuPasswordChange")
         {
             frmChangePassWord obj = new frmChangePassWord();
             obj.ShowDialog();
         }
         else if (NameText == "mnuTransactionType")
         {
             frmAccountTransaction obj = new frmAccountTransaction();
             obj.ShowDialog();
         }
         else if (NameText == "mnuDelSalesInvoice")
         {
             frmDelSalesInvoice obj = new frmDelSalesInvoice();
             obj.ShowDialog();
         }
         else if (NameText == "mnuSalesRefund")
         {
             frmSalesRefundInfo obj = new frmSalesRefundInfo();
             obj.ShowDialog();
         }
         else if (NameText == "mnuSalesRefundInvoice")
         {
             frmListOfSalesRefundInvoice obj = new frmListOfSalesRefundInvoice();
             obj.ShowDialog();
         }
         else if (NameText == "mnuSalesReturnInvoice")
         {
             frmListOfSalesReturnInvoice obj = new frmListOfSalesReturnInvoice();
             obj.ShowDialog();
         }
         else if (NameText == "mnuSalesInvoice")
         {
             frmListOfSalesInvoice obj = new frmListOfSalesInvoice();
             obj.ShowDialog();
         }
         else if (NameText == "mnuPurchaseInvoice")
         {
             frmListOfPurchaseInvoice obj = new frmListOfPurchaseInvoice();
             obj.ShowDialog();
         }
         else if (NameText == "mnuExit")
         {
             Application.Exit();
         }
         ///////////////////////  report menu start ////////////////////////////////////
         else if (NameText == "mnuProductSalesStatement")
         {
             frmReportSalesStatement obj = new frmReportSalesStatement();
             obj.ShowDialog();
         }
         else if (NameText == "mnuProductSalesProfit")
         {
             frmReportProductSalesProfit obj = new frmReportProductSalesProfit();
             obj.ShowDialog();
         }
         else if (NameText == "mnuProductPurchaseStatement")
         {
             frmReportPurchaseStatement obj = new frmReportPurchaseStatement();
             obj.ShowDialog();
         }
         else if (NameText == "mnuRptProductList")
         {
             frmReportProductList obj = new frmReportProductList();
             obj.ShowDialog();
         }
         else if (NameText == "mnuMonthlyAccountStatement")
         {
             frmReportMonthlyAccStatement obj = new frmReportMonthlyAccStatement();
             obj.ShowDialog();
         }
         else if (NameText == "mnuPersonalStatement")
         {
             frmReportPersonalStatement obj = new frmReportPersonalStatement();
             obj.ShowDialog();
         }
         else if (NameText == "mnuRptReorderProduct")
         {
             frmReportReOrderProduct obj = new frmReportReOrderProduct();
             obj.ShowDialog();
         }
         else if (NameText == "mnuExpenditure")
         {
             frmReportExpenditure obj = new frmReportExpenditure();
             obj.ShowDialog();
         }
         else if (NameText == "mnuDebitorCreditor")
         {
             frmReportDebtoCredtorList obj = new frmReportDebtoCredtorList();
             obj.ShowDialog();
         }
         else if (NameText == "mnuProductOpenCloseStock")
         {
             frmReportOpeningClosingStock obj = new frmReportOpeningClosingStock();
             obj.ShowDialog();
         }
         else if (NameText == "mnuCashBook")
         {
             frmReportCashBook obj = new frmReportCashBook();
             obj.ShowDialog();
         }
         else if (NameText == "mnuRptCurrentProductStock")
         {
             frmReportCurrentStock obj = new frmReportCurrentStock();
             obj.ShowDialog();
         }
         else if (NameText == "mnuCashReceive")
         {
             frmReportCashReceive obj = new frmReportCashReceive();
             obj.ShowDialog();
         }
         else if (NameText == "mnuSalesReturnStatement")
         {
             frmReportSalesReturn obj = new frmReportSalesReturn();
             obj.ShowDialog();
         }
         else if (NameText == "mnuProductOut")
         {
             frmProductOut obj = new frmProductOut();
             obj.ShowDialog();
         }
        //////////////////////////// End of report menu ////////////////////////////////
#endregion
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSubMenuList(MenuList);
            lblUserName.Text =bllUtility.LoggedInSystemInformation.LoggedUserName;
            lblTerminal.Text = bllUtility.LoggedInSystemInformation.TerminalID;
            lblCurrentDate.Text = DateTime.Now.ToString("dd MMM, yyyy (dddd) ");
            lblLoggedTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        public void LoadSubMenuList(DataTable DTabList)
        {
            #region Add Menu
            foreach (DataRow dr in DTabList.Rows)
            {
                
                ToolStripMenuItem tpMenu = new ToolStripMenuItem();
                tpMenu.Text = dr[2].ToString().Trim();
                tpMenu.Name = dr[1].ToString().Trim();
                //tpMenu.Image = Image.FromFile(".\\icon\\1.gif");
                long MenuCode=Convert.ToInt64(dr[0].ToString().Trim());
                DataTable DTab_SubMenu = (DataTable)bllScreenInfo.getUserSubMenuList(MenuCode, UserID);
                #region Add SubMenu
                foreach (DataRow drSub in DTab_SubMenu.Rows)
                {
                    ToolStripMenuItem tpSubMenu = new ToolStripMenuItem();
                    tpSubMenu.Text = drSub[1].ToString().Trim();
                    tpSubMenu.Name = drSub[2].ToString().Trim();
                    //tpSubMenu.Image = global::SalesPOS.Properties.Resources.exit1;
                    tpSubMenu.Image = Image.FromFile(".\\icon\\"+drSub[3].ToString().Trim()+"");
                    tpSubMenu.Click += new System.EventHandler(this.MenuandSubmenu_Click);
                    //mnuSetup.DropDownItems.Add(tpSubMenu1UserID);             
                    tpMenu.DropDownItems.Add(tpSubMenu);

                }
                #endregion
                //mnuSetup.DropDownItems.Add(tpSubMenu1UserID);             
                menuStrip.Items.Add(tpMenu);

            }
            #endregion
            #region Add ExitMenu
            ToolStripMenuItem tpMenuExit = new ToolStripMenuItem();
            tpMenuExit.Text = "Exit";
            tpMenuExit.Name = "mnuExit";            
            tpMenuExit.Click += new System.EventHandler(this.MenuandSubmenu_Click);
            menuStrip.Items.Add(tpMenuExit);
           #endregion
            
        }
        
        
             
          
    }
}
