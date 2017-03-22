using System.ComponentModel.DataAnnotations;

namespace GH.WebUI.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
