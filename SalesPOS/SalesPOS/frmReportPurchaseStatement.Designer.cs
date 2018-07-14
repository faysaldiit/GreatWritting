namespace SalesPOS
{
    partial class frmReportPurchaseStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPurchaseStatement));
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rptSummary = new System.Windows.Forms.RadioButton();
            this.rptDetails = new System.Windows.Forms.RadioButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_supplier = new DevExpress.XtraEditors.LookUpEdit();
            this.opt_supplier_manufacturer = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmb_manufacturer = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_supplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_supplier_manufacturer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_manufacturer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(188, 72);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(231, 20);
            this.dtpFrom.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(38, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Date From :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(38, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Date To :";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(188, 98);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(231, 20);
            this.dtpTo.TabIndex = 114;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Appearance.Options.UseForeColor = true;
            this.btnPreview.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnPreview.Location = new System.Drawing.Point(470, 164);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(81, 25);
            this.btnPreview.TabIndex = 112;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rptSummary);
            this.groupBox1.Controls.Add(this.rptDetails);
            this.groupBox1.Location = new System.Drawing.Point(470, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 36);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            // 
            // rptSummary
            // 
            this.rptSummary.AutoSize = true;
            this.rptSummary.Location = new System.Drawing.Point(81, 12);
            this.rptSummary.Name = "rptSummary";
            this.rptSummary.Size = new System.Drawing.Size(69, 17);
            this.rptSummary.TabIndex = 1;
            this.rptSummary.Text = "Summary";
            this.rptSummary.UseVisualStyleBackColor = true;
            // 
            // rptDetails
            // 
            this.rptDetails.AutoSize = true;
            this.rptDetails.Checked = true;
            this.rptDetails.Location = new System.Drawing.Point(6, 14);
            this.rptDetails.Name = "rptDetails";
            this.rptDetails.Size = new System.Drawing.Size(57, 17);
            this.rptDetails.TabIndex = 0;
            this.rptDetails.TabStop = true;
            this.rptDetails.Text = "Details";
            this.rptDetails.UseVisualStyleBackColor = true;
            this.rptDetails.CheckedChanged += new System.EventHandler(this.rptDetails_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(557, 164);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 25);
            this.btnClose.TabIndex = 119;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(467, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "Report Type :";
            // 
            // cmb_supplier
            // 
            this.cmb_supplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_supplier.Location = new System.Drawing.Point(188, 141);
            this.cmb_supplier.Name = "cmb_supplier";
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
            this.cmb_supplier.Size = new System.Drawing.Size(231, 20);
            this.cmb_supplier.TabIndex = 122;
            // 
            // opt_supplier_manufacturer
            // 
            this.opt_supplier_manufacturer.Location = new System.Drawing.Point(32, 133);
            this.opt_supplier_manufacturer.Name = "opt_supplier_manufacturer";
            this.opt_supplier_manufacturer.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.opt_supplier_manufacturer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_supplier_manufacturer.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.opt_supplier_manufacturer.Properties.Appearance.Options.UseBackColor = true;
            this.opt_supplier_manufacturer.Properties.Appearance.Options.UseFont = true;
            this.opt_supplier_manufacturer.Properties.Appearance.Options.UseForeColor = true;
            this.opt_supplier_manufacturer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.opt_supplier_manufacturer.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Supplier Wise"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Manufacturer Wise")});
            this.opt_supplier_manufacturer.Size = new System.Drawing.Size(150, 64);
            this.opt_supplier_manufacturer.TabIndex = 125;
            this.opt_supplier_manufacturer.SelectedIndexChanged += new System.EventHandler(this.opt_supplier_manufacturer_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.cmb_manufacturer);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.dtpFrom);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Controls.Add(this.opt_supplier_manufacturer);
            this.groupControl1.Controls.Add(this.cmb_supplier);
            this.groupControl1.Controls.Add(this.dtpTo);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Location = new System.Drawing.Point(36, 53);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(660, 245);
            this.groupControl1.TabIndex = 126;
            this.groupControl1.Text = "Purchase Report";
            // 
            // cmb_manufacturer
            // 
            this.cmb_manufacturer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_manufacturer.Enabled = false;
            this.cmb_manufacturer.Location = new System.Drawing.Point(188, 169);
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
            this.cmb_manufacturer.TabIndex = 126;
            // 
            // frmReportPurchaseStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 352);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportPurchaseStatement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Analysis Report";
            this.Load += new System.EventHandler(this.frmReportPurchaseStatement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_supplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_supplier_manufacturer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_manufacturer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rptSummary;
        private System.Windows.Forms.RadioButton rptDetails;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit cmb_supplier;
        private DevExpress.XtraEditors.RadioGroup opt_supplier_manufacturer;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit cmb_manufacturer;
    }
}