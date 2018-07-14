namespace SalesPOS
{
    partial class frmAccountTransactionDouble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountTransactionDouble));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAccountNo_CashPaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchAccNo_CashPaid = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountHolder_CashPaid = new System.Windows.Forms.TextBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountNo_CashRecv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchAccNo = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountHolder_CashRecv = new System.Windows.Forms.TextBox();
            this.btnResetForm = new DevExpress.XtraEditors.SimpleButton();
            this.label15 = new System.Windows.Forms.Label();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblDrCr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.btnResetForm);
            this.groupControl1.Controls.Add(this.label15);
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Controls.Add(this.txtRef);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Controls.Add(this.txtAmount);
            this.groupControl1.Controls.Add(this.dtpTransactionDate);
            this.groupControl1.Controls.Add(this.lblDrCr);
            this.groupControl1.Location = new System.Drawing.Point(10, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(757, 199);
            this.groupControl1.TabIndex = 111;
            this.groupControl1.Text = "Account Transaction Entry";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAccountNo_CashPaid);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSearchAccNo_CashPaid);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAccountHolder_CashPaid);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(7, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 75);
            this.groupBox2.TabIndex = 163;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cash Paid";
            // 
            // txtAccountNo_CashPaid
            // 
            this.txtAccountNo_CashPaid.BackColor = System.Drawing.Color.White;
            this.txtAccountNo_CashPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNo_CashPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo_CashPaid.ForeColor = System.Drawing.Color.Maroon;
            this.txtAccountNo_CashPaid.Location = new System.Drawing.Point(109, 20);
            this.txtAccountNo_CashPaid.MaxLength = 14;
            this.txtAccountNo_CashPaid.Name = "txtAccountNo_CashPaid";
            this.txtAccountNo_CashPaid.ReadOnly = true;
            this.txtAccountNo_CashPaid.Size = new System.Drawing.Size(194, 21);
            this.txtAccountNo_CashPaid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "Account No :";
            // 
            // txtSearchAccNo_CashPaid
            // 
            this.txtSearchAccNo_CashPaid.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAccNo_CashPaid.Appearance.Options.UseFont = true;
            this.txtSearchAccNo_CashPaid.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.txtSearchAccNo_CashPaid.Location = new System.Drawing.Point(309, 20);
            this.txtSearchAccNo_CashPaid.Name = "txtSearchAccNo_CashPaid";
            this.txtSearchAccNo_CashPaid.Size = new System.Drawing.Size(27, 20);
            this.txtSearchAccNo_CashPaid.TabIndex = 1;
            this.txtSearchAccNo_CashPaid.Click += new System.EventHandler(this.txtSearchAccNo_CashPaid_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.TabIndex = 89;
            this.label2.Text = "Account Holder :";
            // 
            // txtAccountHolder_CashPaid
            // 
            this.txtAccountHolder_CashPaid.BackColor = System.Drawing.Color.White;
            this.txtAccountHolder_CashPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountHolder_CashPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolder_CashPaid.ForeColor = System.Drawing.Color.Gray;
            this.txtAccountHolder_CashPaid.Location = new System.Drawing.Point(109, 46);
            this.txtAccountHolder_CashPaid.Name = "txtAccountHolder_CashPaid";
            this.txtAccountHolder_CashPaid.ReadOnly = true;
            this.txtAccountHolder_CashPaid.Size = new System.Drawing.Size(227, 21);
            this.txtAccountHolder_CashPaid.TabIndex = 2;
            this.txtAccountHolder_CashPaid.TabStop = false;
            this.txtAccountHolder_CashPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountHolder_CashPaid_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = global::SalesPOS.Properties.Resources.Close_16x16;
            this.btnClose.Location = new System.Drawing.Point(671, 153);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = global::SalesPOS.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(596, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccountNo_CashRecv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSearchAccNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccountHolder_CashRecv);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(7, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 75);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cash Receive";
            // 
            // txtAccountNo_CashRecv
            // 
            this.txtAccountNo_CashRecv.BackColor = System.Drawing.Color.White;
            this.txtAccountNo_CashRecv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNo_CashRecv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo_CashRecv.ForeColor = System.Drawing.Color.Maroon;
            this.txtAccountNo_CashRecv.Location = new System.Drawing.Point(109, 20);
            this.txtAccountNo_CashRecv.MaxLength = 14;
            this.txtAccountNo_CashRecv.Name = "txtAccountNo_CashRecv";
            this.txtAccountNo_CashRecv.ReadOnly = true;
            this.txtAccountNo_CashRecv.Size = new System.Drawing.Size(194, 21);
            this.txtAccountNo_CashRecv.TabIndex = 0;
            this.txtAccountNo_CashRecv.TextChanged += new System.EventHandler(this.txtAccountNo_CashRecv_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 94;
            this.label4.Text = "Account No :";
            // 
            // txtSearchAccNo
            // 
            this.txtSearchAccNo.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAccNo.Appearance.Options.UseFont = true;
            this.txtSearchAccNo.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.txtSearchAccNo.Location = new System.Drawing.Point(309, 20);
            this.txtSearchAccNo.Name = "txtSearchAccNo";
            this.txtSearchAccNo.Size = new System.Drawing.Size(27, 20);
            this.txtSearchAccNo.TabIndex = 1;
            this.txtSearchAccNo.Click += new System.EventHandler(this.txtSearchAccNo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 89;
            this.label3.Text = "Account Holder :";
            // 
            // txtAccountHolder_CashRecv
            // 
            this.txtAccountHolder_CashRecv.BackColor = System.Drawing.Color.White;
            this.txtAccountHolder_CashRecv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountHolder_CashRecv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolder_CashRecv.ForeColor = System.Drawing.Color.Gray;
            this.txtAccountHolder_CashRecv.Location = new System.Drawing.Point(109, 46);
            this.txtAccountHolder_CashRecv.Name = "txtAccountHolder_CashRecv";
            this.txtAccountHolder_CashRecv.ReadOnly = true;
            this.txtAccountHolder_CashRecv.Size = new System.Drawing.Size(227, 21);
            this.txtAccountHolder_CashRecv.TabIndex = 2;
            this.txtAccountHolder_CashRecv.TabStop = false;
            this.txtAccountHolder_CashRecv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountHolder_CashRecv_KeyPress);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetForm.Appearance.Options.UseFont = true;
            this.btnResetForm.Appearance.Options.UseForeColor = true;
            this.btnResetForm.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnResetForm.Location = new System.Drawing.Point(520, 153);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(74, 25);
            this.btnResetForm.TabIndex = 5;
            this.btnResetForm.Text = "&Reset";
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(387, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 14);
            this.label15.TabIndex = 162;
            this.label15.Text = "Ref:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::SalesPOS.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(520, 153);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 25);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "&Print";
            this.btnPrint.Visible = false;
            // 
            // txtRef
            // 
            this.txtRef.BackColor = System.Drawing.Color.White;
            this.txtRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.Location = new System.Drawing.Point(518, 119);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(227, 21);
            this.txtRef.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(386, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 14);
            this.label12.TabIndex = 111;
            this.label12.Text = "Description :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(386, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 14);
            this.label8.TabIndex = 105;
            this.label8.Text = "Transaction Date :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(13, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 14);
            this.label9.TabIndex = 103;
            this.label9.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(518, 92);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(227, 21);
            this.txtDescription.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(518, 64);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(227, 22);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDate.Location = new System.Drawing.Point(518, 37);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(224, 21);
            this.dtpTransactionDate.TabIndex = 12;
            // 
            // lblDrCr
            // 
            this.lblDrCr.AutoSize = true;
            this.lblDrCr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrCr.ForeColor = System.Drawing.Color.Black;
            this.lblDrCr.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDrCr.Location = new System.Drawing.Point(387, 64);
            this.lblDrCr.Name = "lblDrCr";
            this.lblDrCr.Size = new System.Drawing.Size(59, 14);
            this.lblDrCr.TabIndex = 100;
            this.lblDrCr.Text = "Amount :";
            this.lblDrCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAccountTransactionDouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 222);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountTransactionDouble";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Transaction";
            this.Load += new System.EventHandler(this.frmAccountTransactionDouble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.SimpleButton btnResetForm;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.TextBox txtAccountHolder_CashRecv;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountNo_CashRecv;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblDrCr;
        private DevExpress.XtraEditors.SimpleButton txtSearchAccNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAccountNo_CashPaid;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton txtSearchAccNo_CashPaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountHolder_CashPaid;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}