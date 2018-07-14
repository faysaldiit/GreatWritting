namespace SalesPOS.Report
{
    partial class frmRptv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptv));
            this.rptvCommon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptvCommon
            // 
            this.rptvCommon.ActiveViewIndex = -1;
            this.rptvCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptvCommon.DisplayGroupTree = false;
            this.rptvCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptvCommon.Location = new System.Drawing.Point(0, 0);
            this.rptvCommon.Name = "rptvCommon";
            this.rptvCommon.SelectionFormula = "";
            this.rptvCommon.Size = new System.Drawing.Size(1028, 468);
            this.rptvCommon.TabIndex = 0;
            this.rptvCommon.ViewTimeSelectionFormula = "";
            // 
            // frmRptv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 468);
            this.Controls.Add(this.rptvCommon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptv";
            this.Text = "Preview Report";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptvCommon;
    }
}