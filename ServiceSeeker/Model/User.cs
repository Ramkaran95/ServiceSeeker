

using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model
{
    public class User
    {
        public required int UserId { get; set; }
        
        public required String UserName { get; set; }
        public required String FirstName { get; set; }
        public required String MiddleName { get; set; }
        public required String LastName { get; set; }
        [Phone]
        public required int PhoneNumber { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        [MaxLength(8)]
        public required int Password { get; set; }
        public String? ProfilePhoto { get; set; } ="Default.jpg";

        public required DateTime CreatAt { get; set; }=DateTime.Now; 

    }
}
