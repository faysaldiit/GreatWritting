namespace SalesPOS
{
    partial class frmVatInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVatInfo));
            this.dgvVatList = new System.Windows.Forms.DataGridView();
            this.VatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vatrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVatList
            // 
            this.dgvVatList.AllowUserToAddRows = false;
            this.dgvVatList.AllowUserToDeleteRows = false;
            this.dgvVatList.AllowUserToResizeRows = false;
            this.dgvVatList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvVatList.BackgroundColor = System.Drawing.Color.White;
            this.dgvVatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VatID,
            this.VatDescription,
            this.Vatrate});
            this.dgvVatList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVatList.Location = new System.Drawing.Point(41, 13);
            this.dgvVatList.MultiSelect = false;
            this.dgvVatList.Name = "dgvVatList";
            this.dgvVatList.RowHeadersVisible = false;
            this.dgvVatList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvVatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVatList.Size = new System.Drawing.Size(337, 436);
            this.dgvVatList.TabIndex = 16;
            // 
            // VatID
            // 
            this.VatID.DataPropertyName = "VatID";
            this.VatID.FillWeight = 62.28374F;
            this.VatID.HeaderText = "VatID";
            this.VatID.Name = "VatID";
            this.VatID.Width = 60;
            // 
            // VatDescription
            // 
            this.VatDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VatDescription.DataPropertyName = "VatDescription";
            this.VatDescription.FillWeight = 155.3365F;
            this.VatDescription.HeaderText = "Vat Description";
            this.VatDescription.Name = "VatDescription";
            // 
            // Vatrate
            // 
            this.Vatrate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Vatrate.DataPropertyName = "Vatrate";
            this.Vatrate.FillWeight = 82.37981F;
            this.Vatrate.HeaderText = "Vat Rate";
            this.Vatrate.Name = "Vatrate";
            this.Vatrate.Width = 90;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(304, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 26);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmVatInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 504);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvVatList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVatInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vat Information";
            this.Load += new System.EventHandler(this.frmVatInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVatList;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vatrate;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}