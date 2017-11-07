using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class Log
    {        
        public void LogEntry(string log)
        {
           
            string directory = @"C:\log\";
            string file = "log.txt";
            string path = Path.Combine(directory, file);
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(DateTime.UtcNow + " " + log);
            }
        }
        public Log()
        {

        }
    }
}
