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
            this.btn_add_stmt = new System.Windows.Forms.Button();
            this.btn_add_acc = new System.Windows.Forms.Button();
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
            this.pnl_nav.Location = new System.Drawing.Point(10, 6);
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
            this.navbtn_ovrvw.Location = new System.Drawing.Point(2, 2);
            this.navbtn_ovrvw.Margin = new System.Windows.Forms.Padding(2);
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
            this.navbtn_trx.Location = new System.Drawing.Point(166, 2);
            this.navbtn_trx.Margin = new System.Windows.Forms.Padding(2);
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
            this.navbtn_partners.Location = new System.Drawing.Point(330, 2);
            this.navbtn_partners.Margin = new System.Windows.Forms.Padding(2);
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
            this.navbtn_budget.Location = new System.Drawing.Point(494, 2);
            this.navbtn_budget.Margin = new System.Windows.Forms.Padding(2);
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
            this.navbtn_acc.Location = new System.Drawing.Point(658, 2);
            this.navbtn_acc.Margin = new System.Windows.Forms.Padding(2);
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
            this.navtbn_inv.Location = new System.Drawing.Point(822, 2);
            this.navtbn_inv.Margin = new System.Windows.Forms.Padding(2);
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
            this.navbtn_res.Location = new System.Drawing.Point(986, 2);
            this.navbtn_res.Margin = new System.Windows.Forms.Padding(2);
            this.navbtn_res.Name = "navbtn_res";
            this.navbtn_res.Size = new System.Drawing.Size(160, 91);
            this.navbtn_res.TabIndex = 6;
            this.navbtn_res.Text = " ";
            this.navbtn_res.UseVisualStyleBackColor = false;
            // 
            // pnl_acc
            // 
            this.pnl_acc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_acc.Controls.Add(this.btn_add_stmt);
            this.pnl_acc.Controls.Add(this.btn_add_acc);
            this.pnl_acc.Controls.Add(this.dgv_accounts);
            this.pnl_acc.Location = new System.Drawing.Point(12, 89);
            this.pnl_acc.Name = "pnl_acc";
            this.pnl_acc.Size = new System.Drawing.Size(1255, 595);
            this.pnl_acc.TabIndex = 1;
            // 
            // btn_add_stmt
            // 
            this.btn_add_stmt.Location = new System.Drawing.Point(1069, 455);
            this.btn_add_stmt.Name = "btn_add_stmt";
            this.btn_add_stmt.Size = new System.Drawing.Size(166, 57);
            this.btn_add_stmt.TabIndex = 2;
            this.btn_add_stmt.Text = "ADD STATEMENT";
            this.btn_add_stmt.UseVisualStyleBackColor = true;
            this.btn_add_stmt.Click += new System.EventHandler(this.btn_add_stmt_Click);
            // 
            // btn_add_acc
            // 
            this.btn_add_acc.Location = new System.Drawing.Point(1069, 518);
            this.btn_add_acc.Name = "btn_add_acc";
            this.btn_add_acc.Size = new System.Drawing.Size(166, 57);
            this.btn_add_acc.TabIndex = 1;
            this.btn_add_acc.Text = "ADD ACCOUNT";
            this.btn_add_acc.UseVisualStyleBackColor = true;
            this.btn_add_acc.Click += new System.EventHandler(this.btn_add_acc_Click);
            // 
            // dgv_accounts
            // 
            this.dgv_accounts.AllowUserToAddRows = false;
            this.dgv_accounts.AllowUserToDeleteRows = false;
            this.dgv_accounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_accounts.Location = new System.Drawing.Point(20, 20);
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
            this.pnl_ovrvw.Location = new System.Drawing.Point(12, 89);
            this.pnl_ovrvw.Name = "pnl_ovrvw";
            this.pnl_ovrvw.Size = new System.Drawing.Size(1255, 595);
            this.pnl_ovrvw.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1284, 690);
            this.Controls.Add(this.pnl_acc);
            this.Controls.Add(this.pnl_nav);
            this.Controls.Add(this.pnl_ovrvw);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.pnl_nav.ResumeLayout(false);
            this.pnl_acc.ResumeLayout(false);
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
        private Button btn_add_stmt;
        private Button btn_add_acc;
        private DataGridView dgv_accounts;
    }
}