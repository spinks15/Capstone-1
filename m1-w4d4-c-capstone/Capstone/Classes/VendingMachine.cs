using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Capstone
{

    public class VendingMachine
    {
        private List<Item> inventoryList = new List<Item>();
        private double depositedAmount;
        private List<Item> inventoryList2 = new List<Item>();
        private double itemCost = 0;

        Log newLog = new Log();
        List<string> slotList = new List<string>();
        string directory = @"C:\VendingMachineStock";
        string fileName = "vendingmachine.csv";
        
        public double DepositedAmount { get => depositedAmount; set => depositedAmount = value; }
        public List<Item> InventoryList { get => inventoryList; set => inventoryList = value; }
        public List<Item> InventoryList2 { get => inventoryList2; set => inventoryList2 = value; }
        public double ItemCost { get => itemCost; set => itemCost = value; }

        public void DisplayItems()
        {
            Console.WriteLine("SlotID".PadRight(10) + "Name".PadRight(20) + "Cost".PadRight(10) + "Quantity");
            foreach (Item item in inventoryList)
            {
                if (item.Quantity == 0)
                {
                    Console.WriteLine(item.Slot.PadRight(10) + item.Name.PadRight(20) + item.Price.PadRight(10) + "SOLD OUT");
                }
                else
                {
                    Console.WriteLine(item.Slot.PadRight(10) + item.Name.PadRight(20) + item.Price.PadRight(10) + item.Quantity);
                }
            }
        }

        public void PurchaseItem(string slotID)
        {
            foreach (Item thisItem in inventoryList)
            {
                if (thisItem.Slot == slotID)
                {
                    double cost = double.Parse(thisItem.Price);
                    if (cost < depositedAmount)
                    {
                        if (thisItem.Quantity > 0)
                        {
                            thisItem.Quantity -= 1;
                            depositedAmount -= cost;
                            SalesReporting(thisItem);
                            itemCost += double.Parse(thisItem.Price);
                            Console.WriteLine($"Thank you for purchasing {thisItem.Name}!");
                            newLog.LogEntry((thisItem.Name + " " + thisItem.Slot + ":").PadRight(25) + "$" + (depositedAmount + cost).ToString("F2").PadRight(15) + depositedAmount.ToString("F2"));
                            if (thisItem.Slot.Contains("A"))
                            {
                                Console.WriteLine("Crunch Crunch, Yum!");
                            }
                            else if (thisItem.Slot.Contains("B"))
                            {
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            else if (thisItem.Slot.Contains("C"))
                            {
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            else if (thisItem.Slot.Contains("D"))
                            {
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, this item is out of stock");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please insert more money");
                    }
                }
            }
            if (!slotList.Contains(slotID))
            {
                Console.WriteLine("Oops, you entered an incorrect item code.");
                Console.WriteLine("Please try again");
            }
        }
        public void DepositMoney(double deposit)
        {
            depositedAmount += deposit;
            newLog.LogEntry("FEED MONEY:".PadRight(25) + "$" + deposit.ToString("F2").PadRight(15) + depositedAmount.ToString("F2"));
        }
        public void SalesReporting(Item salesItem)
        {
            foreach (Item items in inventoryList2)
            {
                if (salesItem.Name == items.Name)
                {
                    items.Quantity += 1;
                }
            }
        }
        public void ReturnChange()
        {
            depositedAmount = 0;
        }
        public VendingMachine()
        {
            depositedAmount = 0;
            string stock = Path.Combine(directory, fileName);
            using (StreamReader sr = new StreamReader(stock))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Item nextItem = new Item(line);
                    Item secondItem = new Item(line);
                    string[] input = line.Split('|');

                    nextItem.Slot = input[0];
                    nextItem.Name = input[1];
                    nextItem.Price = input[2];
                    nextItem.Quantity = 5;

                    secondItem.Slot = input[0];
                    secondItem.Name = input[1];
                    secondItem.Price = input[2];
                    secondItem.Quantity = 0;

                    slotList.Add(input[0]);
                    inventoryList.Add(nextItem);
                    inventoryList2.Add(secondItem);
                }

            }
        }
    }
}
