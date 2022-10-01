using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigHub.Models;


namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();
        public ActionResult Index()
        {
            //using Eager loading include() for loading artist var
            var commingGigs = DB.Gigs.Include(n => n.Artist).Where(n => n.Datatime > DateTime.Now);
            return View(commingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}