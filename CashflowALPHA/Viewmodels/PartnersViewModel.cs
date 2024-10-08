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

        public static async void SetPartnerTrxType(List<string> partnernames, string trxtypename)
        {
            List<Partner> partners = new List<Partner>();
            Partner partn = new Partner();
            foreach (string partnername in partnernames)
            {
                partn = Partner.GetObjectDb(partnername);
                int trxtypeid = TransactionType.GetObjectId(trxtypename);
                partn.TypeID = trxtypeid;
                partners.Add(partn);
                
            }
            Partner.UpdateObjectListAsync(partners);
            await Task.Run(() => SetTrxTypes());
        }

        public static List<string> GetSelectedNames(DataGridView dgv)
        {
            List<string> selectedNames = new List<string>();
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                selectedNames.Add(row.Cells[1].Value.ToString());
            }
            return selectedNames;

        }

        private static async void SetTrxTypes()
        {
            List<Partner> partners = await Task.Run(() => Partner.GetObjectListDbAsync());
            List<Transaction> trxlist = new List<Transaction>();
            foreach (Partner partner in partners)
            {
                trxlist.Clear();
                if(partner.TypeID != null)
                {
                    trxlist = await Transaction.GetObjectListForPartnerDb(partner);
                    foreach(Transaction trx in trxlist)
                    {
                        if (trx.TypeID == null)
                        {
                            trx.TypeID = partner.TypeID;
                        }
                    }
                    Transaction.UpdateObjectListAsync(trxlist);
                    
                }
            }
        }
    }
}
