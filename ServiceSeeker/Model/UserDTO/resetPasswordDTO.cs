using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.UserDTO
{
    public class resetPasswordDTO
    {
       
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Otp { get; set; }
        [Required]
        public required string NewPassword { get; set; }



    }
}
