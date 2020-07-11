using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Structure.Services;
using Task.Structure.ViewModels;

namespace Task.Controllers
{
    public class OrderController : Controller    
    {

        private readonly OrderService OrderService;

        public OrderController (OrderService _OrderService)
        {
            OrderService = _OrderService;
        }
        // GET: Home
        public ActionResult Order()
        {
            if(Session["log"] == null)
                return RedirectToAction("Login");
            var Orders = OrderService.GetAll().ToList();
            return View(Orders);
        }
       
        public ActionResult Details(int id)
        {
           
            if (Session["log"] == null)
                return RedirectToAction("Login");
            OrderViewModel Order = OrderService.GetByID(id);
            return View(Order);
        }
       
        public ActionResult Add()
        {
            if (Session["log"] == null)
                return RedirectToAction("Login"); 
            return View();
        }
        [HttpPost]
        public ActionResult Add(OrderEditViewModel Order)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            OrderService.Add(Order);
            return RedirectToAction("Order");
        }
       
        [HttpGet]
        public ActionResult Delete(int id)
        {  
            OrderService.Remove(id);
            return RedirectToAction("Order");
        }
        public ActionResult Update(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Login");
            var Order = OrderService.GetByID(id);
            return View(Order);
        }
        [HttpPost]
        public ActionResult Update(OrderEditViewModel Order)
        {
            if (!ModelState.IsValid)
                return View();
            OrderService.Update(Order);
            return RedirectToAction("Order");
        }

    }
}