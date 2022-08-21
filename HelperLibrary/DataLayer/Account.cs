using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class Account
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public int? Type { get; set; }
        public decimal? Balance { get; set; }

        //Function to asynchronously load mysqldata into Object
        public static async Task<Account> GetObjectDbAsync(string name)
        {
            Account acc = new Account();
            DataTable acctypedt = await Task.Run(() => MySqlHandler.Select("*", "tab_accounts", "acc_name", name));
            DataRow row = acctypedt.Rows[0];

            try
            {
                acc.ID = int.Parse(row["acc_id"].ToString());
                acc.Name = row["acc_name"].ToString();
                acc.Iban = row["acc_iban"].ToString();
                acc.Bic = row["acc_bic"].ToString();
                acc.Type = int.Parse(row["acc_acctype_id"].ToString());
                acc.Balance = decimal.Parse(row["acc_balance"].ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return acc;
        }
        //Function to asynchronously load mysql data into object list
        public static async Task<List<Account>> GetObjectListDbAsync()
        {
            List<Account> list = new List<Account>();
            DataTable acctypedt = await Task.Run(() => MySqlHandler.Select("*", "tab_accounts"));
            try
            {
                foreach (DataRow dr in acctypedt.Rows)
                {
                    list.Add(new Account { 
                        ID = int.Parse(dr["acc_id"].ToString()), 
                        Name = dr["acc_name"].ToString(), 
                        Iban = dr["acc_iban"].ToString(), 
                        Bic = dr["acc_bic"].ToString(), 
                        Type = int.Parse(dr["acc_acctype_id" ].ToString()), 
                        Balance = decimal.Parse(dr["acc_balance"].ToString()) 
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }
    }
}
