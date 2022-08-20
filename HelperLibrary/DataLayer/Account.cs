using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }

        public void GetValuesFromTable(DataTable dt)
        {
            //ITableMapping mapping = new ITableMapping();
            //mapping.Add
        } 
    }
}
