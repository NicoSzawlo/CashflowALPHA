using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class Transaction
    {
        int ID { get; set; }
        DateTime Date { get; set; }
        Decimal Amount { get; set; }
        string Currency { get; set; }
        string  Info { get; set; }
        string Reference { get; set; }
        string Partner  { get; set; }
        string Account { get; set; }
        string Type { get; set; }
        string InvestmentPosition { get; set; }


    }
}
