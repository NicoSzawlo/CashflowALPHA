using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class Partner
    {
        int ID { get; set; }
        string Name { get; set; }
        string Iban { get; set; }
        string Bic { get; set; }
        string Bankcode { get; set; }
        string UsualTransactionType { get; set; }
    }
}
