namespace SalesPOS
{
    partial class frmReportProductSalesProfit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportProductSalesProfit));
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chk_pivot = new System.Windows.Forms.CheckBox();
            this.grp_report = new DevExpress.XtraEditors.GroupControl();
            this.btnPreviewPivotGrid = new DevExpress.XtraEditors.SimpleButton();
            this.grd_report = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btn_close_report = new DevExpress.XtraEditors.SimpleButton();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grp_report)).BeginInit();
            this.grp_report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(289, 172);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(161, 20);
            this.dtpFrom.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(213, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Date From :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(213, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Date To :";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(289, 199);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(161, 20);
            this.dtpTo.TabIndex = 119;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Appearance.Options.UseForeColor = true;
            this.btnPreview.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnPreview.Location = new System.Drawing.Point(289, 253);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(81, 25);
            this.btnPreview.TabIndex = 117;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbSection
            // 
            this.cmbSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(289, 226);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(161, 21);
            this.cmbSection.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(213, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Category :";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(376, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 124;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chk_pivot
            // 
            this.chk_pivot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chk_pivot.AutoSize = true;
            this.chk_pivot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_pivot.ForeColor = System.Drawing.Color.Black;
            this.chk_pivot.Location = new System.Drawing.Point(217, 260);
            this.chk_pivot.Name = "chk_pivot";
            this.chk_pivot.Size = new System.Drawing.Size(53, 18);
            this.chk_pivot.TabIndex = 145;
            this.chk_pivot.Text = "Pivot";
            this.chk_pivot.UseVisualStyleBackColor = true;
            // 
            // grp_report
            // 
            this.grp_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_report.Controls.Add(this.btnPreviewPivotGrid);
            this.grp_report.Controls.Add(this.grd_report);
            this.grp_report.Controls.Add(this.btn_close_report);
            this.grp_report.Location = new System.Drawing.Point(8, 12);
            this.grp_report.Name = "grp_report";
            this.grp_report.Size = new System.Drawing.Size(660, 429);
            this.grp_report.TabIndex = 146;
            this.grp_report.Visible = false;
            // 
            // btnPreviewPivotGrid
            // 
            this.btnPreviewPivotGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewPivotGrid.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviewPivotGrid.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreviewPivotGrid.Appearance.Options.UseFont = true;
            this.btnPreviewPivotGrid.Appearance.Options.UseForeColor = true;
            this.btnPreviewPivotGrid.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btnPreviewPivotGrid.Location = new System.Drawing.Point(554, 0);
            this.btnPreviewPivotGrid.Name = "btnPreviewPivotGrid";
            this.btnPreviewPivotGrid.Size = new System.Drawing.Size(81, 21);
            this.btnPreviewPivotGrid.TabIndex = 121;
            this.btnPreviewPivotGrid.Text = "Preview";
            this.btnPreviewPivotGrid.Click += new System.EventHandler(this.btnPreviewPivotGrid_Click);
            // 
            // grd_report
            // 
            this.grd_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_report.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9,
            this.pivotGridField10,
            this.pivotGridField11});
            this.grd_report.Location = new System.Drawing.Point(5, 25);
            this.grd_report.Name = "grd_report";
            this.grd_report.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grd_report.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grd_report.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grd_report.OptionsPrint.PrintHeadersOnEveryPage = true;
            this.grd_report.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grd_report.OptionsPrint.PrintUnusedFilterFields = false;
            this.grd_report.Size = new System.Drawing.Size(650, 404);
            this.grd_report.TabIndex = 120;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 1;
            this.pivotGridField1.Caption = "InvoiceNo";
            this.pivotGridField1.FieldName = "InvoiceNo";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.Caption = "SalesDate";
            this.pivotGridField2.FieldName = "SalesDate";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "TotalSalesAmount";
            this.pivotGridField4.CellFormat.FormatString = "f2";
            this.pivotGridField4.FieldName = "TotalSalesPrice";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField5.AreaIndex = 1;
            this.pivotGridField5.Caption = "TotalCostAmount";
            this.pivotGridField5.CellFormat.FormatString = "f2";
            this.pivotGridField5.FieldName = "TotalCostPrice";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.AreaIndex = 2;
            this.pivotGridField7.Caption = "UnitCostPrice";
            this.pivotGridField7.CellFormat.FormatString = "f2";
            this.pivotGridField7.FieldName = "UnitCostPrice";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField8.AreaIndex = 3;
            this.pivotGridField8.Caption = "ProductName";
            this.pivotGridField8.FieldName = "ProductName";
            this.pivotGridField8.Name = "pivotGridField8";
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.AreaIndex = 0;
            this.pivotGridField9.Caption = "Unit";
            this.pivotGridField9.FieldName = "UnitName";
            this.pivotGridField9.Name = "pivotGridField9";
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField10.AreaIndex = 2;
            this.pivotGridField10.Caption = "ProductID";
            this.pivotGridField10.FieldName = "ProductID";
            this.pivotGridField10.Name = "pivotGridField10";
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.AreaIndex = 1;
            this.pivotGridField11.Caption = "UnitSalesPrice";
            this.pivotGridField11.FieldName = "UnitSalesPrice";
            this.pivotGridField11.Name = "pivotGridField11";
            // 
            // btn_close_report
            // 
            this.btn_close_report.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close_report.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close_report.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_close_report.Appearance.Options.UseFont = true;
            this.btn_close_report.Appearance.Options.UseForeColor = true;
            this.btn_close_report.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btn_close_report.Location = new System.Drawing.Point(636, 0);
            this.btn_close_report.Name = "btn_close_report";
            this.btn_close_report.Size = new System.Drawing.Size(24, 21);
            this.btn_close_report.TabIndex = 119;
            this.btn_close_report.Click += new System.EventHandler(this.btn_close_report_Click);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.grd_report;
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // frmReportProductSalesProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 453);
            this.Controls.Add(this.grp_report);
            this.Controls.Add(this.chk_pivot);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportProductSalesProfit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Sales Profit Loss Analysis Report";
            this.Load += new System.EventHandler(this.frmReportProductSalesProfit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grp_report)).EndInit();
            this.grp_report.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.CheckBox chk_pivot;
        private DevExpress.XtraEditors.GroupControl grp_report;
        private DevExpress.XtraEditors.SimpleButton btnPreviewPivotGrid;
        private DevExpress.XtraPivotGrid.PivotGridControl grd_report;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraEditors.SimpleButton btn_close_report;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
    }
}