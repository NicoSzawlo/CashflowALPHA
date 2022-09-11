using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    internal class Networth
    {
        public DateTime Date { get; set; }
        public decimal Capital { get; set; }

        public static List<Networth> CalculateOverallNetworth()
        {
            List<Networth> DateList = new List<Networth>();

            List<Transaction> TrxList = Transaction.GetObjectListDb();

            foreach(Transaction trx in TrxList)
            {
                if (DateList.Count == 0)
                { 

                }
            }

            return DateList;

        }

    }
}
