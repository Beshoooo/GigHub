using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigHub.Models;
using GigHub.ViewModels;
using System.Globalization;
using System.Threading;
using Microsoft.AspNet.Identity;


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

            //this obj for control show button in view to prevent any one to use unless register or login users.
            //by checking authuntication
            var ViewModel = new GigsViewModel
            {
                commingGigs = commingGigs,
                ShowActions = User.Identity.IsAuthenticated
            };
            ViewBag.Heading = "Upcomming Gigs";
            

            var UserID = User.Identity.GetUserId();

            #region Get all gigs_ids that i'm attending 
            //Get all gigs_ids that i'm attending and send it to appear in page when start
            var att_list = DB.attendance.Where(n => n.UserId == UserID).ToList();
            List<int> list_Gigs_Id = new List<int>() ;
            foreach (var item in att_list)
            {
                list_Gigs_Id.Add(item.GigId);
            }
            ViewBag.Gigs_Id = list_Gigs_Id;
            #endregion

            #region Get all followee_ids that i'm follow them 
            //Get all followee_ids that i'm follow them  and send it to appear in page when start
            var followees_list = DB.followers.Where(n => n.FollowerID == UserID).Select(n=>n.FolloweeID).ToList();
            List<string> list_Followee_Id = new List<string>();
            foreach (var item in followees_list)
            {
                list_Followee_Id.Add(item);
            }
            ViewBag.Followee_Id = list_Followee_Id;
            #endregion

            return View("Gigs",ViewModel);
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