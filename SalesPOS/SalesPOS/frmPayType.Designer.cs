namespace SalesPOS
{
    partial class frmPayType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayType));
            this.dgvPayTypeList = new System.Windows.Forms.DataGridView();
            this.PayTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayTypeList
            // 
            this.dgvPayTypeList.AllowUserToAddRows = false;
            this.dgvPayTypeList.AllowUserToDeleteRows = false;
            this.dgvPayTypeList.AllowUserToResizeRows = false;
            this.dgvPayTypeList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPayTypeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayTypeList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PayTypeId,
            this.PayTypeName});
            this.dgvPayTypeList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPayTypeList.Location = new System.Drawing.Point(12, 11);
            this.dgvPayTypeList.MultiSelect = false;
            this.dgvPayTypeList.Name = "dgvPayTypeList";
            this.dgvPayTypeList.RowHeadersVisible = false;
            this.dgvPayTypeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPayTypeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayTypeList.Size = new System.Drawing.Size(366, 392);
            this.dgvPayTypeList.TabIndex = 16;
            // 
            // PayTypeId
            // 
            this.PayTypeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PayTypeId.DataPropertyName = "PayTypeId";
            this.PayTypeId.HeaderText = "Code";
            this.PayTypeId.Name = "PayTypeId";
            this.PayTypeId.Width = 110;
            // 
            // PayTypeName
            // 
            this.PayTypeName.DataPropertyName = "PayTypeName";
            this.PayTypeName.HeaderText = "PayType Name";
            this.PayTypeName.Name = "PayTypeName";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(304, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 27);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPayType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 445);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPayTypeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Type Information";
            this.Load += new System.EventHandler(this.frmPayType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayTypeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPayTypeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayTypeName;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}