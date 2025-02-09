using System.ComponentModel.DataAnnotations;

namespace Social.Web.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "ಈಮೇಲ್")]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ಪಾಸ್‌ವರ್ಡ")]
        public string Password { get; set; }

        [Display(Name = "ನೆನಪಿಡಿ")]
        public bool RememberMe { get; set; }

        public string? RedirectUrl { get; set; }
    }
}
