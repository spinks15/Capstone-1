using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vending = new VendingMachine();
            CommandLine commandLine = new CommandLine(vending);
            commandLine.MainMenu();          
        }
    }
}