namespace SalesPOS
{
    partial class frmReportCurrentStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCurrentStock));
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSubSection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_manufacturer = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.link_product_stock_storewise = new System.Windows.Forms.LinkLabel();
            this.lnk_material_stock = new System.Windows.Forms.LinkLabel();
            this.chk_product = new System.Windows.Forms.CheckBox();
            this.cmb_product = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.cmb_view_product = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_close_material_stock = new DevExpress.XtraEditors.SimpleButton();
            this.grd_material_stock = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grp_material_stock = new DevExpress.XtraEditors.GroupControl();
            this.grp_product_current_stock = new DevExpress.XtraEditors.GroupControl();
            this.grdStoreWiseProductStock = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_manufacturer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_product.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_view_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_material_stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_material_stock)).BeginInit();
            this.grp_material_stock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grp_product_current_stock)).BeginInit();
            this.grp_product_current_stock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStoreWiseProductStock)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(120, 75);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(231, 21);
            this.cmbSection.TabIndex = 125;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(5, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Category :";
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Appearance.Options.UseForeColor = true;
            this.btnPreview.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnPreview.Location = new System.Drawing.Point(181, 129);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(86, 25);
            this.btnPreview.TabIndex = 124;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbSubSection
            // 
            this.cmbSubSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSubSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubSection.FormattingEnabled = true;
            this.cmbSubSection.Location = new System.Drawing.Point(226, 66);
            this.cmbSubSection.Name = "cmbSubSection";
            this.cmbSubSection.Size = new System.Drawing.Size(172, 21);
            this.cmbSubSection.TabIndex = 128;
            this.cmbSubSection.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(129, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Sub-Category :";
            this.label2.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(272, 129);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 25);
            this.btnClose.TabIndex = 129;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmb_manufacturer
            // 
            this.cmb_manufacturer.Location = new System.Drawing.Point(120, 102);
            this.cmb_manufacturer.Name = "cmb_manufacturer";
            this.cmb_manufacturer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_manufacturer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufacturarName", 40, "Manufacturar"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufacturerID", 40, "Code")});
            this.cmb_manufacturer.Properties.DisplayMember = "ManufacturarName";
            this.cmb_manufacturer.Properties.NullText = "";
            this.cmb_manufacturer.Properties.PopupWidth = 300;
            this.cmb_manufacturer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmb_manufacturer.Properties.ValueMember = "ManufacturerID";
            this.cmb_manufacturer.Size = new System.Drawing.Size(231, 20);
            this.cmb_manufacturer.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(5, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 132;
            this.label4.Text = "Manufacturer";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.link_product_stock_storewise);
            this.groupControl1.Controls.Add(this.lnk_material_stock);
            this.groupControl1.Controls.Add(this.chk_product);
            this.groupControl1.Controls.Add(this.cmb_product);
            this.groupControl1.Controls.Add(this.cmbSection);
            this.groupControl1.Controls.Add(this.cmb_manufacturer);
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Location = new System.Drawing.Point(109, 110);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(364, 183);
            this.groupControl1.TabIndex = 134;
            this.groupControl1.Text = "Current Stock Report";
            // 
            // link_product_stock_storewise
            // 
            this.link_product_stock_storewise.AutoSize = true;
            this.link_product_stock_storewise.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_product_stock_storewise.Location = new System.Drawing.Point(5, 163);
            this.link_product_stock_storewise.Name = "link_product_stock_storewise";
            this.link_product_stock_storewise.Size = new System.Drawing.Size(148, 13);
            this.link_product_stock_storewise.TabIndex = 147;
            this.link_product_stock_storewise.TabStop = true;
            this.link_product_stock_storewise.Text = "Store wise Product Stock";
            this.link_product_stock_storewise.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_product_stock_storewise_LinkClicked);
            // 
            // lnk_material_stock
            // 
            this.lnk_material_stock.AutoSize = true;
            this.lnk_material_stock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnk_material_stock.Location = new System.Drawing.Point(5, 141);
            this.lnk_material_stock.Name = "lnk_material_stock";
            this.lnk_material_stock.Size = new System.Drawing.Size(89, 13);
            this.lnk_material_stock.TabIndex = 146;
            this.lnk_material_stock.TabStop = true;
            this.lnk_material_stock.Text = "Material Stock";
            this.lnk_material_stock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_material_stock_LinkClicked);
            // 
            // chk_product
            // 
            this.chk_product.AutoSize = true;
            this.chk_product.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_product.Location = new System.Drawing.Point(7, 48);
            this.chk_product.Name = "chk_product";
            this.chk_product.Size = new System.Drawing.Size(108, 17);
            this.chk_product.TabIndex = 145;
            this.chk_product.Text = "Select Product";
            this.chk_product.UseVisualStyleBackColor = true;
            this.chk_product.CheckedChanged += new System.EventHandler(this.chk_product_CheckedChanged);
            // 
            // cmb_product
            // 
            this.cmb_product.Location = new System.Drawing.Point(120, 45);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_product.Properties.Appearance.Options.UseFont = true;
            this.cmb_product.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_product.Properties.NullText = "";
            this.cmb_product.Properties.View = this.cmb_view_product;
            this.cmb_product.Size = new System.Drawing.Size(231, 24);
            this.cmb_product.TabIndex = 144;
            // 
            // cmb_view_product
            // 
            this.cmb_view_product.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cmb_view_product.Name = "cmb_view_product";
            this.cmb_view_product.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cmb_view_product.OptionsView.ShowGroupPanel = false;
            // 
            // btn_close_material_stock
            // 
            this.btn_close_material_stock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close_material_stock.Image = global::SalesPOS.Properties.Resources.Delete_16x16;
            this.btn_close_material_stock.Location = new System.Drawing.Point(522, 0);
            this.btn_close_material_stock.Name = "btn_close_material_stock";
            this.btn_close_material_stock.Size = new System.Drawing.Size(22, 23);
            this.btn_close_material_stock.TabIndex = 136;
            this.btn_close_material_stock.Click += new System.EventHandler(this.btn_close_material_stock_Click);
            // 
            // grd_material_stock
            // 
            this.grd_material_stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_material_stock.Location = new System.Drawing.Point(2, 22);
            this.grd_material_stock.MainView = this.gridView1;
            this.grd_material_stock.Name = "grd_material_stock";
            this.grd_material_stock.Size = new System.Drawing.Size(540, 315);
            this.grd_material_stock.TabIndex = 137;
            this.grd_material_stock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.grd_material_stock;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "MaterialID";
            this.gridColumn1.FieldName = "MaterialID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "MaterialName";
            this.gridColumn2.FieldName = "MaterialName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "UnitName";
            this.gridColumn3.FieldName = "UnitName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "StockQty";
            this.gridColumn4.FieldName = "StockQty";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TotalCostPrice";
            this.gridColumn5.FieldName = "TotalCostPrice";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grd_material_stock;
            this.gridView2.Name = "gridView2";
            // 
            // grp_material_stock
            // 
            this.grp_material_stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_material_stock.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_material_stock.AppearanceCaption.Options.UseFont = true;
            this.grp_material_stock.Controls.Add(this.grd_material_stock);
            this.grp_material_stock.Controls.Add(this.btn_close_material_stock);
            this.grp_material_stock.Location = new System.Drawing.Point(12, 12);
            this.grp_material_stock.Name = "grp_material_stock";
            this.grp_material_stock.Size = new System.Drawing.Size(544, 339);
            this.grp_material_stock.TabIndex = 138;
            this.grp_material_stock.Text = "Material Stock";
            this.grp_material_stock.Visible = false;
            // 
            // grp_product_current_stock
            // 
            this.grp_product_current_stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_product_current_stock.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_product_current_stock.AppearanceCaption.Options.UseFont = true;
            this.grp_product_current_stock.Controls.Add(this.grdStoreWiseProductStock);
            this.grp_product_current_stock.Controls.Add(this.simpleButton1);
            this.grp_product_current_stock.Location = new System.Drawing.Point(12, 12);
            this.grp_product_current_stock.Name = "grp_product_current_stock";
            this.grp_product_current_stock.Size = new System.Drawing.Size(544, 339);
            this.grp_product_current_stock.TabIndex = 139;
            this.grp_product_current_stock.Text = "Product Stock Qty Wise";
            this.grp_product_current_stock.Visible = false;
            // 
            // grdStoreWiseProductStock
            // 
            this.grdStoreWiseProductStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStoreWiseProductStock.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4});
            this.grdStoreWiseProductStock.Location = new System.Drawing.Point(2, 22);
            this.grdStoreWiseProductStock.Name = "grdStoreWiseProductStock";
            this.grdStoreWiseProductStock.Size = new System.Drawing.Size(540, 315);
            this.grdStoreWiseProductStock.TabIndex = 137;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "ProductID";
            this.pivotGridField1.FieldName = "ProductID";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "ProductName";
            this.pivotGridField2.FieldName = "ProductName";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "StoreName";
            this.pivotGridField3.FieldName = "StoreName";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "Quantity";
            this.pivotGridField4.CellFormat.FormatString = "f2";
            this.pivotGridField4.FieldName = "Quantity";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = global::SalesPOS.Properties.Resources.Delete_16x16;
            this.simpleButton1.Location = new System.Drawing.Point(522, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(22, 23);
            this.simpleButton1.TabIndex = 136;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmReportCurrentStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 363);
            this.Controls.Add(this.grp_product_current_stock);
            this.Controls.Add(this.grp_material_stock);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cmbSubSection);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportCurrentStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Stock Analysis Report";
            this.Load += new System.EventHandler(this.frmReportCurrentStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_manufacturer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_product.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_view_product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_material_stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_material_stock)).EndInit();
            this.grp_material_stock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grp_product_current_stock)).EndInit();
            this.grp_product_current_stock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStoreWiseProductStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.ComboBox cmbSubSection;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LookUpEdit cmb_manufacturer;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.CheckBox chk_product;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_product;
        private DevExpress.XtraGrid.Views.Grid.GridView cmb_view_product;
        private System.Windows.Forms.LinkLabel lnk_material_stock;
        private DevExpress.XtraEditors.SimpleButton btn_close_material_stock;
        private DevExpress.XtraGrid.GridControl grd_material_stock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.GroupControl grp_material_stock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.GroupControl grp_product_current_stock;
        private DevExpress.XtraPivotGrid.PivotGridControl grdStoreWiseProductStock;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.LinkLabel link_product_stock_storewise;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
    }
}