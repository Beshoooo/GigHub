using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using GigHub.Dtos;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Attend(AttendaceDto dto)
        {
            var userID = User.Identity.GetUserId();

            //check gig are in database or not.
            var Gig_check = DB.Gigs.Any(n => n.Id == dto.gigId);

            //check duplicating to prevent it.
            //remove attendace
            var Exists = DB.attendance.Any(n => n.GigId == dto.gigId && n.UserId == userID);
            if (Exists)
            {

                var attend = DB.attendance.Where(n => n.GigId == dto.gigId && n.UserId == userID).FirstOrDefault();
                
                DB.attendance.Remove(attend);
                DB.SaveChanges();
                return Ok();
            }
            
            else if (!Gig_check)
            {
                return BadRequest("The gig not in database.");
            }
            //add attendace
            else
            {
                var attend = new Attendance() { GigId = dto.gigId, UserId = userID };
                DB.attendance.Add(attend);
                DB.SaveChanges();

                return Ok();
            }
            
        }

    }
}
