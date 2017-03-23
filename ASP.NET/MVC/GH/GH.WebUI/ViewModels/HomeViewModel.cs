using GH.WebUI.Models;
using System.Collections.Generic;

namespace GH.WebUI.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}