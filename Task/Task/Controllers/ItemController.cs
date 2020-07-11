using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models;
using Task.Structure.Entities;
using Task.Structure.Services;
using Task.Structure.ViewModels;

namespace Task.Controllers
{

    public class ItemController : Controller    
    {
        

        private readonly ItemService ItemService;
        private readonly ClientService ClientService;
        private readonly OrderService OrderService;

        public ItemController (ItemService _ItemService, OrderService _OrderService, ClientService _ClientService)
        {
            ItemService = _ItemService;
            OrderService = _OrderService;
            ClientService = _ClientService;
        }
        // GET: Home
        public ActionResult Item()
        {

            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            li.Clear();
            ViewBag.Items = ItemService.GetAll().ToList();
            TempData["Cart"] = li;
            ViewBag.Clients = ClientService.GetAll();
            ViewBag.Total = order.Total;
            return View();
        }
        OrderEditViewModel order =new OrderEditViewModel();
        OrderItemEditViewModel orderItem = new OrderItemEditViewModel();
        List<OrderItemEditViewModel> list = new List<OrderItemEditViewModel>();
        public static List<Cart> cartli = new List<Cart>();

        [HttpPost]
        public ActionResult OrderNow(OrderEditViewModel _order)
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            

            order.ID = 0;
            order.Total =0;
            order.Date = DateTime.Now;
            order.ClientID = _order.ClientID;
            foreach (var i in li)
            {
                orderItem.ID = 0;
                orderItem.OrderID = order.ID;
                orderItem.ItemID = i.ID;
                orderItem.Quantity = i.Quantity;
                order.Total += i.TotalPrice;
                list.Add(orderItem);
            }
            Client client =  ClientService.GetByID(order.ClientID);
            order.ClientName = client.Name; 
            order.OrderItems = list;
            cartli = li;
            TempData["Cartli"] = cartli;
            OrderEditViewModel Order =OrderService.Add(order);
            return View(Order);
        }

        public ActionResult Details(int id)
        {

            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            ItemViewModel Item = ItemService.GetByID(id);
            return View(Item);
        }
        public static List<Cart> li = new List<Cart>();
        [HttpGet]
        public ActionResult Cart(int id)
        {
            ItemViewModel Item = ItemService.GetByID(id);
            order.Total = 0;
            
            var cart = li.FirstOrDefault(i => i.ID == id);
            if (cart ==null)
            {
                Cart c = new Cart();
                c.ID = Item.ID;
                c.ItemName = Item.Name;
                c.Price = Item.Price;
                c.Quantity = 1;
                c.TotalPrice = c.Quantity * c.Price;
                li.Add(c);
            }
               
            else
            {
                cart.ID = Item.ID;
                cart.ItemName = Item.Name;
                cart.Price = Item.Price;
                cart.Quantity = cart.Quantity + 1;
                cart.TotalPrice = cart.Quantity * cart.Price;
                
            }
            foreach (var i in li)
            {
                order.Total += i.TotalPrice;
                
            }
            ViewBag.Total = order.Total;
            TempData["Cart"] = li;
            ViewBag.Clients = ClientService.GetAll();
            ViewBag.Items = ItemService.GetAll().ToList();
            return View("Item");
        }
        
        public ActionResult Add()
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            return View();
        }
        [HttpPost]
        public ActionResult Add(ItemEditViewModel Item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ItemService.Add(Item);
            return RedirectToAction("Item");
        }
       
        [HttpGet]
        public ActionResult Delete(int id)
        {  
            ItemService.Remove(id);
            return RedirectToAction("Item");
        }
        public ActionResult Update(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            var Item = ItemService.GetByID(id);
            return View(Item);
        }
        [HttpPost]
        public ActionResult Update(ItemEditViewModel Item)
        {
            if (!ModelState.IsValid)
                return View();
            ItemService.Update(Item);
            return RedirectToAction("Item");
        }

    }
}