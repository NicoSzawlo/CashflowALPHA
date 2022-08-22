using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
        int? PartnerID  { get; set; }
        int? AccountID { get; set; }
        int? TypeID { get; set; }
        int? InvPosID { get; set; }

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
        public static async Task<List<Transaction>> GetObjectListDbAsync()
        {
            List<Transaction> list = new List<Transaction>();
            DataTable trxdt = await Task.Run(() => MySqlHandler.Select("*", "tab_trx"));
            list = await Task.Run(() => DbToList(trxdt));

            return list;
        }

        public static async Task<List<Transaction>> GetObjectListStmtAsync(DataTable stmt)
        {
            List<Transaction> list = await Task.Run(() => FileToListAsync(stmt));
            return list;
        }

        //Adding all george statement transaction entries of file and get partner ID from db
        //Also check for transaction type of partner and add if already set
        private async static Task<List<Transaction>> FileToListAsync(DataTable stmt)
        {
            List<Transaction> list = new List<Transaction>();
            foreach (DataRow dr in stmt.Rows)
            {

                Partner partn = null;
                partn = await Task.Run(() => Partner.GetObjectDbAsync(dr["Partner Name"].ToString()));
                if(partn.UsualTrxType == null)
                {
                    list.Add(new Transaction
                    {
                        Date = DateTime.Parse(dr["Booking Date"].ToString()),
                        Amount = decimal.Parse(dr["Amount"].ToString()),
                        Currency = dr["Currency"].ToString(),
                        Info = dr["Booking Info"].ToString(),
                        Reference = dr["Booking Reference"].ToString(),
                        PartnerID = partn.ID
                    });
                }
                else
                {
                    list.Add(new Transaction
                    {
                        Date = DateTime.Parse(dr["Booking Date"].ToString()),
                        Amount = decimal.Parse(dr["Amount"].ToString()),
                        Currency = dr["Currency"].ToString(),
                        Info = dr["Booking Info"].ToString(),
                        Reference = dr["Booking Reference"].ToString(),
                        PartnerID = partn.ID,
                        TypeID = partn.UsualTrxType
                    });
                }
                
            }
            return list;
        }

        //Adding all database entries to objectlist
        private static List<Transaction> DbToList(DataTable db)
        {
            List<Transaction> list = new List<Transaction>();
            foreach (DataRow dr in db.Rows)
            {
                list.Add(new Transaction
                {
                    ID = int.Parse(dr["trx_id"].ToString()),
                    Date = DateTime.Parse(dr["trx_name"].ToString()),
                    Amount = decimal.Parse(dr["trx_iban"].ToString()),
                    Currency = dr["trx_bic"].ToString(),
                    Info = dr["trx_balance"].ToString(),
                    Reference = dr["trx_acctype_id"].ToString(),
                    PartnerID = int.Parse(dr["trx_id"].ToString()),
                    AccountID = int.Parse(dr["trx_id"].ToString()),
                    TypeID = int.Parse(dr["trx_id"].ToString()),
                    InvPosID = int.Parse(dr["trx_id"].ToString()),
                });
            }
            return list;
        }
    }
}
