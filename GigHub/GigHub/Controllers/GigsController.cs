using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using Microsoft.AspNet.Identity;



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
            List<Types> T = DB.type.ToList();
            ViewBag.types = T;
            return View();
        }

        //This function to save gig data.
        //HttpPost=> Redirect to this action just if you return from Create action by method (post)
        [HttpPost]
        public ActionResult Create(GigFormCreate g)
        {
            Gigs gig = new Gigs();
            
            var artist_id = User.Identity.GetUserId();

            //no longer needed that's to get all artist data
            //single=>To select the only element of an array that satisfies a condition.
            //var artist = DB.Users.Single(n => n.Id == artist_id);

            

            gig.ArtistId = artist_id;
            gig.Location = g.Location;
            gig.Datatime = Convert.ToDateTime(g.Date +" "+ g.Time);
            gig.GenreId = g.Genre;

            DB.Gig.Add(gig);
            DB.SaveChanges();

            return RedirectToAction("Index","Home");
        }

    }

}