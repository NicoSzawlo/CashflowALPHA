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
            for (DateTime date = DateTime.Now; date >= (DateTime)TrxList[0].Date; date = date.AddDays(-1))
            {
                DateList.Add( new Networth { Date = date});
            }
            foreach(Networth networth in DateList)
            {

            }
            return DateList;

        }

    }
}
