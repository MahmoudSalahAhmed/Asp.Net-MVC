using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Structure.Services;
using Task.Structure.ViewModels;

namespace Task.Controllers
{
    public class LoginController : Controller
    {

        private readonly AdminService AdminService;

        public LoginController(AdminService _AdminService)
        {
            AdminService = _AdminService;
        }
        // GET: Home
        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminEditViewModel admin)
        {
            AdminViewModel user = AdminService.GetAll().
                FirstOrDefault(i => i.UserName == admin.UserName
                && i.Password == admin.Password);
            if (!ModelState.IsValid)
            {
                if(admin.UserName == ""||admin.UserName==null)
                    ViewBag.UserName = "this field is required";

                if (admin.Password == "" || admin.Password == null)
                    ViewBag.Password = "this field is required";
                return View();
            }
                

            if (user == null)
            {
                ViewBag.IsAdmin = "This Account Is Not Correct";
                return View();
            }
            else
            {
                Session["log"] = user;
                return RedirectToAction("Home","Home",null);
            }

            
        }
        public ActionResult LogOut()
        { 
             Session["log"] = null;
             return RedirectToAction("Login", "Login", null);
        }

    }
}