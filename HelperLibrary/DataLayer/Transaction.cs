using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelperLibrary.DataLayer
{
    public class Transaction
    {
        int? ID { get; set; }
        DateTime? Date { get; set; }
        decimal? Amount { get; set; }
        string? Currency { get; set; }
        string?  Info { get; set; }
        string? Reference { get; set; }
        int? Partner  { get; set; }
        int? Account { get; set; }
        int? Type { get; set; }
        int? InvPos { get; set; }

        //Function to asynchronously load mysqldata into Object
        //public static async Task<Transaction> GetObjectAsync(string name)
        //{
        //    Partner partn = new Partner();
        //    MySqlHandler mySqlHandler = new MySqlHandler();
        //    DataTable partnerdt = await Task.Run(() => mySqlHandler.Select("*", "tab_partners", "partn_name", name));
        //    DataRow row = partnerdt.Rows[0];

        //    try
        //    {
        //        partn.ID = int.Parse(row["partn_id"].ToString());
        //        partn.Name = row["partn_name"].ToString();
        //        partn.Iban = row["partn_iban"].ToString();
        //        partn.Bic = row["partn_bic"].ToString();
        //        partn.Bankcode = row["partn_balance"].ToString();
        //        partn.UsualTrxType = int.Parse(row["partn_trxtype_id"].ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return partn;
        //}
        //Function to asynchronously load mysql data into object list
        public static async Task<List<Transaction>> GetObjectListAsync()
        {
            List<Transaction> list = new List<Transaction>();
            MySqlHandler mySqlHandler = new MySqlHandler();
            DataTable trxdt = await Task.Run(() => mySqlHandler.Select("*", "tab_trx"));
            try
            {
                foreach (DataRow dr in trxdt.Rows)
                {
                    list.Add(new Transaction
                    {
                        ID = int.Parse(dr["trx_id"].ToString()),
                        Date = DateTime.Parse(dr["trx_name"].ToString()),
                        Amount = decimal.Parse(dr["trx_iban"].ToString()),
                        Currency = dr["trx_bic"].ToString(),
                        Info = dr["trx_balance"].ToString(),
                        Reference = dr["trx_acctype_id"].ToString(),
                        Partner = int.Parse(dr["trx_id"].ToString()),
                        Account = int.Parse(dr["trx_id"].ToString()),
                        Type = int.Parse(dr["trx_id"].ToString()),
                        InvPos = int.Parse(dr["trx_id"].ToString()),
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
