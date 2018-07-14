namespace SalesPOS
{
    partial class frmSalesRefundInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesRefundInfo));
            this.txtSalesDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvSalesGrid = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSalesPriceWithVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSalesDate
            // 
            this.txtSalesDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSalesDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesDate.ForeColor = System.Drawing.Color.DimGray;
            this.txtSalesDate.Location = new System.Drawing.Point(411, 58);
            this.txtSalesDate.MaxLength = 14;
            this.txtSalesDate.Name = "txtSalesDate";
            this.txtSalesDate.ReadOnly = true;
            this.txtSalesDate.Size = new System.Drawing.Size(195, 20);
            this.txtSalesDate.TabIndex = 70;
            this.txtSalesDate.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(333, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Sales Date :";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtInvoiceNo.Location = new System.Drawing.Point(89, 58);
            this.txtInvoiceNo.MaxLength = 14;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(195, 20);
            this.txtInvoiceNo.TabIndex = 68;
            this.txtInvoiceNo.TabStop = false;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(11, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 69;
            this.label14.Text = "Invoice No :";
            // 
            // dgvSalesGrid
            // 
            this.dgvSalesGrid.AllowUserToAddRows = false;
            this.dgvSalesGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSalesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.ProductQuantity,
            this.UnitName,
            this.UnitSalesPrice,
            this.VatAmount,
            this.TotalSalesPriceWithVat});
            this.dgvSalesGrid.Location = new System.Drawing.Point(12, 84);
            this.dgvSalesGrid.MultiSelect = false;
            this.dgvSalesGrid.Name = "dgvSalesGrid";
            this.dgvSalesGrid.RowHeadersVisible = false;
            this.dgvSalesGrid.Size = new System.Drawing.Size(603, 177);
            this.dgvSalesGrid.TabIndex = 67;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "Code";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 80;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 110;
            // 
            // ProductQuantity
            // 
            this.ProductQuantity.DataPropertyName = "ProductQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ProductQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProductQuantity.HeaderText = "Quantity";
            this.ProductQuantity.Name = "ProductQuantity";
            this.ProductQuantity.ReadOnly = true;
            this.ProductQuantity.Width = 70;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle2;
            this.UnitName.HeaderText = "Unit";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 70;
            // 
            // UnitSalesPrice
            // 
            this.UnitSalesPrice.DataPropertyName = "UnitSalesPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.UnitSalesPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnitSalesPrice.HeaderText = "Unit Price";
            this.UnitSalesPrice.Name = "UnitSalesPrice";
            this.UnitSalesPrice.ReadOnly = true;
            // 
            // VatAmount
            // 
            this.VatAmount.DataPropertyName = "VatAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.VatAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.VatAmount.HeaderText = "Vat";
            this.VatAmount.Name = "VatAmount";
            this.VatAmount.ReadOnly = true;
            this.VatAmount.Width = 70;
            // 
            // TotalSalesPriceWithVat
            // 
            this.TotalSalesPriceWithVat.DataPropertyName = "TotalSalesPriceWithVat";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.TotalSalesPriceWithVat.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalSalesPriceWithVat.HeaderText = "Total Price";
            this.TotalSalesPriceWithVat.Name = "TotalSalesPriceWithVat";
            this.TotalSalesPriceWithVat.ReadOnly = true;
            // 
            // frmSalesRefundInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 273);
            this.Controls.Add(this.txtSalesDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvSalesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesRefundInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Refund";
            this.Load += new System.EventHandler(this.frmSalesRefundInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalesDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvSalesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSalesPriceWithVat;
    }
}