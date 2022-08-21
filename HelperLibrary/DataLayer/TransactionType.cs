using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class TransactionType
    {
        int ID { get; set; }
        string Name { get; set; }
        decimal Budget { get; set; }

        public static async Task<List<TransactionType>> GetObjectListAsync()
        {
            List<TransactionType> list = new List<TransactionType>();
            DataTable trxtypedt = await Task.Run(() => MySqlHandler.Select("*", "tab_trxtype"));
            try
            {
                foreach (DataRow dr in trxtypedt.Rows)
                {
                    list.Add(new TransactionType
                    {
                        ID = int.Parse(dr["trx_id"].ToString()),
                        Name = dr["trx_name"].ToString(),
                        Budget = decimal.Parse(dr["trx_iban"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }
    }
}
