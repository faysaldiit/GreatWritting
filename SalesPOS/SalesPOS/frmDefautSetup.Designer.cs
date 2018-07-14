namespace SalesPOS
{
    partial class frmDefautSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefautSetup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optRetailSale = new System.Windows.Forms.RadioButton();
            this.optWholeSale = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSalesPriceEditable = new System.Windows.Forms.CheckBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkDiscountAllow = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkMiniAccAllow = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkCreditSaleAllow = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.optSalesPrintTypeMini = new System.Windows.Forms.RadioButton();
            this.optSalesPrintTypeLarge = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.optRetailSale);
            this.groupBox1.Controls.Add(this.optWholeSale);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(33, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 58);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Default Sales Type";
            // 
            // optRetailSale
            // 
            this.optRetailSale.AutoSize = true;
            this.optRetailSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optRetailSale.ForeColor = System.Drawing.Color.DarkRed;
            this.optRetailSale.Location = new System.Drawing.Point(12, 25);
            this.optRetailSale.Name = "optRetailSale";
            this.optRetailSale.Size = new System.Drawing.Size(76, 17);
            this.optRetailSale.TabIndex = 4;
            this.optRetailSale.TabStop = true;
            this.optRetailSale.Text = "Retail Sale";
            this.optRetailSale.UseVisualStyleBackColor = true;
            // 
            // optWholeSale
            // 
            this.optWholeSale.AutoSize = true;
            this.optWholeSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWholeSale.ForeColor = System.Drawing.Color.DarkRed;
            this.optWholeSale.Location = new System.Drawing.Point(100, 25);
            this.optWholeSale.Name = "optWholeSale";
            this.optWholeSale.Size = new System.Drawing.Size(80, 17);
            this.optWholeSale.TabIndex = 3;
            this.optWholeSale.TabStop = true;
            this.optWholeSale.Text = "Whole Sale";
            this.optWholeSale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkSalesPriceEditable);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox2.Location = new System.Drawing.Point(33, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 58);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Sales Price Editable";
            // 
            // chkSalesPriceEditable
            // 
            this.chkSalesPriceEditable.AutoSize = true;
            this.chkSalesPriceEditable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalesPriceEditable.ForeColor = System.Drawing.Color.DarkRed;
            this.chkSalesPriceEditable.Location = new System.Drawing.Point(12, 24);
            this.chkSalesPriceEditable.Name = "chkSalesPriceEditable";
            this.chkSalesPriceEditable.Size = new System.Drawing.Size(44, 17);
            this.chkSalesPriceEditable.TabIndex = 0;
            this.chkSalesPriceEditable.Text = "Yes";
            this.chkSalesPriceEditable.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = global::SalesPOS.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(306, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 25);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(381, 215);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 25);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.chkDiscountAllow);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox3.Location = new System.Drawing.Point(33, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 58);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Allow Discount Sale";
            // 
            // chkDiscountAllow
            // 
            this.chkDiscountAllow.AutoSize = true;
            this.chkDiscountAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDiscountAllow.ForeColor = System.Drawing.Color.DarkRed;
            this.chkDiscountAllow.Location = new System.Drawing.Point(12, 24);
            this.chkDiscountAllow.Name = "chkDiscountAllow";
            this.chkDiscountAllow.Size = new System.Drawing.Size(44, 17);
            this.chkDiscountAllow.TabIndex = 1;
            this.chkDiscountAllow.Text = "Yes";
            this.chkDiscountAllow.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.chkMiniAccAllow);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox4.Location = new System.Drawing.Point(33, 284);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 58);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. Allow Mini Accounts";
            // 
            // chkMiniAccAllow
            // 
            this.chkMiniAccAllow.AutoSize = true;
            this.chkMiniAccAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMiniAccAllow.ForeColor = System.Drawing.Color.DarkRed;
            this.chkMiniAccAllow.Location = new System.Drawing.Point(12, 25);
            this.chkMiniAccAllow.Name = "chkMiniAccAllow";
            this.chkMiniAccAllow.Size = new System.Drawing.Size(44, 17);
            this.chkMiniAccAllow.TabIndex = 2;
            this.chkMiniAccAllow.Text = "Yes";
            this.chkMiniAccAllow.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.chkCreditSaleAllow);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox5.Location = new System.Drawing.Point(251, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 58);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "5. Allow Credit Sale";
            // 
            // chkCreditSaleAllow
            // 
            this.chkCreditSaleAllow.AutoSize = true;
            this.chkCreditSaleAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCreditSaleAllow.ForeColor = System.Drawing.Color.DarkRed;
            this.chkCreditSaleAllow.Location = new System.Drawing.Point(12, 25);
            this.chkCreditSaleAllow.Name = "chkCreditSaleAllow";
            this.chkCreditSaleAllow.Size = new System.Drawing.Size(44, 17);
            this.chkCreditSaleAllow.TabIndex = 2;
            this.chkCreditSaleAllow.Text = "Yes";
            this.chkCreditSaleAllow.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.optSalesPrintTypeMini);
            this.groupBox6.Controls.Add(this.optSalesPrintTypeLarge);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox6.Location = new System.Drawing.Point(251, 142);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(199, 58);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "6. Sales Print Type";
            // 
            // optSalesPrintTypeMini
            // 
            this.optSalesPrintTypeMini.AutoSize = true;
            this.optSalesPrintTypeMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSalesPrintTypeMini.ForeColor = System.Drawing.Color.DarkRed;
            this.optSalesPrintTypeMini.Location = new System.Drawing.Point(12, 25);
            this.optSalesPrintTypeMini.Name = "optSalesPrintTypeMini";
            this.optSalesPrintTypeMini.Size = new System.Drawing.Size(44, 17);
            this.optSalesPrintTypeMini.TabIndex = 4;
            this.optSalesPrintTypeMini.TabStop = true;
            this.optSalesPrintTypeMini.Text = "Mini";
            this.optSalesPrintTypeMini.UseVisualStyleBackColor = true;
            // 
            // optSalesPrintTypeLarge
            // 
            this.optSalesPrintTypeLarge.AutoSize = true;
            this.optSalesPrintTypeLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSalesPrintTypeLarge.ForeColor = System.Drawing.Color.DarkRed;
            this.optSalesPrintTypeLarge.Location = new System.Drawing.Point(100, 25);
            this.optSalesPrintTypeLarge.Name = "optSalesPrintTypeLarge";
            this.optSalesPrintTypeLarge.Size = new System.Drawing.Size(52, 17);
            this.optSalesPrintTypeLarge.TabIndex = 3;
            this.optSalesPrintTypeLarge.TabStop = true;
            this.optSalesPrintTypeLarge.Text = "Large";
            this.optSalesPrintTypeLarge.UseVisualStyleBackColor = true;
            // 
            // frmDefautSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 397);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDefautSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defaut Setup";
            this.Load += new System.EventHandler(this.frmDefautSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optRetailSale;
        private System.Windows.Forms.RadioButton optWholeSale;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSalesPriceEditable;
        private System.Windows.Forms.CheckBox chkDiscountAllow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkMiniAccAllow;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkCreditSaleAllow;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton optSalesPrintTypeMini;
        private System.Windows.Forms.RadioButton optSalesPrintTypeLarge;

    }
}