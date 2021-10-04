using System.ComponentModel.DataAnnotations;

namespace VBooX.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string WebClientUrl { get; set; }
    }
}
