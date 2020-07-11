using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Structure.Services;
using Task.Structure.ViewModels;

namespace Task.Controllers
{
    public class ClientController : Controller    
    {

        private readonly ClientService ClientService; 
        private readonly GroupService GroupService;
        public ClientController (ClientService _ClientService , GroupService _GroupService)
        {
            ClientService = _ClientService;
            GroupService = _GroupService;
        }
        // GET: Home
        public ActionResult Client()
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            var Clients = ClientService.GetAll().ToList();
            return View(Clients);
        }
       
        public ActionResult Details(int id)
        {

            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            ClientViewModel Client = ClientService.GetByID(id).ToViewModel();
            return View(Client);
        }
       
        public ActionResult Add()
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            ViewBag.Groups = GroupService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Add(ClientEditViewModel Client)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = GroupService.GetAll();
                return View();
            }

            ClientService.Add(Client);
            return RedirectToAction("Client");
        }
       
        [HttpGet]
        public ActionResult Delete(int id)
        {  
            ClientService.Remove(id);
            return RedirectToAction("Client");
        }
        public ActionResult Update(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            var Client = ClientService.GetByID(id).ToEditableViewModel();
            ViewBag.Groups = GroupService.GetAll();
            return View(Client);
        }
        [HttpPost]
        public ActionResult Update(ClientEditViewModel Client)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = GroupService.GetAll();
                return View();
            }
                
            ClientService.Update(Client);
            return RedirectToAction("Client");
        }

    }
}