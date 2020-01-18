using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models.Authentication
{
    public class LoginViewModel : FormViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be between 6 and 30 symbols")]
        [RegularExpression("^((?=.*[A-Z])(?=.*\\d)).+$", ErrorMessage = "Invalid password, please enter at least one upper case letter ands one numeric digit.")]
        public string Password { get; set; }

    }
}
