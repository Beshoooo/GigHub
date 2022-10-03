using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using GigHub.Dtos;
using Microsoft.AspNet.Identity;


namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Follow(FolloweeDto dto)
        {
            var UserID = User.Identity.GetUserId();

            bool Exist = DB.followers.Any(n => n.FolloweeID == dto.FolloweeId && n.FollowerID == UserID);
            if (Exist)
            {
                return BadRequest("You already Following.");
            }
            else if (UserID == dto.FolloweeId)
            {
                //you can't follow yourself.
                return BadRequest("Bad request.");
            } 
            else
            {
                bool Exist2 = DB.Users.Any(n => n.Id == dto.FolloweeId);
                if (Exist2)
                {
                    var follow = new Followers() { FolloweeID = dto.FolloweeId, FollowerID = UserID };
                    DB.followers.Add(follow);
                    DB.SaveChanges();

                    return Ok();
                }
                else
                {
                    //To sure that the comming id is already userid .
                    return BadRequest("Bad request.");
                }
                
            }


        }

    }
}
