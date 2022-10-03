using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Threading;
using System.Globalization;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        // Create=> To add gigs
        //Autorize=> To prevent any one to open this view except login users.
        [Authorize]
        public ActionResult Create()
        {
            List<Types> T = DB.types.ToList();
            ViewBag.types = T;
            return View();
        }

        //This function to save gig data.
        //HttpPost=> Redirect to this action just if you return from Create action by method (post)
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]//Check CSRF attackers
        public ActionResult Create(GigFormCreate g)
        {
            //(Validation)For check that comming model data is validate (server-side)
            if (!ModelState.IsValid)
            {
                //Send types data for DropDownList ,
                //Because value cannot be null in Parameter name: items in SelectList.
                List<Types> T = DB.types.ToList();
                ViewBag.types = T;

                return View("Create");//Return to the same page 
            }
            Gigs gig = new Gigs();
            
            var artist_id = User.Identity.GetUserId();

            //no longer needed that's to get all artist data
            //single=>To select the only element of an array that satisfies a condition.
            //var artist = DB.Users.Single(n => n.Id == artist_id);

            

            gig.ArtistId = artist_id;
            gig.Location = g.Location;
            gig.Datatime = Convert.ToDateTime(g.Date +" "+ g.Time);
            gig.GenreId = g.Genre;

            DB.Gigs.Add(gig);
            DB.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        [Authorize]
        public ActionResult Attending()
        {
            #region Setting Culture To English To Make Months English.
            //make Culture Set To English
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            #endregion

            string UserId = User.Identity.GetUserId();

            var gigs = DB.attendance
                .Where(n => n.UserId == UserId)
                .Select(n=>n.Gig)
                .Include(n=>n.Artist)
                .Include(n=>n.Genre)
                .ToList();

            var commingGigs = new GigsViewModel
            {
                commingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated
            };
            ViewBag.Heading = "Gigs I'm Attending";
            return View("Gigs",commingGigs);

        }





    }

}