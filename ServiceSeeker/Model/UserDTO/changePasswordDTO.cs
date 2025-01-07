using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.UserDTO
{
    public class changePasswordDTO
    {
        [Required]
        public required string existingPassword { get; set; }
        [Required]
        [MinLength(8)]

        public required string newPassword { get; set; }

    }
}
