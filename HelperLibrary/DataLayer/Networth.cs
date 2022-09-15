using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Calculate networth from transactions
            for(int i = DateList.Count-1; i >= 0; i--)
            {
                foreach(Transaction transaction in TrxList)
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
