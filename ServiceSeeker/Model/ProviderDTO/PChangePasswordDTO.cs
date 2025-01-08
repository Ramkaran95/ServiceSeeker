using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class PChangePasswordDTO
    {
        [Required]
        public required string ExistingPassword { get; set; }
        [Required]
        [MinLength(8)]

        public required string NewPassword { get; set; }

    }
}
