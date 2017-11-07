using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class CommandLine
    {
        private VendingMachine myVendingMachine;

        public void MainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            string mainSelection = Console.ReadLine();
            if (mainSelection != "1" && mainSelection != "2" && mainSelection != "3")
            {
                Console.WriteLine("Invalid input, please make another selection");
                MainMenu();
            }
            else if (mainSelection == "1")
            {
                myVendingMachine.DisplayItems();
                MainMenu();
            }
            else if (mainSelection == "2")
            {
                PurchaseMenu();
            }
            else
            {
                Console.WriteLine("Are you sure you want to exit? (Y)es or (N)o");
                string exitResponse = Console.ReadLine();
                if (exitResponse != "N" && exitResponse != "Y" && exitResponse != "n" && exitResponse != "y")
                {
                    Console.WriteLine("Invalid input, returning to Main Menu");
                    MainMenu();
                }
                else if (exitResponse == "N")
                {
                    MainMenu();
                }
                else
                {                  
                    SalesReport salesReport = new SalesReport(myVendingMachine.InventoryList2, myVendingMachine.ItemCost);
                    Console.WriteLine();
                }
            }
        }
        public void PurchaseMenu()
        {
            Log newLog = new Log();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"Current Money Provided: ${myVendingMachine.DepositedAmount.ToString("F2")}");
            string selection = Console.ReadLine();
            if (selection != "1" && selection != "2" && selection != "3")
            {
                Console.WriteLine("Sorry, input not recognized, please try again.");
                PurchaseMenu();
            }
            int intSelection = int.Parse(selection);
            if (intSelection == 1)
            {
                FeedMoney();
            }
            else if (intSelection == 2)
            {
                Console.WriteLine("Input item code");
                string codes = Console.ReadLine();
                myVendingMachine.PurchaseItem(codes);
                PurchaseMenu();
            }
            else if (intSelection == 3)
            {
                Console.WriteLine($"Your change is ${myVendingMachine.DepositedAmount.ToString("F2")}");
                double change = myVendingMachine.DepositedAmount * 100;
                newLog.LogEntry("GIVE CHANGE:".PadRight(25) + "$" + myVendingMachine.DepositedAmount.ToString("F2").PadRight(15) + "$0.00");
                int quarters = 0;
                int dimes = 0;
                int nickels = 0;

                while (change >= 25)
                {
                    quarters++;
                    change -= 25;
                }
                while (change >= 10)
                {
                    dimes++;
                    change -= 10;
                }
                while (change >= 5)
                {
                    nickels++;
                    change -= 5;
                }
                Console.WriteLine($"Dispensing {quarters} quarters, {dimes} dimes, {nickels} nickels");
                myVendingMachine.ReturnChange();                
                MainMenu();
            }
        }
        public CommandLine(VendingMachine vendingMachine)
        {
            myVendingMachine = vendingMachine;
        }
        private void FeedMoney()
        {
            Console.WriteLine("Would you like to insert a (1), (5), (10), or (20) dollar bill?");
            string fedMoney = Console.ReadLine();
            double moneyInserted = double.Parse(fedMoney);
            if (moneyInserted != 1 && moneyInserted != 5 && moneyInserted != 10 && moneyInserted != 20)
            {
                Console.WriteLine("Sorry we don't accept bills of that size, please insert a (1), (5), (10), or (20) dollar bill");
                PurchaseMenu();
            }
            else
            {
                myVendingMachine.DepositMoney(moneyInserted);
                PurchaseMenu();
            }
        }
    }

}
