﻿using System.ComponentModel.DataAnnotations;

namespace GH.WebUI.Core.ViewModels
{

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
