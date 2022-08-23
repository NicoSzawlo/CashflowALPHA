namespace CashflowALPHA
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_nav = new System.Windows.Forms.FlowLayoutPanel();
            this.navbtnOvrvw = new System.Windows.Forms.Button();
            this.navbtnTrx = new System.Windows.Forms.Button();
            this.navbtnPartners = new System.Windows.Forms.Button();
            this.navbtnBudget = new System.Windows.Forms.Button();
            this.navbtnAcc = new System.Windows.Forms.Button();
            this.navtbnInv = new System.Windows.Forms.Button();
            this.navbtnSpare = new System.Windows.Forms.Button();
            this.pnlAcc = new System.Windows.Forms.Panel();
            this.btnAccUpdate = new System.Windows.Forms.Button();
            this.comboAccType = new System.Windows.Forms.ComboBox();
            this.txtAccBalance = new System.Windows.Forms.TextBox();
            this.txtAccBic = new System.Windows.Forms.TextBox();
            this.txtAccIban = new System.Windows.Forms.TextBox();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.lblAccName = new System.Windows.Forms.Label();
            this.lblAccBalance = new System.Windows.Forms.Label();
            this.lblAccIban = new System.Windows.Forms.Label();
            this.btnAccAdd = new System.Windows.Forms.Button();
            this.lblAccType = new System.Windows.Forms.Label();
            this.btnAccAddStmt = new System.Windows.Forms.Button();
            this.lblAccBic = new System.Windows.Forms.Label();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.pnlOvrvw = new System.Windows.Forms.Panel();
            this.pnlPartners = new System.Windows.Forms.Panel();
            this.dgvPartnerTypes = new System.Windows.Forms.DataGridView();
            this.dgvPartners = new System.Windows.Forms.DataGridView();
            this.pnlBudgets = new System.Windows.Forms.Panel();
            this.btnUpdateTrxType = new System.Windows.Forms.Button();
            this.txtTrxTypeBudget = new System.Windows.Forms.TextBox();
            this.lblTrxTypeBudget = new System.Windows.Forms.Label();
            this.txtTryTypeName = new System.Windows.Forms.TextBox();
            this.lblTrxTypeName = new System.Windows.Forms.Label();
            this.btnAddTrxType = new System.Windows.Forms.Button();
            this.dgvTransactionTypes = new System.Windows.Forms.DataGridView();
            this.pnl_nav.SuspendLayout();
            this.pnlAcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.pnlPartners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartners)).BeginInit();
            this.pnlBudgets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_nav
            // 
            this.pnl_nav.Controls.Add(this.navbtnOvrvw);
            this.pnl_nav.Controls.Add(this.navbtnTrx);
            this.pnl_nav.Controls.Add(this.navbtnPartners);
            this.pnl_nav.Controls.Add(this.navbtnBudget);
            this.pnl_nav.Controls.Add(this.navbtnAcc);
            this.pnl_nav.Controls.Add(this.navtbnInv);
            this.pnl_nav.Controls.Add(this.navbtnSpare);
            this.pnl_nav.Location = new System.Drawing.Point(10, 5);
            this.pnl_nav.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_nav.Name = "pnl_nav";
            this.pnl_nav.Size = new System.Drawing.Size(1255, 91);
            this.pnl_nav.TabIndex = 0;
            // 
            // navbtnOvrvw
            // 
            this.navbtnOvrvw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.navbtnOvrvw.FlatAppearance.BorderSize = 0;
            this.navbtnOvrvw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtnOvrvw.Location = new System.Drawing.Point(2, 3);
            this.navbtnOvrvw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtnOvrvw.Name = "navbtnOvrvw";
            this.navbtnOvrvw.Size = new System.Drawing.Size(160, 91);
            this.navbtnOvrvw.TabIndex = 0;
            this.navbtnOvrvw.Text = " Overview";
            this.navbtnOvrvw.UseVisualStyleBackColor = false;
            this.navbtnOvrvw.Click += new System.EventHandler(this.navbtnOvrvw_Click);
            // 
            // navbtnTrx
            // 
            this.navbtnTrx.BackColor = System.Drawing.Color.LightGray;
            this.navbtnTrx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtnTrx.Location = new System.Drawing.Point(166, 3);
            this.navbtnTrx.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtnTrx.Name = "navbtnTrx";
            this.navbtnTrx.Size = new System.Drawing.Size(160, 91);
            this.navbtnTrx.TabIndex = 1;
            this.navbtnTrx.Text = " Transactions";
            this.navbtnTrx.UseVisualStyleBackColor = false;
            this.navbtnTrx.Click += new System.EventHandler(this.navbtnTrx_Click);
            // 
            // navbtnPartners
            // 
            this.navbtnPartners.BackColor = System.Drawing.Color.LightGray;
            this.navbtnPartners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtnPartners.Location = new System.Drawing.Point(330, 3);
            this.navbtnPartners.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtnPartners.Name = "navbtnPartners";
            this.navbtnPartners.Size = new System.Drawing.Size(160, 91);
            this.navbtnPartners.TabIndex = 2;
            this.navbtnPartners.Text = " Partners";
            this.navbtnPartners.UseVisualStyleBackColor = false;
            this.navbtnPartners.Click += new System.EventHandler(this.navbtnPartners_Click);
            // 
            // navbtnBudget
            // 
            this.navbtnBudget.BackColor = System.Drawing.Color.LightGray;
            this.navbtnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtnBudget.Location = new System.Drawing.Point(494, 3);
            this.navbtnBudget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtnBudget.Name = "navbtnBudget";
            this.navbtnBudget.Size = new System.Drawing.Size(160, 91);
            this.navbtnBudget.TabIndex = 3;
            this.navbtnBudget.Text = " Budgets";
            this.navbtnBudget.UseVisualStyleBackColor = false;
            this.navbtnBudget.Click += new System.EventHandler(this.navbtnBudget_Click);
            // 
            // navbtnAcc
            // 
            this.navbtnAcc.BackColor = System.Drawing.Color.LightGray;
            this.navbtnAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtnAcc.Location = new System.Drawing.Point(658, 3);
            this.navbtnAcc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtnAcc.Name = "navbtnAcc";
            this.navbtnAcc.Size = new System.Drawing.Size(160, 91);
            this.navbtnAcc.TabIndex = 4;
            this.navbtnAcc.Text = " Accounts";
            this.navbtnAcc.UseVisualStyleBackColor = false;
            this.navbtnAcc.Click += new System.EventHandler(this.navbtnAcc_Click);
            // 
            // navtbnInv
            // 
            this.navtbnInv.BackColor = System.Drawing.Color.LightGray;
            this.navtbnInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navtbnInv.Location = new System.Drawing.Point(822, 3);
            this.navtbnInv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navtbnInv.Name = "navtbnInv";
            this.navtbnInv.Size = new System.Drawing.Size(160, 91);
            this.navtbnInv.TabIndex = 5;
            this.navtbnInv.Text = " Investments";
            this.navtbnInv.UseVisualStyleBackColor = false;
            // 
            // navbtnSpare
            // 
            this.navbtnSpare.BackColor = System.Drawing.Color.LightGray;
            this.navbtnSpare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtnSpare.Location = new System.Drawing.Point(986, 3);
            this.navbtnSpare.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtnSpare.Name = "navbtnSpare";
            this.navbtnSpare.Size = new System.Drawing.Size(160, 91);
            this.navbtnSpare.TabIndex = 6;
            this.navbtnSpare.Text = " ";
            this.navbtnSpare.UseVisualStyleBackColor = false;
            // 
            // pnlAcc
            // 
            this.pnlAcc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAcc.Controls.Add(this.btnAccUpdate);
            this.pnlAcc.Controls.Add(this.comboAccType);
            this.pnlAcc.Controls.Add(this.txtAccBalance);
            this.pnlAcc.Controls.Add(this.txtAccBic);
            this.pnlAcc.Controls.Add(this.txtAccIban);
            this.pnlAcc.Controls.Add(this.txtAccName);
            this.pnlAcc.Controls.Add(this.lblAccName);
            this.pnlAcc.Controls.Add(this.lblAccBalance);
            this.pnlAcc.Controls.Add(this.lblAccIban);
            this.pnlAcc.Controls.Add(this.btnAccAdd);
            this.pnlAcc.Controls.Add(this.lblAccType);
            this.pnlAcc.Controls.Add(this.btnAccAddStmt);
            this.pnlAcc.Controls.Add(this.lblAccBic);
            this.pnlAcc.Controls.Add(this.dgvAccounts);
            this.pnlAcc.Location = new System.Drawing.Point(11, 89);
            this.pnlAcc.Name = "pnlAcc";
            this.pnlAcc.Size = new System.Drawing.Size(1255, 595);
            this.pnlAcc.TabIndex = 1;
            // 
            // btnAccUpdate
            // 
            this.btnAccUpdate.Location = new System.Drawing.Point(785, 429);
            this.btnAccUpdate.Name = "btnAccUpdate";
            this.btnAccUpdate.Size = new System.Drawing.Size(166, 57);
            this.btnAccUpdate.TabIndex = 14;
            this.btnAccUpdate.Text = "UPDATE ACCOUNT";
            this.btnAccUpdate.UseVisualStyleBackColor = true;
            this.btnAccUpdate.Click += new System.EventHandler(this.btnAccUpdate_Click);
            // 
            // comboAccType
            // 
            this.comboAccType.FormattingEnabled = true;
            this.comboAccType.Location = new System.Drawing.Point(717, 227);
            this.comboAccType.Name = "comboAccType";
            this.comboAccType.Size = new System.Drawing.Size(215, 28);
            this.comboAccType.TabIndex = 13;
            // 
            // txtAccBalance
            // 
            this.txtAccBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAccBalance.Location = new System.Drawing.Point(717, 312);
            this.txtAccBalance.Name = "txtAccBalance";
            this.txtAccBalance.Size = new System.Drawing.Size(215, 33);
            this.txtAccBalance.TabIndex = 12;
            // 
            // txtAccBic
            // 
            this.txtAccBic.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAccBic.Location = new System.Drawing.Point(985, 137);
            this.txtAccBic.Name = "txtAccBic";
            this.txtAccBic.Size = new System.Drawing.Size(215, 33);
            this.txtAccBic.TabIndex = 11;
            // 
            // txtAccIban
            // 
            this.txtAccIban.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAccIban.Location = new System.Drawing.Point(717, 137);
            this.txtAccIban.Name = "txtAccIban";
            this.txtAccIban.Size = new System.Drawing.Size(215, 33);
            this.txtAccIban.TabIndex = 10;
            // 
            // txtAccName
            // 
            this.txtAccName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAccName.Location = new System.Drawing.Point(717, 52);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.Size = new System.Drawing.Size(215, 33);
            this.txtAccName.TabIndex = 9;
            // 
            // lblAccName
            // 
            this.lblAccName.AutoSize = true;
            this.lblAccName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccName.Location = new System.Drawing.Point(689, 19);
            this.lblAccName.Name = "lblAccName";
            this.lblAccName.Size = new System.Drawing.Size(83, 30);
            this.lblAccName.TabIndex = 4;
            this.lblAccName.Text = "Name :";
            // 
            // lblAccBalance
            // 
            this.lblAccBalance.AutoSize = true;
            this.lblAccBalance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccBalance.Location = new System.Drawing.Point(689, 279);
            this.lblAccBalance.Name = "lblAccBalance";
            this.lblAccBalance.Size = new System.Drawing.Size(94, 30);
            this.lblAccBalance.TabIndex = 8;
            this.lblAccBalance.Text = "Balance:";
            // 
            // lblAccIban
            // 
            this.lblAccIban.AutoSize = true;
            this.lblAccIban.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccIban.Location = new System.Drawing.Point(689, 104);
            this.lblAccIban.Name = "lblAccIban";
            this.lblAccIban.Size = new System.Drawing.Size(77, 30);
            this.lblAccIban.TabIndex = 5;
            this.lblAccIban.Text = "IBAN :";
            // 
            // btnAccAdd
            // 
            this.btnAccAdd.Location = new System.Drawing.Point(785, 366);
            this.btnAccAdd.Name = "btnAccAdd";
            this.btnAccAdd.Size = new System.Drawing.Size(166, 57);
            this.btnAccAdd.TabIndex = 3;
            this.btnAccAdd.Text = "ADD ACCOUNT";
            this.btnAccAdd.UseVisualStyleBackColor = true;
            this.btnAccAdd.Click += new System.EventHandler(this.btnAccAdd_Click);
            // 
            // lblAccType
            // 
            this.lblAccType.AutoSize = true;
            this.lblAccType.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccType.Location = new System.Drawing.Point(689, 194);
            this.lblAccType.Name = "lblAccType";
            this.lblAccType.Size = new System.Drawing.Size(153, 30);
            this.lblAccType.TabIndex = 7;
            this.lblAccType.Text = "Account Type:";
            // 
            // btnAccAddStmt
            // 
            this.btnAccAddStmt.Location = new System.Drawing.Point(957, 429);
            this.btnAccAddStmt.Name = "btnAccAddStmt";
            this.btnAccAddStmt.Size = new System.Drawing.Size(166, 57);
            this.btnAccAddStmt.TabIndex = 2;
            this.btnAccAddStmt.Text = "ADD STATEMENT";
            this.btnAccAddStmt.UseVisualStyleBackColor = true;
            this.btnAccAddStmt.Click += new System.EventHandler(this.btnAccAddStmt_Click);
            // 
            // lblAccBic
            // 
            this.lblAccBic.AutoSize = true;
            this.lblAccBic.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccBic.Location = new System.Drawing.Point(957, 104);
            this.lblAccBic.Name = "lblAccBic";
            this.lblAccBic.Size = new System.Drawing.Size(58, 30);
            this.lblAccBic.TabIndex = 6;
            this.lblAccBic.Text = "BIC :";
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Location = new System.Drawing.Point(21, 19);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowTemplate.Height = 29;
            this.dgvAccounts.Size = new System.Drawing.Size(632, 555);
            this.dgvAccounts.TabIndex = 0;
            this.dgvAccounts.SelectionChanged += new System.EventHandler(this.dgvAccounts_SelectionChanged);
            // 
            // pnlOvrvw
            // 
            this.pnlOvrvw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlOvrvw.Location = new System.Drawing.Point(11, 89);
            this.pnlOvrvw.Name = "pnlOvrvw";
            this.pnlOvrvw.Size = new System.Drawing.Size(1255, 595);
            this.pnlOvrvw.TabIndex = 2;
            // 
            // pnlPartners
            // 
            this.pnlPartners.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPartners.Controls.Add(this.dgvPartnerTypes);
            this.pnlPartners.Controls.Add(this.dgvPartners);
            this.pnlPartners.Location = new System.Drawing.Point(11, 89);
            this.pnlPartners.Name = "pnlPartners";
            this.pnlPartners.Size = new System.Drawing.Size(1255, 595);
            this.pnlPartners.TabIndex = 3;
            // 
            // dgvPartnerTypes
            // 
            this.dgvPartnerTypes.AllowUserToAddRows = false;
            this.dgvPartnerTypes.AllowUserToDeleteRows = false;
            this.dgvPartnerTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartnerTypes.Location = new System.Drawing.Point(682, 19);
            this.dgvPartnerTypes.Name = "dgvPartnerTypes";
            this.dgvPartnerTypes.ReadOnly = true;
            this.dgvPartnerTypes.RowTemplate.Height = 29;
            this.dgvPartnerTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartnerTypes.Size = new System.Drawing.Size(269, 172);
            this.dgvPartnerTypes.TabIndex = 2;
            // 
            // dgvPartners
            // 
            this.dgvPartners.AllowUserToAddRows = false;
            this.dgvPartners.AllowUserToDeleteRows = false;
            this.dgvPartners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartners.Location = new System.Drawing.Point(21, 19);
            this.dgvPartners.Name = "dgvPartners";
            this.dgvPartners.ReadOnly = true;
            this.dgvPartners.RowTemplate.Height = 29;
            this.dgvPartners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartners.Size = new System.Drawing.Size(632, 555);
            this.dgvPartners.TabIndex = 1;
            // 
            // pnlBudgets
            // 
            this.pnlBudgets.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBudgets.Controls.Add(this.btnUpdateTrxType);
            this.pnlBudgets.Controls.Add(this.txtTrxTypeBudget);
            this.pnlBudgets.Controls.Add(this.lblTrxTypeBudget);
            this.pnlBudgets.Controls.Add(this.txtTryTypeName);
            this.pnlBudgets.Controls.Add(this.lblTrxTypeName);
            this.pnlBudgets.Controls.Add(this.btnAddTrxType);
            this.pnlBudgets.Controls.Add(this.dgvTransactionTypes);
            this.pnlBudgets.Location = new System.Drawing.Point(11, 89);
            this.pnlBudgets.Name = "pnlBudgets";
            this.pnlBudgets.Size = new System.Drawing.Size(1255, 595);
            this.pnlBudgets.TabIndex = 3;
            // 
            // btnUpdateTrxType
            // 
            this.btnUpdateTrxType.Location = new System.Drawing.Point(1089, 121);
            this.btnUpdateTrxType.Name = "btnUpdateTrxType";
            this.btnUpdateTrxType.Size = new System.Drawing.Size(144, 70);
            this.btnUpdateTrxType.TabIndex = 15;
            this.btnUpdateTrxType.Text = "UPDATE TRANSACTION TYPE";
            this.btnUpdateTrxType.UseVisualStyleBackColor = true;
            // 
            // txtTrxTypeBudget
            // 
            this.txtTrxTypeBudget.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTrxTypeBudget.Location = new System.Drawing.Point(711, 158);
            this.txtTrxTypeBudget.Name = "txtTrxTypeBudget";
            this.txtTrxTypeBudget.Size = new System.Drawing.Size(215, 33);
            this.txtTrxTypeBudget.TabIndex = 14;
            // 
            // lblTrxTypeBudget
            // 
            this.lblTrxTypeBudget.AutoSize = true;
            this.lblTrxTypeBudget.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTrxTypeBudget.Location = new System.Drawing.Point(689, 125);
            this.lblTrxTypeBudget.Name = "lblTrxTypeBudget";
            this.lblTrxTypeBudget.Size = new System.Drawing.Size(96, 30);
            this.lblTrxTypeBudget.TabIndex = 13;
            this.lblTrxTypeBudget.Text = "Budget :";
            // 
            // txtTryTypeName
            // 
            this.txtTryTypeName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTryTypeName.Location = new System.Drawing.Point(711, 67);
            this.txtTryTypeName.Name = "txtTryTypeName";
            this.txtTryTypeName.Size = new System.Drawing.Size(215, 33);
            this.txtTryTypeName.TabIndex = 12;
            // 
            // lblTrxTypeName
            // 
            this.lblTrxTypeName.AutoSize = true;
            this.lblTrxTypeName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTrxTypeName.Location = new System.Drawing.Point(683, 34);
            this.lblTrxTypeName.Name = "lblTrxTypeName";
            this.lblTrxTypeName.Size = new System.Drawing.Size(83, 30);
            this.lblTrxTypeName.TabIndex = 11;
            this.lblTrxTypeName.Text = "Name :";
            // 
            // btnAddTrxType
            // 
            this.btnAddTrxType.Location = new System.Drawing.Point(1089, 30);
            this.btnAddTrxType.Name = "btnAddTrxType";
            this.btnAddTrxType.Size = new System.Drawing.Size(144, 70);
            this.btnAddTrxType.TabIndex = 10;
            this.btnAddTrxType.Text = "ADD TRANSACTION TYPE";
            this.btnAddTrxType.UseVisualStyleBackColor = true;
            this.btnAddTrxType.Click += new System.EventHandler(this.btnAddTrxType_Click);
            // 
            // dgvTransactionTypes
            // 
            this.dgvTransactionTypes.AllowUserToAddRows = false;
            this.dgvTransactionTypes.AllowUserToDeleteRows = false;
            this.dgvTransactionTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionTypes.Location = new System.Drawing.Point(21, 19);
            this.dgvTransactionTypes.Name = "dgvTransactionTypes";
            this.dgvTransactionTypes.ReadOnly = true;
            this.dgvTransactionTypes.RowTemplate.Height = 29;
            this.dgvTransactionTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactionTypes.Size = new System.Drawing.Size(632, 555);
            this.dgvTransactionTypes.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1285, 691);
            this.Controls.Add(this.pnl_nav);
            this.Controls.Add(this.pnlAcc);
            this.Controls.Add(this.pnlPartners);
            this.Controls.Add(this.pnlBudgets);
            this.Controls.Add(this.pnlOvrvw);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnl_nav.ResumeLayout(false);
            this.pnlAcc.ResumeLayout(false);
            this.pnlAcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.pnlPartners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartners)).EndInit();
            this.pnlBudgets.ResumeLayout(false);
            this.pnlBudgets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel pnl_nav;
        private Button navbtnOvrvw;
        private Button navbtnTrx;
        private Button navbtnPartners;
        private Button navbtnBudget;
        private Button navbtnAcc;
        private Button navtbnInv;
        private Button navbtnSpare;
        private Panel pnlAcc;
        private Panel pnlOvrvw;
        private Button btnAccAddStmt;
        private DataGridView dgvAccounts;
        private Button btnAccAdd;
        private Button btnAccUpdate;
        private ComboBox comboAccType;
        private TextBox txtAccBalance;
        private TextBox txtAccBic;
        private TextBox txtAccIban;
        private TextBox txtAccName;
        private Label lblAccName;
        private Label lblAccBalance;
        private Label lblAccIban;
        private Label lblAccType;
        private Label lblAccBic;
        private Panel pnlPartners;
        private DataGridView dgvPartners;
        private Panel pnlBudgets;
        private Button btnUpdateTrxType;
        private TextBox txtTrxTypeBudget;
        private Label lblTrxTypeBudget;
        private TextBox txtTryTypeName;
        private Label lblTrxTypeName;
        private Button btnAddTrxType;
        private DataGridView dgvTransactionTypes;
        private DataGridView dgvPartnerTypes;
    }
}