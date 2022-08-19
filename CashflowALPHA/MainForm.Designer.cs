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
            this.navbtn_ovrvw = new System.Windows.Forms.Button();
            this.navbtn_trx = new System.Windows.Forms.Button();
            this.navbtn_partners = new System.Windows.Forms.Button();
            this.navbtn_budget = new System.Windows.Forms.Button();
            this.navbtn_acc = new System.Windows.Forms.Button();
            this.navtbn_inv = new System.Windows.Forms.Button();
            this.navbtn_res = new System.Windows.Forms.Button();
            this.pnl_acc = new System.Windows.Forms.Panel();
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
            this.btnAccStmtAdd = new System.Windows.Forms.Button();
            this.lblAccBic = new System.Windows.Forms.Label();
            this.dgv_accounts = new System.Windows.Forms.DataGridView();
            this.pnl_ovrvw = new System.Windows.Forms.Panel();
            this.pnl_nav.SuspendLayout();
            this.pnl_acc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_accounts)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_nav
            // 
            this.pnl_nav.Controls.Add(this.navbtn_ovrvw);
            this.pnl_nav.Controls.Add(this.navbtn_trx);
            this.pnl_nav.Controls.Add(this.navbtn_partners);
            this.pnl_nav.Controls.Add(this.navbtn_budget);
            this.pnl_nav.Controls.Add(this.navbtn_acc);
            this.pnl_nav.Controls.Add(this.navtbn_inv);
            this.pnl_nav.Controls.Add(this.navbtn_res);
            this.pnl_nav.Location = new System.Drawing.Point(10, 5);
            this.pnl_nav.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_nav.Name = "pnl_nav";
            this.pnl_nav.Size = new System.Drawing.Size(1255, 91);
            this.pnl_nav.TabIndex = 0;
            // 
            // navbtn_ovrvw
            // 
            this.navbtn_ovrvw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.navbtn_ovrvw.FlatAppearance.BorderSize = 0;
            this.navbtn_ovrvw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtn_ovrvw.Location = new System.Drawing.Point(2, 3);
            this.navbtn_ovrvw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtn_ovrvw.Name = "navbtn_ovrvw";
            this.navbtn_ovrvw.Size = new System.Drawing.Size(160, 91);
            this.navbtn_ovrvw.TabIndex = 0;
            this.navbtn_ovrvw.Text = " Overview";
            this.navbtn_ovrvw.UseVisualStyleBackColor = false;
            this.navbtn_ovrvw.Click += new System.EventHandler(this.navbtn_ovrvw_Click);
            // 
            // navbtn_trx
            // 
            this.navbtn_trx.BackColor = System.Drawing.Color.LightGray;
            this.navbtn_trx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtn_trx.Location = new System.Drawing.Point(166, 3);
            this.navbtn_trx.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtn_trx.Name = "navbtn_trx";
            this.navbtn_trx.Size = new System.Drawing.Size(160, 91);
            this.navbtn_trx.TabIndex = 1;
            this.navbtn_trx.Text = " Transactions";
            this.navbtn_trx.UseVisualStyleBackColor = false;
            // 
            // navbtn_partners
            // 
            this.navbtn_partners.BackColor = System.Drawing.Color.LightGray;
            this.navbtn_partners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtn_partners.Location = new System.Drawing.Point(330, 3);
            this.navbtn_partners.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtn_partners.Name = "navbtn_partners";
            this.navbtn_partners.Size = new System.Drawing.Size(160, 91);
            this.navbtn_partners.TabIndex = 2;
            this.navbtn_partners.Text = " Partners";
            this.navbtn_partners.UseVisualStyleBackColor = false;
            // 
            // navbtn_budget
            // 
            this.navbtn_budget.BackColor = System.Drawing.Color.LightGray;
            this.navbtn_budget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtn_budget.Location = new System.Drawing.Point(494, 3);
            this.navbtn_budget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtn_budget.Name = "navbtn_budget";
            this.navbtn_budget.Size = new System.Drawing.Size(160, 91);
            this.navbtn_budget.TabIndex = 3;
            this.navbtn_budget.Text = " Budgets";
            this.navbtn_budget.UseVisualStyleBackColor = false;
            // 
            // navbtn_acc
            // 
            this.navbtn_acc.BackColor = System.Drawing.Color.LightGray;
            this.navbtn_acc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtn_acc.Location = new System.Drawing.Point(658, 3);
            this.navbtn_acc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtn_acc.Name = "navbtn_acc";
            this.navbtn_acc.Size = new System.Drawing.Size(160, 91);
            this.navbtn_acc.TabIndex = 4;
            this.navbtn_acc.Text = " Accounts";
            this.navbtn_acc.UseVisualStyleBackColor = false;
            this.navbtn_acc.Click += new System.EventHandler(this.navbtn_acc_Click);
            // 
            // navtbn_inv
            // 
            this.navtbn_inv.BackColor = System.Drawing.Color.LightGray;
            this.navtbn_inv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navtbn_inv.Location = new System.Drawing.Point(822, 3);
            this.navtbn_inv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navtbn_inv.Name = "navtbn_inv";
            this.navtbn_inv.Size = new System.Drawing.Size(160, 91);
            this.navtbn_inv.TabIndex = 5;
            this.navtbn_inv.Text = " Investments";
            this.navtbn_inv.UseVisualStyleBackColor = false;
            // 
            // navbtn_res
            // 
            this.navbtn_res.BackColor = System.Drawing.Color.LightGray;
            this.navbtn_res.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navbtn_res.Location = new System.Drawing.Point(986, 3);
            this.navbtn_res.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.navbtn_res.Name = "navbtn_res";
            this.navbtn_res.Size = new System.Drawing.Size(160, 91);
            this.navbtn_res.TabIndex = 6;
            this.navbtn_res.Text = " ";
            this.navbtn_res.UseVisualStyleBackColor = false;
            // 
            // pnl_acc
            // 
            this.pnl_acc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_acc.Controls.Add(this.btnAccUpdate);
            this.pnl_acc.Controls.Add(this.comboAccType);
            this.pnl_acc.Controls.Add(this.txtAccBalance);
            this.pnl_acc.Controls.Add(this.txtAccBic);
            this.pnl_acc.Controls.Add(this.txtAccIban);
            this.pnl_acc.Controls.Add(this.txtAccName);
            this.pnl_acc.Controls.Add(this.lblAccName);
            this.pnl_acc.Controls.Add(this.lblAccBalance);
            this.pnl_acc.Controls.Add(this.lblAccIban);
            this.pnl_acc.Controls.Add(this.btnAccAdd);
            this.pnl_acc.Controls.Add(this.lblAccType);
            this.pnl_acc.Controls.Add(this.btnAccStmtAdd);
            this.pnl_acc.Controls.Add(this.lblAccBic);
            this.pnl_acc.Controls.Add(this.dgv_accounts);
            this.pnl_acc.Location = new System.Drawing.Point(11, 89);
            this.pnl_acc.Name = "pnl_acc";
            this.pnl_acc.Size = new System.Drawing.Size(1255, 595);
            this.pnl_acc.TabIndex = 1;
            // 
            // btnAccUpdate
            // 
            this.btnAccUpdate.Location = new System.Drawing.Point(785, 429);
            this.btnAccUpdate.Name = "btnAccUpdate";
            this.btnAccUpdate.Size = new System.Drawing.Size(166, 57);
            this.btnAccUpdate.TabIndex = 14;
            this.btnAccUpdate.Text = "ADD ACCOUNT";
            this.btnAccUpdate.UseVisualStyleBackColor = true;
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
            // btnAccStmtAdd
            // 
            this.btnAccStmtAdd.Location = new System.Drawing.Point(957, 429);
            this.btnAccStmtAdd.Name = "btnAccStmtAdd";
            this.btnAccStmtAdd.Size = new System.Drawing.Size(166, 57);
            this.btnAccStmtAdd.TabIndex = 2;
            this.btnAccStmtAdd.Text = "ADD STATEMENT";
            this.btnAccStmtAdd.UseVisualStyleBackColor = true;
            this.btnAccStmtAdd.Click += new System.EventHandler(this.btn_add_stmt_Click);
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
            // dgv_accounts
            // 
            this.dgv_accounts.AllowUserToAddRows = false;
            this.dgv_accounts.AllowUserToDeleteRows = false;
            this.dgv_accounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_accounts.Location = new System.Drawing.Point(21, 19);
            this.dgv_accounts.Name = "dgv_accounts";
            this.dgv_accounts.ReadOnly = true;
            this.dgv_accounts.RowTemplate.Height = 29;
            this.dgv_accounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_accounts.Size = new System.Drawing.Size(632, 555);
            this.dgv_accounts.TabIndex = 0;
            // 
            // pnl_ovrvw
            // 
            this.pnl_ovrvw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_ovrvw.Location = new System.Drawing.Point(11, 89);
            this.pnl_ovrvw.Name = "pnl_ovrvw";
            this.pnl_ovrvw.Size = new System.Drawing.Size(1255, 595);
            this.pnl_ovrvw.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1285, 691);
            this.Controls.Add(this.pnl_nav);
            this.Controls.Add(this.pnl_acc);
            this.Controls.Add(this.pnl_ovrvw);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnl_nav.ResumeLayout(false);
            this.pnl_acc.ResumeLayout(false);
            this.pnl_acc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_accounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel pnl_nav;
        private Button navbtn_ovrvw;
        private Button navbtn_trx;
        private Button navbtn_partners;
        private Button navbtn_budget;
        private Button navbtn_acc;
        private Button navtbn_inv;
        private Button navbtn_res;
        private Panel pnl_acc;
        private Panel pnl_ovrvw;
        private Button btnAccStmtAdd;
        private DataGridView dgv_accounts;
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
    }
}