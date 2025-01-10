using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class PResetPasswordDTO
    {
       
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Otp { get; set; }
        [Required]
        [MinLength(8)]
        public required string NewPassword { get; set; }



    }
}
