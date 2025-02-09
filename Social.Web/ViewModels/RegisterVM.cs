using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Social.Web.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "ಈಮೇಲ್")]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ಪಾಸ್‌ವರ್ಡ")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "ಇನ್ನೋಮ್ಮೆ ಪಾಸ್‌ವರ್ಡ")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "ಹೆಸರು")]
        [Required]
        public string Name { get; set; }

        [Display(Name= "ಫೋನ್‌ ನಂಬರ್")]
        public string? PhoneNumber { get; set; }

        public string? RedirectUrl { get; set; }
        public string? Role { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? RoleList { get; set; }
    }
}
