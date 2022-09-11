﻿using HelperLibrary;
using HelperLibrary.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowALPHA.Viewmodels
{
    public class TransactionsViewModel
    {
        public static async void LoadTrxTableAsync(DataGridView dgv)
        {
            DataTable dt = await Task.Run(() => MySqlHandler.Select("*", "view_trx"));
            dgv.DataSource = dt;
        }

        //Load transaction entry into Textboxes for detailed information
        public static async void LoadTrxEntryAsync(TextBox date, TextBox account, TextBox amount, TextBox partner, /*TextBox invpos,*/ TextBox info, TextBox reference, ComboBox type, string id)
        {
            //Load transaction entry
            Transaction trx = await Task.Run(() => Transaction.GetObjectDb(id));
            //Load transaction types list
            List<TransactionType> typelist = await TransactionType.GetObjectListDbAsync();
            Partner partn = Partner.GetObjectDb(trx.PartnerID);

            date.Text = trx.Date.ToString();
            account.Text = acc.Name;
            amount.Text = trx.Amount.ToString();
            partner.Text = partn.Name;
            //invpos.Text =
            info.Text = trx.Info;
            reference.Text = trx.Reference;
            foreach(TransactionType trxtype in typelist)
            {
                type.Items.Add(trxtype.Name);
                if(trxtype.ID == trx.TypeID)
                {
                    type.Text = trxtype.Name;
                }
            }
        }
    }
}
