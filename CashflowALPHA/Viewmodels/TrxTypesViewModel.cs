using HelperLibrary;
using HelperLibrary.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowALPHA.Viewmodels
{
    public class TrxTypesViewModel
    {
        //Loads content of Transactiontypes for the Budget setting page
        public static async void LoadTrxTypeTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => MySqlHandler.Select("*", "view_trxtypes"));
            dgv.DataSource = dt;
        }

        public static void InsertTrxType(string name, decimal budget)
        {
            TransactionType trxtype = new TransactionType { Name = name, Budget = budget};
            MySqlHandler.InsertIntoTrxTypes(trxtype);
        }
    }
}
