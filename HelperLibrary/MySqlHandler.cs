﻿using System;
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
        //Connection string for MySqlDb
        private string connStr = "Server=localhost;Database=cashflow_alpha;Uid=root;Pwd=root;";

        //Select from Mysql database 
        //Select item from table
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
        //Select item from table where param = value
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

        //Open Mysql server connection on command handle
        public MySqlCommand Connect()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Connection.Open();
            return cmd;
        }

        //Close Mysql server connection on command
        public void Disconnect(MySqlCommand cmd)
        {
            cmd.Connection.Close();
        }
    }

    
}
