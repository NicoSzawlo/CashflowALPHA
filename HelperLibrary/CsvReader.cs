using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    internal class CsvReader
    {
        public string FilePath { get; set; }

        public string FileContent { get; set; } 
        
        public DataTable ContentTable { get; set; }

        public void ReadFileToString()
        {
            StreamReader sr = new StreamReader(FilePath);
            
        }

        public void ReadFileToTable()
        {

        }

    }
}
