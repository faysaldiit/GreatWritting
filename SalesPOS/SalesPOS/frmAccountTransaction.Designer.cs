namespace SalesPOS
{
    partial class frmAccountTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountTransaction));
            this.dgvAccountTransaction = new System.Windows.Forms.DataGridView();
            this.ATID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccHolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEditable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNoSearch = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAccountHolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccTransTypeSearch = new System.Windows.Forms.ComboBox();
            this.chkTransactionType = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAmountTo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAmountFrom = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRefSearch = new System.Windows.Forms.TextBox();
            this.chk_all = new DevExpress.XtraEditors.CheckEdit();
            this.btnSearchUser = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountHolderSearch = new System.Windows.Forms.TextBox();
            this.btn_search_account = new DevExpress.XtraEditors.SimpleButton();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbRecordType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.cmbAccTransType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAtid = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDrCr = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_master_head = new System.Windows.Forms.ComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lnkAccountTransaction = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.chk_deposit_to_bank = new System.Windows.Forms.CheckBox();
            this.cmb_bank = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.btnResetForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearchAccNo = new DevExpress.XtraEditors.SimpleButton();
            this.grd_bank_balance = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_total_balance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransaction)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_all.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_bank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_bank_balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAccountTransaction
            // 
            this.dgvAccountTransaction.AllowUserToAddRows = false;
            this.dgvAccountTransaction.AllowUserToDeleteRows = false;
            this.dgvAccountTransaction.AllowUserToResizeRows = false;
            this.dgvAccountTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccountTransaction.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccountTransaction.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvAccountTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATID,
            this.TransactionDate,
            this.TerminalID,
            this.AccountNo,
            this.AccHolderName,
            this.ATTID,
            this.TransactionType,
            this.Debit,
            this.Credit,
            this.IsEditable,
            this.Description,
            this.RefNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccountTransaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccountTransaction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAccountTransaction.Location = new System.Drawing.Point(2, 165);
            this.dgvAccountTransaction.MultiSelect = false;
            this.dgvAccountTransaction.Name = "dgvAccountTransaction";
            this.dgvAccountTransaction.RowHeadersVisible = false;
            this.dgvAccountTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAccountTransaction.Size = new System.Drawing.Size(959, 165);
            this.dgvAccountTransaction.TabIndex = 80;
            this.dgvAccountTransaction.TabStop = false;
            this.dgvAccountTransaction.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountTransaction_CellMouseClick);
            this.dgvAccountTransaction.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAccountTransaction_RowPrePaint);
            this.dgvAccountTransaction.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountTransaction_CellMouseDown);
            this.dgvAccountTransaction.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountTransaction_CellMouseDoubleClick);
            this.dgvAccountTransaction.SelectionChanged += new System.EventHandler(this.dgvAccountTransaction_SelectionChanged);
            // 
            // ATID
            // 
            this.ATID.DataPropertyName = "ATID";
            this.ATID.HeaderText = "ATID";
            this.ATID.Name = "ATID";
            this.ATID.Visible = false;
            // 
            // TransactionDate
            // 
            this.TransactionDate.DataPropertyName = "TransactionDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TransactionDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.TransactionDate.FillWeight = 534.2331F;
            this.TransactionDate.HeaderText = "Date";
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.Width = 90;
            // 
            // TerminalID
            // 
            this.TerminalID.DataPropertyName = "TerminalID";
            this.TerminalID.HeaderText = "Terminal";
            this.TerminalID.Name = "TerminalID";
            this.TerminalID.Visible = false;
            this.TerminalID.Width = 65;
            // 
            // AccountNo
            // 
            this.AccountNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AccountNo.DataPropertyName = "AccountNo";
            this.AccountNo.FillWeight = 15.995F;
            this.AccountNo.HeaderText = "Account No";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.Width = 140;
            // 
            // AccHolderName
            // 
            this.AccHolderName.DataPropertyName = "AccHolderName";
            this.AccHolderName.FillWeight = 15.995F;
            this.AccHolderName.HeaderText = "Account Name";
            this.AccHolderName.Name = "AccHolderName";
            this.AccHolderName.Width = 190;
            // 
            // ATTID
            // 
            this.ATTID.DataPropertyName = "ATTID";
            this.ATTID.HeaderText = "ATTID";
            this.ATTID.Name = "ATTID";
            this.ATTID.Visible = false;
            this.ATTID.Width = 77;
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "TransactionType";
            this.TransactionType.FillWeight = 15.995F;
            this.TransactionType.HeaderText = "Transaction Type";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.Width = 150;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            this.Debit.FillWeight = 15.995F;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.Width = 80;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.FillWeight = 15.995F;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.Width = 80;
            // 
            // IsEditable
            // 
            this.IsEditable.DataPropertyName = "IsEditable";
            this.IsEditable.HeaderText = "Editable";
            this.IsEditable.Name = "IsEditable";
            this.IsEditable.Visible = false;
            this.IsEditable.Width = 70;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 15.995F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // RefNo
            // 
            this.RefNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RefNo.DataPropertyName = "RefNo";
            this.RefNo.HeaderText = "RefNo";
            this.RefNo.Name = "RefNo";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(108, 86);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(155, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 82;
            this.label1.Text = "Date From :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(108, 110);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(155, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(7, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 84;
            this.label2.Text = "Date To :";
            // 
            // txtAccountNoSearch
            // 
            this.txtAccountNoSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAccountNoSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNoSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNoSearch.Location = new System.Drawing.Point(108, 14);
            this.txtAccountNoSearch.MaxLength = 14;
            this.txtAccountNoSearch.Name = "txtAccountNoSearch";
            this.txtAccountNoSearch.ReadOnly = true;
            this.txtAccountNoSearch.Size = new System.Drawing.Size(207, 22);
            this.txtAccountNoSearch.TabIndex = 2;
            this.txtAccountNoSearch.TextChanged += new System.EventHandler(this.txtAccountNoSearch_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(7, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 14);
            this.label20.TabIndex = 87;
            this.label20.Text = "Account No :";
            // 
            // txtAccountHolder
            // 
            this.txtAccountHolder.BackColor = System.Drawing.Color.White;
            this.txtAccountHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolder.ForeColor = System.Drawing.Color.Gray;
            this.txtAccountHolder.Location = new System.Drawing.Point(164, 57);
            this.txtAccountHolder.Name = "txtAccountHolder";
            this.txtAccountHolder.ReadOnly = true;
            this.txtAccountHolder.Size = new System.Drawing.Size(227, 21);
            this.txtAccountHolder.TabIndex = 1;
            this.txtAccountHolder.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 89;
            this.label3.Text = "Account Holder :";
            // 
            // cmbAccTransTypeSearch
            // 
            this.cmbAccTransTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccTransTypeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccTransTypeSearch.FormattingEnabled = true;
            this.cmbAccTransTypeSearch.Location = new System.Drawing.Point(385, 220);
            this.cmbAccTransTypeSearch.Name = "cmbAccTransTypeSearch";
            this.cmbAccTransTypeSearch.Size = new System.Drawing.Size(284, 21);
            this.cmbAccTransTypeSearch.TabIndex = 6;
            this.cmbAccTransTypeSearch.Visible = false;
            // 
            // chkTransactionType
            // 
            this.chkTransactionType.AutoSize = true;
            this.chkTransactionType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransactionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkTransactionType.Location = new System.Drawing.Point(270, 221);
            this.chkTransactionType.Name = "chkTransactionType";
            this.chkTransactionType.Size = new System.Drawing.Size(121, 18);
            this.chkTransactionType.TabIndex = 5;
            this.chkTransactionType.Text = "Transaction Type";
            this.chkTransactionType.UseVisualStyleBackColor = true;
            this.chkTransactionType.Visible = false;
            this.chkTransactionType.CheckedChanged += new System.EventHandler(this.chkTransactionType_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtAmountTo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtAmountFrom);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtRefSearch);
            this.groupBox1.Controls.Add(this.chk_all);
            this.groupBox1.Controls.Add(this.btnSearchUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAccountHolderSearch);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.btn_search_account);
            this.groupBox1.Controls.Add(this.txtAccountNoSearch);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 160);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(175, 139);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 14);
            this.label17.TabIndex = 103;
            this.label17.Text = "To";
            // 
            // txtAmountTo
            // 
            this.txtAmountTo.BackColor = System.Drawing.Color.White;
            this.txtAmountTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountTo.Location = new System.Drawing.Point(199, 135);
            this.txtAmountTo.MaxLength = 14;
            this.txtAmountTo.Name = "txtAmountTo";
            this.txtAmountTo.Size = new System.Drawing.Size(64, 22);
            this.txtAmountTo.TabIndex = 102;
            this.txtAmountTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountTo_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(7, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 14);
            this.label16.TabIndex = 101;
            this.label16.Text = "Amount From:";
            // 
            // txtAmountFrom
            // 
            this.txtAmountFrom.BackColor = System.Drawing.Color.White;
            this.txtAmountFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountFrom.Location = new System.Drawing.Point(108, 135);
            this.txtAmountFrom.MaxLength = 14;
            this.txtAmountFrom.Name = "txtAmountFrom";
            this.txtAmountFrom.Size = new System.Drawing.Size(64, 22);
            this.txtAmountFrom.TabIndex = 100;
            this.txtAmountFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountSearch_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(7, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 14);
            this.label14.TabIndex = 99;
            this.label14.Text = "Ref :";
            // 
            // txtRefSearch
            // 
            this.txtRefSearch.BackColor = System.Drawing.Color.White;
            this.txtRefSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefSearch.Location = new System.Drawing.Point(108, 61);
            this.txtRefSearch.MaxLength = 14;
            this.txtRefSearch.Name = "txtRefSearch";
            this.txtRefSearch.Size = new System.Drawing.Size(264, 22);
            this.txtRefSearch.TabIndex = 98;
            // 
            // chk_all
            // 
            this.chk_all.Location = new System.Drawing.Point(342, 13);
            this.chk_all.Name = "chk_all";
            this.chk_all.Properties.Caption = "All";
            this.chk_all.Size = new System.Drawing.Size(33, 19);
            this.chk_all.TabIndex = 94;
            this.chk_all.CheckedChanged += new System.EventHandler(this.chk_all_CheckedChanged);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchUser.Appearance.Options.UseFont = true;
            this.btnSearchUser.Appearance.Options.UseForeColor = true;
            this.btnSearchUser.Image = global::SalesPOS.Properties.Resources.Preview_32x321;
            this.btnSearchUser.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSearchUser.Location = new System.Drawing.Point(309, 102);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(63, 55);
            this.btnSearchUser.TabIndex = 8;
            this.btnSearchUser.Text = "Search";
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(7, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 93;
            this.label5.Text = "Account Holder :";
            // 
            // txtAccountHolderSearch
            // 
            this.txtAccountHolderSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAccountHolderSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountHolderSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolderSearch.ForeColor = System.Drawing.Color.Black;
            this.txtAccountHolderSearch.Location = new System.Drawing.Point(108, 37);
            this.txtAccountHolderSearch.Name = "txtAccountHolderSearch";
            this.txtAccountHolderSearch.ReadOnly = true;
            this.txtAccountHolderSearch.Size = new System.Drawing.Size(264, 22);
            this.txtAccountHolderSearch.TabIndex = 4;
            this.txtAccountHolderSearch.TabStop = false;
            // 
            // btn_search_account
            // 
            this.btn_search_account.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_account.Appearance.Options.UseFont = true;
            this.btn_search_account.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.btn_search_account.Location = new System.Drawing.Point(315, 14);
            this.btn_search_account.Name = "btn_search_account";
            this.btn_search_account.Size = new System.Drawing.Size(27, 22);
            this.btn_search_account.TabIndex = 3;
            this.btn_search_account.Click += new System.EventHandler(this.btn_search_account_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Blue;
            this.lblRecordCount.Location = new System.Drawing.Point(554, 166);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(14, 13);
            this.lblRecordCount.TabIndex = 97;
            this.lblRecordCount.Text = "0";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecordCount.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(463, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 96;
            this.label10.Text = "Record Found :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Visible = false;
            // 
            // cmbRecordType
            // 
            this.cmbRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecordType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecordType.FormattingEnabled = true;
            this.cmbRecordType.Items.AddRange(new object[] {
            "Editable",
            "NotEditable",
            "Both"});
            this.cmbRecordType.Location = new System.Drawing.Point(385, 245);
            this.cmbRecordType.Name = "cmbRecordType";
            this.cmbRecordType.Size = new System.Drawing.Size(284, 21);
            this.cmbRecordType.TabIndex = 7;
            this.cmbRecordType.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(270, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 98;
            this.label11.Text = "Record Type";
            this.label11.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 94;
            this.label4.Text = "Account No :";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.BackColor = System.Drawing.Color.White;
            this.txtAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtAccountNo.Location = new System.Drawing.Point(164, 31);
            this.txtAccountNo.MaxLength = 14;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(194, 21);
            this.txtAccountNo.TabIndex = 0;
            this.txtAccountNo.TextChanged += new System.EventHandler(this.txtAccountNo_TextChanged);
            // 
            // cmbAccTransType
            // 
            this.cmbAccTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccTransType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccTransType.FormattingEnabled = true;
            this.cmbAccTransType.Location = new System.Drawing.Point(164, 109);
            this.cmbAccTransType.Name = "cmbAccTransType";
            this.cmbAccTransType.Size = new System.Drawing.Size(227, 23);
            this.cmbAccTransType.TabIndex = 3;
            this.cmbAccTransType.SelectedIndexChanged += new System.EventHandler(this.cmbAccTransType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 14);
            this.label6.TabIndex = 97;
            this.label6.Text = "Transaction Head :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(491, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 14);
            this.label7.TabIndex = 99;
            this.label7.Text = "Serial No :";
            // 
            // txtAtid
            // 
            this.txtAtid.BackColor = System.Drawing.Color.Bisque;
            this.txtAtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtid.Location = new System.Drawing.Point(623, 32);
            this.txtAtid.Name = "txtAtid";
            this.txtAtid.ReadOnly = true;
            this.txtAtid.Size = new System.Drawing.Size(225, 21);
            this.txtAtid.TabIndex = 9;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(164, 165);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(227, 22);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(623, 86);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(227, 21);
            this.txtDescription.TabIndex = 6;
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
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDate.Location = new System.Drawing.Point(623, 59);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(224, 21);
            this.dtpTransactionDate.TabIndex = 12;
            this.dtpTransactionDate.ValueChanged += new System.EventHandler(this.dtpTransactionDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(491, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 14);
            this.label8.TabIndex = 105;
            this.label8.Text = "Transaction Date :";
            // 
            // lblDrCr
            // 
            this.lblDrCr.AutoSize = true;
            this.lblDrCr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrCr.ForeColor = System.Drawing.Color.Black;
            this.lblDrCr.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDrCr.Location = new System.Drawing.Point(12, 165);
            this.lblDrCr.Name = "lblDrCr";
            this.lblDrCr.Size = new System.Drawing.Size(97, 14);
            this.lblDrCr.TabIndex = 100;
            this.lblDrCr.Text = "DR/CR Amount :";
            this.lblDrCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(9, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 14);
            this.label13.TabIndex = 109;
            this.label13.Text = "Transaction Master Head :";
            // 
            // cmb_master_head
            // 
            this.cmb_master_head.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_master_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_master_head.FormattingEnabled = true;
            this.cmb_master_head.Location = new System.Drawing.Point(164, 82);
            this.cmb_master_head.Name = "cmb_master_head";
            this.cmb_master_head.Size = new System.Drawing.Size(227, 23);
            this.cmb_master_head.TabIndex = 2;
            this.cmb_master_head.SelectedIndexChanged += new System.EventHandler(this.cmb_master_head_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lnkAccountTransaction);
            this.groupControl1.Controls.Add(this.label15);
            this.groupControl1.Controls.Add(this.txtRef);
            this.groupControl1.Controls.Add(this.chk_deposit_to_bank);
            this.groupControl1.Controls.Add(this.cmb_bank);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.btnResetForm);
            this.groupControl1.Controls.Add(this.label13);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.cmb_master_head);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Controls.Add(this.txtAccountHolder);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.lblRecordCount);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtAccountNo);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtAmount);
            this.groupControl1.Controls.Add(this.dtpTransactionDate);
            this.groupControl1.Controls.Add(this.lblDrCr);
            this.groupControl1.Controls.Add(this.txtSearchAccNo);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtAtid);
            this.groupControl1.Controls.Add(this.cmbAccTransType);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Location = new System.Drawing.Point(3, 336);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(959, 199);
            this.groupControl1.TabIndex = 110;
            this.groupControl1.Text = "Account Transaction Entry";
            // 
            // lnkAccountTransaction
            // 
            this.lnkAccountTransaction.AutoSize = true;
            this.lnkAccountTransaction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAccountTransaction.Location = new System.Drawing.Point(206, 4);
            this.lnkAccountTransaction.Name = "lnkAccountTransaction";
            this.lnkAccountTransaction.Size = new System.Drawing.Size(175, 13);
            this.lnkAccountTransaction.TabIndex = 163;
            this.lnkAccountTransaction.TabStop = true;
            this.lnkAccountTransaction.Text = "Advance Account Transaction";
            this.lnkAccountTransaction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccountTransaction_LinkClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(491, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 14);
            this.label15.TabIndex = 162;
            this.label15.Text = "Ref:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRef
            // 
            this.txtRef.BackColor = System.Drawing.Color.White;
            this.txtRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.Location = new System.Drawing.Point(623, 113);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(227, 21);
            this.txtRef.TabIndex = 7;
            // 
            // chk_deposit_to_bank
            // 
            this.chk_deposit_to_bank.BackColor = System.Drawing.Color.Transparent;
            this.chk_deposit_to_bank.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chk_deposit_to_bank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_deposit_to_bank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chk_deposit_to_bank.Location = new System.Drawing.Point(15, 138);
            this.chk_deposit_to_bank.Name = "chk_deposit_to_bank";
            this.chk_deposit_to_bank.Size = new System.Drawing.Size(133, 18);
            this.chk_deposit_to_bank.TabIndex = 160;
            this.chk_deposit_to_bank.Text = "Bank Deposit";
            this.chk_deposit_to_bank.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chk_deposit_to_bank.UseVisualStyleBackColor = false;
            this.chk_deposit_to_bank.Visible = false;
            this.chk_deposit_to_bank.CheckedChanged += new System.EventHandler(this.chk_deposit_to_bank_CheckedChanged);
            // 
            // cmb_bank
            // 
            this.cmb_bank.Enabled = false;
            this.cmb_bank.Location = new System.Drawing.Point(164, 138);
            this.cmb_bank.Name = "cmb_bank";
            this.cmb_bank.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_bank.Properties.Appearance.Options.UseFont = true;
            this.cmb_bank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_bank.Properties.NullText = "";
            this.cmb_bank.Properties.View = this.gridView3;
            this.cmb_bank.Size = new System.Drawing.Size(227, 21);
            this.cmb_bank.TabIndex = 4;
            this.cmb_bank.Visible = false;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn7});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "AccountNo";
            this.gridColumn5.FieldName = "AccountNo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 160;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Bank";
            this.gridColumn7.FieldName = "Bank";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 443;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(491, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 14);
            this.label12.TabIndex = 111;
            this.label12.Text = "Description :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnResetForm
            // 
            this.btnResetForm.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetForm.Appearance.Options.UseFont = true;
            this.btnResetForm.Appearance.Options.UseForeColor = true;
            this.btnResetForm.Image = global::SalesPOS.Properties.Resources.Refresh_16x16;
            this.btnResetForm.Location = new System.Drawing.Point(623, 154);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(74, 25);
            this.btnResetForm.TabIndex = 10;
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
            this.btnClose.Location = new System.Drawing.Point(774, 154);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 9;
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
            this.btnPrint.Location = new System.Drawing.Point(623, 154);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 25);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "&Print";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = global::SalesPOS.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(699, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearchAccNo
            // 
            this.txtSearchAccNo.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAccNo.Appearance.Options.UseFont = true;
            this.txtSearchAccNo.Image = global::SalesPOS.Properties.Resources.Preview_16x16;
            this.txtSearchAccNo.Location = new System.Drawing.Point(364, 31);
            this.txtSearchAccNo.Name = "txtSearchAccNo";
            this.txtSearchAccNo.Size = new System.Drawing.Size(27, 20);
            this.txtSearchAccNo.TabIndex = 1;
            this.txtSearchAccNo.Click += new System.EventHandler(this.txtSearchAccNo_Click);
            // 
            // grd_bank_balance
            // 
            this.grd_bank_balance.Location = new System.Drawing.Point(386, 7);
            this.grd_bank_balance.MainView = this.gridView1;
            this.grd_bank_balance.Name = "grd_bank_balance";
            this.grd_bank_balance.Size = new System.Drawing.Size(426, 152);
            this.grd_bank_balance.TabIndex = 111;
            this.grd_bank_balance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.grd_bank_balance;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Account Name";
            this.gridColumn1.FieldName = "AccountName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 300;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Balance";
            this.gridColumn2.FieldName = "Balance";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 108;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.lbl_total_balance);
            this.groupControl2.Location = new System.Drawing.Point(814, 7);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(125, 152);
            this.groupControl2.TabIndex = 112;
            this.groupControl2.Text = "Total Balance";
            // 
            // lbl_total_balance
            // 
            this.lbl_total_balance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_balance.ForeColor = System.Drawing.Color.Green;
            this.lbl_total_balance.Location = new System.Drawing.Point(4, 68);
            this.lbl_total_balance.Name = "lbl_total_balance";
            this.lbl_total_balance.Size = new System.Drawing.Size(119, 27);
            this.lbl_total_balance.TabIndex = 83;
            this.lbl_total_balance.Text = "10000000";
            this.lbl_total_balance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmAccountTransaction
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 538);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grd_bank_balance);
            this.Controls.Add(this.cmbRecordType);
            this.Controls.Add(this.cmbAccTransTypeSearch);
            this.Controls.Add(this.chkTransactionType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAccountTransaction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Transaction Info";
            this.Load += new System.EventHandler(this.frmAccountTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransaction)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_all.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_bank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_bank_balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnResetForm;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.DataGridView dgvAccountTransaction;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btn_search_account;
        private System.Windows.Forms.TextBox txtAccountNoSearch;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtAccountHolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAccTransTypeSearch;
        private System.Windows.Forms.CheckBox chkTransactionType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccountHolderSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccountNo;
        private DevExpress.XtraEditors.SimpleButton txtSearchAccNo;
        private System.Windows.Forms.ComboBox cmbAccTransType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAtid;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnSearchUser;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.ComboBox cmbRecordType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDrCr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_master_head;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraGrid.GridControl grd_bank_balance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.CheckBox chk_deposit_to_bank;
        private DevExpress.XtraEditors.SearchLookUpEdit cmb_bank;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label lbl_total_balance;
        private DevExpress.XtraEditors.CheckEdit chk_all;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRefSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccHolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsEditable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAmountFrom;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAmountTo;
        private System.Windows.Forms.LinkLabel lnkAccountTransaction;
    }
}