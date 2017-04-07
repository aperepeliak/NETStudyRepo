using ST.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ST.WebUI.ViewModels
{
    public class SkillFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }
        public string Action => Id == 0 ? "Create" : "Update";
    }
}