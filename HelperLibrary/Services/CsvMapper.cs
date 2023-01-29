using HelperLibrary.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.Services
{
    public class CsvMapper
    {
        public static DataTable InitializeDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Linked Tag");
            dt.Columns.Add("CsvFileColumn");

            List<string> list = CsvMapCashAcc.GetTagList();
            foreach(string item in list)
            {
                dt.Rows.Add(item);
            }


            return dt;
        }

        public static List<string> LoadCsvColumns(DataTable dt)
        {
            List<string> CsvColumns = new List<string>();
            
            foreach(DataColumn col in dt.Columns) 
            {
                CsvColumns.Add(col.ColumnName);
            }
            
            return CsvColumns;
        }
    }
}
