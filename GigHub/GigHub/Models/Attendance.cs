using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GigHub.Models
{
    public class Attendance
    {
        public Gigs Gig { get; set; }
        public ApplicationUser User_atttendee { get; set; }

        [Key]
        [Column(Order =1)]
        public int GigId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }



    }
}