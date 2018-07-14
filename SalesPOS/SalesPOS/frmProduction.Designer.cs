namespace SalesPOS
{
    partial class frmProduction
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduction));
            this.btnAddToGrid = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductionNo = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpProductionDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmnu_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtProductionQty = new DevExpress.XtraEditors.TextEdit();
            this.label41 = new System.Windows.Forms.Label();
            this.cmbProduct = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label42 = new System.Windows.Forms.Label();
            this.grdProduction = new DevExpress.XtraGrid.GridControl();
            this.gvProduction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductionQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialStockQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_amount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionNo.Properties)).BeginInit();
            this.cmnu_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduction)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddToGrid
            // 
            this.btnAddToGrid.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToGrid.Appearance.Options.UseFont = true;
            this.btnAddToGrid.Image = global::SalesPOS.Properties.Resources.Add_16x16;
            this.btnAddToGrid.Location = new System.Drawing.Point(327, 56);
            this.btnAddToGrid.Name = "btnAddToGrid";
            this.btnAddToGrid.Size = new System.Drawing.Size(56, 22);
            this.btnAddToGrid.TabIndex = 2;
            this.btnAddToGrid.Text = "Add";
            this.btnAddToGrid.Click += new System.EventHandler(this.btnAddToGrid_Click);
            // 
            // txtProductionNo
            // 
            this.txtProductionNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductionNo.Location = new System.Drawing.Point(597, 25);
            this.txtProductionNo.Name = "txtProductionNo";
            this.txtProductionNo.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductionNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionNo.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txtProductionNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtProductionNo.Properties.Appearance.Options.UseFont = true;
            this.txtProductionNo.Properties.Appearance.Options.UseForeColor = true;
            this.txtProductionNo.Properties.ReadOnly = true;
            this.txtProductionNo.Size = new System.Drawing.Size(207, 21);
            this.txtProductionNo.TabIndex = 0;
            this.txtProductionNo.TabStop = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(498, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 14);
            this.label14.TabIndex = 40;
            this.label14.Text = "Production ID";
            // 
            // dtpProductionDate
            // 
            this.dtpProductionDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpProductionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpProductionDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProductionDate.Location = new System.Drawing.Point(597, 52);
            this.dtpProductionDate.Name = "dtpProductionDate";
            this.dtpProductionDate.Size = new System.Drawing.Size(207, 22);
            this.dtpProductionDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(498, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Production Date";
            // 
            // cmnu_strip
            // 
            this.cmnu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_delete});
            this.cmnu_strip.Name = "contextMenuStrip1";
            this.cmnu_strip.Size = new System.Drawing.Size(108, 26);
            // 
            // mnu_delete
            // 
            this.mnu_delete.Name = "mnu_delete";
            this.mnu_delete.Size = new System.Drawing.Size(107, 22);
            this.mnu_delete.Text = "Delete";
            this.mnu_delete.Click += new System.EventHandler(this.mnu_delete_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetForm.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetForm.Appearance.Options.UseFont = true;
            this.btnResetForm.Appearance.Options.UseForeColor = true;
            this.btnResetForm.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnResetForm.Location = new System.Drawing.Point(584, 334);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(74, 27);
            this.btnResetForm.TabIndex = 3;
            this.btnResetForm.Text = "&Reset";
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(744, 334);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 27);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = global::SalesPOS.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(664, 334);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtProductionQty);
            this.groupControl1.Controls.Add(this.label41);
            this.groupControl1.Controls.Add(this.cmbProduct);
            this.groupControl1.Controls.Add(this.label42);
            this.groupControl1.Controls.Add(this.btnAddToGrid);
            this.groupControl1.Controls.Add(this.txtProductionNo);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.dtpProductionDate);
            this.groupControl1.Controls.Add(this.label14);
            this.groupControl1.Location = new System.Drawing.Point(5, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(813, 88);
            this.groupControl1.TabIndex = 45;
            this.groupControl1.Text = "Production";
            // 
            // txtProductionQty
            // 
            this.txtProductionQty.Location = new System.Drawing.Point(125, 56);
            this.txtProductionQty.Name = "txtProductionQty";
            this.txtProductionQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionQty.Properties.Appearance.Options.UseFont = true;
            this.txtProductionQty.Properties.MaxLength = 10;
            this.txtProductionQty.Size = new System.Drawing.Size(196, 21);
            this.txtProductionQty.TabIndex = 1;
            this.txtProductionQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductionQty_KeyPress);
            this.txtProductionQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductionQty_KeyDown);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(6, 56);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(117, 14);
            this.label41.TabIndex = 62;
            this.label41.Text = "Production Quantity";
            // 
            // cmbProduct
            // 
            this.cmbProduct.Location = new System.Drawing.Point(125, 28);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.Properties.Appearance.Options.UseFont = true;
            this.cmbProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProduct.Properties.NullText = "";
            this.cmbProduct.Properties.View = this.gridView1;
            this.cmbProduct.Size = new System.Drawing.Size(196, 22);
            this.cmbProduct.TabIndex = 0;
            this.cmbProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMaterial_KeyDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "ID";
            this.gridColumn3.FieldName = "ProductID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 170;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "Material Name";
            this.gridColumn4.FieldName = "ProductName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 433;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(6, 29);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(85, 14);
            this.label42.TabIndex = 60;
            this.label42.Text = "Product Name";
            // 
            // grdProduction
            // 
            this.grdProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProduction.ContextMenuStrip = this.cmnu_strip;
            this.grdProduction.Location = new System.Drawing.Point(5, 107);
            this.grdProduction.MainView = this.gvProduction;
            this.grdProduction.Name = "grdProduction";
            this.grdProduction.Size = new System.Drawing.Size(813, 221);
            this.grdProduction.TabIndex = 0;
            this.grdProduction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProduction});
            // 
            // gvProduction
            // 
            this.gvProduction.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvProduction.Appearance.FooterPanel.Options.UseFont = true;
            this.gvProduction.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvProduction.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvProduction.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvProduction.Appearance.Row.Options.UseFont = true;
            this.gvProduction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductID,
            this.ProductName,
            this.ProductUnit,
            this.ProductionQty,
            this.MaterialID,
            this.MaterialName,
            this.MaterialUnit,
            this.MaterialQty,
            this.MaterialStockQty});
            this.gvProduction.GridControl = this.grdProduction;
            this.gvProduction.Name = "gvProduction";
            this.gvProduction.OptionsBehavior.Editable = false;
            this.gvProduction.OptionsView.AllowCellMerge = true;
            this.gvProduction.OptionsView.ShowFooter = true;
            this.gvProduction.OptionsView.ShowGroupPanel = false;
            this.gvProduction.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gvProduction_CellMerge);
            this.gvProduction.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvProduction_RowCellStyle);
            // 
            // ProductID
            // 
            this.ProductID.Caption = "ProductID";
            this.ProductID.FieldName = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.ProductID.Visible = true;
            this.ProductID.VisibleIndex = 0;
            this.ProductID.Width = 67;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "ProductName";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            this.ProductName.Width = 191;
            // 
            // ProductUnit
            // 
            this.ProductUnit.Caption = "Unit";
            this.ProductUnit.FieldName = "ProductUnit";
            this.ProductUnit.Name = "ProductUnit";
            this.ProductUnit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.ProductUnit.Visible = true;
            this.ProductUnit.VisibleIndex = 3;
            this.ProductUnit.Width = 73;
            // 
            // ProductionQty
            // 
            this.ProductionQty.Caption = "ProductionQty";
            this.ProductionQty.FieldName = "ProductionQty";
            this.ProductionQty.Name = "ProductionQty";
            this.ProductionQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.ProductionQty.Visible = true;
            this.ProductionQty.VisibleIndex = 2;
            this.ProductionQty.Width = 87;
            // 
            // MaterialID
            // 
            this.MaterialID.Caption = "MaterialID";
            this.MaterialID.FieldName = "MaterialID";
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MaterialID.Visible = true;
            this.MaterialID.VisibleIndex = 4;
            this.MaterialID.Width = 73;
            // 
            // MaterialName
            // 
            this.MaterialName.Caption = "MaterialName";
            this.MaterialName.FieldName = "MaterialName";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MaterialName.Visible = true;
            this.MaterialName.VisibleIndex = 5;
            this.MaterialName.Width = 100;
            // 
            // MaterialUnit
            // 
            this.MaterialUnit.Caption = "Unit";
            this.MaterialUnit.FieldName = "MaterialUnit";
            this.MaterialUnit.Name = "MaterialUnit";
            this.MaterialUnit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MaterialUnit.Visible = true;
            this.MaterialUnit.VisibleIndex = 6;
            this.MaterialUnit.Width = 58;
            // 
            // MaterialQty
            // 
            this.MaterialQty.Caption = "MaterialQty";
            this.MaterialQty.FieldName = "MaterialQty";
            this.MaterialQty.Name = "MaterialQty";
            this.MaterialQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MaterialQty.Visible = true;
            this.MaterialQty.VisibleIndex = 7;
            this.MaterialQty.Width = 79;
            // 
            // MaterialStockQty
            // 
            this.MaterialStockQty.Caption = "StockQty";
            this.MaterialStockQty.FieldName = "MaterialStockQty";
            this.MaterialStockQty.Name = "MaterialStockQty";
            this.MaterialStockQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MaterialStockQty.Visible = true;
            this.MaterialStockQty.VisibleIndex = 8;
            this.MaterialStockQty.Width = 67;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 61;
            this.label2.Text = "Total Amount :";
            // 
            // lbl_amount
            // 
            this.lbl_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_amount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_amount.ForeColor = System.Drawing.Color.Blue;
            this.lbl_amount.Location = new System.Drawing.Point(99, 339);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(116, 18);
            this.lbl_amount.TabIndex = 63;
            this.lbl_amount.Text = "54000";
            // 
            // frmProduction
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 369);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.grdProduction);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production";
            this.Load += new System.EventHandler(this.frmPurchaseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionNo.Properties)).EndInit();
            this.cmnu_strip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpProductionDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtProductionNo;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.SimpleButton btnResetForm;
        private DevExpress.XtraEditors.SimpleButton btnAddToGrid;
        private System.Windows.Forms.ContextMenuStrip cmnu_strip;
        private System.Windows.Forms.ToolStripMenuItem mnu_delete;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Label label42;
        private DevExpress.XtraEditors.TextEdit txtProductionQty;
        private System.Windows.Forms.Label label41;
        private DevExpress.XtraGrid.GridControl grdProduction;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProduction;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn ProductUnit;
        private DevExpress.XtraGrid.Columns.GridColumn ProductionQty;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialUnit;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialQty;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialStockQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_amount;
    }
}