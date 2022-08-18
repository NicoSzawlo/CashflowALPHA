using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class CsvProcessing
    {
        public DataTable CsvToTable(string filepath)
        {
            string content = ReadFile(filepath);
            DataTable dt = new DataTable();
            


            return dt;
        }

        private string ReadFile(string filepath)
        {
            string content = "";
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    content = sr.ReadToEnd();
                    Console.WriteLine("File loaded");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }
            return content;
        }
    }
}
