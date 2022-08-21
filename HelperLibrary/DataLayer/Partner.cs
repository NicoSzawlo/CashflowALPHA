﻿using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelperLibrary.DataLayer
{
    public class Partner
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public string? Bankcode { get; set; }
        public int? UsualTrxType { get; set; }


        //Function to asynchronously load mysqldata into Object
        public static async Task<Partner> GetObjectDbAsync(string name)
        {
            Partner partn = new Partner();
            DataTable partnerdt = await Task.Run(() => MySqlHandler.Select("*", "tab_partners", "partn_name", name));
            DataRow row = partnerdt.Rows[0];

            try
            {
                partn.ID = int.Parse(row["partn_id"].ToString());
                partn.Name = row["partn_name"].ToString();
                partn.Iban = row["partn_iban"].ToString();
                partn.Bic = row["partn_bic"].ToString();
                partn.Bankcode = row["partn_balance"].ToString();
                partn.UsualTrxType = int.Parse(row["partn_trxtype_id"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return partn;
        }
        //Function to asynchronously load mysql data into object list
        public static async Task<List<Partner>> GetObjectListDbAsync()
        {
            DataTable partnerdt = await Task.Run(() => MySqlHandler.Select("*", "tab_accounts"));
            List<Partner> list = await Task.Run(() => DbToList(partnerdt));

            return list;
        }
        //Function to push objectlist into db
        public static async void InsertObjectListDbAsync(List<Partner> list)
        {
            List<Task> tasks = new List<Task>();
            foreach(Partner partn in list)
            {
                tasks.Add(Task.Run(() => MySqlHandler.InsertIntoPartners(partn)));
            }
            await Task.WhenAll(tasks);
        }


        //Async task extracting all partners from file
        public static async Task<List<Partner>> GetObjectListStmtAsync(DataTable stmt)
        {

            List<Partner> list = await Task.Run(() => FileToList(stmt));
            return list;
        }





        //Method for extracting Distinct Partners
        public static List<Partner> GetDistinctObjectList(List<Partner> inlist)
        {
            List<Partner> outlist = new List<Partner>();
            bool dupe = false;
            foreach(Partner ipartn in inlist)
            {

                if (outlist.Count == 0)
                {
                    outlist.Add(ipartn);
                }
                else
                {
                    foreach (Partner opartn in outlist)
                    {
                        if(opartn.Name == ipartn.Name)
                        {
                            dupe = true;
                            break;
                        }
                    }
                    if (!dupe)
                    {
                        outlist.Add(ipartn);
                    }
                    dupe = false;

                }
            }

            return outlist;
        }







        //Adding all george statement partners to objectlist
        private static List<Partner> FileToList(DataTable stmt)
        {
            List<Partner> list = new List<Partner>();
            foreach (DataRow dr in stmt.Rows)
            {
                list.Add(new Partner
                {
                    Name = dr["Partner Name"].ToString(),
                    Iban = dr["Partner IBAN"].ToString(),
                    Bic = dr["BIC/SWIFT"].ToString(),
                    Bankcode = dr["Bank code"].ToString()
                });
            }
            return list;
        }

        //Adding all database entries to objectlist
        private static List<Partner> DbToList(DataTable db)
        {
            List<Partner> list = new List<Partner>();
            foreach (DataRow dr in db.Rows)
            {
                list.Add(new Partner
                {
                    ID = int.Parse(dr["acc_id"].ToString()),
                    Name = dr["acc_name"].ToString(),
                    Iban = dr["acc_iban"].ToString(),
                    Bic = dr["acc_bic"].ToString(),
                    Bankcode = dr["acc_balance"].ToString(),
                    UsualTrxType = int.Parse(dr["acc_acctype_id"].ToString())
                });
            }
            return list;
        }
    }
}
