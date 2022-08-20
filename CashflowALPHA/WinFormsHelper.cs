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
        private CsvProcessor csvProcessor = new CsvProcessor();
        private MySqlHandler mySqlHandler = new MySqlHandler();
        public string OpenFD( string initDir, string filter)
        {
            string filepath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initDir;
            ofd.Filter = filter;
            ofd.ShowDialog();
            filepath = ofd.FileName;

            csvProcessor.CsvToTable(filepath);

            return filepath;
        }

        public async void LoadAccTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => mySqlHandler.Select("*", "view_accounts"));
            dgv.DataSource = dt;
        }

        public async void LoadAccEntryAsync(TextBox name, TextBox iban, TextBox bic, ComboBox type, TextBox balance)
        {
            DataTable accdt = await Task.Run(() => mySqlHandler.Select("*", "tab_accounts", "acc_name", "Sparkasse"));
            Account accentry = new Account();
            accentry.GetValuesFromTable(accdt.Rows[0]);

            name.Text = accentry.Name;
            iban.Text = accentry.Iban;
            bic.Text = accentry.Bic;

            DataTable acctypedt = await Task.Run(() => mySqlHandler.Select("*", "tab_acctypes"));
            List<AccountType> typelist = new List<AccountType>();
            for (int i = 0; i < acctypedt.Rows.Count; i++)
            {
                DataRow row = acctypedt.Rows[i];
                //typelist.Add()
            }
            balance.Text = accentry.Balance.ToString();
        }

        public async Task InsertAccAsync()
        {
            List<Task> tasks = new List<Task>();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(Task.Run(() => mySqlHandler.InsertIntoAccount(i.ToString(), "test", "Test", 1)));
            }
            await Task.WhenAll(tasks);
            watch.Stop();
            Debug.WriteLine("Duration was:");
            Debug.WriteLine(watch.ElapsedMilliseconds);
        }

    }
}
