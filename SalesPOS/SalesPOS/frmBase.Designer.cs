namespace SalesPOS
{
    partial class frmBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barButtonItem_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.status_bar_info = new DevExpress.XtraBars.BarStaticItem();
            this.bar_btn_log_out = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.nbMain = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarStockInventory = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemGlobalSearch = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem13 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem14 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_file_upload = new DevExpress.XtraEditors.SimpleButton();
            this.btn_prepare_data = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbonGalleryBarItem1,
            this.barButtonItem_Exit,
            this.status_bar_info,
            this.bar_btn_log_out,
            this.barStaticItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(835, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 1;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // barButtonItem_Exit
            // 
            this.barButtonItem_Exit.Caption = "Exit";
            this.barButtonItem_Exit.Id = 3;
            this.barButtonItem_Exit.LargeGlyph = global::SalesPOS.Properties.Resources.Close_32x32;
            this.barButtonItem_Exit.Name = "barButtonItem_Exit";
            this.barButtonItem_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Exit_ItemClick);
            // 
            // status_bar_info
            // 
            this.status_bar_info.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_bar_info.Appearance.Options.UseFont = true;
            this.status_bar_info.Caption = "barStaticItem1";
            this.status_bar_info.Id = 4;
            this.status_bar_info.Name = "status_bar_info";
            this.status_bar_info.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar_btn_log_out
            // 
            this.bar_btn_log_out.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bar_btn_log_out.Appearance.Options.UseFont = true;
            this.bar_btn_log_out.Caption = "Log Out";
            this.bar_btn_log_out.Id = 6;
            this.bar_btn_log_out.Name = "bar_btn_log_out";
            this.bar_btn_log_out.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_btn_log_out_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.barStaticItem1.Appearance.Options.UseFont = true;
            this.barStaticItem1.Caption = "|";
            this.barStaticItem1.Id = 7;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupExit});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.ribbonGalleryBarItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Theme";
            // 
            // ribbonPageGroupExit
            // 
            this.ribbonPageGroupExit.ItemLinks.Add(this.barButtonItem_Exit);
            this.ribbonPageGroupExit.Name = "ribbonPageGroupExit";
            this.ribbonPageGroupExit.Text = "Exit";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bar_btn_log_out);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.status_bar_info);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 383);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(835, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // nbMain
            // 
            this.nbMain.ActiveGroup = null;
            this.nbMain.AllowSelectedLink = true;
            this.nbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.nbMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarStockInventory});
            this.nbMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemGlobalSearch,
            this.navBarItem13,
            this.navBarItem14,
            this.navBarItem15,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem5,
            this.navBarItem6});
            this.nbMain.Location = new System.Drawing.Point(0, 147);
            this.nbMain.Name = "nbMain";
            this.nbMain.OptionsNavPane.ExpandedWidth = 186;
            this.nbMain.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbMain.Size = new System.Drawing.Size(254, 236);
            this.nbMain.TabIndex = 9;
            this.nbMain.Text = "navBarControl1";
            this.nbMain.Click += new System.EventHandler(this.nbMain_Click);
            // 
            // navBarStockInventory
            // 
            this.navBarStockInventory.Caption = "Stock Inventory";
            this.navBarStockInventory.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6)});
            this.navBarStockInventory.Name = "navBarStockInventory";
            this.navBarStockInventory.Visible = false;
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Inventory information";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Inventory Item Entry";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "Finish Inventory";
            this.navBarItem5.Name = "navBarItem5";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "Yet to be Inventory";
            this.navBarItem6.Name = "navBarItem6";
            // 
            // navBarItemGlobalSearch
            // 
            this.navBarItemGlobalSearch.Caption = "Global Search";
            this.navBarItemGlobalSearch.Name = "navBarItemGlobalSearch";
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "Product Stock Own Store";
            this.navBarItem13.Name = "navBarItem13";
            // 
            // navBarItem14
            // 
            this.navBarItem14.Caption = "Outlet Product Stock ";
            this.navBarItem14.Name = "navBarItem14";
            // 
            // navBarItem15
            // 
            this.navBarItem15.Caption = "Related transaction";
            this.navBarItem15.Name = "navBarItem15";
            // 
            // btn_file_upload
            // 
            this.btn_file_upload.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_file_upload.Appearance.Options.UseFont = true;
            this.btn_file_upload.Appearance.Options.UseTextOptions = true;
            this.btn_file_upload.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btn_file_upload.Image = global::SalesPOS.Properties.Resources.ActiveRents_16x16;
            this.btn_file_upload.Location = new System.Drawing.Point(260, 186);
            this.btn_file_upload.Name = "btn_file_upload";
            this.btn_file_upload.Size = new System.Drawing.Size(189, 32);
            this.btn_file_upload.TabIndex = 12;
            this.btn_file_upload.Text = "02. File Upload to Server";
            this.btn_file_upload.Visible = false;
            this.btn_file_upload.Click += new System.EventHandler(this.btn_file_upload_Click);
            // 
            // btn_prepare_data
            // 
            this.btn_prepare_data.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prepare_data.Appearance.Options.UseFont = true;
            this.btn_prepare_data.Appearance.Options.UseTextOptions = true;
            this.btn_prepare_data.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btn_prepare_data.Image = global::SalesPOS.Properties.Resources.ActiveRents_16x16;
            this.btn_prepare_data.Location = new System.Drawing.Point(260, 153);
            this.btn_prepare_data.Name = "btn_prepare_data";
            this.btn_prepare_data.Size = new System.Drawing.Size(189, 32);
            this.btn_prepare_data.TabIndex = 15;
            this.btn_prepare_data.Text = "01. Prepare Data";
            this.btn_prepare_data.Visible = false;
            this.btn_prepare_data.Click += new System.EventHandler(this.btn_prepare_data_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleButton1.Image = global::SalesPOS.Properties.Resources.ActiveRents_16x16;
            this.simpleButton1.Location = new System.Drawing.Point(260, 220);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(189, 32);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "03. Publish Data";
            this.simpleButton1.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lbl1.Location = new System.Drawing.Point(455, 163);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(32, 14);
            this.lbl1.TabIndex = 21;
            this.lbl1.Text = "Done";
            this.lbl1.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lbl2.Location = new System.Drawing.Point(455, 194);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(32, 14);
            this.lbl2.TabIndex = 22;
            this.lbl2.Text = "Done";
            this.lbl2.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lbl3.Location = new System.Drawing.Point(455, 227);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(32, 14);
            this.lbl3.TabIndex = 23;
            this.lbl3.Text = "Done";
            this.lbl3.Visible = false;
            // 
            // frmBase
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 414);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_file_upload);
            this.Controls.Add(this.btn_prepare_data);
            this.Controls.Add(this.nbMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmBase";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Sales System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBase_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupExit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Exit;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraNavBar.NavBarControl nbMain;
        private DevExpress.XtraNavBar.NavBarGroup navBarStockInventory;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItemGlobalSearch;
        private DevExpress.XtraNavBar.NavBarItem navBarItem13;
        private DevExpress.XtraNavBar.NavBarItem navBarItem14;
        private DevExpress.XtraNavBar.NavBarItem navBarItem15;
        private DevExpress.XtraBars.BarStaticItem status_bar_info;
       
        private DevExpress.XtraBars.BarButtonItem bar_btn_log_out;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraEditors.SimpleButton btn_file_upload;
        private DevExpress.XtraEditors.SimpleButton btn_prepare_data;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl lbl3;
        private DevExpress.XtraEditors.LabelControl lbl2;
        private DevExpress.XtraEditors.LabelControl lbl1;
    }
}