using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Roguelike___Mini_Project
{
    internal class Items
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public Items (string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
