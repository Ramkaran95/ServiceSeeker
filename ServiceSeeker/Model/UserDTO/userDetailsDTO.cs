using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.UserDTO
{
    public class userDetailsDTO
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; } = null;
        public string? LastName { get; set; } = null;
        [MinLength(10)]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address..")]
        public required string Email { get; set; }

    }
}