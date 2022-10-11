using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperLibrary;
using HelperLibrary.DataLayer;

namespace CashflowALPHA
{
    public class AccountsViewModel
    {
        //Opens file dialog and reads file
        public static async void OpenFD( string initDir, string filter, string accname)
        {
            string filepath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initDir;
            ofd.Filter = filter;
            ofd.ShowDialog();
            filepath = ofd.FileName;

            await Task.Run(() => ProcessStmtFile(filepath, accname));
            
        }

        //Loads content for accounts panel datagridview from mysql view_ac
        public static async void LoadAccTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => MySqlHandler.Select("*", "view_accounts"));
            dgv.DataSource = dt;
        }

        //Loads Account table entry for Textboxes to add/edit accounts
        public static async void LoadAccEntryAsync(TextBox name, TextBox iban, TextBox bic, ComboBox type, TextBox balance, string accountname)
        {

            //Load Account table and select single account
            Account accentry = await Task.Run(() => Account.GetObjectDb(accountname));
            List<AccountType> typelist = await Task.Run(() => AccountType.GetObjectListDbAsync());

            //Set Textbox info for account
            name.Text = accentry.Name;
            iban.Text = accentry.Iban;
            bic.Text = accentry.Bic;
            balance.Text = accentry.Balance.ToString();
            foreach(AccountType acctype in typelist)
            {
                if(acctype.ID == accentry.TypeID)
                {
                    type.Text = acctype.Name;
                }
            }
            InitAccTypeCombobox(type);


        }
        
        //Adding a new account into the database
        public static void AddAccEntry(string name, string iban, string bic, string type, decimal balance)
        {
            AccountType acctype = AccountType.GetObjectDb(type);
            Account acc = new Account
            {
                Name = name,
                Iban = iban,
                Bic = bic,
                TypeID = acctype.ID,
                Balance = balance
            };
            MySqlHandler.InsertIntoAccount(acc);
        }

        //Updates account in db with data from textboxes
        public static void UpdateAccEntry(string name, string iban, string bic, string type, decimal balance)
        {
            int accid = Account.GetObjectId(name);
            int acctypeid = AccountType.GetObjectId(type);

            Account acc = new Account
            {
                ID = accid,
                Name = name,
                Iban = iban,
                Bic = bic,
                TypeID = acctypeid,
                Balance = balance
            };
            Account.UpdateObjectAsync(acc);
        }

        //Method for processing statement file asynchronously
        private static async Task ProcessStmtFile(string filepath, string accname)
        {
            DataTable dt = CsvProcessor.CsvToTable(filepath);
            
            //Get distinct partners of csv file
            List<Partner> partners = Partner.GetObjectListStmtAsync(dt);
            List<Partner> distpartners = Partner.GetDistinctObjectList(partners);
            //Insert partner into db
            Partner.InsertObjectListDbAsync(distpartners);

            //Load list of trx
            List<Transaction> trx = Transaction.GetObjectListStmt(dt, accname);

            //Check if there are already trx linked to selected acc
            Account acc = Account.GetObjectDb(accname);
            if(await Task.Run(() => Transaction.CheckTrxForAcc(acc)))
            {
                //Placeholder for recalculating account value after adding transactions
            }

            
            await Task.Run(() => Transaction.InsertObjectListDbAsync(trx, accname));
        }

        public static async void InitAccTypeCombobox(ComboBox type)
        {
            //Load Account type Table for Combobox
            List<AccountType> typelist = await Task.Run(() => AccountType.GetObjectListDbAsync());

            //Check if combobox empty
            if (type.Items.Count == 0)
            {
                //Add Account type list to Combobox and set current type
                foreach (AccountType acctype in typelist)
                {
                    type.Items.Add(acctype.Name);
                }
            }
        }

        public static decimal CalcAccValueDifference(List<Transaction> trxlist)
        {
            decimal difference = 0;

            foreach(Transaction trx in trxlist)
            {
                difference = (decimal)trx.Amount + difference;
            }

            return difference;
        }
    }
}
