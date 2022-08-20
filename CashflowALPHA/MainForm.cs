
namespace CashflowALPHA
{
    public partial class MainForm : Form
    {

        WinFormsHelper winFormsHelper = new WinFormsHelper();
        public MainForm()
        {
            InitializeComponent();
            startupAcc();
        }

        //Navigation buttons
        //##############################
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

        //############################################################
        //PAGES
        //############################################################

        //ACCOUNTS PANEL
        //##############################
        private void btn_add_stmt_Click(object sender, EventArgs e)
        {
            
            winFormsHelper.OpenFD("F:\\Nicos Dateien\\Finanzen\\Kontoauszüge", "csv files (*.csv)|*.csv|All files (*.*)|*.*");
        }
        private void btnAccUpdate_Click(object sender, EventArgs e)
        {
            winFormsHelper.LoadAccEntryAsync(txtAccName, txtAccIban, txtAccBic, comboAccType, txtAccBalance);
        }

        private void btnAccAdd_Click(object sender, EventArgs e)
        {

        }
        //Init routine for accounts panel
        private void startupAcc()
        {
            winFormsHelper.LoadAccTableAsync(dgv_accounts);

        }

        //OVERVIEW PANEL
        //##############################



        //UI Helper functions
        //##############################
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}