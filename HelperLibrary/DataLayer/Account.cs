using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperLibrary.Services;

namespace HelperLibrary.DataLayer
{
    public class Account
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public int? TypeID { get; set; }
        public decimal? Balance { get; set; }

        //Function to load mysqldata into Object
        // + 1 Overload to load from ID
        public static Account GetObjectDb(string name)
        {
            Account acc = new Account();
            DataTable acctypedt = MySqlHandler.Select("*", "tab_accounts", "acc_name", name);
            DataRow row = acctypedt.Rows[0];

            try
            {
                acc.ID = int.Parse(row["acc_id"].ToString());
                acc.Name = row["acc_name"].ToString();
                acc.Iban = row["acc_iban"].ToString();
                acc.Bic = row["acc_bic"].ToString();
                acc.TypeID = int.Parse(row["acc_acctype_id"].ToString());
                acc.Balance = decimal.Parse(row["acc_balance"].ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return acc;
        }
        //Overload 1: Load entry from ID
        public static Account GetObjectDb(int? id)
        {
            Account acc = new Account();
            DataTable acctypedt = MySqlHandler.Select("*", "tab_accounts", "acc_id", id.ToString());
            DataRow row = acctypedt.Rows[0];

            try
            {
                acc.ID = int.Parse(row["acc_id"].ToString());
                acc.Name = row["acc_name"].ToString();
                acc.Iban = row["acc_iban"].ToString();
                acc.Bic = row["acc_bic"].ToString();
                acc.TypeID = int.Parse(row["acc_acctype_id"].ToString());
                acc.Balance = decimal.Parse(row["acc_balance"].ToString());
            }
            catch (Exception ex)
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
                        TypeID = int.Parse(dr["acc_acctype_id" ].ToString()), 
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

        public static int GetObjectId(string name)
        {
            Account account = GetObjectDb(name);
            int id = (int)account.ID;
            return id;
        }

        //Method for updating Account in database
        public static async void UpdateObjectAsync(Account acc)
        {
            await Task.Run(() => MySqlHandler.UpdateAccount(acc));
        }

        public static decimal GetNetworth()
        {
            decimal networth = 0;
            DataTable accdt = MySqlHandler.SelectOrderBySync("*", "tab_accounts","acc_id");
            foreach (DataRow dr in accdt.Rows)
            {
                networth += decimal.Parse(dr["acc_balance"].ToString());
            }
            return networth;
        }
    }
}
