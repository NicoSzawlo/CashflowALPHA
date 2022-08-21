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
    public class WinFormsHelper
    {
        //Calling instances of other handling classes
        private CsvProcessor csvProcessor = new CsvProcessor();

        //Opens file dialog and reads file
        public string OpenFD( string initDir, string filter)
        {
            string filepath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initDir;
            ofd.Filter = filter;
            ofd.ShowDialog();
            filepath = ofd.FileName;

            CsvProcessor.CsvToTable(filepath);

            return filepath;
        }

        //Loads content for accounts panel datagridview from mysql view_ac
        public async void LoadAccTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => MySqlHandler.Select("*", "view_accounts"));
            dgv.DataSource = dt;
        }

        //Loads Account table entry for Textboxes to add/edit accounts
        public async void LoadAccEntryAsync(TextBox name, TextBox iban, TextBox bic, ComboBox type, TextBox balance)
        {

            //Load Account table and select single account
            Account accentry = await Task.Run(() => Account.GetObjectDbAsync("Sparkasse"));
            //Load Account type Table for Combobox
            List<AccountType> typelist = await Task.Run(() => AccountType.GetObjectListDbAsync());

            //Set Textbox info for account
            name.Text = accentry.Name;
            iban.Text = accentry.Iban;
            bic.Text = accentry.Bic;
            balance.Text = accentry.Balance.ToString();
            //Add Account type list to Combobox and set current type
            foreach(var item in typelist){
                type.Items.Add(item.Name);
                if(item.ID == accentry.Type)
                {
                    type.Text = item.Name;
                }
            }
            
        }
        //Inserts an Account asynchronous
        public async Task InsertAccAsync()
        {
            //List<Task> tasks = new List<Task>();
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //for (int i = 0; i < 1000; i++)
            //{
            //    tasks.Add(Task.Run(() => mySqlHandler.InsertIntoAccount(i.ToString(), "test", "Test", 1)));
            //}
            //await Task.WhenAll(tasks);
            //watch.Stop();
            //Debug.WriteLine("Duration was:");
            //Debug.WriteLine(watch.ElapsedMilliseconds);
        }

    }
}
