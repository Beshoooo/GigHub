using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigHub.Models;
using System.Globalization;
using System.Threading;


namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();
        public ActionResult Index()
        {
        #region Setting Culture To English To Make Months English.
            //make Culture Set To English
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
        #endregion
            //using Eager loading include() for loading artist var and types
            var commingGigs = DB.Gigs.Include(n => n.Artist).Include(n=>n.Genre).Where(n => n.Datatime > DateTime.Now);
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