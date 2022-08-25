
using CashflowALPHA.Viewmodels;
using HelperLibrary.DataLayer;
using System.Globalization;
using System.Xml.Linq;

namespace CashflowALPHA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        //Navigation buttons
        //##############################
        private void navbtnOvrvw_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtnOvrvw.BackColor = Color.WhiteSmoke;
            this.pnlOvrvw.BringToFront();
        }

        private void navbtnAcc_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtnAcc.BackColor = Color.WhiteSmoke;
            this.pnlAcc.BringToFront();
        }

        private void navbtnPartners_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtnPartners.BackColor = Color.WhiteSmoke;
            this.pnlPartners.BringToFront();
        }
        private void navbtnBudget_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtnBudget.BackColor = Color.WhiteSmoke;
            this.pnlBudgets.BringToFront();
        }
        private void navbtnTrx_Click(object sender, EventArgs e)
        {
            ResetNavbtnBackColor();
            this.navbtnTrx.BackColor = Color.WhiteSmoke;
            this.pnlTrx.BringToFront();
        }

        //############################################################
        //PAGES
        //############################################################

        //ACCOUNTS PANEL
        //##############################
        private void btnAccAddStmt_Click(object sender, EventArgs e)
        {
            
            AccountsViewModel.OpenFD("F:\\Nicos Dateien\\Finanzen\\Kontoauszüge", "csv files (*.csv)|*.csv|All files (*.*)|*.*", dgvAccounts.CurrentRow.Cells[0].Value.ToString());
        }
        private void btnAccUpdate_Click(object sender, EventArgs e)
        {
            AccountsViewModel.UpdateAccEntry(txtAccName.Text, txtAccIban.Text, txtAccBic.Text, comboAccType.Text, Decimal.Parse(txtAccBalance.Text));
        }

        private void btnAccAdd_Click(object sender, EventArgs e)
        {

        }
        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvAccounts.CurrentRow != null)
            {

                string name = dgvAccounts.CurrentRow.Cells[0].Value.ToString();
                AccountsViewModel.LoadAccEntryAsync(txtAccName, txtAccIban, txtAccBic, comboAccType, txtAccBalance, name);
            }
            
        }
        //Init routine for accounts panel
        private void Startup()
        {
            AccountsViewModel.LoadAccTableAsync(dgvAccounts);
            PartnersViewModel.LoadPartnersTableAsync(dgvPartners);
            PartnersViewModel.LoadTrxTypeTableAsync(dgvPartnerTypes);
            TrxTypesViewModel.LoadTrxTypeTableAsync(dgvTransactionTypes);
            TransactionsViewModel.LoadTrxTableAsync(dgvTrx);
        }

        //OVERVIEW PANEL
        //##############################

        //TRANSACTIONTYPES PANEL
        //##############################
        private void btnAddTrxType_Click(object sender, EventArgs e)
        {
            TrxTypesViewModel.InsertTrxType(txtTryTypeName.Text, decimal.Parse(txtTrxTypeBudget.Text));
            TrxTypesViewModel.LoadTrxTypeTableAsync(dgvTransactionTypes);
        }
        //PARTNERS PANEL
        //##############################
        private void btnSetPartnType_Click(object sender, EventArgs e)
        {
            PartnersViewModel.SetPartnerTrxTypeAsync(dgvPartners.CurrentRow.Cells[1].Value.ToString(), dgvPartnerTypes.CurrentRow.Cells[0].Value.ToString());
        }


        //TRANSACTIONS PANEL
        //##############################


        //UI Helper functions
        //##############################
        private void ResetNavbtnBackColor()
        {
            this.navbtnAcc.BackColor = Color.LightGray;
            this.navbtnBudget.BackColor = Color.LightGray;
            this.navbtnOvrvw.BackColor = Color.LightGray;
            this.navbtnPartners.BackColor = Color.LightGray;
            this.navbtnTrx.BackColor = Color.LightGray;            
            this.navtbnInv.BackColor = Color.LightGray;
            this.navbtnSpare.BackColor = Color.LightGray;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Startup();
        }

        





        //Temp testing area
    }
}