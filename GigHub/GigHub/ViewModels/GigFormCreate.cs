using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GigHub.Models;

namespace GigHub.ViewModels
{
    // Created to carry data from form to action
    public class GigFormCreate
    {
        [Required]
        public string Location { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }
        

        
    }
}