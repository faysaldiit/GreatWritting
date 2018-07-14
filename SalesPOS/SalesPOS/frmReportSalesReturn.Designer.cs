namespace SalesPOS
{
    partial class frmReportSalesReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportSalesReturn));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rptSummary = new System.Windows.Forms.RadioButton();
            this.rptDetails = new System.Windows.Forms.RadioButton();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_product = new System.Windows.Forms.CheckBox();
            this.cmb_manufacturer = new DevExpress.XtraEditors.LookUpEdit();
            this.cmb_product = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.cmb_view_product = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_manufacturer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_product.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_view_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(208, 197);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 25);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rptSummary);
            this.groupBox1.Controls.Add(this.rptDetails);
            this.groupBox1.Location = new System.Drawing.Point(122, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 52);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            // 
            // rptSummary
            // 
            this.rptSummary.AutoSize = true;
            this.rptSummary.Location = new System.Drawing.Point(6, 29);
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
            this.rptDetails.Location = new System.Drawing.Point(6, 10);
            this.rptDetails.Name = "rptDetails";
            this.rptDetails.Size = new System.Drawing.Size(57, 17);
            this.rptDetails.TabIndex = 0;
            this.rptDetails.TabStop = true;
            this.rptDetails.Text = "Details";
            this.rptDetails.UseVisualStyleBackColor = true;
            this.rptDetails.CheckedChanged += new System.EventHandler(this.rptDetails_CheckedChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(121, 92);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(224, 20);
            this.dtpFrom.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(11, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 122;
            this.label1.Text = "Date From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Date To";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(121, 119);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(224, 20);
            this.dtpTo.TabIndex = 121;
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Appearance.Options.UseForeColor = true;
            this.btnPreview.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnPreview.Location = new System.Drawing.Point(121, 197);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(81, 25);
            this.btnPreview.TabIndex = 119;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(11, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Report Type";
            // 
            // chk_product
            // 
            this.chk_product.AutoSize = true;
            this.chk_product.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_product.Location = new System.Drawing.Point(14, 39);
            this.chk_product.Name = "chk_product";
            this.chk_product.Size = new System.Drawing.Size(108, 17);
            this.chk_product.TabIndex = 147;
            this.chk_product.Text = "Select Product";
            this.chk_product.UseVisualStyleBackColor = true;
            this.chk_product.CheckedChanged += new System.EventHandler(this.chk_product_CheckedChanged);
            // 
            // cmb_manufacturer
            // 
            this.cmb_manufacturer.Location = new System.Drawing.Point(121, 66);
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
            this.cmb_manufacturer.Size = new System.Drawing.Size(225, 20);
            this.cmb_manufacturer.TabIndex = 145;
            // 
            // cmb_product
            // 
            this.cmb_product.Location = new System.Drawing.Point(121, 36);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_product.Properties.Appearance.Options.UseFont = true;
            this.cmb_product.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_product.Properties.NullText = "";
            this.cmb_product.Properties.View = this.cmb_view_product;
            this.cmb_product.Size = new System.Drawing.Size(225, 24);
            this.cmb_product.TabIndex = 146;
            // 
            // cmb_view_product
            // 
            this.cmb_view_product.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cmb_view_product.Name = "cmb_view_product";
            this.cmb_view_product.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cmb_view_product.OptionsView.ShowGroupPanel = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 144;
            this.label4.Text = "Manufacturer";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.cmb_product);
            this.groupControl1.Controls.Add(this.chk_product);
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Controls.Add(this.cmb_manufacturer);
            this.groupControl1.Controls.Add(this.dtpTo);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.dtpFrom);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Location = new System.Drawing.Point(62, 44);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(368, 238);
            this.groupControl1.TabIndex = 148;
            this.groupControl1.Text = "Sales Return";
            // 
            // frmReportSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 342);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportSalesReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frpReportSalesReturn";
            this.Load += new System.EventHandler(this.frpReportSalesReturn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_manufacturer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_product.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_view_product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rptSummary;
        private System.Windows.Forms.RadioButton rptDetails;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_product;
        private DevExpress.XtraEditors.LookUpEdit cmb_manufacturer;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_product;
        private DevExpress.XtraGrid.Views.Grid.GridView cmb_view_product;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}