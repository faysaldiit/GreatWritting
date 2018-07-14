namespace SalesPOS
{
    partial class frmPurchaseInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseInfo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDues = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPaid = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.btnSupplierSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSupplierName = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSupplierCode = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.btnResetGrid = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddToGrid = new DevExpress.XtraEditors.SimpleButton();
            this.lblMinimumUnitID = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblMinimumUnit = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtPurchaseNo = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemoNo = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.chkExpireDate = new System.Windows.Forms.CheckBox();
            this.btnSearchProduct = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductID = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPurchaseGrid = new SalesPOS.ja_grid();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductMinimumUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsExpDate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnu_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnResetForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalItemAmount = new System.Windows.Forms.Label();
            this.lblTotalItem = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgvProductUnitQuantity = new SalesPOS.ja_grid();
            this.PUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnteredQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDues.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid.Properties)).BeginInit();
            this.grpSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseGrid)).BeginInit();
            this.cmnu_strip.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductUnitQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtDues);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPaid);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(596, 438);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 99);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Info";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(193, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "TK.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(193, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "TK.";
            // 
            // txtDues
            // 
            this.txtDues.EditValue = "0.00";
            this.txtDues.Location = new System.Drawing.Point(44, 57);
            this.txtDues.Name = "txtDues";
            this.txtDues.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDues.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDues.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtDues.Properties.Appearance.Options.UseBackColor = true;
            this.txtDues.Properties.Appearance.Options.UseFont = true;
            this.txtDues.Properties.Appearance.Options.UseForeColor = true;
            this.txtDues.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDues.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDues.Properties.ReadOnly = true;
            this.txtDues.Size = new System.Drawing.Size(147, 29);
            this.txtDues.TabIndex = 13;
            this.txtDues.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(7, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 14);
            this.label11.TabIndex = 15;
            this.label11.Text = "Dues";
            // 
            // txtPaid
            // 
            this.txtPaid.EditValue = "0.00";
            this.txtPaid.Location = new System.Drawing.Point(44, 23);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Properties.Appearance.Options.UseFont = true;
            this.txtPaid.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPaid.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPaid.Properties.MaxLength = 10;
            this.txtPaid.Size = new System.Drawing.Size(147, 29);
            this.txtPaid.TabIndex = 12;
            this.txtPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaid_KeyPress);
            this.txtPaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPaid_KeyUp);
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(7, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "Paid";
            // 
            // grpSupplier
            // 
            this.grpSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpSupplier.BackColor = System.Drawing.Color.Transparent;
            this.grpSupplier.Controls.Add(this.btnSupplierSearch);
            this.grpSupplier.Controls.Add(this.txtSupplierName);
            this.grpSupplier.Controls.Add(this.label7);
            this.grpSupplier.Controls.Add(this.txtSupplierCode);
            this.grpSupplier.Controls.Add(this.label8);
            this.grpSupplier.Enabled = false;
            this.grpSupplier.Location = new System.Drawing.Point(5, 456);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(319, 80);
            this.grpSupplier.TabIndex = 15;
            this.grpSupplier.TabStop = false;
            // 
            // btnSupplierSearch
            // 
            this.btnSupplierSearch.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierSearch.Appearance.Options.UseFont = true;
            this.btnSupplierSearch.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnSupplierSearch.Location = new System.Drawing.Point(286, 23);
            this.btnSupplierSearch.Name = "btnSupplierSearch";
            this.btnSupplierSearch.Size = new System.Drawing.Size(27, 20);
            this.btnSupplierSearch.TabIndex = 19;
            this.btnSupplierSearch.Click += new System.EventHandler(this.btnSupplierSearch_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(102, 49);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSupplierName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.txtSupplierName.Properties.Appearance.Options.UseBackColor = true;
            this.txtSupplierName.Properties.Appearance.Options.UseFont = true;
            this.txtSupplierName.Properties.Appearance.Options.UseForeColor = true;
            this.txtSupplierName.Properties.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(211, 20);
            this.txtSupplierName.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "Supplier Name";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(102, 23);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSupplierCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txtSupplierCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtSupplierCode.Properties.Appearance.Options.UseFont = true;
            this.txtSupplierCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtSupplierCode.Properties.MaxLength = 14;
            this.txtSupplierCode.Size = new System.Drawing.Size(181, 20);
            this.txtSupplierCode.TabIndex = 18;
            this.txtSupplierCode.TextChanged += new System.EventHandler(this.txtSupplierCode_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Supplier Code";
            // 
            // chkSupplier
            // 
            this.chkSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSupplier.ForeColor = System.Drawing.Color.Black;
            this.chkSupplier.Location = new System.Drawing.Point(13, 455);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(107, 18);
            this.chkSupplier.TabIndex = 12;
            this.chkSupplier.Text = "Select Supplier";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkSupplier_CheckedChanged);
            // 
            // btnResetGrid
            // 
            this.btnResetGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetGrid.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGrid.Appearance.Options.UseFont = true;
            this.btnResetGrid.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnResetGrid.Location = new System.Drawing.Point(648, 131);
            this.btnResetGrid.Name = "btnResetGrid";
            this.btnResetGrid.Size = new System.Drawing.Size(75, 28);
            this.btnResetGrid.TabIndex = 58;
            this.btnResetGrid.Text = "Reset";
            this.btnResetGrid.Click += new System.EventHandler(this.btnResetGrid_Click);
            // 
            // btnAddToGrid
            // 
            this.btnAddToGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToGrid.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToGrid.Appearance.Options.UseFont = true;
            this.btnAddToGrid.Image = global::SalesPOS.Properties.Resources.Add_16x16;
            this.btnAddToGrid.Location = new System.Drawing.Point(729, 131);
            this.btnAddToGrid.Name = "btnAddToGrid";
            this.btnAddToGrid.Size = new System.Drawing.Size(75, 28);
            this.btnAddToGrid.TabIndex = 57;
            this.btnAddToGrid.Text = "Add";
            this.btnAddToGrid.Click += new System.EventHandler(this.btnAddToGrid_Click);
            // 
            // lblMinimumUnitID
            // 
            this.lblMinimumUnitID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimumUnitID.Location = new System.Drawing.Point(377, 51);
            this.lblMinimumUnitID.Name = "lblMinimumUnitID";
            this.lblMinimumUnitID.Size = new System.Drawing.Size(56, 13);
            this.lblMinimumUnitID.TabIndex = 56;
            this.lblMinimumUnitID.Text = "lblUnitID";
            this.lblMinimumUnitID.Visible = false;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnitPrice.Location = new System.Drawing.Point(456, 134);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(71, 13);
            this.lblUnitPrice.TabIndex = 54;
            this.lblUnitPrice.Text = "0.00";
            this.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUnitPrice.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(382, 134);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 13);
            this.label20.TabIndex = 53;
            this.label20.Text = "Unit Price :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Visible = false;
            // 
            // lblMinimumUnit
            // 
            this.lblMinimumUnit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimumUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMinimumUnit.Location = new System.Drawing.Point(377, 31);
            this.lblMinimumUnit.Name = "lblMinimumUnit";
            this.lblMinimumUnit.Size = new System.Drawing.Size(56, 13);
            this.lblMinimumUnit.TabIndex = 52;
            this.lblMinimumUnit.Text = "Pcs";
            this.lblMinimumUnit.Visible = false;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblProductName.Location = new System.Drawing.Point(88, 6);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(246, 16);
            this.lblProductName.TabIndex = 50;
            this.lblProductName.Text = "Napa";
            // 
            // lblProductID
            // 
            this.lblProductID.BackColor = System.Drawing.Color.Transparent;
            this.lblProductID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblProductID.Location = new System.Drawing.Point(1, 6);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(77, 16);
            this.lblProductID.TabIndex = 51;
            this.lblProductID.Text = "P000000001";
            this.lblProductID.Click += new System.EventHandler(this.lblProductID_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalQty.Location = new System.Drawing.Point(449, 112);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(63, 13);
            this.lblTotalQty.TabIndex = 44;
            this.lblTotalQty.Visible = false;
            // 
            // txtPurchaseNo
            // 
            this.txtPurchaseNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPurchaseNo.Location = new System.Drawing.Point(597, 25);
            this.txtPurchaseNo.Name = "txtPurchaseNo";
            this.txtPurchaseNo.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPurchaseNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseNo.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txtPurchaseNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtPurchaseNo.Properties.Appearance.Options.UseFont = true;
            this.txtPurchaseNo.Properties.Appearance.Options.UseForeColor = true;
            this.txtPurchaseNo.Properties.ReadOnly = true;
            this.txtPurchaseNo.Size = new System.Drawing.Size(207, 21);
            this.txtPurchaseNo.TabIndex = 0;
            this.txtPurchaseNo.TabStop = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(502, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 14);
            this.label14.TabIndex = 40;
            this.label14.Text = "Purchase No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(380, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Total Qty :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // txtMemoNo
            // 
            this.txtMemoNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemoNo.Location = new System.Drawing.Point(597, 78);
            this.txtMemoNo.Name = "txtMemoNo";
            this.txtMemoNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemoNo.Properties.Appearance.Options.UseFont = true;
            this.txtMemoNo.Size = new System.Drawing.Size(207, 21);
            this.txtMemoNo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(502, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "Memo No";
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpireDate.Location = new System.Drawing.Point(549, 0);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(207, 21);
            this.dtpExpireDate.TabIndex = 7;
            this.dtpExpireDate.Visible = false;
            // 
            // chkExpireDate
            // 
            this.chkExpireDate.AutoSize = true;
            this.chkExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExpireDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkExpireDate.Location = new System.Drawing.Point(455, 2);
            this.chkExpireDate.Name = "chkExpireDate";
            this.chkExpireDate.Size = new System.Drawing.Size(91, 17);
            this.chkExpireDate.TabIndex = 6;
            this.chkExpireDate.Text = "Expire Date";
            this.chkExpireDate.UseVisualStyleBackColor = true;
            this.chkExpireDate.Visible = false;
            this.chkExpireDate.CheckedChanged += new System.EventHandler(this.chkExpireDate_CheckedChanged);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProduct.Appearance.Options.UseFont = true;
            this.btnSearchProduct.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnSearchProduct.Location = new System.Drawing.Point(325, 27);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(27, 22);
            this.btnSearchProduct.TabIndex = 4;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(104, 55);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(248, 21);
            this.txtProductName.TabIndex = 5;
            this.txtProductName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Product Name";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(104, 28);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.Properties.Appearance.Options.UseFont = true;
            this.txtProductID.Properties.MaxLength = 10;
            this.txtProductID.Size = new System.Drawing.Size(215, 20);
            this.txtProductID.TabIndex = 3;
            this.txtProductID.EditValueChanged += new System.EventHandler(this.txtProductID_EditValueChanged);
            this.txtProductID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductID_KeyPress);
            this.txtProductID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductID_KeyDown);
            this.txtProductID.TextChanged += new System.EventHandler(this.txtProductID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Product Code";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPurchaseDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(597, 52);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(207, 22);
            this.dtpPurchaseDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(502, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Purchase Date";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dgvPurchaseGrid);
            this.groupBox4.Location = new System.Drawing.Point(5, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(815, 243);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            // 
            // dgvPurchaseGrid
            // 
            this.dgvPurchaseGrid.AllowUserToAddRows = false;
            this.dgvPurchaseGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPurchaseGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Quantity,
            this.ProductMinimumUnit,
            this.UnitPrice,
            this.TotalPrice,
            this.ExpireDate,
            this.IsExpDate,
            this.UnitID});
            this.dgvPurchaseGrid.ContextMenuStrip = this.cmnu_strip;
            this.dgvPurchaseGrid.CurrentRowIndex = 0;
            this.dgvPurchaseGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvPurchaseGrid.Location = new System.Drawing.Point(3, 17);
            this.dgvPurchaseGrid.MultiSelect = false;
            this.dgvPurchaseGrid.Name = "dgvPurchaseGrid";
            this.dgvPurchaseGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPurchaseGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchaseGrid.Size = new System.Drawing.Size(809, 223);
            this.dgvPurchaseGrid.TabIndex = 11;
            this.dgvPurchaseGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPurchaseGrid_KeyDown);
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.FillWeight = 58.02832F;
            this.ProductID.Frozen = true;
            this.ProductID.HeaderText = "Code";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.FillWeight = 66.36297F;
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantity.FillWeight = 38.69161F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // ProductMinimumUnit
            // 
            this.ProductMinimumUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductMinimumUnit.FillWeight = 32.57603F;
            this.ProductMinimumUnit.HeaderText = "Unit";
            this.ProductMinimumUnit.Name = "ProductMinimumUnit";
            this.ProductMinimumUnit.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.TotalPrice.FillWeight = 87.53905F;
            this.TotalPrice.HeaderText = "Total Price(Tk.)";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 120;
            // 
            // ExpireDate
            // 
            this.ExpireDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpireDate.FillWeight = 93.98608F;
            this.ExpireDate.HeaderText = "Expire Date";
            this.ExpireDate.Name = "ExpireDate";
            this.ExpireDate.ReadOnly = true;
            this.ExpireDate.Visible = false;
            this.ExpireDate.Width = 130;
            // 
            // IsExpDate
            // 
            this.IsExpDate.FillWeight = 319.797F;
            this.IsExpDate.HeaderText = "IsExpDate";
            this.IsExpDate.Name = "IsExpDate";
            this.IsExpDate.ReadOnly = true;
            this.IsExpDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsExpDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsExpDate.Visible = false;
            this.IsExpDate.Width = 60;
            // 
            // UnitID
            // 
            this.UnitID.HeaderText = "UnitID";
            this.UnitID.Name = "UnitID";
            this.UnitID.Visible = false;
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
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.btnResetForm);
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnPrint);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Location = new System.Drawing.Point(360, 460);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(164, 76);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            // 
            // btnResetForm
            // 
            this.btnResetForm.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetForm.Appearance.Options.UseFont = true;
            this.btnResetForm.Appearance.Options.UseForeColor = true;
            this.btnResetForm.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnResetForm.Location = new System.Drawing.Point(84, 43);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(74, 27);
            this.btnResetForm.TabIndex = 16;
            this.btnResetForm.Text = "&Reset";
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(6, 43);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::SalesPOS.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(6, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 27);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "&Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = global::SalesPOS.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(84, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 27);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(5, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Total No of Item(s) : ";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(309, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Total Amount (BDT) : ";
            // 
            // lblTotalItemAmount
            // 
            this.lblTotalItemAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalItemAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotalItemAmount.Location = new System.Drawing.Point(437, 424);
            this.lblTotalItemAmount.Name = "lblTotalItemAmount";
            this.lblTotalItemAmount.Size = new System.Drawing.Size(180, 30);
            this.lblTotalItemAmount.TabIndex = 42;
            this.lblTotalItemAmount.Text = "0.00";
            this.lblTotalItemAmount.TextChanged += new System.EventHandler(this.lblTotalItemAmount_TextChanged);
            // 
            // lblTotalItem
            // 
            this.lblTotalItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalItem.Location = new System.Drawing.Point(127, 424);
            this.lblTotalItem.Name = "lblTotalItem";
            this.lblTotalItem.Size = new System.Drawing.Size(31, 13);
            this.lblTotalItem.TabIndex = 43;
            this.lblTotalItem.Text = "0";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.lblUnitPrice);
            this.groupControl1.Controls.Add(this.lblMinimumUnitID);
            this.groupControl1.Controls.Add(this.label20);
            this.groupControl1.Controls.Add(this.btnResetGrid);
            this.groupControl1.Controls.Add(this.txtProductID);
            this.groupControl1.Controls.Add(this.btnAddToGrid);
            this.groupControl1.Controls.Add(this.lblTotalQty);
            this.groupControl1.Controls.Add(this.lblMinimumUnit);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.btnSearchProduct);
            this.groupControl1.Controls.Add(this.txtProductName);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtPurchaseNo);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.dtpPurchaseDate);
            this.groupControl1.Controls.Add(this.label14);
            this.groupControl1.Controls.Add(this.txtMemoNo);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.chkExpireDate);
            this.groupControl1.Controls.Add(this.dtpExpireDate);
            this.groupControl1.Location = new System.Drawing.Point(5, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(813, 164);
            this.groupControl1.TabIndex = 45;
            this.groupControl1.Text = "Product Purchase";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.dgvProductUnitQuantity);
            this.panelControl1.Controls.Add(this.lblProductID);
            this.panelControl1.Controls.Add(this.lblProductName);
            this.panelControl1.Location = new System.Drawing.Point(12, 81);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(340, 82);
            this.panelControl1.TabIndex = 12;
            // 
            // dgvProductUnitQuantity
            // 
            this.dgvProductUnitQuantity.AllowUserToAddRows = false;
            this.dgvProductUnitQuantity.AllowUserToResizeColumns = false;
            this.dgvProductUnitQuantity.AllowUserToResizeRows = false;
            this.dgvProductUnitQuantity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductUnitQuantity.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductUnitQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductUnitQuantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductUnitQuantity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PUnitName,
            this.UnitQuantity,
            this.EnteredQuantity,
            this.PTotalQuantity,
            this.UPrice});
            this.dgvProductUnitQuantity.CurrentRowIndex = 0;
            this.dgvProductUnitQuantity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProductUnitQuantity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvProductUnitQuantity.Location = new System.Drawing.Point(2, 26);
            this.dgvProductUnitQuantity.MultiSelect = false;
            this.dgvProductUnitQuantity.Name = "dgvProductUnitQuantity";
            this.dgvProductUnitQuantity.RowHeadersVisible = false;
            this.dgvProductUnitQuantity.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductUnitQuantity.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProductUnitQuantity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProductUnitQuantity.Size = new System.Drawing.Size(336, 54);
            this.dgvProductUnitQuantity.TabIndex = 8;
            this.dgvProductUnitQuantity.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductUnitQuantity_CellEndEdit);
            this.dgvProductUnitQuantity.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductUnitQuantity_DataError);
            this.dgvProductUnitQuantity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductUnitQuantity_CellContentClick);
            // 
            // PUnitName
            // 
            this.PUnitName.DataPropertyName = "UnitName";
            this.PUnitName.HeaderText = "Unit";
            this.PUnitName.MaxInputLength = 15;
            this.PUnitName.Name = "PUnitName";
            this.PUnitName.ReadOnly = true;
            this.PUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PUnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // UnitQuantity
            // 
            this.UnitQuantity.DataPropertyName = "UnitQty";
            this.UnitQuantity.HeaderText = "Unit Quantity";
            this.UnitQuantity.MaxInputLength = 10;
            this.UnitQuantity.Name = "UnitQuantity";
            this.UnitQuantity.ReadOnly = true;
            this.UnitQuantity.Visible = false;
            // 
            // EnteredQuantity
            // 
            this.EnteredQuantity.HeaderText = "Quantity";
            this.EnteredQuantity.MaxInputLength = 10;
            this.EnteredQuantity.Name = "EnteredQuantity";
            // 
            // PTotalQuantity
            // 
            this.PTotalQuantity.HeaderText = "Total Quantity";
            this.PTotalQuantity.MaxInputLength = 10;
            this.PTotalQuantity.Name = "PTotalQuantity";
            this.PTotalQuantity.ReadOnly = true;
            this.PTotalQuantity.Visible = false;
            // 
            // UPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.UPrice.HeaderText = "Unit Price";
            this.UPrice.MaxInputLength = 10;
            this.UPrice.Name = "UPrice";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(597, 104);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Size = new System.Drawing.Size(207, 21);
            this.txtDescription.TabIndex = 67;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(502, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 68;
            this.label12.Text = "Description";
            // 
            // frmPurchaseInfo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 548);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.lblTotalItem);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalItemAmount);
            this.Controls.Add(this.chkSupplier);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSupplier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Purchase";
            this.Load += new System.EventHandler(this.frmPurchaseInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseInfo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDues.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid.Properties)).EndInit();
            this.grpSupplier.ResumeLayout(false);
            this.grpSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseGrid)).EndInit();
            this.cmnu_strip.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductUnitQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpSupplier;
        private System.Windows.Forms.CheckBox chkSupplier;
        private DevExpress.XtraEditors.SimpleButton btnSupplierSearch;
        private DevExpress.XtraEditors.TextEdit txtSupplierName;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtSupplierCode;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtDues;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtPaid;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnSearchProduct;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkExpireDate;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private DevExpress.XtraEditors.TextEdit txtMemoNo;
        private System.Windows.Forms.Label label4;
        private ja_grid dgvProductUnitQuantity;
        private System.Windows.Forms.GroupBox groupBox4;
        private ja_grid dgvPurchaseGrid;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtPurchaseNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalItemAmount;
        private System.Windows.Forms.Label lblTotalItem;
        private DevExpress.XtraEditors.SimpleButton btnResetForm;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblMinimumUnit;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblMinimumUnitID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraEditors.SimpleButton btnResetGrid;
        private DevExpress.XtraEditors.SimpleButton btnAddToGrid;
        private System.Windows.Forms.ContextMenuStrip cmnu_strip;
        private System.Windows.Forms.ToolStripMenuItem mnu_delete;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductMinimumUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpireDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnteredQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPrice;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private System.Windows.Forms.Label label12;
    }
}