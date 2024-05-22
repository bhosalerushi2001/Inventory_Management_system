using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_system.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}