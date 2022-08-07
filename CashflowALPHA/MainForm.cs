namespace CashflowALPHA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       
    //Windows Forms navigation buttons
        private void navbtn_ovrvw_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtn_ovrvw.BackColor = Color.WhiteSmoke;
            this.pnl_ovrvw.BringToFront();
        }

        private void navbtn_acc_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtn_acc.BackColor = Color.WhiteSmoke;
            this.pnl_acc.BringToFront();
        }

        //UI Helper functions
        private void ResetNavbtnBackColor()
        {
            this.navbtn_acc.BackColor = Color.LightGray;
            this.navbtn_budget.BackColor = Color.LightGray;
            this.navbtn_ovrvw.BackColor = Color.LightGray;
            this.navbtn_partners.BackColor = Color.LightGray;
            this.navbtn_trx.BackColor = Color.LightGray;            
            this.navtbn_inv.BackColor = Color.LightGray;
            this.navbtn_res.BackColor = Color.LightGray;
        }

        
    }
}