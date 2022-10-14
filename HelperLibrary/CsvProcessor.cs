using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class CsvProcessor
    {

        //Process filestring to Datatable
        //MISSING CHECK FOR EMPTY ROW 
        public static DataTable CsvToTable(string filepath)
        {
            DataTable dt = new DataTable();

            string content = ReadFile(filepath);
            string linebreak = "\n";
            string templine = "";
            string[] lines = null;
            string[] columns = null;
            char separator = ';';

            int colcount = 0;

            bool header = true;

            lines = content.Split(linebreak);
            if (lines[lines.Length-1] != "")
            {

            }
            columns = lines[0].Split(separator);

            colcount = columns.Length;

            if (header)
            {
                foreach (string item in columns)
                {
                    dt.Columns.Add(item.Trim('"'));
                }

                lines = lines.Skip(1).ToArray();
            }
            else
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    dt.Columns.Add(i.ToString());
                }
            }

            foreach (string line in lines)
            {
                if(line != "")
                {
                    templine = TrimSemicolon(line);
                    columns = templine.Split(separator);

                    columns = TrimQuotes(columns);

                    dt.Rows.Add(columns);
                }
                
            }

            return dt;
        }

        //Read raw file string
        private static string ReadFile(string filepath)
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
            catch (Exception ex)
            {

                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);

            }
            return content;
        }


        //Trimming Quotes from array of single strings
        private static string[] TrimQuotes(string[] array)
        {
            string[] strings = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                strings[i] = array[i].Trim('"');
            }
            return strings;
        }

        //George Statement csv has every Field separated with ; and
        //every content "xxx" so we can filter out semicolon in text 
        private static string TrimSemicolon(string row)
        {
            string trimmedRow = "";
            char[] chars = row.ToCharArray();

            bool quoteOpen = false;
            try
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == '"' && !quoteOpen)
                    {
                        quoteOpen = true;
                    }
                    if (chars[i] == '"' && quoteOpen)
                    {
                        quoteOpen = false;
                    }
                    if (quoteOpen && chars[i] == ';')
                    {
                        chars[i] = ' ';
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            trimmedRow = new string(chars);

            return trimmedRow;
        }

    }
}
