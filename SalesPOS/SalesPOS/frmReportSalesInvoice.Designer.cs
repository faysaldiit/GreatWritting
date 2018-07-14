namespace SalesPOS
{
    partial class frmReportSalesInvoice
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
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreviewReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(136, 32);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(334, 20);
            this.txtInvoiceNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Invoice Number : ";
            // 
            // btnPreviewReport
            // 
            this.btnPreviewReport.Location = new System.Drawing.Point(136, 58);
            this.btnPreviewReport.Name = "btnPreviewReport";
            this.btnPreviewReport.Size = new System.Drawing.Size(139, 23);
            this.btnPreviewReport.TabIndex = 2;
            this.btnPreviewReport.Text = "Preview Report";
            //this.btnPreviewReport.UseVisualStyleBackColor = true;
            this.btnPreviewReport.Click += new System.EventHandler(this.btnPreviewReport_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(281, 58);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(75, 23);
            this.btnPrintReport.TabIndex = 3;
            this.btnPrintReport.Text = "Print";
            //this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // frmReportSalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(622, 262);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnPreviewReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Name = "frmReportSalesInvoice";
            this.Text = "frmReportSalesInvoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnPreviewReport;
        private DevExpress.XtraEditors.SimpleButton btnPrintReport;
    }
}