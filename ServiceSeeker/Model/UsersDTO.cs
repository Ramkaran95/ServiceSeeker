



namespace ServiceSeeker.Model
{
    public class UsersDTO
    {
       
        public required String UserName { get; set; }
        public required String FirstName { get; set; }
        public required String MiddleName { get; set; }
        public required String LastName { get; set; }
        public required int PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required int ID { get; set; }

        public required int Password { get; set; }
        public String? ProfilePhoto { get; set; } = "Default.jpg";

        public required DateTime CreatAt { get; set; } = DateTime.Now;

    }
}
