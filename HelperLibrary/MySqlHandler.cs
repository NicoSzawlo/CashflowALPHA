using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HelperLibrary
{
    public class MySqlHandler
    {
        private string connStr = "Server=localhost;Database=cashflow_alpha;Uid=root;Pwd=root;";
        public async Task<DataTable> Select(string item, string table)
        {
            DataTable result = new DataTable();
            MySqlCommand cmd = Connect();
            cmd.CommandText = "SELECT " + item + " FROM " + table + ";";

            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                await adapter.FillAsync(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Disconnect(cmd);
            return result;

        }
        public async Task<DataTable> Select(string item, string table, string whereparam, string whereval)
        {
            DataTable result = new DataTable();
            MySqlCommand cmd = Connect();
            
            cmd.CommandText = "SELECT " + item + " FROM " + table + " WHERE " + whereparam +" = @whereval;";
            cmd.Parameters.AddWithValue("@whereval", whereval);

            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                await adapter.FillAsync(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Disconnect(cmd);
            return result;

        }

        public void InsertIntoAccount(string name, string iban, string bic, int type)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "INSERT INTO tab_accounts (name, iban, bic, type) VALUES (@name, @iban, @bic, @type)";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@iban", iban);
            cmd.Parameters.AddWithValue("@bic", bic);
            cmd.Parameters.AddWithValue("@type", type);

            try
            {
                var result = cmd.ExecuteNonQuery();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Disconnect(cmd);
            
        }

        public MySqlCommand Connect()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Connection.Open();
            return cmd;
        }

        public void Disconnect(MySqlCommand cmd)
        {
            cmd.Connection.Close();
        }

        //Function to add data in multiple columns
        private MySqlCommand AddColumnsValues(MySqlCommand cmd, IEnumerable<string> columns, IEnumerable<string> values)
        {
            IEnumerator<string> column = columns.GetEnumerator();
            IEnumerator<string> value = values.GetEnumerator();
            while(column.MoveNext() && value.MoveNext())
            {
                cmd.Parameters.AddWithValue(column.Current, value.Current); 
            }
            return cmd;
        }
    }

    
}
