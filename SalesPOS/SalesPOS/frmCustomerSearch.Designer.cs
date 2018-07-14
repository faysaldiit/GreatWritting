namespace SalesPOS
{
    partial class frmCustomerSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerSearch));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.opt_type = new DevExpress.XtraEditors.RadioGroup();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.btnSearchProduct = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.grpCustSupList = new System.Windows.Forms.GroupBox();
            this.dgvCustomerInfoList = new System.Windows.Forms.DataGridView();
            this.AccHolderInfoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountHolderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opt_type.Properties)).BeginInit();
            this.grpCustSupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfoList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.opt_type);
            this.groupBox2.Controls.Add(this.txtContactNo);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbActivity);
            this.groupBox2.Controls.Add(this.btnSearchProduct);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.txtCustomerCode);
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 156);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Criteria";
            // 
            // opt_type
            // 
            this.opt_type.Location = new System.Drawing.Point(350, 65);
            this.opt_type.Name = "opt_type";
            this.opt_type.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "General Customer"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Distributor"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Retailer"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Wholesaler")});
            this.opt_type.Size = new System.Drawing.Size(122, 79);
            this.opt_type.TabIndex = 64;
            this.opt_type.SelectedIndexChanged += new System.EventHandler(this.opt_type_SelectedIndexChanged);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(93, 123);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(243, 21);
            this.txtContactNo.TabIndex = 63;
            this.txtContactNo.TextChanged += new System.EventHandler(this.txtContactNo_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(93, 97);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(243, 21);
            this.txtAddress.TabIndex = 62;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Contact no.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Address";
            // 
            // cmbActivity
            // 
            this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(93, 69);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(243, 21);
            this.cmbActivity.TabIndex = 58;
            this.cmbActivity.SelectedIndexChanged += new System.EventHandler(this.cmbActivity_SelectedIndexChanged);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProduct.Appearance.Options.UseFont = true;
            this.btnSearchProduct.Image = global::SalesPOS.Properties.Resources.Preview_32x32;
            this.btnSearchProduct.Location = new System.Drawing.Point(350, 16);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(43, 47);
            this.btnSearchProduct.TabIndex = 31;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Activity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(93, 42);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(243, 21);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(93, 16);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(243, 21);
            this.txtCustomerCode.TabIndex = 0;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // grpCustSupList
            // 
            this.grpCustSupList.BackColor = System.Drawing.Color.Transparent;
            this.grpCustSupList.Controls.Add(this.dgvCustomerInfoList);
            this.grpCustSupList.Location = new System.Drawing.Point(7, 165);
            this.grpCustSupList.Name = "grpCustSupList";
            this.grpCustSupList.Size = new System.Drawing.Size(578, 318);
            this.grpCustSupList.TabIndex = 12;
            this.grpCustSupList.TabStop = false;
            this.grpCustSupList.Text = "Customer List";
            // 
            // dgvCustomerInfoList
            // 
            this.dgvCustomerInfoList.AllowUserToAddRows = false;
            this.dgvCustomerInfoList.AllowUserToDeleteRows = false;
            this.dgvCustomerInfoList.AllowUserToResizeRows = false;
            this.dgvCustomerInfoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerInfoList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccHolderInfoId,
            this.ProductID,
            this.ProductName,
            this.Activity,
            this.colAccountHolderType});
            this.dgvCustomerInfoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCustomerInfoList.Location = new System.Drawing.Point(11, 19);
            this.dgvCustomerInfoList.MultiSelect = false;
            this.dgvCustomerInfoList.Name = "dgvCustomerInfoList";
            this.dgvCustomerInfoList.RowHeadersVisible = false;
            this.dgvCustomerInfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerInfoList.Size = new System.Drawing.Size(561, 267);
            this.dgvCustomerInfoList.TabIndex = 5;
            this.dgvCustomerInfoList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomerInfoList_CellMouseDoubleClick);
            // 
            // AccHolderInfoId
            // 
            this.AccHolderInfoId.DataPropertyName = "AccHolderInfoId";
            this.AccHolderInfoId.HeaderText = "AccHolderInfoId";
            this.AccHolderInfoId.Name = "AccHolderInfoId";
            this.AccHolderInfoId.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "AccountNo";
            this.ProductID.FillWeight = 52.11506F;
            this.ProductID.HeaderText = "Code";
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductName.DataPropertyName = "AccHolderName";
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 190;
            // 
            // Activity
            // 
            this.Activity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Activity.DataPropertyName = "Activity";
            this.Activity.HeaderText = "Activity";
            this.Activity.Name = "Activity";
            this.Activity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAccountHolderType
            // 
            this.colAccountHolderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAccountHolderType.DataPropertyName = "AccountHolderType";
            this.colAccountHolderType.HeaderText = "Account Type";
            this.colAccountHolderType.Name = "colAccountHolderType";
            this.colAccountHolderType.ReadOnly = true;
            this.colAccountHolderType.Width = 140;
            // 
            // frmCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 487);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpCustSupList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Search";
            this.Load += new System.EventHandler(this.frmCustomerSearch_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomerSearch_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opt_type.Properties)).EndInit();
            this.grpCustSupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfoList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnSearchProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.GroupBox grpCustSupList;
        private System.Windows.Forms.DataGridView dgvCustomerInfoList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtAddress;
        private DevExpress.XtraEditors.RadioGroup opt_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccHolderInfoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountHolderType;
    }
}