﻿using GH.WebUI.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace GH.WebUI.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() => DateTime.Parse($"{Date} {Time}");
    }
}