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
    public class PartnersViewModel
    {
        public static async void LoadPartnersTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => MySqlHandler.Select("*", "view_partners"));
            dgv.DataSource = dt;
        }

        public static async void LoadTrxTypeTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => MySqlHandler.Select("*", "view_trxtypes"));
            dgv.DataSource = dt;
        }

        public static void SetPartnerTrxTypeAsync(string partnername, string trxtypename)
        {
            Partner partn = Partner.GetObjectDb(partnername);
            int trxtypeid = TransactionType.GetObjectId(trxtypename);

            partn.TypeID = trxtypeid;

            Partner.UpdateObjectAsync(partn);
        }
    }
}
