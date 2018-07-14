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
    public partial class frmDefautSetup : DevExpress.XtraEditors.XtraForm
    {
        public frmDefautSetup()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strID = bllUtility.DefaultSettings.ID;
            string strDefaultSaleType = "";
            string strSalesPriceIsEditable = "";
            string strDiscountAllow = "";
            string strMiniAccAllow = "";
            string strCreditSaleAllow = "";
            string strSalesInvoicePrintType="";
            // Set strDefaultSaleType
            if (optRetailSale.Checked == true)
            {
                strDefaultSaleType = "R";
            }
            else
            {
                strDefaultSaleType = "W";
            }

            // Set strSalesPriceIsEditable
            if (chkSalesPriceEditable.Checked == true)
            {
                strSalesPriceIsEditable = "1";
            }
            else
            {
                strSalesPriceIsEditable = "0";
            }

            // Set strDiscountAllow
            if (chkDiscountAllow.Checked == true)
            {
                strDiscountAllow = "1";
            }
            else
            {
                strDiscountAllow = "0";
            }

            // Set strMiniAccAllow
            if (chkMiniAccAllow.Checked == true)
            {
                strMiniAccAllow = "1";
            }
            else
            {
                strMiniAccAllow = "0";
            }

            // Set strCreditSaleAllow
            if (chkCreditSaleAllow.Checked == true)
            {
                strCreditSaleAllow = "1";
            }
            else
            {
                strCreditSaleAllow = "0";
            }

            // Set strDefaultSaleType
            if (optSalesPrintTypeMini.Checked == true)
            {
                strSalesInvoicePrintType = "Mini";
            }
            else
            {
                strSalesInvoicePrintType = "Large";
            }
            /************************************************************/
            // **************** Start Save Process.... ******************
            /************************************************************/

            if (bllSecurityInfo.InsertUpdateDefaultSetting(strID, strDefaultSaleType, strSalesPriceIsEditable, strDiscountAllow, strMiniAccAllow, strCreditSaleAllow, strSalesInvoicePrintType) == true)
            {
                XtraMessageBox.Show("Default Settings Sucessfully Saved.", "Successfully Message");
            }
            else
            {
                XtraMessageBox.Show("Saving Error.", "Error Message");
            }
        }

        private void frmDefautSetup_Load(object sender, EventArgs e)
        {
            if (bllSecurityInfo.SoftDefaultSetting() == false)
            {
                XtraMessageBox.Show("There is no default setup found in the system. Please setup it first.", "Empty Message");
                ClearAll();
            }
            else
            {
                InitializeValue();
            }
        }

        private void InitializeValue()
        {
            /**********************************************************
            * Setting Default Sales Type
            **********************************************************/
            if (bllUtility.DefaultSettings.DefaultSaleType == "R")
            {
                optRetailSale.Checked = true;
                optWholeSale.Checked = false;
            }
            else
            {
                optWholeSale.Checked = true;
                optRetailSale.Checked = false;
            }

            /**********************************************************
            * Setting Is Editable Sales Price
            **********************************************************/
            if (bllUtility.DefaultSettings.IsEditableSalePrice == "True")
            {
                chkSalesPriceEditable.Checked = true;
            }
            else
            {
                chkSalesPriceEditable.Checked = false;
            }

            /**********************************************************
            * Setting Discount allow or not in sales process
            **********************************************************/
            if (bllUtility.DefaultSettings.DiscountAllow == "True")
            {
                chkDiscountAllow.Checked = true;
            }
            else
            {
                chkDiscountAllow.Checked = false;
            }

            /**********************************************************
            * Setting Mini Accounts allow or not in this system
            **********************************************************/
            if (bllUtility.DefaultSettings.MiniAccAllow == "True")
            {
                chkMiniAccAllow.Checked = true;
            }
            else
            {
                chkMiniAccAllow.Checked = false;
            }

            /**********************************************************
            * Setting Credit Sale allow or not in this system
            **********************************************************/
            if (bllUtility.DefaultSettings.CreditSaleAllow == "True")
            {
                chkCreditSaleAllow.Checked = true;
            }
            else
            {
                chkCreditSaleAllow.Checked = false;
            }
            /**********************************************************
            * Setting Default Sales Print Type
            **********************************************************/
            if (bllUtility.DefaultSettings.SalePrintType == "Mini")
            {
                optSalesPrintTypeMini.Checked = true;
                optSalesPrintTypeLarge.Checked = false;
            }
            else
            {
                optSalesPrintTypeMini.Checked = false;
                optSalesPrintTypeLarge.Checked = true;
            }
        }

        private void ClearAll()
        {
            optRetailSale.Checked = false;
            optWholeSale.Checked = false;
            chkSalesPriceEditable.Checked = false;
            chkDiscountAllow.Visible = false;
        }
    }
}
