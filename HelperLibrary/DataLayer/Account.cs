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
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public string? Type { get; set; }
        public decimal? Balance { get; set; }

        public void GetValuesFromTable(DataRow row)
        {
            try
            {
                this.ID = int.Parse(row["acc_id"].ToString());
                this.Name = row["acc_name"].ToString();
                this.Iban = row["acc_iban"].ToString();
                this.Bic = row["acc_bic"].ToString();
                this.Type = row["acc_acctype_id"].ToString();
                this.Balance = decimal.Parse(row["acc_balance"].ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        } 
    }
}
