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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Disconnect(cmd);
            return result;

        }

        private async Task InsertInto(string table, string columns, string value)
        {
            MySqlCommand cmd = Connect();
            cmd.CommandText = "INSERT INTO "+table+"("+columns+") VALUES ("+value+");";
            try
            {
                var result = await Task.Run(() => cmd.ExecuteNonQuery());
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
            conn.Open();
            cmd.Connection.Close();
            return cmd;
        }

        public void Disconnect(MySqlCommand cmd)
        {
            cmd.Connection.Close();
        }

        
    }
}
