using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HelperLibrary.DataLayer
{
    public class Transaction
    {
        public int? ID { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string?  Info { get; set; }
        public string? Reference { get; set; }
        public int? PartnerID  { get; set; }
        public int? AccountID { get; set; }
        public int? TypeID { get; set; }
        public int? InvPosID { get; set; }
        private const string CashPlaceholder = "_Cash";

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

        public static List<Transaction> GetObjectListStmt(DataTable stmt, string accname)
        {
            Account acc = Account.GetObjectDb(accname);
            List<Transaction> list = FileToList(stmt, acc);
            return list;
        }

        public static async void InsertObjectListDbAsync(List<Transaction> list, string accname)
        {
            Account accentry = Account.GetObjectDb(accname);
            List<Task> tasks = new List<Task>();
            foreach (Transaction trx in list)
            {
                await Task.Run(() => MySqlHandler.InsertIntoTrx(trx));
            }

        }

        //Adding all george statement transaction entries of file and get partner ID from db
        //Also check for transaction type of partner and add if already set
        private static List<Transaction> FileToList(DataTable stmt, Account acc)
        {
            List<Transaction> list = new List<Transaction>();
            

            foreach (DataRow dr in stmt.Rows)
            {
                Partner partn = new Partner();
                if (dr["Partner Name"].ToString() == "")
                {
                    partn = Partner.GetObjectDb(CashPlaceholder);
                }
                else
                {
                    partn = Partner.GetObjectDb(dr["Partner Name"].ToString());
                }

                
                if (partn.TypeID == null)
                {
                    list.Add(new Transaction
                    {
                        Date = DateTime.Parse(dr["Booking Date"].ToString()),
                        Amount = decimal.Parse(dr["Amount"].ToString(), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Currency = dr["Currency"].ToString(),
                        Info = dr["Booking Info"].ToString(),
                        Reference = dr["Booking Reference"].ToString(),
                        AccountID = acc.ID,
                        PartnerID = partn.ID
                    });
                }
                else
                {
                    list.Add(new Transaction
                    {
                        Date = DateTime.Parse(dr["Booking Date"].ToString()),
                        Amount = decimal.Parse(dr["Amount"].ToString(), new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        Currency = dr["Currency"].ToString(),
                        Info = dr["Booking Info"].ToString(),
                        Reference = dr["Booking Reference"].ToString(),
                        AccountID = acc.ID,
                        PartnerID = partn.ID,
                        TypeID = partn.TypeID
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
