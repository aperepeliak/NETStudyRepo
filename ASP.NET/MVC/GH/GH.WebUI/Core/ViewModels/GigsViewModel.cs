﻿using GH.WebUI.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace GH.WebUI.Core.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; internal set; }
    }
}