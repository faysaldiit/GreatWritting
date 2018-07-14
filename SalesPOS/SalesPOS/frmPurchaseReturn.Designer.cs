namespace SalesPOS
{
    partial class frmPurchaseReturn
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.txtPRNumber = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpPRDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_supplier = new DevExpress.XtraEditors.LookUpEdit();
            this.cmb_product = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.grd_purchase_return = new DevExpress.XtraGrid.GridControl();
            this.ctMenuStrip_Category = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_delete_line = new System.Windows.Forms.ToolStripMenuItem();
            this.grd_view_purchase_return = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPRAmount = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddToGrid = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip_button = new System.Windows.Forms.ToolStrip();
            this.toolStrip_btn_new = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_btn_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_btn_print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_btn_close = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPRNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_supplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_product.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_purchase_return)).BeginInit();
            this.ctMenuStrip_Category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_purchase_return)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPRAmount.Properties)).BeginInit();
            this.toolStrip_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPRNumber
            // 
            this.txtPRNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPRNumber.Location = new System.Drawing.Point(522, 64);
            this.txtPRNumber.Name = "txtPRNumber";
            this.txtPRNumber.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPRNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txtPRNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtPRNumber.Properties.Appearance.Options.UseFont = true;
            this.txtPRNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtPRNumber.Properties.ReadOnly = true;
            this.txtPRNumber.Size = new System.Drawing.Size(207, 20);
            this.txtPRNumber.TabIndex = 41;
            this.txtPRNumber.TabStop = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(427, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "PR Number";
            // 
            // dtpPRDate
            // 
            this.dtpPRDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPRDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPRDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPRDate.Location = new System.Drawing.Point(522, 91);
            this.dtpPRDate.Name = "dtpPRDate";
            this.dtpPRDate.Size = new System.Drawing.Size(207, 21);
            this.dtpPRDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(427, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "PR Date";
            // 
            // cmb_supplier
            // 
            this.cmb_supplier.EnterMoveNextControl = true;
            this.cmb_supplier.Location = new System.Drawing.Point(108, 63);
            this.cmb_supplier.Name = "cmb_supplier";
            this.cmb_supplier.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_supplier.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmb_supplier.Properties.Appearance.Options.UseFont = true;
            this.cmb_supplier.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_supplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_supplier.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccHolderName", 40, "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", 40, "Address"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountNo", 40, "Account No")});
            this.cmb_supplier.Properties.DisplayMember = "AccHolderName";
            this.cmb_supplier.Properties.NullText = "";
            this.cmb_supplier.Properties.PopupWidth = 300;
            this.cmb_supplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmb_supplier.Properties.ValueMember = "AccountNo";
            this.cmb_supplier.Size = new System.Drawing.Size(241, 20);
            this.cmb_supplier.TabIndex = 0;
            // 
            // cmb_product
            // 
            this.cmb_product.Location = new System.Drawing.Point(108, 92);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_product.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmb_product.Properties.Appearance.Options.UseFont = true;
            this.cmb_product.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_product.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_product.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_product.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_product.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Product Name", 60, DevExpress.Utils.FormatType.DateTime, "d", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductID", 30, "Code")});
            this.cmb_product.Properties.DisplayMember = "ProductName";
            this.cmb_product.Properties.DropDownRows = 15;
            this.cmb_product.Properties.NullText = "";
            this.cmb_product.Properties.PopupWidth = 300;
            this.cmb_product.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmb_product.Properties.ValueMember = "ProductID";
            this.cmb_product.Size = new System.Drawing.Size(241, 20);
            this.cmb_product.TabIndex = 1;
            this.cmb_product.EditValueChanged += new System.EventHandler(this.cmb_product_EditValueChanged);
            this.cmb_product.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmb_product_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Location = new System.Drawing.Point(16, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 66;
            this.labelControl2.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Product Code";
            // 
            // grd_purchase_return
            // 
            this.grd_purchase_return.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_purchase_return.ContextMenuStrip = this.ctMenuStrip_Category;
            gridLevelNode1.RelationName = "Level1";
            this.grd_purchase_return.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grd_purchase_return.Location = new System.Drawing.Point(16, 139);
            this.grd_purchase_return.MainView = this.grd_view_purchase_return;
            this.grd_purchase_return.Name = "grd_purchase_return";
            this.grd_purchase_return.Size = new System.Drawing.Size(713, 237);
            this.grd_purchase_return.TabIndex = 3;
            this.grd_purchase_return.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grd_view_purchase_return});
            this.grd_purchase_return.EditorKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grd_purchase_return_EditorKeyPress);
            // 
            // ctMenuStrip_Category
            // 
            this.ctMenuStrip_Category.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_delete_line});
            this.ctMenuStrip_Category.Name = "contextMenuStrip1";
            this.ctMenuStrip_Category.Size = new System.Drawing.Size(131, 26);
            // 
            // mnu_delete_line
            // 
            this.mnu_delete_line.Name = "mnu_delete_line";
            this.mnu_delete_line.Size = new System.Drawing.Size(130, 22);
            this.mnu_delete_line.Text = "Delete Item";
            this.mnu_delete_line.Click += new System.EventHandler(this.mnu_delete_line_Click);
            // 
            // grd_view_purchase_return
            // 
            this.grd_view_purchase_return.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2});
            this.grd_view_purchase_return.GridControl = this.grd_purchase_return;
            this.grd_view_purchase_return.Name = "grd_view_purchase_return";
            this.grd_view_purchase_return.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grd_view_purchase_return.OptionsCustomization.AllowColumnMoving = false;
            this.grd_view_purchase_return.OptionsCustomization.AllowColumnResizing = false;
            this.grd_view_purchase_return.OptionsCustomization.AllowFilter = false;
            this.grd_view_purchase_return.OptionsCustomization.AllowGroup = false;
            this.grd_view_purchase_return.OptionsCustomization.AllowSort = false;
            this.grd_view_purchase_return.OptionsNavigation.EnterMoveNextColumn = true;
            this.grd_view_purchase_return.OptionsPrint.PrintPreview = true;
            this.grd_view_purchase_return.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grd_view_purchase_return.OptionsView.ShowFooter = true;
            this.grd_view_purchase_return.OptionsView.ShowGroupPanel = false;
            this.grd_view_purchase_return.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grd_view_purchase_return_ValidatingEditor);
            this.grd_view_purchase_return.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grd_view_purchase_return_CellValueChanged);
            this.grd_view_purchase_return.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grd_view_purchase_return_KeyPress);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Code";
            this.gridColumn6.FieldName = "ProductID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 116;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Product Name";
            this.gridColumn7.FieldName = "ProductName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 215;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "PR Qty";
            this.gridColumn8.FieldName = "PRQty";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 82;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Unit";
            this.gridColumn9.FieldName = "UnitName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 54;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "UnitID";
            this.gridColumn11.FieldName = "UnitId";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Total Price";
            this.gridColumn10.FieldName = "TotalPrice";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn10.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 202;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Unit Price";
            this.gridColumn1.FieldName = "UnitPrice";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "On Stock";
            this.gridColumn2.FieldName = "Stock";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 63;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.txtPRAmount);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.btnAddToGrid);
            this.groupControl1.Controls.Add(this.toolStrip_button);
            this.groupControl1.Controls.Add(this.dtpPRDate);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.grd_purchase_return);
            this.groupControl1.Controls.Add(this.label14);
            this.groupControl1.Controls.Add(this.cmb_supplier);
            this.groupControl1.Controls.Add(this.txtPRNumber);
            this.groupControl1.Controls.Add(this.cmb_product);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(19, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(750, 421);
            this.groupControl1.TabIndex = 73;
            this.groupControl1.Text = "Purchase Return";
            // 
            // txtPRAmount
            // 
            this.txtPRAmount.EditValue = "0.00";
            this.txtPRAmount.Location = new System.Drawing.Point(552, 382);
            this.txtPRAmount.Name = "txtPRAmount";
            this.txtPRAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRAmount.Properties.Appearance.Options.UseFont = true;
            this.txtPRAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPRAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPRAmount.Properties.MaxLength = 10;
            this.txtPRAmount.Size = new System.Drawing.Size(175, 29);
            this.txtPRAmount.TabIndex = 74;
            this.txtPRAmount.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(476, 389);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 75;
            this.label10.Text = "PR Amount";
            this.label10.Visible = false;
            // 
            // btnAddToGrid
            // 
            this.btnAddToGrid.Image = global::SalesPOS.Properties.Resources.Add_16x16;
            this.btnAddToGrid.Location = new System.Drawing.Point(356, 90);
            this.btnAddToGrid.Name = "btnAddToGrid";
            this.btnAddToGrid.Size = new System.Drawing.Size(58, 23);
            this.btnAddToGrid.TabIndex = 73;
            this.btnAddToGrid.Text = "Add";
            this.btnAddToGrid.Click += new System.EventHandler(this.btnAddToGrid_Click);
            // 
            // toolStrip_button
            // 
            this.toolStrip_button.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_button.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_btn_new,
            this.toolStripSeparator1,
            this.toolStrip_btn_save,
            this.toolStripSeparator2,
            this.toolStrip_btn_print,
            this.toolStripSeparator3,
            this.toolStrip_btn_close});
            this.toolStrip_button.Location = new System.Drawing.Point(2, 22);
            this.toolStrip_button.Name = "toolStrip_button";
            this.toolStrip_button.Size = new System.Drawing.Size(746, 25);
            this.toolStrip_button.TabIndex = 65;
            this.toolStrip_button.Text = "toolStrip1";
            // 
            // toolStrip_btn_new
            // 
            this.toolStrip_btn_new.AutoSize = false;
            this.toolStrip_btn_new.AutoToolTip = false;
            this.toolStrip_btn_new.Image = global::SalesPOS.Properties.Resources.New;
            this.toolStrip_btn_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btn_new.Name = "toolStrip_btn_new";
            this.toolStrip_btn_new.Size = new System.Drawing.Size(48, 22);
            this.toolStrip_btn_new.Text = "&New";
            this.toolStrip_btn_new.Click += new System.EventHandler(this.toolStrip_btn_new_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip_btn_save
            // 
            this.toolStrip_btn_save.Image = global::SalesPOS.Properties.Resources.Save;
            this.toolStrip_btn_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btn_save.Name = "toolStrip_btn_save";
            this.toolStrip_btn_save.Size = new System.Drawing.Size(51, 22);
            this.toolStrip_btn_save.Text = "&Save";
            this.toolStrip_btn_save.Click += new System.EventHandler(this.toolStrip_btn_save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStrip_btn_print
            // 
            this.toolStrip_btn_print.Image = global::SalesPOS.Properties.Resources.print;
            this.toolStrip_btn_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btn_print.Name = "toolStrip_btn_print";
            this.toolStrip_btn_print.Size = new System.Drawing.Size(49, 22);
            this.toolStrip_btn_print.Text = "Print";
            this.toolStrip_btn_print.Visible = false;
            this.toolStrip_btn_print.Click += new System.EventHandler(this.toolStrip_btn_print_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip_btn_close
            // 
            this.toolStrip_btn_close.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.toolStrip_btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btn_close.Name = "toolStrip_btn_close";
            this.toolStrip_btn_close.Size = new System.Drawing.Size(53, 22);
            this.toolStrip_btn_close.Text = "&Close";
            this.toolStrip_btn_close.Click += new System.EventHandler(this.toolStrip_btn_close_Click);
            // 
            // frmPurchaseReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 445);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Purchase Return";
            this.Load += new System.EventHandler(this.frmPurchaseReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPRNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_supplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_product.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_purchase_return)).EndInit();
            this.ctMenuStrip_Category.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_purchase_return)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPRAmount.Properties)).EndInit();
            this.toolStrip_button.ResumeLayout(false);
            this.toolStrip_button.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPRNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpPRDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit cmb_supplier;
        private DevExpress.XtraEditors.LookUpEdit cmb_product;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl grd_purchase_return;
        private DevExpress.XtraGrid.Views.Grid.GridView grd_view_purchase_return;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ToolStrip toolStrip_button;
        private System.Windows.Forms.ToolStripButton toolStrip_btn_new;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStrip_btn_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStrip_btn_print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStrip_btn_close;
        private DevExpress.XtraEditors.SimpleButton btnAddToGrid;
        private System.Windows.Forms.ContextMenuStrip ctMenuStrip_Category;
        private System.Windows.Forms.ToolStripMenuItem mnu_delete_line;
        private DevExpress.XtraEditors.TextEdit txtPRAmount;
        private System.Windows.Forms.Label label10;

    }
}