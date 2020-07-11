using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Structure.Services;
using Task.Structure.ViewModels;

namespace Task.Controllers
{
    public class GroupController : Controller    
    {

        private readonly GroupService GroupService;

        public GroupController (GroupService _GroupService)
        {
            GroupService = _GroupService;
        }
        // GET: Home
        public ActionResult Group()
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            var Groups = GroupService.GetAll().ToList();
            return View(Groups);
        }
       
        public ActionResult Details(int id)
        {

            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            GroupViewModel Group = GroupService.GetByID(id);
            return View(Group);
        }
       
        public ActionResult Add()
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            return View();
        }
        [HttpPost]
        public ActionResult Add(GroupEditViewModel Group)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            GroupService.Add(Group);
            return RedirectToAction("Group");
        }
       
        [HttpGet]
        public ActionResult Delete(int id)
        {  
            GroupService.Remove(id);
            return RedirectToAction("Group");
        }
        public ActionResult Update(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Login", "Login", null);
            var Group = GroupService.GetByID(id);
            return View(Group);
        }
        [HttpPost]
        public ActionResult Update(GroupEditViewModel Group)
        {
            if (!ModelState.IsValid)
                return View();
            GroupService.Update(Group);
            return RedirectToAction("Group");
        }

    }
}