using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void VendingMachineCashInOutTest()
        {
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.DepositMoney(10);
            Assert.AreEqual(10, vendingMachine.DepositedAmount);
            vendingMachine.DepositMoney(5);
            Assert.AreEqual(15, vendingMachine.DepositedAmount);
            vendingMachine.PurchaseItem("A2");
            Assert.AreEqual(13.55, vendingMachine.DepositedAmount);
            vendingMachine.PurchaseItem("B4");
            Assert.AreEqual(11.80, vendingMachine.DepositedAmount);
            vendingMachine.ReturnChange();
            Assert.AreEqual(0, vendingMachine.DepositedAmount);
        }

        [TestMethod]
        public void VendingMachineItemTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Item item = new Item("A1|SlimJim|3.05|");

            item.Quantity = 5;
            Assert.AreEqual("A1", item.Slot);
            Assert.AreEqual("SlimJim", item.Name);
            Assert.AreEqual("3.05", item.Price);
            Assert.AreEqual(5, item.Quantity);
        }
        [TestMethod]
        public void CommandLineTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            CommandLine commandLine = new CommandLine(vendingMachine);


        }

    }
}
