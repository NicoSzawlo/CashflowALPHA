using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    internal class Account
    {
        int ID { get; set; }
        string Name { get; set; }
        string Iban { get; set; }
        string Bic { get; set; }
        string Type { get; set; }
        decimal Balance { get; set; }
    }
}
