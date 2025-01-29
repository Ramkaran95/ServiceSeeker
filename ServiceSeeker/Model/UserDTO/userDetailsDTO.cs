using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.UserDTO
{
    public class userDetailsDTO
    {
        public required int  UserId { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; } = null;
        public string? LastName { get; set; } = null;
        [MinLength(10)]
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


    }
}