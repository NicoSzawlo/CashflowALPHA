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
        public DataTable CsvToTable(string filepath)
        {
            DataTable dt = new DataTable();

            string content = ReadFile(filepath);
            string linebreak = "\n";

            string[] lines = null;
            string[] columns = null;
            char separator = ';';

            int colcount = 0;

            bool header = true;

            lines = content.Split(linebreak);
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

            foreach(string line in lines)
            {
                columns = line.Split(separator);
                columns = TrimQuotes(columns);

                dt.Rows.Add(columns);
            }

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
            catch (Exception ex)
            {

                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);

            }
            return content;
        }

        private string[] TrimQuotes(string[] array)
        {
            string[] strings = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                strings[i] = array[i].Trim('"');
            }
            return strings;
        }
    }
}
