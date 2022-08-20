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

        public void GetValuesFromTable(DataRow row)
        {

            try
            {
                this.ID = int.Parse(row["acctype_id"].ToString());
                this.Name = row["acctype_name"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public List<AccountType> GetObjectList(DataTable dt)
        {
            List<AccountType> list = new List<AccountType>();
            
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new AccountType { ID = int.Parse(dr["acctype_id"].ToString()), Name = dr["acctype_name"].ToString() });
            }
            return list;
        }
    }
}
