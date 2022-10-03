using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gigs> commingGigs { get; set; }
        public bool ShowActions { get; set; }

    }
}