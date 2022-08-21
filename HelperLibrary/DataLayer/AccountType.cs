﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class AccountType
    {
        public int? ID { get; set; }
        public string? Name { get; set; }

        public static async Task<AccountType> GetObjectAsync(string name)
        {
            AccountType accountType = new AccountType();
            MySqlHandler mySqlHandler = new MySqlHandler();
            DataTable acctypedt = await Task.Run(() => mySqlHandler.Select("*", "tab_acctypes", "acctype_name", name));
            DataRow row = acctypedt.Rows[0];
            try
            {
                accountType.ID = int.Parse(row["acctype_id"].ToString());
                accountType.Name = row["acctype_name"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return accountType;

        }
        public static async Task<List<AccountType>> GetObjectListAsync()
        {
            List<AccountType> list = new List<AccountType>();
            MySqlHandler mySqlHandler = new MySqlHandler();
            DataTable acctypedt = await Task.Run(() => mySqlHandler.Select("*", "tab_acctypes"));
            try
            {
                foreach (DataRow dr in acctypedt.Rows)
                {
                    list.Add(new AccountType { ID = int.Parse(dr["acctype_id"].ToString()), Name = dr["acctype_name"].ToString() });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return list;
        }
    }
}
