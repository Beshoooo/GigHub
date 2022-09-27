using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GigHub.ViewModels;

namespace GigHub.Models
{
    public class Gigs
    {
        public int Id { get; set; }

        //Artist =>For relation and will not add in the table also (Genre)
        //because you call id so can call all object ,and it's mean that "ArtistId" is forignkey
        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime Datatime { get; set; }

        [Required]
        [StringLength(255)] //To make nvarchar(255) in our db
        public string Location { get; set; }

        public Types Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}