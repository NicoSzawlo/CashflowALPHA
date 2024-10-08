﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using HelperLibrary.Services;

namespace HelperLibrary.DataLayer
{
    public class TransactionType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }

        public static TransactionType GetObjectDb(string name)
        {
            TransactionType trxtype = new TransactionType();
            DataTable trxtypedt = MySqlHandler.Select("*", "tab_trxtypes", "trxtype_name", name);
            DataRow row = trxtypedt.Rows[0];

            try
            {
                trxtype.ID = int.Parse(row["trxtype_id"].ToString());
                trxtype.Name = row["trxtype_name"].ToString();
                trxtype.Budget = decimal.Parse(row["trxtype_budget"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return trxtype;
        }
        public static List<TransactionType> GetObjectListDbSync()
        {
            List<TransactionType> list = new List<TransactionType>();
            DataTable trxtypedt = MySqlHandler.SelectOrderBySync("*", "tab_trxtypes", "trxtype_id");
            try
            {
                foreach (DataRow dr in trxtypedt.Rows)
                {
                    list.Add(new TransactionType
                    {
                        ID = int.Parse(dr["trxtype_id"].ToString()),
                        Name = dr["trxtype_name"].ToString(),
                        Budget = decimal.Parse(dr["trxtype_budget"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public static int GetObjectId(string name)
        {
            TransactionType trxtype = GetObjectDb(name);
            int id = (int)trxtype.ID;
            return id;
        }
        public static void InsertObjectDb(TransactionType trxtype)
        {
            MySqlHandler.InsertIntoTrxTypes(trxtype);
        }
    }
}
