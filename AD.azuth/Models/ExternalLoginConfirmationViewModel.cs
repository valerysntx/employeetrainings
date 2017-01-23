using System.ComponentModel.DataAnnotations;

namespace AD.azuth.Models
{
    public partial class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hometown")]
        public string Hometown { get; set; }
    }
}