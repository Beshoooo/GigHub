using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gigs
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Artist { get; set; }

        public DateTime Datatime { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        public Types Genre { get; set; }
    }
}