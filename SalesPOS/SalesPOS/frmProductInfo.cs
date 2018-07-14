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
    public partial class frmProductInfo : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dtProductInfo = new DataTable();
        private string _SelctedProductID = "";
        private Int32 _SelctedPSPID = 0;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        public frmProductInfo()
        {
            InitializeComponent();
        }
        private void LoadSection()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSectionInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["SectionID"] = "0";
                dr["SectionName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbSection.DisplayMember = "SectionName";
                cmbSection.ValueMember = "SectionID";
                cmbSection.DataSource = dt;
            }
            catch
            { }
        }
        private void LoadSectionSearch()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSectionInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["SectionID"] = "0";
                dr["SectionName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbSectionSearch.DisplayMember = "SectionName";
                cmbSectionSearch.ValueMember = "SectionID";
                cmbSectionSearch.DataSource = dt;
            }
            catch
            { }
        }
        private void LoadSubSection(long SectionId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSubSectionInfo.getBySectionId(SectionId);
                DataRow dr = dt.NewRow();
                dr["SubSectionID"] = "0";
                dr["SubSectionName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbSubSection.DisplayMember = "SubSectionName";
                cmbSubSection.ValueMember = "SubSectionID";
                cmbSubSection.DataSource = dt;
            }
            catch
            { }
        }
        private void LoadSubSectionSearch(long SectionId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllSubSectionInfo.getBySectionId(SectionId);
                DataRow dr = dt.NewRow();
                dr["SubSectionID"] = "0";
                dr["SubSectionName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbSubSectionSearch.DisplayMember = "SubSectionName";
                cmbSubSectionSearch.ValueMember = "SubSectionID";
                cmbSubSectionSearch.DataSource = dt;
            }
            catch
            { }
        }
        private void LoadVat()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllVatInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["VatID"] = "0";
                dr["Vatrate"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbVat.DisplayMember = "Vatrate";
                cmbVat.ValueMember = "VatID";
                cmbVat.DataSource = dt;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadUnit()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllUnitInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["UnitId"] = "0";
                dr["UnitName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbUnit.DisplayMember = "UnitName";
                cmbUnit.ValueMember = "UnitId";
                cmbUnit.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadManufacturer()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllManufacturerInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["ManufacturerID"] = "0";
                dr["ManufacturarName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbManufacturer.DisplayMember = "ManufacturarName";
                cmbManufacturer.ValueMember = "ManufacturerID";
                cmbManufacturer.DataSource = dt;
                cmbManufacturer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadManufacturerSearch()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllManufacturerInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["ManufacturerID"] = "0";
                dr["ManufacturarName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbManufacturerSearch.DisplayMember = "ManufacturarName";
                cmbManufacturerSearch.ValueMember = "ManufacturerID";
                cmbManufacturerSearch.DataSource = dt;
                cmbManufacturerSearch.SelectedIndex = 0;
            }
            catch (Exception e)
            { XtraMessageBox.Show(e.ToString()); }
        }
        private void LoadGrid()
        {
            dtProductInfo = bllProductInfo.getAll();
            this.dgvProductInfoList.AutoGenerateColumns = false;
            this.dgvProductInfoList.DataSource = dtProductInfo;
            lblRecord.Text = dtProductInfo.Rows.Count.ToString();

            if (this.dgvProductInfoList.Rows.Count > 0)
                this.dgvProductInfoList.Rows[0].Selected = false;

            for (int i = 0; i < dtProductInfo.Rows.Count; i++)
            {
                namesCollection.Add(dtProductInfo.Rows[i]["ProductName"].ToString());
            }

            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteCustomSource = namesCollection;
        }
        private void LoadGridSearch()
        {
            string sql = "";
            sql = "USP_Search_ProductInfo '" + txtProductCodeSearch.Text.Trim() + "','" + txtProductNameSearch.Text.Trim() + "','" + this.cmbActivitySearch.SelectedValue + "','" + this.cmbSectionSearch.SelectedValue + "','" + this.cmbSubSectionSearch.SelectedValue + "','" + this.cmbManufacturerSearch.SelectedValue + "','" + this.cmb_product_type_search.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData(sql);
            this.dgvProductInfoList.AutoGenerateColumns = false;
            this.dgvProductInfoList.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();

            if (this.dgvProductInfoList.Rows.Count > 0)
                this.dgvProductInfoList.Rows[0].Selected = false;
        }
        private void LoadUnitPriceGrid(string productID)
        {
            dtProductInfo = bllProductUnitPrice.getProductAllUnitPrice(productID);
            this.dgvUnitPriceList.AutoGenerateColumns = false;
            this.dgvUnitPriceList.DataSource = dtProductInfo;

        }

        private void LoadOfferGrid(string productID)
        {
            DataTable dt = bllProductOffer.getProductAllOffer(productID);
            this.dgvOfferList.AutoGenerateColumns = false;
            this.dgvOfferList.DataSource = dt;

        }

        private void LoadMaterialGrid(string productID)
        {
            DataTable dt = bllProductMaterial.getMaterialConfigure(productID);
            this.dgvMaterialList.AutoGenerateColumns = false;
            this.dgvMaterialList.DataSource = dt;
        }

        private void LoadUnitPriceInfoByID(Int64 selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllProductUnitPrice.getProductUnitPriceInfoByID(selectedID);
            this.txtPSPID.Text = dt.Rows[0]["PSPID"].ToString();
            this.cmbUnit.SelectedValue = dt.Rows[0]["UnitID"].ToString();
            this.txtUnitPrice.Text = dt.Rows[0]["Price"].ToString();
            this.txtWholeSalePrice.Text = dt.Rows[0]["WholeSalePrice"].ToString();
            this.txtUnitQuantity.Text = dt.Rows[0]["UnitQty"].ToString();
            this.cmbUnitPriceActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
            this.chkMinimumUnit.Checked = Convert.ToBoolean(dt.Rows[0]["IsMinimumUnit"]);
        }

        private void LoadOfferInfoByID(Int64 selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllProductOffer.getProductOfferInfoByID(selectedID);
            this.txtOfferID.Text = dt.Rows[0]["OfferID"].ToString();
            this.dtpStartDate.Value = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
            this.dtpEndDate.Value = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
            this.txtQty.Text = dt.Rows[0]["Qty"].ToString();
            this.cmbFreeProduct.EditValue = dt.Rows[0]["FreeProductID"].ToString();
            this.txtFreeQty.Text = dt.Rows[0]["FreeQty"].ToString();
            this.txtGiftName.Text = dt.Rows[0]["GiftName"].ToString();
            this.txtGiftQty.Text = dt.Rows[0]["GiftQty"].ToString();
            this.cmbGiftUnit.SelectedValue = dt.Rows[0]["GiftUnitID"].ToString();

        }

        private void LoadMaterialInfoByID(Int64 selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllProductMaterial.getMaterialByID(selectedID);
            this.txtConfigID.Text = dt.Rows[0]["ConfigID"].ToString();            
            this.txtMaterialQty.Text = dt.Rows[0]["Qty"].ToString();
            this.cmbMaterial.EditValue = dt.Rows[0]["MaterialID"].ToString();
        }

        private void LoadUnitOffer()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bllUnitInfo.getAll();
                DataRow dr = dt.NewRow();
                dr["UnitId"] = "0";
                dr["UnitName"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                cmbGiftUnit.DisplayMember = "UnitName";
                cmbGiftUnit.ValueMember = "UnitId";
                cmbGiftUnit.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void LoadAcitivityCombo()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivity.DisplayMember = "Activity";
            this.cmbActivity.ValueMember = "ActivityID";
            cmbActivity.DataSource = dt;
        }
        private void LoadProductType()
        {
            DataTable dt = new DataTable();
            dt = bllReportUtility.ReportData(@"SELECT  TypeID, TypeName FROM  MedicineType WHERE (ActivityID = 1) ORDER BY TypeName");
            DataRow dr = dt.NewRow();
            dr["TypeID"] = "0";
            dr["TypeName"] = "Select";
            dt.Rows.InsertAt(dr, 0);
            this.cmb_product_type.DisplayMember = "TypeName";
            this.cmb_product_type.ValueMember = "TypeID";
            this.cmb_product_type.DataSource = dt;

            this.cmb_product_type_search.DisplayMember = "TypeName";
            this.cmb_product_type_search.ValueMember = "TypeID";
            this.cmb_product_type_search.DataSource = dt.Copy();
        }
        private void LoadAcitivityComboSearch()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbActivitySearch.DisplayMember = "Activity";
            this.cmbActivitySearch.ValueMember = "ActivityID";
            cmbActivitySearch.DataSource = dt;
        }
        private void LoadAcitivityComboUnit()
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            this.cmbUnitPriceActivity.DisplayMember = "Activity";
            this.cmbUnitPriceActivity.ValueMember = "ActivityID";
            cmbUnitPriceActivity.DataSource = dt;
        }
        private void LoadProductInfoByID(string selectedID)
        {
            DataTable dt = new DataTable();
            dt = bllProductInfo.getById(selectedID);
            this.txtProductCode.Text = dt.Rows[0]["ProductID"].ToString();
            lbl_old_product_id.Text = dt.Rows[0]["ProductID"].ToString();
            this.txtOtherCode.Text = dt.Rows[0]["OtherCode"].ToString();
            this.lblBarProductCode.Text = dt.Rows[0]["ProductID"].ToString();
            this.lblBarCode.Text = dt.Rows[0]["ProductID"].ToString();
            this.txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
            this.cmbSection.SelectedValue = Convert.ToInt64(dt.Rows[0]["SectionID"]);
            this.cmbSubSection.SelectedValue = Convert.ToInt64(dt.Rows[0]["SubSectionID"]);
            this.txtProductDescription.Text = dt.Rows[0]["ProductDescription"].ToString();
            this.txtReOrderLevel.Text = dt.Rows[0]["ReOrderLevel"].ToString();
            this.cmbVat.SelectedValue = Convert.ToInt64(dt.Rows[0]["VatID"]);
            this.cmbManufacturer.SelectedValue = dt.Rows[0]["ManufacturerID"].ToString();
            this.cmbActivity.SelectedValue = Convert.ToInt64(dt.Rows[0]["ActivityID"].ToString());
            this.cmb_product_type.SelectedValue = Convert.ToInt64(dt.Rows[0]["TypeID"].ToString());
            this.chkFractionAllow.Checked = Convert.ToBoolean(dt.Rows[0]["IsFractionAllow"]);
            lbl_serial.Text = dt.Rows[0]["SerialNo"].ToString();
            //load in Unit Tab
            this.lblProductLevel.Text = dt.Rows[0]["ProductName"].ToString() + " - " + dt.Rows[0]["ProductID"].ToString();
            this.lblProductLevelOffer.Text = dt.Rows[0]["ProductName"].ToString() + " - " + dt.Rows[0]["ProductID"].ToString();
            this.lblProductLevelMaterial.Text = dt.Rows[0]["ProductName"].ToString() + " - " + dt.Rows[0]["ProductID"].ToString();
        }
        private void LoadUnitTab(string productID)
        {
            //Load UnitPriceGrid
            LoadUnitPriceGrid(productID);
            //Select first row
            if (this.dgvUnitPriceList.Rows.Count > 0)
            {
                this.dgvUnitPriceList.Rows[0].Selected = true;
            }
            else
            {
                ClearUnitTabFields();
            }
            //Enable button
            UnitTabIsEnabled(true);
        }
        private void LoadOfferTab(string productID)
        {
            //Load UnitPriceGrid
            LoadOfferGrid(productID);
            //Select first row
            if (this.dgvOfferList.Rows.Count > 0)
            {
                this.dgvOfferList.Rows[0].Selected = true;
            }
            else
            {
                ClearOfferTabFields();
            }
            //Enable button
            UnitTabIsEnabled(true);
        }

        private void LoadMaterialConfigTab(string productID)
        {
            LoadMaterialGrid(productID);
            //Select first row
            if (this.dgvMaterialList.Rows.Count > 0)
            {
                this.dgvMaterialList.Rows[0].Selected = true;
            }
            else
            {
                ClearMaterialTabFields();
            }
            //Enable button
            UnitTabIsEnabled(true);
        }

        private void UnitTabIsEnabled(bool chk)
        {
            try
            {
                this.btnResetUnit.Enabled = chk;
                this.btnSaveUnit.Enabled = chk;
                this.btnResetOffer.Enabled = chk;
                this.btnSaveOffer.Enabled = chk;
                this.btnReset_MaterialConfig.Enabled = chk;
                this.btnSave_MaterialConfig.Enabled = chk;
            }
            catch
            { }
        }
        private void ClearFields()
        {
            try
            {
                //clear genaral tab info
                lbl_old_product_id.Text = "";
                this.txtProductCode.Text = string.Empty;
                this.txtProductDescription.Text = string.Empty;
                this.txtProductName.Text = string.Empty;
                this.txtReOrderLevel.Text = string.Empty;
                this.cmbActivity.SelectedIndex = 0;
                this.cmbManufacturer.SelectedIndex = 0;
                this.cmbVat.SelectedIndex = 0;
                this.cmbSection.SelectedIndex = 0;
                this.lblBarCode.Text = "";
                this.lblBarProductCode.Text = "";
                this.chkFractionAllow.Checked = false;
                txtOtherCode.Text = "";
                //clear unit tab info
                this.lblProductLevel.Text = "";
                this.lblProductLevelOffer.Text = "";
                ClearUnitTabFields();
                ClearOfferTabFields();
                UnitTabIsEnabled(false);
                txtProductCode.Properties.ReadOnly = false;
                this.err_productInfo.Clear();
                dgvUnitPriceList.DataSource = null;
                lbl_serial.Text = "";
            }
            catch
            { }
        }
        private void ClearFieldsSearch()
        {
            try
            {
                //clear genaral tab info
                this.txtProductCodeSearch.Text = string.Empty;
                this.txtProductNameSearch.Text = string.Empty;
                this.txtProductCodeSearch.Text = string.Empty;

                this.cmbManufacturerSearch.SelectedIndex = 0;
                this.cmbActivitySearch.SelectedIndex = 0;
                this.cmbSectionSearch.SelectedIndex = 0;
                this.cmbSubSectionSearch.SelectedIndex = 0;
            }
            catch
            { }
        }
        private void ClearUnitTabFields()
        {
            try
            {

                this.txtPSPID.Text = string.Empty;
                this.cmbUnit.SelectedIndex = 0;
                this.txtUnitPrice.Text = string.Empty;
                this.txtWholeSalePrice.Text = string.Empty;
                this.txtUnitQuantity.Text = string.Empty;
                this.cmbUnitPriceActivity.SelectedIndex = 0;
                this.chkMinimumUnit.Checked = false;
                this.err_productUnitInfo.Clear();

                if (this.dgvUnitPriceList.Rows.Count > 0)
                    this.dgvUnitPriceList.Rows[0].Selected = false;
            }
            catch
            { }
        }
        private void load_product_info()
        {
            DataTable dt = bllProductInfo.getAll();
            cmbFreeProduct.Properties.DisplayMember = "ProductName";
            cmbFreeProduct.Properties.ValueMember = "ProductID";
            cmbFreeProduct.Properties.DataSource = dt;
        }
        private void ClearOfferTabFields()
        {
            try
            {

                this.txtOfferID.Text = string.Empty;
                this.dtpStartDate.Value = DateTime.Now;
                this.dtpEndDate.Value = DateTime.Now;
                this.txtQty.Text = "";
                this.cmbFreeProduct.EditValue = null;
                cmbGiftUnit.SelectedIndex = 0;
                this.txtFreeQty.Text = string.Empty;
                this.txtGiftName.Text = string.Empty;
                this.txtGiftQty.Text = string.Empty;
                if (this.dgvOfferList.Rows.Count > 0)
                    this.dgvOfferList.Rows[0].Selected = false;
            }
            catch
            { }
        }

        private void ClearMaterialTabFields()
        {
            try
            {
                this.txtConfigID.Text = string.Empty;                
                this.txtMaterialQty.Text = "";
                this.cmbMaterial.EditValue = null;                
                if (this.dgvMaterialList.Rows.Count > 0)
                    this.dgvMaterialList.Rows[0].Selected = false;
            }
            catch
            { }
        }


        private bool isValid()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtProductCode.Text))
            {
                this.err_productInfo.SetError(txtProductCode, "Product code is mandatory");
                chk = false;
            }
            else if (string.IsNullOrEmpty(this.txtProductName.Text))
            {
                this.err_productInfo.SetError(txtProductName, "Name is mandatory");
                chk = false;
            }
            return chk;
        }
        private bool isValidUnitPrice()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(this.txtUnitQuantity.Text))
            {
                this.err_productUnitInfo.SetError(txtUnitQuantity, "Unit Quantity is mandatory");
                chk = false;
            }
            if (string.IsNullOrEmpty(this.txtUnitPrice.Text))
            {
                this.err_productUnitInfo.SetError(txtUnitPrice, "Unit Price is mandatory");
                chk = false;
            }
            return chk;
        }
        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            ActiveControl = txtProductCodeSearch;
            lbl_old_product_id.Text = "";
            this.lbl_serial.Text = "";
            bllUtility.ResetGridColor(dgvProductInfoList);
            bllUtility.ResetGridColor(dgvUnitPriceList);
            this.ActiveControl = txtProductCode;
            LoadAcitivityCombo();
            LoadProductType();
            LoadAcitivityComboSearch();
            LoadGrid();
            LoadSection();
            LoadSectionSearch();
            LoadVat();
            LoadManufacturer();
            LoadManufacturerSearch();
            //unit tab
            LoadUnit();
            LoadUnitOffer();
            LoadAcitivityComboUnit();
            load_product_info();
            load_material_info();
            UnitTabIsEnabled(false);
            this.dgvProductInfoList.DefaultCellStyle.ForeColor = Color.Black;
            //this.tab.TabPages.Remove(this.tab.TabPages["tabWarranty"]);
            //this.tab.TabPages.Remove(this.tab.TabPages["tabDiscount"]);
            //this.tab.TabPages.Remove(this.tab.TabPages["tabFree"]);
            cmbManufacturer.SelectedIndex = 0;
            cmbVat.SelectedIndex = 0;
            txtProductCodeSearch.Focus();
            txtProductCodeSearch.Focus();
        }

        private void load_material_info()
        {
            DataTable dt = bllMaterial.getAll();
            cmbMaterial.Properties.DisplayMember = "MaterialName";
            cmbMaterial.Properties.ValueMember = "MaterialID";
            cmbMaterial.Properties.DataSource = dt;
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            long SectionID = Convert.ToInt64(this.cmbSection.SelectedValue);
            LoadSubSection(SectionID);
        }
        private void dgvProductInfoList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            {

            }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                try
                {
                    //txtProductCode.Properties.ReadOnly = true;
                    this._SelctedProductID = Convert.ToString(dr.Cells[0].Value);
                    LoadProductInfoByID(_SelctedProductID);
                    LoadUnitTab(_SelctedProductID);
                    LoadOfferTab(_SelctedProductID);
                    LoadMaterialConfigTab(_SelctedProductID);
                }
                catch { }
            }
        }
        private void dgvProductInfoList_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this._SelctedProductID = Convert.ToString(this.dgvProductInfoList.SelectedRows[0].Cells[0].Value);
                LoadProductInfoByID(_SelctedProductID);
                LoadUnitTab(_SelctedProductID);
            }
            catch { }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFieldsSearch();
            ClearFields();
            //LoadGrid();
            this.txtProductCode.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.err_productInfo.Clear();
            if (isValid())
            {
                if (this.txtReOrderLevel.Text == "")
                {
                    this.txtReOrderLevel.Text = "0";
                }
                if (this.lbl_serial.Text == "")
                {
                    //insert
                    ProductInfo objProductInfo = new ProductInfo();
                    objProductInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objProductInfo.ProductID = this.txtProductCode.Text.Trim();
                    objProductInfo.OtherCode = this.txtProductCode.Text.Trim();
                    objProductInfo.ProductDescription = this.txtProductDescription.Text;
                    objProductInfo.ProductImage = "";
                    objProductInfo.ProductName = this.txtProductName.Text.ToString();
                    objProductInfo.ReorderLevel = Convert.ToInt32(this.txtReOrderLevel.Text);
                    objProductInfo.SectionId = Convert.ToInt64(this.cmbSection.SelectedValue);
                    objProductInfo.SubSectionID = Convert.ToInt64(this.cmbSubSection.SelectedValue);
                    objProductInfo.VatId = Convert.ToInt64(this.cmbVat.SelectedValue);
                    objProductInfo.ManufacturerID = Convert.ToString(this.cmbManufacturer.SelectedValue);
                    objProductInfo.CreatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
                    objProductInfo.CreatedDate = DateTime.Now;
                    objProductInfo.IsFractionAllow = Convert.ToInt16(this.chkFractionAllow.Checked);
                    objProductInfo.TypeID = Convert.ToInt64(this.cmb_product_type.SelectedValue);
                    objProductInfo.SerialNo = lbl_serial.Text;
                    DataTable dt1 = bllProductInfo.IsDuplicateProductCode(lbl_serial.Text, this.txtProductCode.Text.Trim(), "Insert");
                    if (dt1.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Product Code Found. Please change the Product Code");
                        this.txtProductCode.Focus();
                        txtProductCode.SelectAll();
                    }
                    else
                    {
                        DataTable dt = bllProductInfo.Insert(objProductInfo);
                        lbl_serial.Text = dt.Rows[0][0].ToString();
                        LoadProductInfoByID(txtProductCode.Text);
                        LoadUnitTab(txtProductCode.Text);
                    }

                }
                else
                {
                    //update
                    bool chk = false;
                    ProductInfo objProductInfo = new ProductInfo();
                    objProductInfo.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
                    objProductInfo.ProductID = this.txtProductCode.Text.Trim();
                    objProductInfo.OtherCode = this.txtProductCode.Text.Trim();
                    objProductInfo.ProductDescription = this.txtProductDescription.Text;
                    objProductInfo.ProductImage = "";
                    objProductInfo.ProductName = this.txtProductName.Text.ToString();
                    objProductInfo.ReorderLevel = Convert.ToInt32(this.txtReOrderLevel.Text);
                    objProductInfo.SectionId = Convert.ToInt64(this.cmbSection.SelectedValue);
                    objProductInfo.SubSectionID = Convert.ToInt64(this.cmbSubSection.SelectedValue);
                    objProductInfo.VatId = Convert.ToInt64(this.cmbVat.SelectedValue);
                    objProductInfo.ManufacturerID = Convert.ToString(this.cmbManufacturer.SelectedValue);
                    objProductInfo.UpdatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
                    objProductInfo.UpdatedDate = DateTime.Now;
                    objProductInfo.IsFractionAllow = Convert.ToInt16(this.chkFractionAllow.Checked);
                    objProductInfo.TypeID = Convert.ToInt64(this.cmb_product_type.SelectedValue);
                    objProductInfo.SerialNo = lbl_serial.Text;
                    DataTable dt1 = bllProductInfo.IsDuplicateProductCode(this.lbl_serial.Text.Trim(), this.txtProductCode.Text.Trim(), "Update");
                    if (dt1.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Product Code Found. Please change the Product Code");
                        this.txtProductCode.Focus();
                        txtProductCode.SelectAll();
                    }
                    else
                    {
                        chk = bllProductInfo.Update(objProductInfo, lbl_old_product_id.Text);
                        if (chk)
                        {
                            XtraMessageBox.Show("Successfully Updated the record");
                            //ClearFields();                        
                        }
                        LoadProductInfoByID(this.txtProductCode.Text.Trim());
                    }
                }
                //LoadGrid();
                //this.dgvProductInfoList.Rows[0].Selected = false;
            }
        }
        private void dgvUnitPriceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            { }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                try
                {
                    this._SelctedPSPID = Convert.ToInt32(dr.Cells[0].Value);
                    LoadUnitPriceInfoByID(_SelctedPSPID);
                }
                catch { }
            }
        }
        private void dgvUnitPriceList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //Load the selected row data fro edit mode
                DataGridView dgv = (DataGridView)sender;
                this._SelctedPSPID = Convert.ToInt32(dgv.SelectedCells[0].Value);
                LoadUnitPriceInfoByID(_SelctedPSPID);
            }
            catch { }
        }
        private void btnResetUnit_Click(object sender, EventArgs e)
        {
            ClearUnitTabFields();
        }
        private void btnSaveUnit_Click(object sender, EventArgs e)
        {
            this.err_productUnitInfo.Clear();
            ProductUnitPrice objProductUnitPrice = new ProductUnitPrice();
            if (isValidUnitPrice())
            {
                if (this.txtWholeSalePrice.Text == "")
                {
                    this.txtWholeSalePrice.Text = "0";
                }
                if (this.txtPSPID.Text == "")
                {
                    //insert operation///////////////////////////////////////////////////////////////////////////                    
                    InitializeValue(objProductUnitPrice);

                    DataTable dt2 = bllProductUnitPrice.IsDuplicateProductUnit(0, txtProductCode.Text.Trim(), Convert.ToInt64(this.cmbUnit.SelectedValue), "Insert");
                    if (dt2.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Unit Name Found. Please change the Unit Name");
                        this.cmbUnit.Focus();
                        this.cmbUnit.SelectAll();
                    }
                    else
                    {
                        //if chkMinimumUnit checked
                        if (this.chkMinimumUnit.Checked)
                        {
                            DataTable dt1 = bllProductUnitPrice.IsAlreadyHasMinimumUnit(txtProductCode.Text.Trim(), 0, "Insert");
                            if (dt1.Rows.Count > 0)
                            {
                                //if already Minimum unit defined
                                if (XtraMessageBox.Show("There is already a Minimum Unit found of this product. Do you want to replace previous one. ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    bllProductUnitPrice.UpdateIsMinimumUnitFalse(objProductUnitPrice);
                                    DataTable dt = bllProductUnitPrice.Insert(objProductUnitPrice);
                                    long ppID = Convert.ToInt64(dt.Rows[0][0]);
                                    LoadUnitPriceGrid(txtProductCode.Text.Trim());
                                    this.dgvUnitPriceList.Rows[0].Selected = false;
                                    LoadUnitPriceInfoByID(ppID);
                                }
                            }
                            else
                            {
                                //if Minimum unit not defined
                                DataTable dt = bllProductUnitPrice.Insert(objProductUnitPrice);
                                long ppID = Convert.ToInt64(dt.Rows[0][0]);
                                LoadUnitPriceGrid(txtProductCode.Text.Trim());
                                this.dgvUnitPriceList.Rows[0].Selected = false;
                                LoadUnitPriceInfoByID(ppID);
                            }
                        }
                        //if chkMinimumUnit not checked
                        else
                        {
                            DataTable dt = bllProductUnitPrice.Insert(objProductUnitPrice);
                            long ppID = Convert.ToInt64(dt.Rows[0][0]);
                            LoadUnitPriceGrid(txtProductCode.Text.Trim());
                            this.dgvUnitPriceList.Rows[0].Selected = false;
                            LoadUnitPriceInfoByID(ppID);
                        }
                    }
                }
                else
                {
                    //update operation////////////////////////////////////////////////////////////////                    
                    InitializeValue(objProductUnitPrice);

                    DataTable dt2 = bllProductUnitPrice.IsDuplicateProductUnit(Convert.ToInt64(this.txtPSPID.Text.Trim()), txtProductCode.Text.Trim(), Convert.ToInt64(this.cmbUnit.SelectedValue), "Update");
                    if (dt2.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Duplicate Unit Name Found. Please change the Unit Name");
                        this.cmbUnit.Focus();
                        this.cmbUnit.SelectAll();
                    }
                    else
                    {
                        if (this.chkMinimumUnit.Checked)
                        {
                            DataTable dt = bllProductUnitPrice.IsAlreadyHasMinimumUnit(txtProductCode.Text.Trim(), Convert.ToInt64(this.txtPSPID.Text.Trim()), "Update");
                            if (dt.Rows.Count > 0)
                            {
                                if (XtraMessageBox.Show("There is already a Minimum Unit found of this product. Do you want to replace previous one. ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    bool chk = false;
                                    bllProductUnitPrice.UpdateIsMinimumUnitFalse(objProductUnitPrice);
                                    chk = bllProductUnitPrice.Update(objProductUnitPrice);
                                    if (chk)
                                    {
                                        XtraMessageBox.Show("Successfully Updated the record");
                                    }
                                    long ppID1 = Convert.ToInt64(this.txtPSPID.Text.Trim());
                                    LoadUnitPriceGrid(txtProductCode.Text.Trim());
                                    this.dgvUnitPriceList.Rows[0].Selected = false;
                                    LoadUnitPriceInfoByID(ppID1);
                                }
                            }
                            else
                            {
                                bool chk = false;
                                chk = bllProductUnitPrice.Update(objProductUnitPrice);
                                if (chk)
                                {
                                    XtraMessageBox.Show("Successfully Updated the record");
                                }
                                long ppID1 = Convert.ToInt64(this.txtPSPID.Text.Trim());
                                LoadUnitPriceGrid(txtProductCode.Text.Trim());
                                this.dgvUnitPriceList.Rows[0].Selected = false;
                                LoadUnitPriceInfoByID(ppID1);
                            }
                        }

                        else
                        {
                            bool chk = false;
                            chk = bllProductUnitPrice.Update(objProductUnitPrice);
                            if (chk)
                            {
                                XtraMessageBox.Show("Successfully Updated the record");
                            }
                            long ppID1 = Convert.ToInt64(this.txtPSPID.Text.Trim());
                            LoadUnitPriceGrid(txtProductCode.Text.Trim());
                            this.dgvUnitPriceList.Rows[0].Selected = false;
                            LoadUnitPriceInfoByID(ppID1);
                        }
                    }
                }
            }
        }

        private void InitializeValue(ProductUnitPrice objProductUnitPrice)
        {

            if (txtPSPID.Text != "")
            {
                objProductUnitPrice.PSPID = Convert.ToInt64(this.txtPSPID.Text.Trim());
            }
            objProductUnitPrice.ProductID = this.txtProductCode.Text.Trim();
            objProductUnitPrice.UnitID = Convert.ToInt64(this.cmbUnit.SelectedValue);
            objProductUnitPrice.UnitQty = Convert.ToInt64(this.txtUnitQuantity.Text);
            objProductUnitPrice.Price = Convert.ToDouble(this.txtUnitPrice.Text);
            objProductUnitPrice.WholeSalePrice = Convert.ToDouble(this.txtWholeSalePrice.Text);
            objProductUnitPrice.ActivityID = Convert.ToInt64(this.cmbActivity.SelectedValue);
            objProductUnitPrice.IsMinimumUnit = this.chkMinimumUnit.Checked;
            objProductUnitPrice.UpdatedBy = bllUtility.LoggedInSystemInformation.LoggedUserId;
        }

        private void txtReOrderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUnitQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbSectionSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            long SectionID = Convert.ToInt64(this.cmbSectionSearch.SelectedValue);
            LoadSubSectionSearch(SectionID);
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadGridSearch();
            ClearFields();

        }

        private void btnResetOffer_Click(object sender, EventArgs e)
        {
            ClearOfferTabFields();
        }

        private void dgvOfferList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            { }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                try
                {
                    int OfferID = Convert.ToInt32(dr.Cells[0].Value);
                    LoadOfferInfoByID(OfferID);
                }
                catch { }
            }
        }

        private void dgvOfferList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //Load the selected row data fro edit mode
                DataGridView dgv = (DataGridView)sender;
                int OfferID = Convert.ToInt32(dgv.SelectedCells[0].Value);
                LoadOfferInfoByID(OfferID);
            }
            catch { }
        }

        private void btnSaveOffer_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                XtraMessageBox.Show("Product code not found.");
                return;
            }

            if (txtQty.Text == "" || txtQty.Text == "0")
            {
                XtraMessageBox.Show("Qty not entered.");
                txtQty.Focus();
                return;
            }

            //if (cmbFreeProduct.EditValue==null)
            //{
            //    XtraMessageBox.Show("Free product not selected.");
            //    cmbFreeProduct.Focus();
            //    return;
            //}

            if (txtFreeQty.Text == "")
            {
                txtFreeQty.Text="0";
            }
            if (txtGiftQty.Text == "")
            {
                txtGiftQty.Text = "0";
            }

            int OfferID = 0;
            string StartDate = "";
            string EndDate = "";
            string ProductID = "";
            int Qty = 0;
            string FreeProductID = "";
            int FreeQty = 0;
            string GiftName = "";
            int GiftQty = 0;
            string GiftUnitID = "0";

            if (cmbFreeProduct.EditValue == null)
                FreeProductID = "";
            else
                FreeProductID = cmbFreeProduct.EditValue.ToString();

            if (txtOfferID.Text=="")
                OfferID = 0;
            else
                OfferID = Convert.ToInt16(txtOfferID.Text);
            StartDate = Convert.ToDateTime(dtpStartDate.Value).ToString("dd/MM/yyyy");
            EndDate = Convert.ToDateTime(dtpEndDate.Value).ToString("dd/MM/yyyy");
            ProductID=txtProductCode.Text.Trim();
            Qty =Convert.ToInt16(txtQty.Text);
            //FreeProductID = cmbFreeProduct.EditValue.ToString();
            FreeQty = Convert.ToInt16(txtFreeQty.Text);
            GiftQty = Convert.ToInt16(txtGiftQty.Text);
            GiftName = txtGiftName.Text.Trim();
            GiftUnitID = cmbGiftUnit.SelectedValue.ToString();
            DataTable dt = bllProductOffer.Insert(OfferID, StartDate, EndDate, ProductID, Qty, FreeProductID, FreeQty, GiftName, GiftQty, GiftUnitID);
            OfferID = Convert.ToInt16(dt.Rows[0][0]);
            LoadOfferGrid(txtProductCode.Text.Trim());
            this.dgvOfferList.Rows[0].Selected = false;
            LoadOfferInfoByID(OfferID);
            XtraMessageBox.Show("Successfully Updated the record");
        }

        private void dgvProductInfoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaterialQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFreeQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiftQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvMaterialList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) == -1)
            { }
            else
            {
                DataGridViewRow dr = ((DataGridView)sender).Rows[e.RowIndex];
                try
                {
                    int MaterialID = Convert.ToInt32(dr.Cells[0].Value);
                    LoadMaterialInfoByID(MaterialID);
                }
                catch { }
            }
        }

        private void btnReset_MaterialConfig_Click(object sender, EventArgs e)
        {
            ClearMaterialTabFields();
            cmbMaterial.Focus();
        }

        private void btnSave_MaterialConfig_Click(object sender, EventArgs e)
        {
            int ConfigID = 0;
            string MaterialID = "";
            string ProductID = "";
            double Qty = 0;

            #region valid check
            if (txtProductCode.Text == "")
            {
                XtraMessageBox.Show("Product code not found.");
                return;
            }

            if (cmbMaterial.EditValue == null)
            {
                XtraMessageBox.Show("Material code not found.");
                cmbMaterial.Focus();
                return;
            }

            if (txtMaterialQty.Text == "" || txtMaterialQty.Text == "0")
            {
                XtraMessageBox.Show("Material Qty not entered.");
                txtMaterialQty.Focus();
                return;
            }
            #endregion

            if (txtConfigID.Text == "")
                ConfigID = 0;
            else
                ConfigID = Convert.ToInt16(txtConfigID.Text);            
            ProductID = txtProductCode.Text.Trim();
            MaterialID = cmbMaterial.EditValue.ToString();
            Qty = bllUtility.Val(txtMaterialQty.Text);
            
            
            DataTable dt = bllProductMaterial.Insert(ConfigID,ProductID,MaterialID,Qty);
            ConfigID = Convert.ToInt16(dt.Rows[0][0]);
            LoadMaterialGrid(txtProductCode.Text.Trim());
            this.dgvMaterialList.Rows[0].Selected = false;
            LoadMaterialInfoByID(ConfigID);
            XtraMessageBox.Show("Successfully Updated the record");
        }

        private void dgvMaterialList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //Load the selected row data fro edit mode
                DataGridView dgv = (DataGridView)sender;
                int ConfigID = Convert.ToInt32(dgv.SelectedCells[0].Value);
                LoadMaterialInfoByID(ConfigID);
            }
            catch { }
        }

        private void txtProductCodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void txtProductNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmbActivitySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmbSectionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmbSubSectionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmbManufacturerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void cmb_product_type_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }
    }
}
