using Inventory_Management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_system.Controllers
{
    public class InventoryController : Controller
    {

        Inventory_DbContext db=new Inventory_DbContext();
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayInventory() 
        {
            //use a list store instance of the item class & display all items
            List<Inventory> list=db.inventories.ToList();
                return View(list);
        }



        [HttpGet]
        public ActionResult CreateInventory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInventory(Inventory inventory) 
        {
            //Adding new item
            db.inventories.Add(inventory);
            db.SaveChanges();
            return RedirectToAction("DisplayInventory");
        }



        [HttpGet]
        public ActionResult UpdateInventory(int id)
        {
            Inventory data = db.inventories.Where(x => x.Id == id).FirstOrDefault();
            if (id==null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult UpdateInventory(int id,Inventory inv)
        {
            //Finding an item in id
            Inventory data = db.inventories.Where(x => x.Id == id).FirstOrDefault();

            //updating an items information
            data.Id = inv.Id;
            data.Name = inv.Name;
            data.Price = inv.Price;
            data.Quantity = inv.Quantity;
            db.SaveChanges();

            return RedirectToAction("DisplayInventory");
        }


        [HttpGet]
        public ActionResult DetailsInventory(int id) 
        {
            //Details of inventory
            Inventory dataShow= db.inventories.Where(x=>x.Id == id).FirstOrDefault();
            return View(dataShow);
        }



        [HttpGet]
        public ActionResult DeleteInventory(int id) 
        {
            Inventory idData=db.inventories.Where(x=> x.Id == id).FirstOrDefault();
            if(idData==null)
            {
               return HttpNotFound();
            }
            return View(idData);  
        }
        [HttpPost]
        public ActionResult Deleteinventory(int id) 
        {
            Inventory idData = db.inventories.Where(x => x.Id == id).FirstOrDefault();
            if (idData == null)
            {
                return HttpNotFound();
            }
            //delete an item by id
            db.inventories.Remove(idData);
            db.SaveChanges();
            return RedirectToAction("DisplayInventory");

        }


    }
}