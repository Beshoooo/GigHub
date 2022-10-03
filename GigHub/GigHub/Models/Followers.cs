using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Followers
    {
        [Required]
        public int Id { get; set; }
        public string FollowerID { get; set; }
        public string FolloweeID { get; set; }


        public ApplicationUser UserFollower { get; set; }
        public ApplicationUser UserFollowee { get; set; }

    }
}