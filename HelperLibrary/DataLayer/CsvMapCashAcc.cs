using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class CsvMapCashAcc
    {
        public string? AccountName { get; set; }
        public string? PartnerName { get; set; }
        public string? PartnerIban { get; set; }
        public string? PartnerBic { get; set; }
        public string? PartnerBankcode { get; set; }
        public string? TransactionDate { get; set; }
        public string? TransactionAmount { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? TransactionInfo { get; set; }
        public string? TransactionReference { get; set; }

        public static List<string> GetTagList()
        {
            List<string> list = new List<string>();
            list.Add("Partner Name");
            list.Add("Partner Iban");
            list.Add("Partner Bic");
            list.Add("Partner Bankcode");
            list.Add("Transaction Date");
            list.Add("Transaction Amount");
            list.Add("Transaction Currency");
            list.Add("Transaction Info");
            list.Add("Transaction Reference");
            return list;

        }
    }
}
