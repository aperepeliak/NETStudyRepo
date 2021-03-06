﻿using ST.Core.Models;
using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class SkillsViewModel
    {
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string SelectedCategoryName { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}