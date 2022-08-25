using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public static DataTable Select(string item, string table, string whereparam, string whereval)
        {
            DataTable result = new DataTable();
            MySqlCommand cmd = Connect();
            
            cmd.CommandText = "SELECT " + item + " FROM " + table + " WHERE " + whereparam +" = @whereval;";
            cmd.Parameters.AddWithValue("@whereval", whereval);

            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.FillAsync(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Disconnect(cmd);
            return result;

        }

        //Transactions table
        //#######################################################

        //Insert into Transactions table
        public static void InsertIntoTrx(Transaction trx)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = 
                "INSERT INTO tab_trx " +
                "(trx_date, trx_amnt, trx_currency, trx_info, trx_reference, trx_partn_id, trx_acc_id, trx_trxtype_id, trx_invpos_id)" +
                " VALUES " +
                "(@date, @amnt, @curr, @info, @reference, @partnid, @accid, @trxtypeid, @invposid )";
            cmd.Parameters.AddWithValue("@date", trx.Date);
            cmd.Parameters.AddWithValue("@amnt", trx.Amount);
            cmd.Parameters.AddWithValue("@curr", trx.Currency);
            cmd.Parameters.AddWithValue("@info", trx.Info);
            cmd.Parameters.AddWithValue("@reference", trx.Reference);
            cmd.Parameters.AddWithValue("@partnid", trx.PartnerID);
            cmd.Parameters.AddWithValue("@accid", trx.AccountID);
            cmd.Parameters.AddWithValue("@trxtypeid", trx.TypeID);
            cmd.Parameters.AddWithValue("@invposid", trx.InvPosID);

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

        //Accounts table
        //#######################################################

        //Insert into account table
        public static void InsertIntoAccount(Account acc)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "INSERT INTO tab_accounts (name, iban, bic, type, balance) VALUES (@name, @iban, @bic, @type, @balance)";
            cmd.Parameters.AddWithValue("@name", acc.Name);
            cmd.Parameters.AddWithValue("@iban", acc.Iban);
            cmd.Parameters.AddWithValue("@bic", acc.Bic);
            cmd.Parameters.AddWithValue("@type", acc.TypeID);
            cmd.Parameters.AddWithValue("@balance", acc.Balance);
            cmd.Parameters.AddWithValue("@id", acc.ID);

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
        //Update account row
        public static void UpdateAccount(Account acc)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "UPDATE tab_accounts SET acc_name = @name,acc_iban = @iban, acc_bic = @bic,acc_acctype_id = @type,acc_balance = @balance WHERE acc_id = @id";
            
            cmd.Parameters.AddWithValue("@name", acc.Name);
            cmd.Parameters.AddWithValue("@iban", acc.Iban);
            cmd.Parameters.AddWithValue("@bic", acc.Bic);
            cmd.Parameters.AddWithValue("@type", acc.TypeID);
            cmd.Parameters.AddWithValue("@balance", acc.Balance);
            cmd.Parameters.AddWithValue("@id", acc.ID);

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


        //Partners table
        //#######################################################

        //Insert into partner table
        public static void InsertIntoPartners(Partner partn)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "INSERT INTO tab_partners (partn_name, partn_iban, partn_bic,partn_bankcode, partn_trxtype_id) VALUES (@name, @iban, @bic, @bankcode, @type)";
            cmd.Parameters.AddWithValue("@name", partn.Name);
            cmd.Parameters.AddWithValue("@iban", partn.Iban);
            cmd.Parameters.AddWithValue("@bic", partn.Bic);
            cmd.Parameters.AddWithValue("@bankcode", partn.Bankcode);
            cmd.Parameters.AddWithValue("@type", partn.TypeID);

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

        //Update partner entry
        public static void UpdatePartner(Partner partn)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "UPDATE tab_partners SET partn_name = @name,partn_iban = @iban, partn_bic = @bic,partn_bankcode = @bankcode ,partn_trxtype_id = @trxtypeid WHERE partn_id = @id";

            cmd.Parameters.AddWithValue("@name", partn.Name);
            cmd.Parameters.AddWithValue("@iban", partn.Iban);
            cmd.Parameters.AddWithValue("@bic", partn.Bic);
            cmd.Parameters.AddWithValue("@bankcode", partn.Bankcode);
            cmd.Parameters.AddWithValue("@trxtypeid", partn.TypeID);
            cmd.Parameters.AddWithValue("@id", partn.ID);

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
        //Transactiontypes table
        //#######################################################
        public static void InsertIntoTrxTypes(TransactionType trxtype)
        {
            MySqlCommand cmd = Connect();

            cmd.CommandText = "INSERT INTO tab_trxtypes (trxtype_name, trxtype_budget) VALUES (@name, @budget)";
            cmd.Parameters.AddWithValue("@name", trxtype.Name);
            cmd.Parameters.AddWithValue("@budget", trxtype.Budget);

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
        //General methods
        //#######################################################
        //Open Mysql server connection on command handle
        private static MySqlCommand Connect()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Connection.Open();
            return cmd;
        }

        //Close Mysql server connection on command
        private static void Disconnect(MySqlCommand cmd)
        {
            cmd.Connection.Close();
        }
    }

    
}
