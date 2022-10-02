using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HelperLibrary.DataLayer
{
    public class Networth
    {
        public DateTime? Date { get; set; }
        public decimal Capital { get; set; }

        public static List<Networth> CalculateOverallNetworth()
        {
            List<Networth> DateList = new List<Networth>();

            List<Transaction> TrxList = Transaction.GetObjectListDb();
            
            //Initiating List of Dates from first in DB to NOW
            for (DateTime date = (DateTime)TrxList[0].Date; date <= DateTime.Now; date = date.AddDays(1))
            {
                DateList.Add( new Networth { Date = date});
            }

            //Get Account value and set day one value
            Account acc = Account.GetObjectDb("Sparkasse");
            DateList[DateList.Count - 1].Capital = (decimal)acc.Balance;

            //Calculate networth from transactions
            for(int i = DateList.Count-1; i >= 0; i--)
            {
                if (i < DateList.Count - 1)
                {
                    DateList[i].Capital = DateList[i + 1].Capital;
                }
                
                foreach (Transaction transaction in TrxList)
                {
                    if (DateList[i].Date == transaction.Date)
                    {
                        DateList[i].Capital += (decimal)transaction.Amount;
                    }

                }
            }
            return DateList;

        }

    }
}
