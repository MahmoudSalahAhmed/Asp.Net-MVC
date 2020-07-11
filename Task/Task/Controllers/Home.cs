using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Structure.Services;
using Task.Structure.ViewModels;

namespace Task.Controllers
{
    public class HomeController : Controller    
    {

        private readonly StatisticsService StatisticsService;

        public HomeController (StatisticsService _StatisticsService)
        {
            StatisticsService = _StatisticsService;
        }
        // GET: Home
        public ActionResult Home()
        {
            if(Session["log"] == null)
                return RedirectToAction("Login","Login",null);

            var Statistics = StatisticsService.GetStatistics();
            return View(Statistics);
        }
    }
}