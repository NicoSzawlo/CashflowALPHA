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
            DataSet dt = await Task.Run(() => mySqlHandler.Select("*", "tab_accounts", "acc_name", "Sparkasse"));
            Account accentry = new Account();
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
