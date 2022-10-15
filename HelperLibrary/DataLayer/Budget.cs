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

        public static List<Budget> GetBudgetsForMonth()
        {
            List<Budget> bdgtlist = InitBudgetlist();

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

    }
}
