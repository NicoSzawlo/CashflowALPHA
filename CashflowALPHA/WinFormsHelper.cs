using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperLibrary;

namespace CashflowALPHA
{
    public class WinFormsHelper
    {
        private MySqlHandler mySqlHandler;
        public string OpenFD( string initDir, string filter)
        {
            string filepath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initDir;
            ofd.Filter = filter;
            ofd.ShowDialog();
            filepath = ofd.FileName;


            return filepath;
        }

        public async Task<DataTable> LoadTableAsync(DataGridView dgv, string table)
        {
            DataTable dt = await Task.Run(() => mySqlHandler.Select("*", table));
            dgv.DataSource = dt;
            return dt;
        }

        public async Task InsertIntoTableAsync(DataGridView dgv)
        {

        }
            
    }
}
