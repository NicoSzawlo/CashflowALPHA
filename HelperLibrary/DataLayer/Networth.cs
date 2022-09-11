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

        public static List<Networth> CalculateNetworth()
        {
            List<Networth> DateList = new List<Networth>();

            List<Transaction> TrxList = Transaction.GetObjectListDb();

            return DateList;

        }
    }
}
