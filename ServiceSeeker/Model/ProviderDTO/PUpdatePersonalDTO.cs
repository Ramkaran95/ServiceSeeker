using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class PUpdatePersonalDTO
    {

        [Required, MaxLength(100)]

        public required string UserName { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }

        [Required, MaxLength(100)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(255)]
        public string? ProfilePhoto { get; set; } = "defaultProfile.jpg";

        [Required, MinLength(10), MaxLength(15)]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address..")]
        public required string Email { get; set; }
    }
}
