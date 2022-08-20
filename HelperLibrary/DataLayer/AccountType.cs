using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.DataLayer
{
    public class AccountType
    {
        public int? ID { get; set; }
        public string? Name { get; set; }

        public AccountType GetValuesFromRow(DataRow row)
        {
            AccountType accountType = new AccountType();
            try
            {
                accountType.ID = int.Parse(row["acctype_id"].ToString());
                accountType.Name = row["acctype_name"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return accountType;

        }
        public static List<AccountType> GetObjectList(DataTable dt)
        {
            List<AccountType> list = new List<AccountType>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AccountType { ID = int.Parse(dr["acctype_id"].ToString()), Name = dr["acctype_name"].ToString() });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return list;
        }
    }
}
