using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        // GET: Gigs
        public ActionResult Create()
        {
            List<Types> T = DB.type.ToList();
            ViewBag.types = T;
            return View();
        }
    }
}