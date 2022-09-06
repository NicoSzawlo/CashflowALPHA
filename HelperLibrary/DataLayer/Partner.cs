using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelperLibrary.DataLayer
{
    public class Partner
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public string? Bankcode { get; set; }
        public int? TypeID { get; set; }


        //Function to asynchronously load mysqldata into Object from string name
        // +1 Overload for getting Object via ID
        public static Partner GetObjectDb(string name)
        {
            Partner partn = new Partner();
            DataTable partnerdt = MySqlHandler.Select("*", "tab_partners", "partn_name", name);
            
            if (partnerdt.Rows.Count != 0)
            {
                DataRow row = partnerdt.Rows[0];
                try
                {
                    partn.ID = int.Parse(row["partn_id"].ToString());
                    partn.Name = row["partn_name"].ToString();
                    partn.Iban = row["partn_iban"].ToString();
                    partn.Bic = row["partn_bic"].ToString();
                    partn.Bankcode = row["partn_balance"].ToString();
                    partn.TypeID = int.Parse(row["partn_trxtype_id"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return partn;
        }
        public static Partner GetObjectDb(int? id)
        {
            Partner partn = new Partner();
            DataTable partnerdt = MySqlHandler.Select("*", "tab_partners", "partn_id", id.ToString());

            if (partnerdt.Rows.Count != 0)
            {
                DataRow row = partnerdt.Rows[0];
                try
                {
                    partn.ID = int.Parse(row["partn_id"].ToString());
                    partn.Name = row["partn_name"].ToString();
                    partn.Iban = row["partn_iban"].ToString();
                    partn.Bic = row["partn_bic"].ToString();
                    partn.Bankcode = row["partn_balance"].ToString();
                    partn.TypeID = int.Parse(row["partn_trxtype_id"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return partn;
        }


        //Function to asynchronously load mysql data into object list
        public static async Task<List<Partner>> GetObjectListDbAsync()
        {
            DataTable partnerdt = await Task.Run(() => MySqlHandler.Select("*", "tab_partners"));
            List<Partner> list = DbToList(partnerdt);

            return list;
        }


        //Function to insert objectlist into db
        public static async void InsertObjectListDbAsync(List<Partner> list)
        {
            //Check if Db empty and add Placeholder for cash 
            //Maybe move into software setup later
            List<Partner> check = await Task.Run(() => GetObjectListDbAsync());
            if (check.Count == 0)
            {
                Partner cash = new Partner();
                cash.Name = "_Cash";
                await Task.Run(() => MySqlHandler.InsertIntoPartners(cash));
            }

            //Insert every partner in the list
            List<Task> tasks = new List<Task>();
            foreach (Partner partn in list)
            {
                if (partn.Name != "")
                {
                    await Task.Run(() => MySqlHandler.InsertIntoPartners(partn));
                }
            }
        }


        //Function for updating database entry
        public static async void UpdateObjectListAsync(List<Partner> partners)
        {
            foreach(Partner partn in partners)
            {
                await Task.Run(() => MySqlHandler.UpdatePartner(partn));
            }
            
        }
        //Async task extracting all partners from file
        public static List<Partner> GetObjectListStmtAsync(DataTable stmt)
        {
            List<Partner> list = FileToList(stmt);
            return list;
        }


        //Method for extracting Distinct Partners
        public static List<Partner> GetDistinctObjectList(List<Partner> inlist)
        {
            List<Partner> outlist = new List<Partner>();
            bool dupe = false;
            foreach(Partner ipartn in inlist)
            {

                if (outlist.Count == 0)
                {
                    if(!CheckDbEntry(ipartn))
                    {
                        outlist.Add(ipartn);
                    }
                }
                else
                {
                    dupe = CheckDbEntry(ipartn);
                    if (!dupe)
                    {
                        foreach (Partner opartn in outlist)
                        {
                            if (opartn.Name.ToUpper() == ipartn.Name.ToUpper())
                            {
                                dupe = true;
                                break;
                            }
                        }
                    }

                    if (!dupe)
                    {
                        outlist.Add(ipartn);
                    }
                    dupe = false;
                }
            }

            return outlist;
        }


        //Checking Object instance in Db for dupe
        private static bool CheckDbEntry(Partner partn)
        {
            bool dupe = false;
            DataTable result = MySqlHandler.Select("*", "tab_partners", "partn_name", partn.Name);
            if(result.Rows.Count > 0)
            {
                dupe = true;
            }
            return dupe;
        }


        //Adding all george statement partners to objectlist
        private static List<Partner> FileToList(DataTable stmt)
        {
            List<Partner> list = new List<Partner>();
            foreach (DataRow dr in stmt.Rows)
            {
                list.Add(new Partner
                {
                    Name = dr["Partner Name"].ToString(),
                    Iban = dr["Partner IBAN"].ToString(),
                    Bic = dr["BIC/SWIFT"].ToString(),
                    Bankcode = dr["Bank code"].ToString()
                });
            }
            return list;
        }

        //Adding all database entries to objectlist
        private static List<Partner> DbToList(DataTable db)
        {
            List<Partner> list = new List<Partner>();
            foreach (DataRow dr in db.Rows)
            {
                if (dr["partn_trxtype_id"].ToString() != "")
                {
                    list.Add(new Partner
                    {
                        ID = int.Parse(dr["partn_id"].ToString()),
                        Name = dr["partn_name"].ToString(),
                        Iban = dr["partn_iban"].ToString(),
                        Bic = dr["partn_bic"].ToString(),
                        Bankcode = dr["partn_bankcode"].ToString(),
                        TypeID = int.Parse(dr["partn_trxtype_id"].ToString())
                    });
                }
                else
                {
                    list.Add(new Partner
                    {
                        ID = int.Parse(dr["partn_id"].ToString()),
                        Name = dr["partn_name"].ToString(),
                        Iban = dr["partn_iban"].ToString(),
                        Bic = dr["partn_bic"].ToString(),
                        Bankcode = dr["partn_bankcode"].ToString()
                    });
                }
                
            }
            return list;
        }
    }
}
