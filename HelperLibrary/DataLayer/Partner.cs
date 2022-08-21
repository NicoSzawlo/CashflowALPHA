using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class Partner
    {
        int? ID { get; set; }
        string? Name { get; set; }
        string? Iban { get; set; }
        string? Bic { get; set; }
        string? Bankcode { get; set; }
        int? UsualTrxType { get; set; }


        //Function to asynchronously load mysqldata into Object
        public static async Task<Partner> GetObjectAsync(string name)
        {
            Partner partn = new Partner();
            MySqlHandler mySqlHandler = new MySqlHandler();
            DataTable partnerdt = await Task.Run(() => mySqlHandler.Select("*", "tab_partners", "partn_name", name));
            DataRow row = partnerdt.Rows[0];

            try
            {
                partn.ID = int.Parse(row["partn_id"].ToString());
                partn.Name = row["partn_name"].ToString();
                partn.Iban = row["partn_iban"].ToString();
                partn.Bic = row["partn_bic"].ToString();
                partn.Bankcode = row["partn_balance"].ToString();
                partn.UsualTrxType = int.Parse(row["partn_trxtype_id"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return partn;
        }
        //Function to asynchronously load mysql data into object list
        public static async Task<List<Partner>> GetObjectListAsync()
        {
            List<Partner> list = new List<Partner>();
            MySqlHandler mySqlHandler = new MySqlHandler();
            DataTable partnerdt = await Task.Run(() => mySqlHandler.Select("*", "tab_accounts"));
            try
            {
                foreach (DataRow dr in partnerdt.Rows)
                {
                    list.Add(new Partner
                    {
                        ID = int.Parse(dr["acc_id"].ToString()),
                        Name = dr["acc_name"].ToString(),
                        Iban = dr["acc_iban"].ToString(),
                        Bic = dr["acc_bic"].ToString(),
                        Bankcode = dr["acc_balance"].ToString(),
                        UsualTrxType = int.Parse(dr["acc_acctype_id"].ToString())                        
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
