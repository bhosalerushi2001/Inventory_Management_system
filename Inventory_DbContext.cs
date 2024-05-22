using Inventory_Management_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Management_system
{
    public class Inventory_DbContext:DbContext
    {

        public Inventory_DbContext() : base("Data_of_Inventory") { }

        public DbSet<Inventory> inventories { get; set; }

    }
}