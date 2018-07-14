namespace SalesPOS
{
    partial class frmReportMaterialTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportMaterialTransaction));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.optReportType = new DevExpress.XtraEditors.RadioGroup();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.grd_purchase = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btn_export = new DevExpress.XtraEditors.SimpleButton();
            this.grd_production = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField13 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField14 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField15 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField16 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField17 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField18 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField19 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField20 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.grd_gift = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField21 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField22 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField23 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField24 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField25 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_purchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_production)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_gift)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.optReportType);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.btnLoad);
            this.groupControl1.Controls.Add(this.dtpFrom);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.dtpTo);
            this.groupControl1.Location = new System.Drawing.Point(12, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(475, 157);
            this.groupControl1.TabIndex = 1;
            // 
            // optReportType
            // 
            this.optReportType.Location = new System.Drawing.Point(117, 89);
            this.optReportType.Name = "optReportType";
            this.optReportType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Material Purchase"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Material Production"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Gift Item")});
            this.optReportType.Size = new System.Drawing.Size(161, 61);
            this.optReportType.TabIndex = 120;
            this.optReportType.SelectedIndexChanged += new System.EventHandler(this.optReportType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 119;
            this.label3.Text = "Report type :";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(381, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 118;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Appearance.Options.UseForeColor = true;
            this.btnLoad.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnLoad.Location = new System.Drawing.Point(294, 119);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(81, 25);
            this.btnLoad.TabIndex = 113;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(117, 36);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(161, 20);
            this.dtpFrom.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 116;
            this.label1.Text = "Date From :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 117;
            this.label2.Text = "Date To :";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(117, 63);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(161, 20);
            this.dtpTo.TabIndex = 115;
            // 
            // grd_purchase
            // 
            this.grd_purchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_purchase.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField6,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9,
            this.pivotGridField11,
            this.pivotGridField12});
            this.grd_purchase.Location = new System.Drawing.Point(12, 174);
            this.grd_purchase.Name = "grd_purchase";
            this.grd_purchase.Size = new System.Drawing.Size(760, 398);
            this.grd_purchase.TabIndex = 2;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "PurchaseID";
            this.pivotGridField1.FieldName = "PurchaseID";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "PurchaseDate";
            this.pivotGridField2.FieldName = "PurchaseDate";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "MemoNo";
            this.pivotGridField3.FieldName = "MemoNo";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.AreaIndex = 1;
            this.pivotGridField4.Caption = "Supplier";
            this.pivotGridField4.FieldName = "AccountNo";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.AreaIndex = 2;
            this.pivotGridField5.Caption = "SupplierName";
            this.pivotGridField5.FieldName = "AccHolderName";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField6.AreaIndex = 2;
            this.pivotGridField6.Caption = "MaterialID";
            this.pivotGridField6.FieldName = "MaterialID";
            this.pivotGridField6.Name = "pivotGridField6";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField7.AreaIndex = 3;
            this.pivotGridField7.Caption = "MaterialName";
            this.pivotGridField7.FieldName = "MaterialName";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField8.AreaIndex = 0;
            this.pivotGridField8.Caption = "PurchaseQty";
            this.pivotGridField8.CellFormat.FormatString = "N0";
            this.pivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField8.FieldName = "PurchaseQty";
            this.pivotGridField8.Name = "pivotGridField8";
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField9.AreaIndex = 1;
            this.pivotGridField9.Caption = "UnitPurchasePrice";
            this.pivotGridField9.CellFormat.FormatString = "N2";
            this.pivotGridField9.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField9.FieldName = "UnitPurchasePrice";
            this.pivotGridField9.Name = "pivotGridField9";
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField11.AreaIndex = 2;
            this.pivotGridField11.Caption = "TotalPurchaseAmount";
            this.pivotGridField11.CellFormat.FormatString = "N2";
            this.pivotGridField11.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField11.FieldName = "TotalPurchaseAmount";
            this.pivotGridField11.Name = "pivotGridField11";
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.AreaIndex = 3;
            this.pivotGridField12.Caption = "UnitName";
            this.pivotGridField12.FieldName = "UnitName";
            this.pivotGridField12.Name = "pivotGridField12";
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Appearance.Options.UseFont = true;
            this.btn_export.Image = global::SalesPOS.Properties.Resources.ExportToExcel_16x16;
            this.btn_export.Location = new System.Drawing.Point(652, 141);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(120, 26);
            this.btn_export.TabIndex = 173;
            this.btn_export.Text = "Export to Excel";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // grd_production
            // 
            this.grd_production.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_production.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField10,
            this.pivotGridField13,
            this.pivotGridField14,
            this.pivotGridField15,
            this.pivotGridField16,
            this.pivotGridField17,
            this.pivotGridField18,
            this.pivotGridField19,
            this.pivotGridField20});
            this.grd_production.Location = new System.Drawing.Point(12, 174);
            this.grd_production.Name = "grd_production";
            this.grd_production.Size = new System.Drawing.Size(760, 398);
            this.grd_production.TabIndex = 174;
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField10.AreaIndex = 0;
            this.pivotGridField10.Caption = "ProductionID";
            this.pivotGridField10.FieldName = "ProductionID";
            this.pivotGridField10.Name = "pivotGridField10";
            // 
            // pivotGridField13
            // 
            this.pivotGridField13.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField13.AreaIndex = 1;
            this.pivotGridField13.Caption = "ProductionDate";
            this.pivotGridField13.FieldName = "ProductionDate";
            this.pivotGridField13.Name = "pivotGridField13";
            // 
            // pivotGridField14
            // 
            this.pivotGridField14.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField14.AreaIndex = 2;
            this.pivotGridField14.Caption = "ProductID";
            this.pivotGridField14.FieldName = "ProductID";
            this.pivotGridField14.Name = "pivotGridField14";
            // 
            // pivotGridField15
            // 
            this.pivotGridField15.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField15.AreaIndex = 3;
            this.pivotGridField15.Caption = "ProductName";
            this.pivotGridField15.FieldName = "ProductName";
            this.pivotGridField15.Name = "pivotGridField15";
            // 
            // pivotGridField16
            // 
            this.pivotGridField16.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField16.AreaIndex = 4;
            this.pivotGridField16.Caption = "MaterialID";
            this.pivotGridField16.FieldName = "MaterialID";
            this.pivotGridField16.Name = "pivotGridField16";
            // 
            // pivotGridField17
            // 
            this.pivotGridField17.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField17.AreaIndex = 5;
            this.pivotGridField17.Caption = "MaterialName";
            this.pivotGridField17.FieldName = "MaterialName";
            this.pivotGridField17.Name = "pivotGridField17";
            // 
            // pivotGridField18
            // 
            this.pivotGridField18.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField18.AreaIndex = 0;
            this.pivotGridField18.Caption = "M. Qty";
            this.pivotGridField18.CellFormat.FormatString = "N2";
            this.pivotGridField18.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField18.FieldName = "Quantity";
            this.pivotGridField18.Name = "pivotGridField18";
            // 
            // pivotGridField19
            // 
            this.pivotGridField19.AreaIndex = 0;
            this.pivotGridField19.Caption = "UnitCost";
            this.pivotGridField19.CellFormat.FormatString = "N2";
            this.pivotGridField19.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField19.FieldName = "UnitCost";
            this.pivotGridField19.Name = "pivotGridField19";
            // 
            // pivotGridField20
            // 
            this.pivotGridField20.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField20.AreaIndex = 1;
            this.pivotGridField20.Caption = "TotalCostAmt";
            this.pivotGridField20.CellFormat.FormatString = "N2";
            this.pivotGridField20.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField20.FieldName = "ToTalCostAmount";
            this.pivotGridField20.Name = "pivotGridField20";
            // 
            // grd_gift
            // 
            this.grd_gift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_gift.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField21,
            this.pivotGridField22,
            this.pivotGridField23,
            this.pivotGridField24,
            this.pivotGridField25});
            this.grd_gift.Location = new System.Drawing.Point(12, 174);
            this.grd_gift.Name = "grd_gift";
            this.grd_gift.Size = new System.Drawing.Size(760, 398);
            this.grd_gift.TabIndex = 175;
            // 
            // pivotGridField21
            // 
            this.pivotGridField21.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField21.AreaIndex = 0;
            this.pivotGridField21.Caption = "InvoiceNo";
            this.pivotGridField21.FieldName = "InvoiceNo";
            this.pivotGridField21.Name = "pivotGridField21";
            // 
            // pivotGridField22
            // 
            this.pivotGridField22.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField22.AreaIndex = 1;
            this.pivotGridField22.Caption = "SalesDate";
            this.pivotGridField22.FieldName = "SalesDate";
            this.pivotGridField22.Name = "pivotGridField22";
            // 
            // pivotGridField23
            // 
            this.pivotGridField23.AreaIndex = 0;
            this.pivotGridField23.Caption = "Customer";
            this.pivotGridField23.FieldName = "Customer";
            this.pivotGridField23.Name = "pivotGridField23";
            // 
            // pivotGridField24
            // 
            this.pivotGridField24.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField24.AreaIndex = 2;
            this.pivotGridField24.Caption = "ProductName";
            this.pivotGridField24.FieldName = "ProductName";
            this.pivotGridField24.Name = "pivotGridField24";
            // 
            // pivotGridField25
            // 
            this.pivotGridField25.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField25.AreaIndex = 0;
            this.pivotGridField25.Caption = "Qty";
            this.pivotGridField25.CellFormat.FormatString = "N0";
            this.pivotGridField25.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField25.FieldName = "Qty";
            this.pivotGridField25.Name = "pivotGridField25";
            // 
            // frmReportMaterialTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 584);
            this.Controls.Add(this.grd_gift);
            this.Controls.Add(this.grd_production);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.grd_purchase);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportMaterialTransaction";
            this.Text = "Material Report";
            this.Load += new System.EventHandler(this.frmReportMaterialTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_purchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_production)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_gift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.RadioGroup optReportType;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraPivotGrid.PivotGridControl grd_purchase;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
        private DevExpress.XtraEditors.SimpleButton btn_export;
        private DevExpress.XtraPivotGrid.PivotGridControl grd_production;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField13;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField14;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField15;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField16;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField17;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField18;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField19;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField20;
        private DevExpress.XtraPivotGrid.PivotGridControl grd_gift;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField21;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField22;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField23;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField24;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField25;
    }
}