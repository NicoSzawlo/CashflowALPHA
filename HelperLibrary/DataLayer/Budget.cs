using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    //Model for calculations to display budget data
    public class Budget
    {
        //Set global Transaction type and spending instances
        public TransactionType TransactionType { get; set; }
        public decimal TotalSpending { get; set; }

        public static List<Budget> GetBudgetsForMonth(DateTime month)
        {
            List<Budget> bdgtlist = InitBudgetlist();
            List<Transaction> trxlist = Transaction.GetObjectListDb();
            DateTime fromDate = GetFirstOfMonth(month);
            DateTime toDate = GetEndOfMonth(month);

            //Foreach Transaction type go through all transactions
            foreach(Budget bdgt in bdgtlist)
            {
                foreach(Transaction trx in trxlist)
                {
                    //Check if trx is in range of date
                    if(trx.Date >= fromDate && trx.Date < toDate)
                    {
                        //When Transaction Type ID is equal, add amount to Totalspending
                        if (trx.TypeID == bdgt.TransactionType.ID)
                        {
                            bdgt.TotalSpending = bdgt.TotalSpending + (decimal)trx.Amount;
                        }
                    }
                    
                }
                bdgt.TotalSpending = Math.Abs(bdgt.TotalSpending);
            }

            return bdgtlist;
        }



        //Initialise Budgetlist
        private static List<Budget> InitBudgetlist()
        {
            //Create lists
            List<Budget> budgetlist = new List<Budget>();
            List<TransactionType> typelist = TransactionType.GetObjectListDbSync();

            //Add item to budgetlist for each transaction type
            foreach(TransactionType type in typelist)
            {
                Budget bdgt = new Budget();
                bdgt.TransactionType = type;
                bdgt.TotalSpending = 0;
                budgetlist.Add(bdgt);
                
            }

            return budgetlist;
        }

        //Get end of month date
        private static DateTime GetEndOfMonth(DateTime date)
        {
            DateTime endOfMonth = date;

            //Get integer values
            int dayOfMonth = date.Day;

            //Subtract the number of days in order to get the 1. of the next month
            endOfMonth = endOfMonth.AddDays(
                +(DateTime.DaysInMonth(
                    endOfMonth.Year,
                    endOfMonth.Month)-dayOfMonth)
                );

            return endOfMonth;
        }

        //Get first of month date
        private static DateTime GetFirstOfMonth (DateTime date)
        {
            DateTime firstOfMonth = date;

            //Get integer values
            int dayOfMonth = date.Day;

            //Subtract the number of days in order to get the 1. of the next month
            firstOfMonth = firstOfMonth.AddDays(-dayOfMonth + 1);

            return firstOfMonth;
        }
    }
}
