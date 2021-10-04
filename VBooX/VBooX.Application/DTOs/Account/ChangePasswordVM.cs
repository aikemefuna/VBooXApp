using System.ComponentModel.DataAnnotations;

namespace VBooX.Application.DTOs.Account
{
    public class ChangePasswordVM
    {
        public string Email { get; set; }

        public string CurrentPassword { get; set; }

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
