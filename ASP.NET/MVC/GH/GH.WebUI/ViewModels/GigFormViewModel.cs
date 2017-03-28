using GH.WebUI.Core.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using GH.WebUI.Controllers;
using System.Web.Mvc;

namespace GH.WebUI.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

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

        public string Heading { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update =
                    ((c) => c.Update(this));

                Expression<Func<GigsController, ActionResult>> create =
                    ((c) => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name; 
            }
        }

        public DateTime GetDateTime() => DateTime.Parse($"{Date} {Time}");
    }
}