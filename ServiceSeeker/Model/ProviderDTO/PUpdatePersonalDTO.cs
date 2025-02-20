using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class PUpdatePersonalDTO
    {

        [Required, MaxLength(100)]

        public required string UserName { get; set; }

      

        [Required, MaxLength(100)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

       

        [Required, MinLength(10), MaxLength(15)]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address..")]
        public required string Email { get; set; }
        public required string State { get; set; }

        [Required, MaxLength(100)]
        public required string District { get; set; }

        [Required]
        [Range(100000, 999999, ErrorMessage = "Pincode must be a 6-digit number.")]

        public required int PinCode { get; set; }
        public string? Area { get; set; } = null;

        [Required, MaxLength(100)]
        public required string City { get; set; }
        [Required]
        public required string Longitude { get; set; }

        [Required]
        public required string Latitude { get; set; }

    }
}
