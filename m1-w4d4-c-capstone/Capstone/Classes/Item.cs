using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{

    public class Item
    {
        private string price;
        private string name;
        private string slot;
        private int quantity;

        public string Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public string Slot { get => slot; set => slot = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Item(string lineItem)
        {
            string[] parts = lineItem.Split('|');
            Slot = parts[0];
            Name = parts[1];
            Price = parts[2];
        }
    }
}
