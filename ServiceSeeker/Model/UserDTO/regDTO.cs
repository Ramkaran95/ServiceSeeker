



using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.UserDTO
{
    public class regDTO
    {
        public required int UserId { get; set; }

        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }=null;
        public string? LastName { get; set; } = null;
        [MinLength(10)]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Invalid email address..")]
        public required string Email { get; set; }
        [MinLength(8)]
        public required string Password { get; set; }
        // public String? ProfilePhoto { get; set; } = "Default.jpg";
        [Required]
        public required DateTime CreatAt { get; set; } = DateTime.Now;



    }
}
