

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceSeeker.Model
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public required int UserId { get; set; }

        [Required]
        [MaxLength(50)] // Optional: Set a max length for UserName
        public required string UserName { get; set; }

        [Required]
        [MaxLength(50)] // Optional: Set a max length for FirstName
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; } = null;

        public string? LastName { get; set; } = null;

        [Required]
        [Phone]
        public required string PhoneNumber { get; set; } // Changed from `int` to `string` to support phone numbers with leading zeros.

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; } // Changed from `int` to `string` for better password storage.

        [Required]
        public required DateTime CreatAt { get; set; } = DateTime.Now;

        public string? Otp { get; set; } = null;

        public DateTime? OtpExpiry { get; set; } = null;
    }
}