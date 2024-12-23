

using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ServiceSeeker.Model
{
    public class User
    {
        public required int UserId { get; set; }

        public required String UserName { get; set; }
        public required String FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required String LastName { get; set; }
        [Phone]
        [MinLength(10)]
        public required int PhoneNumber { get; set; }

        [EmailAddress]
        
        public required  string Email { get; set; }
        [MaxLength(12)]
        [MinLength(8)]
        public required int Password { get; set; }
        //public String? ProfilePhoto { get; set; } ="Default.jpg";

        public required DateTime CreatAt { get; set; }=DateTime.Now; 

    }
}
