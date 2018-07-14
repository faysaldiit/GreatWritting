namespace SalesPOS
{
    partial class frmSalesReturnInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesReturnInfo));
            this.txtSalesDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvSalesGrid = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatPerchantage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSalesPriceWithVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnResetForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtSalesReturnNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesGrid)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSalesDate
            // 
            this.txtSalesDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSalesDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesDate.ForeColor = System.Drawing.Color.DimGray;
            this.txtSalesDate.Location = new System.Drawing.Point(327, 56);
            this.txtSalesDate.MaxLength = 14;
            this.txtSalesDate.Name = "txtSalesDate";
            this.txtSalesDate.ReadOnly = true;
            this.txtSalesDate.Size = new System.Drawing.Size(152, 20);
            this.txtSalesDate.TabIndex = 75;
            this.txtSalesDate.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(244, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Sales Date :";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtInvoiceNo.Location = new System.Drawing.Point(90, 56);
            this.txtInvoiceNo.MaxLength = 14;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(148, 20);
            this.txtInvoiceNo.TabIndex = 73;
            this.txtInvoiceNo.TabStop = false;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(12, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 74;
            this.label14.Text = "Invoice No :";
            // 
            // dgvSalesGrid
            // 
            this.dgvSalesGrid.AllowUserToAddRows = false;
            this.dgvSalesGrid.AllowUserToResizeColumns = false;
            this.dgvSalesGrid.AllowUserToResizeRows = false;
            this.dgvSalesGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSalesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.SoldQty,
            this.ReturnQty,
            this.UnitName,
            this.UnitSalesPrice,
            this.VatPerchantage,
            this.VatAmount,
            this.TotalSalesPriceWithVat,
            this.USP,
            this.UnitID});
            this.dgvSalesGrid.Location = new System.Drawing.Point(12, 84);
            this.dgvSalesGrid.MultiSelect = false;
            this.dgvSalesGrid.Name = "dgvSalesGrid";
            this.dgvSalesGrid.RowHeadersVisible = false;
            this.dgvSalesGrid.Size = new System.Drawing.Size(689, 189);
            this.dgvSalesGrid.TabIndex = 72;
            this.dgvSalesGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesGrid_CellEndEdit);
            this.dgvSalesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesGrid_CellContentClick);
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.Frozen = true;
            this.ProductID.HeaderText = "Code";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 80;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.Frozen = true;
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 110;
            // 
            // SoldQty
            // 
            this.SoldQty.DataPropertyName = "SoldQty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SoldQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.SoldQty.Frozen = true;
            this.SoldQty.HeaderText = "Sold Qty";
            this.SoldQty.Name = "SoldQty";
            this.SoldQty.ReadOnly = true;
            this.SoldQty.Width = 80;
            // 
            // ReturnQty
            // 
            this.ReturnQty.DataPropertyName = "ReturnQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ReturnQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReturnQty.Frozen = true;
            this.ReturnQty.HeaderText = "Return Qty";
            this.ReturnQty.Name = "ReturnQty";
            this.ReturnQty.Width = 95;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnitName.Frozen = true;
            this.UnitName.HeaderText = "Unit";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 60;
            // 
            // UnitSalesPrice
            // 
            this.UnitSalesPrice.DataPropertyName = "UnitSalesPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.UnitSalesPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitSalesPrice.Frozen = true;
            this.UnitSalesPrice.HeaderText = "Unit Price";
            this.UnitSalesPrice.Name = "UnitSalesPrice";
            this.UnitSalesPrice.ReadOnly = true;
            // 
            // VatPerchantage
            // 
            this.VatPerchantage.DataPropertyName = "VatPercentage";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VatPerchantage.DefaultCellStyle = dataGridViewCellStyle5;
            this.VatPerchantage.Frozen = true;
            this.VatPerchantage.HeaderText = "Vat(%)";
            this.VatPerchantage.Name = "VatPerchantage";
            this.VatPerchantage.Width = 70;
            // 
            // VatAmount
            // 
            this.VatAmount.DataPropertyName = "VatAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.VatAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.VatAmount.HeaderText = "Vat";
            this.VatAmount.Name = "VatAmount";
            this.VatAmount.ReadOnly = true;
            this.VatAmount.Visible = false;
            this.VatAmount.Width = 65;
            // 
            // TotalSalesPriceWithVat
            // 
            this.TotalSalesPriceWithVat.DataPropertyName = "TotalSalesPriceWithVat";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.TotalSalesPriceWithVat.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalSalesPriceWithVat.Frozen = true;
            this.TotalSalesPriceWithVat.HeaderText = "Total Price";
            this.TotalSalesPriceWithVat.Name = "TotalSalesPriceWithVat";
            this.TotalSalesPriceWithVat.ReadOnly = true;
            this.TotalSalesPriceWithVat.Width = 94;
            // 
            // USP
            // 
            this.USP.DataPropertyName = "USP";
            this.USP.HeaderText = "Unit Sales Price With Vat";
            this.USP.Name = "USP";
            this.USP.Visible = false;
            // 
            // UnitID
            // 
            this.UnitID.DataPropertyName = "UnitID";
            this.UnitID.HeaderText = "UnitID";
            this.UnitID.Name = "UnitID";
            this.UnitID.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Maroon;
            this.txtTotal.Location = new System.Drawing.Point(583, 281);
            this.txtTotal.MaxLength = 14;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(118, 20);
            this.txtTotal.TabIndex = 77;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(478, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Return Amount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "In Word  (BDT) :";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.btnResetForm);
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnPrint);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Location = new System.Drawing.Point(393, 304);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(308, 37);
            this.groupBox5.TabIndex = 82;
            this.groupBox5.TabStop = false;
            // 
            // btnResetForm
            // 
            this.btnResetForm.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetForm.Appearance.Options.UseFont = true;
            this.btnResetForm.Appearance.Options.UseForeColor = true;
            this.btnResetForm.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnResetForm.Location = new System.Drawing.Point(80, 8);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(74, 25);
            this.btnResetForm.TabIndex = 20;
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
            this.btnClose.Location = new System.Drawing.Point(230, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 21;
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
            this.btnPrint.Location = new System.Drawing.Point(3, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 25);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "&Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = global::SalesPOS.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(155, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 25);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSalesReturnNo
            // 
            this.txtSalesReturnNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSalesReturnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesReturnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesReturnNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesReturnNo.Location = new System.Drawing.Point(566, 56);
            this.txtSalesReturnNo.Name = "txtSalesReturnNo";
            this.txtSalesReturnNo.ReadOnly = true;
            this.txtSalesReturnNo.Size = new System.Drawing.Size(135, 20);
            this.txtSalesReturnNo.TabIndex = 83;
            this.txtSalesReturnNo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(487, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Return No :";
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountInWord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAmountInWord.Location = new System.Drawing.Point(113, 281);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(268, 41);
            this.lblAmountInWord.TabIndex = 85;
            this.lblAmountInWord.Text = "Only";
            // 
            // frmSalesReturnInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 349);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.txtSalesReturnNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalesDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvSalesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReturnInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Sales Return";
            this.Load += new System.EventHandler(this.frmSalesReturnInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesGrid)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalesDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvSalesGrid;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatPerchantage;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSalesPriceWithVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn USP;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitID;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.SimpleButton btnResetForm;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        public System.Windows.Forms.TextBox txtSalesReturnNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAmountInWord;
    }
}