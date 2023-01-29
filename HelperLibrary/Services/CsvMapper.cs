using HelperLibrary.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        //Save content of DgvAccCsvMap to json file
        public static void SaveMap(DataTable dt, Account acc)
        {
            CsvMapCashAcc map = new CsvMapCashAcc();
            foreach(DataRow dr in dt.Rows)
            {
                switch (dr["Linked Tag"].ToString()) 
                {
                    case "Partner Name":
                        map.PartnerName = dr["CsvColumns"].ToString();
                        break;
                    case "Partner Iban":
                        map.PartnerIban = dr["CsvColumns"].ToString();
                        break;
                    case "Partner Bic":
                        map.PartnerBic = dr["CsvColumns"].ToString();
                        break;
                    case "Partner Bankcode":
                        map.PartnerBankcode = dr["CsvColumns"].ToString();
                        break;
                    case "Transaction Date":
                        map.TransactionDate = dr["CsvColumns"].ToString();
                        break;
                    case "Transaction Amount":
                        map.TransactionAmount = dr["CsvColumns"].ToString();
                        break;
                    case "Transaction Currency":
                        map.TransactionCurrency = dr["CsvColumns"].ToString();
                        break;
                    case "Transaction Info":
                        map.TransactionInfo = dr["CsvColumns"].ToString();
                        break;
                    case "Transaction Reference":
                        map.TransactionReference = dr["CsvColumns"].ToString();
                        break;
                }
            }
            string jsonString = JsonSerializer.Serialize(map);
            string filePath = ".\\" + acc.Name + "CsvMap.json";
            File.Delete(filePath);
            File.WriteAllText(filePath, jsonString);
        }

        public static CsvMapCashAcc LoadMap(DataTable dt, Account acc)
        {
            CsvMapCashAcc map = new CsvMapCashAcc();
            string filePath = ".\\" + acc.Name + "CsvMap.json";
            map = JsonSerializer.Deserialize<CsvMapCashAcc>(filePath);
            return map;
        }
    }
}
