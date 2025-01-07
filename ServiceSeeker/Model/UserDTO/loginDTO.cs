using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.UserDTO
{
    public class loginDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [MinLength(8)]
        public required string Password { get; set; } 


    }
}
