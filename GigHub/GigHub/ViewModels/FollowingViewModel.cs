using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class FollowingViewModel
    {
        public List<string> Followees_list { get; set; }
        public bool Showaction { get; set; }

    }
}