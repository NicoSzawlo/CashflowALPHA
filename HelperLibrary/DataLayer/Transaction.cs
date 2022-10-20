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

        public static Transaction GetObjectDb(string id)
        {
            Transaction trx = new Transaction();
            DataTable trxdt = MySqlHandler.Select("*", "tab_trx", "trx_id", id);
            DataRow dr = trxdt.Rows[0];

            try
            {
                trx.ID = int.Parse(dr["trx_id"].ToString());
                trx.Date = DateTime.Parse(dr["trx_date"].ToString());
                trx.Amount = decimal.Parse(dr["trx_amnt"].ToString());
                trx.Currency = dr["trx_currency"].ToString();
                trx.Info = dr["trx_info"].ToString();
                trx.Reference = dr["trx_reference"].ToString();
                if (!EmtpyStringCheck(dr["trx_partn_id"].ToString()))
                {
                    trx.PartnerID = int.Parse(dr["trx_partn_id"].ToString());
                }
                if (!EmtpyStringCheck(dr["trx_acc_id"].ToString()))
                {
                    trx.AccountID = int.Parse(dr["trx_acc_id"].ToString());
                }

                if (!EmtpyStringCheck(dr["trx_trxtype_id"].ToString()))
                {
                    trx.TypeID = int.Parse(dr["trx_trxtype_id"].ToString());
                }

                if (!EmtpyStringCheck(dr["trx_invpos_id"].ToString()))
                {
                    trx.InvPosID = int.Parse(dr["trx_invpos_id"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return trx;
        }

        //Function to asynchronously load mysql data into object list
        public static async Task<List<Transaction>> GetObjectListDbAsync()
        {
            List<Transaction> list = new List<Transaction>();
            DataTable trxdt = await Task.Run(() => MySqlHandler.Select("*", "tab_trx"));
            list = await Task.Run(() => DbToList(trxdt));

            return list;
        }
        //Get list of transactions with sepcific partner
        public static async Task<List<Transaction>> GetObjectListForPartnerDb(Partner partner)
        {
            List<Transaction> list = new List<Transaction>();
            DataTable trxdt = await Task.Run(() => MySqlHandler.Select("*", "tab_trx", "trx_partn_id", partner.ID.ToString()));
            list = await Task.Run(() => DbToList(trxdt));

            return list;
        }

        //Check if account has transactions linked to it
        public static async Task<bool> CheckTrxForAcc(Account acc)
        {
            bool flag = false;
            List<Transaction> list = new List<Transaction>();
            DataTable trxdt = await Task.Run(() => MySqlHandler.Select("*", "tab_trx", "trx_acc_id", acc.ID.ToString()));
            list = await Task.Run(() => DbToList(trxdt));

            if(list.Count > 0)
            {
                flag = true;
            }

            return flag;
        }

        public static List<Transaction> GetObjectListDb()
        {
            List<Transaction> list = new List<Transaction>();
            DataTable trxdt = MySqlHandler.SelectOrderBySync("*", "tab_trx", "trx_date");
            list = DbToList(trxdt);
            
            return list;
        }

        //Pull objectlist from Statementfile Datatable
        public static List<Transaction> GetObjectListStmt(DataTable stmt, string accname)
        {
            Account acc = Account.GetObjectDb(accname);
            List<Transaction> list = FileToList(stmt, acc);
            return list;
        }



        //Insert object list into database
        public static async void InsertObjectListDbAsync(List<Transaction> list, string accname, WaitCallback callback)
        {
            if(callback != null)
            {
                callback.Invoke(null);
            }

            Account accentry = Account.GetObjectDb(accname);
            foreach( Transaction t in list)
            {
                t.AccountID = accentry.ID;
            }
            foreach (Transaction trx in list)
            {
                await Task.Run(() => MySqlHandler.InsertIntoTrx(trx));
            }
        }

        //Update database entries for list of objects
        public static void UpdateObjectListAsync(List<Transaction> trxs)
        {
            foreach (Transaction trx in trxs)
            {
                MySqlHandler.UpdateTransaction(trx);
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
                Transaction trx = new Transaction();
                trx.ID = int.Parse(dr["trx_id"].ToString());
                trx.Date = DateTime.Parse(dr["trx_date"].ToString());
                trx.Amount = decimal.Parse(dr["trx_amnt"].ToString());
                trx.Currency = dr["trx_currency"].ToString();
                trx.Info = dr["trx_info"].ToString();
                trx.Reference = dr["trx_reference"].ToString();
                if(!EmtpyStringCheck(dr["trx_partn_id"].ToString()))
                {
                    trx.PartnerID = int.Parse(dr["trx_partn_id"].ToString());
                }
                if (!EmtpyStringCheck(dr["trx_acc_id"].ToString()))
                {
                    trx.AccountID = int.Parse(dr["trx_acc_id"].ToString());
                }
                    
                if (!EmtpyStringCheck(dr["trx_trxtype_id"].ToString()))
                {
                    trx.TypeID = int.Parse(dr["trx_trxtype_id"].ToString());
                }
                  
                if (!EmtpyStringCheck(dr["trx_invpos_id"].ToString()))
                {
                    trx.InvPosID = int.Parse(dr["trx_invpos_id"].ToString());
                }
                list.Add(trx);
                
            }
            return list;
        }
        //Check if string is empty and returns bool
        private static bool EmtpyStringCheck(string str)
        {
            bool empty = false;
            if (str == "")
            {
                empty = true;
            }
            return empty;
        }
    }
}
