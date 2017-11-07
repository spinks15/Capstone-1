using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class SalesReport
    {
        string directory = @"C:\SalesReport\";
        string file = "SalesReport.txt";
        public SalesReport(List<Item> list, double totalCash)
        {            
            string path = Path.Combine(directory, file);
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (Item items in list)
                {
                    sw.WriteLine($"{items.Name}|{items.Quantity}");
                }
                sw.WriteLine();
                sw.WriteLine($"**TOTAL SALES** ${totalCash.ToString("F2")}");
            }
        }
    }
}
