using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperLibrary.DataLayer;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HelperLibrary
{
    public class MySqlHandler
    {
        //Connection string for MySqlDb
        static string connStr = "Server=localhost;Database=cashflow_alpha;Uid=root;Pwd=root;";

        //Select from Mysql database 
        //Select item from table
        public static async Task<DataTable> Select(string item, string table)
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
        //Overload 1:
        //Select item from table where param = value
        public static async Task<DataTable> Select(string item, string table, string whereparam, string whereval)
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

        //Insert into account table
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

        //Insert into partner table
        public static void InsertIntoPartners(Partner partn)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "INSERT INTO tab_partners (partn_name, partn_iban, partn_bic,partn_bankcode, partn_trxtype_id) VALUES (@name, @iban, @bic, @bankcode, @type)";
            cmd.Parameters.AddWithValue("@name", partn.Name);
            cmd.Parameters.AddWithValue("@iban", partn.Iban);
            cmd.Parameters.AddWithValue("@bic", partn.Bic);
            cmd.Parameters.AddWithValue("@bankcode", partn.Bankcode);
            cmd.Parameters.AddWithValue("@type", partn.UsualTrxType);

            try
            {
                var result = cmd.ExecuteNonQuery();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(cmd.ToString());
                Console.WriteLine(ex.Message);
            }
            Disconnect(cmd);

        }

        //Open Mysql server connection on command handle
        public static MySqlCommand Connect()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Connection.Open();
            return cmd;
        }

        //Close Mysql server connection on command
        public static void Disconnect(MySqlCommand cmd)
        {
            cmd.Connection.Close();
        }
    }

    
}
